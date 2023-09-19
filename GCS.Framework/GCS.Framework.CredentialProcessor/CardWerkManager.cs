using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Utils;
using SmartCardAPI.CardModule.HID.ICLASS;
using SmartCardAPI.CardModule.PACS;
using SmartCardAPI.DataModule.Wiegand;
using Subsembly.SmartCard;

namespace GCS.Framework.CredentialProcessor
{
    public class CardWerkManager
    {
        private SynchronizationContext _synchronizationContext;
        private bool _smartCardManagerStarted;
        private ObservableCollection<string> _terminalNames = new ObservableCollection<string>();

        public event EventHandler<CredentialDataEventArgs> CredentialDataReceived;
        public CredentialFormatCodes ExpectedDataFormat { get; set; }
        public CredentialFormatCodes ExpectedICLASSDataFormat { get; set; }
        public CardWerkManager()
        {

            ExpectedDataFormat = CredentialFormatCodes.None;
            ExpectedICLASSDataFormat = CredentialFormatCodes.Standard26Bit;
            _synchronizationContext = SynchronizationContext.Current;
            try
            {
                _synchronizationContext.Send(new SendOrPostCallback(
                    delegate (object state)
                    {
                        _smartCardManagerStarted = StartupCardTerminalManager();
                    }
                ), null);
            }
            catch (Exception e)
            {
                _smartCardManagerStarted = false;
                Trace.WriteLine(e);
            }
        }

        ~CardWerkManager()
        {
            ShutdownCardTerminalManager();

        }

        private void ShutdownCardTerminalManager()
        {
            if (CardTerminalManager.Singleton.StartedUp)
            {
                CardTerminalManager.Singleton.Shutdown();
                _smartCardManagerStarted = false;
            }
        }

        bool StartupCardTerminalManager()
        {
            bool fStartedUp = false;

            try
            {
                CardTerminalManager.Singleton.CardInsertedEvent += new CardTerminalEventHandler(InsertedEvent);
                CardTerminalManager.Singleton.CardRemovedEvent += new CardTerminalEventHandler(RemovedEvent);
                CardTerminalManager.Singleton.CardTerminalFoundEvent += new CardTerminalEventHandler(TerminalFoundEvent);
                CardTerminalManager.Singleton.CardTerminalLostEvent += new CardTerminalEventHandler(TerminalLostEvent);

                // Startup the SmartCard API. The parameter "true" means that any
                // PC/SC smart card reader will automatically be added to the smart card
                // configuration registry. If startup fails, then this will throw an
                // exception.

                int nCountReaders = CardTerminalManager.Singleton.Startup(true);
                fStartedUp = CardTerminalManager.Singleton.StartedUp;
                if (CardTerminalManager.Singleton.StartedUp)
                    BuildCardTerminalList();
            }
            catch (Exception x)
            {
                // TODO: Better diagnstic and error handling would be appropriate here.

                Trace.WriteLine(x.ToString());

                //MessageBox.Show(
                //    "Unable to run CardTerminalManager. Will " +
                //    "exit this application.",
                //    "HelloProx",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Stop,
                //    MessageBoxDefaultButton.Button1);

                fStartedUp = false;
            }
            return fStartedUp;
        }

        private void BuildCardTerminalList()
        {
            Trace.WriteLine(string.Format("ThreadID:{0} BuildCardTerminalList", Thread.CurrentThread.ManagedThreadId));
            _terminalNames.Clear();
            if (CardTerminalManager.Singleton.SlotCount == 0)
            {
            }
            else
            {
                foreach (CardTerminalConfig device in CardTerminalManager.Singleton.Registry)
                {
                    _terminalNames.Add(device.AssignedName);
                }
            }
        }

        public ObservableCollection<string> TerminalNames
        {
            get { return _terminalNames; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aSender"></param>
        /// <param name="aEventArgs"></param>	
        public void InsertedEvent(object aSender, CardTerminalEventArgs aEventArgs)
        {
            //if (base.InvokeRequired)
            //{
            //    object[] vParms = new object[2];
            //    vParms[0] = aSender;
            //    vParms[1] = aEventArgs;
            //    base.BeginInvoke(new CardTerminalEventHandler(InsertedEvent),
            //        vParms);
            //}
            //else
            //{
            // 01APR2011
            // We catch any exceptions during card I/O. This is particularly important
            // for fuzzy communication conditions. Example: an contactless card that 
            // is not in the field throuout the whole I/O might cause an error on the 
            // within the unmanaged Windows code. SmartCardAPI catches this in a general 
            // exception
            try
            {
                //_synchronizationContext.Send(AnalyzeCard, aEventArgs.Slot);
                this.AnalyzeCard(aEventArgs.Slot);
            }
            catch
            {
                //Trace.WriteLine("last read failed");
            }
            //}
        }

        private void AnalyzeCard(object slot)
        {
            var s = slot as CardTerminalSlot;
            if (s != null)
                AnalyzeCard(s);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aCardSlot"></param>

        private void AnalyzeCard(CardTerminalSlot aCardSlot)
        {
            CardActivationResult nActivationResult;
            Trace.WriteLine("Reader Name: " + aCardSlot.CardTerminalName);
            CardHandle aCard = aCardSlot.AcquireCard((CardTypes.T0 | CardTypes.T1), out nActivationResult);
            if (nActivationResult != CardActivationResult.Success)
            {
                Debug.Assert(aCard == null);

                switch (nActivationResult)
                {
                    case CardActivationResult.NoCard:
                        Trace.WriteLine("Please insert card ...");
                        break;
                    case CardActivationResult.UnresponsiveCard:
                        Trace.WriteLine("Defective card or card inserted incorrectly.");
                        break;
                    case CardActivationResult.InUse:
                        Trace.WriteLine("Card reader blocked by other application.");
                        break;
                    default:
                        Trace.WriteLine("Can't power up card!");
                        break;
                }
                return;
            }

            // we now have a card in the reader that is powered up
            Trace.WriteLine("Found card");
            try
            {
                aCardSlot.BeginTransaction();
                // ======== Use card helper for basic card info =============
                var cardHelper = new CardWerkHelper(aCard);

                if (cardHelper.IsProprietaryProx)
                {
                    AnalyzeProxCard(aCardSlot, aCard, cardHelper);
                }
                else if (cardHelper.IsContactless)
                {
                    AnalyzeSmartCard(aCardSlot, aCard, cardHelper);
                }
            } //try
            catch (Exception x)
            {
                Trace.WriteLine(x.GetType().ToString());
                Trace.WriteLine(x.Message);
                if (x.InnerException != null)
                    Trace.WriteLine(x.InnerException.Message);
                Trace.WriteLine("Card access error");
            }
            finally
            {
                aCardSlot.EndTransaction();
                aCard.Dispose(); // release card handle
            }
        }

        private void AnalyzeProxCard(CardTerminalSlot aCardSlot, CardHandle aCard, CardWerkHelper cardHelper)
        {
            WiegandCard pacsCard = new WiegandCard(aCard);
            Trace.WriteLine(pacsCard.info);

            if (pacsCard.readerProtocol == (int)PacsReaderProtocol.HID_PROX_2005 ||
                pacsCard.readerProtocol == (int)PacsReaderProtocol.HID_PROX_2012)
            {
                byte[] rawData = pacsCard.RawWiegandData;
                if (rawData != null)
                {
                    //byte[] originalRawData = rawData;
                    //rawData = GCS.Utilities.ByteFlipper.ReverseBytes(rawData);
                    int rawDataLength = rawData.Length;
                    rawData = HexEncoding.PadByteArray(rawData, 32, false);
                    Trace.WriteLine("HID Prox card returned Wiegand data: " +
                                    CardHex.FromByteArray(rawData, 0, rawData.Length));

                    var rawCredentialData = new RawCredentialData();
                    rawCredentialData.RawBitLengthHint.MinBitLength = (rawDataLength - 1) * 8;
                    rawCredentialData.RawBitLengthHint.MaxBitLength = rawDataLength * 8;

                    rawCredentialData.ReaderDataFormat = CredentialReaderDataFormat.WiegandFormat;
                    rawCredentialData.ExpectedDataFormat = ExpectedDataFormat;
                    rawCredentialData.DataBytes = rawData;
                    rawCredentialData.EnrollmentDeviceDescription = aCardSlot.CardTerminalName;
                    rawCredentialData.CardSerialNumber = cardHelper.Csn;
                    rawCredentialData.UseDataType = RawCredentialData.DataType.Bytes;
                    var format = CredentialAnalyzer.AnalyzeRawData(rawCredentialData);

                    var handler = CredentialDataReceived;
                    if (handler != null)
                        handler(this, new CredentialDataEventArgs(rawCredentialData));
                }
                else
                {
                    Trace.WriteLine("Can't read raw data from this card.");
                }
            }
            else
            {

            }

        }

        private void AnalyzeSmartCard(CardTerminalSlot aCardSlot, CardHandle aCard, CardWerkHelper cardHelper)
        {
            byte[] rawData = null;
            PicoPassCard picoPass = new PicoPassCard(aCard);
            if (cardHelper.IsSeos)
            {
                var seos = new SeosCard(aCard);
                rawData = seos.GetRawWiegandData();
            }
            else if (picoPass.IsICLASS)
            {
                rawData = picoPass.GetRawWiegandData();
            }

            if (rawData != null)
            {
                var wiegandData = new WiegandData(rawData);
                Trace.WriteLine((wiegandData.RawWiegandData.ToString()));
                int rawDataLength = rawData.Length;

                rawData = HexEncoding.PadByteArray(rawData, 32, false);
                Trace.WriteLine("Card returned Wiegand data: " +
                                CardHex.FromByteArray(rawData, 0, rawData.Length));

                var rawCredentialData = new RawCredentialData();
                rawCredentialData.SmartCardType = SmartCardType.iClass;
                rawCredentialData.RawBitLengthHint.MinBitLength = (rawDataLength - 1) * 8;
                rawCredentialData.RawBitLengthHint.MaxBitLength = rawDataLength * 8;

                rawCredentialData.ReaderDataFormat = CredentialReaderDataFormat.WiegandFormat;

                rawCredentialData.ExpectedDataFormat = ExpectedICLASSDataFormat;
                switch (ExpectedICLASSDataFormat)
                {
                    case CredentialFormatCodes.Corporate1K35Bit:
                        rawCredentialData.DataBytes = HexEncoding.ApplyMask(rawData,
                            new byte[] { 0x7, 0xff, 0xff, 0xff, 0xff }, true);
                        //new byte[] { 0x3, 0xff, 0xff, 0xff, 0xff }, true);
                        rawCredentialData.BitCount = 35;
                        break;

                    case CredentialFormatCodes.Corporate1K48Bit:
                        rawCredentialData.DataBytes = HexEncoding.ApplyMask(rawData,
                            new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }, true);
                        rawCredentialData.BitCount = 48;
                        break;

                    case CredentialFormatCodes.Standard26Bit:
                        rawCredentialData.DataBytes = HexEncoding.ApplyMask(rawData,
                            new byte[] { 0x3, 0xff, 0xff, 0xff }, true);
                        rawCredentialData.BitCount = 26;

                        break;
                }

                rawCredentialData.DataBytes = rawData;
                rawCredentialData.EnrollmentDeviceDescription = aCardSlot.CardTerminalName;
                rawCredentialData.UseDataType = RawCredentialData.DataType.Bytes;
                rawCredentialData.CardSerialNumber = cardHelper.Csn;
                var format = CredentialAnalyzer.AnalyzeRawData(rawCredentialData);

                var handler = CredentialDataReceived;
                if (handler != null)
                    handler(this, new CredentialDataEventArgs(rawCredentialData));
            }
            else
            {
                var rawCredentialData = new RawCredentialData();
                rawCredentialData.SmartCardType = SmartCardType.MiFare;
                rawCredentialData.ReaderDataFormat = CredentialReaderDataFormat.ClockDataStandard;
                rawCredentialData.EnrollmentDeviceDescription = aCardSlot.CardTerminalName;
                rawCredentialData.ExpectedDataFormat = CredentialFormatCodes.NumericCardCode;
                rawCredentialData.UseDataType = RawCredentialData.DataType.DecimalString;
                rawCredentialData.DataString = cardHelper.Csn;
                rawCredentialData.CardSerialNumber = cardHelper.Csn;

                var format = CredentialAnalyzer.AnalyzeRawData(rawCredentialData);

                var handler = CredentialDataReceived;
                if (handler != null)
                    handler(this, new CredentialDataEventArgs(rawCredentialData));
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aSender"></param>
        /// <param name="aEventArgs"></param>

        public void RemovedEvent(object aSender, CardTerminalEventArgs aEventArgs)
        {
            Trace.WriteLine(aSender); //29MAR2011
            //if (base.InvokeRequired)
            //{
            //    object[] vParms = new object[2];
            //    vParms[0] = aSender;
            //    vParms[1] = aEventArgs;
            //    base.BeginInvoke(new CardTerminalEventHandler(RemovedEvent),
            //        vParms);
            //}
            //else
            //{
            //this.PromptAnyCard();
            //}
        }

        /// <summary>
        /// We add the reader to be monitored.
        /// </summary>
        /// <param name="aSender"></param>
        /// <param name="aEventArgs"></param>

        public void TerminalFoundEvent(object aSender, CardTerminalEventArgs aEventArgs)
        {
            var args = new MyCardTerminalEventArgs(aSender, aEventArgs);
            _synchronizationContext.Send(HandleTerminalFoundEvent, args);

            //if (CardTerminalManager.Singleton.StartedUp)
            //{
            //    BuildCardTerminalList();
            //    Trace.WriteLine(string.Format("ThreadID:{0} Found reader: {1}", Thread.CurrentThread.ManagedThreadId, aEventArgs.Slot.CardTerminalName));
            //}
        }


        private void HandleTerminalFoundEvent(object EventArgs)
        {
            var args = EventArgs as MyCardTerminalEventArgs;
            if (args != null && CardTerminalManager.Singleton.StartedUp)
            {
                _terminalNames.Add(args.EventArgs.Slot.CardTerminalName);
                //BuildCardTerminalList();
                Trace.WriteLine(string.Format("ThreadID:{0} Found reader: {1}", Thread.CurrentThread.ManagedThreadId, args.EventArgs.Slot.CardTerminalName));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aSender"></param>
        /// <param name="aEventArgs"></param>

        public void TerminalLostEvent(object aSender, CardTerminalEventArgs aEventArgs)
        {

            //try
            //{
            //    if (CardTerminalManager.Singleton.StartedUp)
            //    {
            //        //BuildCardTerminalList();
            //        _terminalNames.Remove(aEventArgs.Slot.CardTerminalName);

            //        Trace.WriteLine(string.Format("ThreadID:{0} Lost reader: {1}", Thread.CurrentThread.ManagedThreadId, aEventArgs.Slot.CardTerminalName));
            //        CardTerminalManager.Singleton.DelistCardTerminal(aEventArgs.Slot.CardTerminal); // remove from monitored list of readers
            //    }
            //}
            //catch (Exception e)
            //{
            //    Trace.WriteLine(e);
            //}



        }

        private void HandleTerminalLostEvent(object EventArgs)
        {
            var args = EventArgs as MyCardTerminalEventArgs;
            if (args != null && CardTerminalManager.Singleton.StartedUp)
            {
                CardTerminalManager.Singleton.DelistCardTerminal(args.EventArgs.Slot.CardTerminal); // remove from monitored list of readers
                BuildCardTerminalList();
                Trace.WriteLine(string.Format("ThreadID:{0} Lost reader: {1}", Thread.CurrentThread.ManagedThreadId, args.EventArgs.Slot.CardTerminalName));
            }
        }
    }
}
