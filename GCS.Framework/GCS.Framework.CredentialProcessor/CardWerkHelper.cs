using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCardAPI.CardModule.HID.ICLASS;
using Subsembly.SmartCard;

namespace GCS.Framework.CredentialProcessor
{
    //public class CardWerkHelper
    //{
    //    CardHandle m_aCard   = null;
    //    bool m_isContactless = false;
    //    bool m_isSeos = false;
    //    bool m_isProxViaATR  = false; // HID PROX via OMNIKEY 5x25
    //    string m_cardInfo = "card info:\n";
    //    private string m_uid = string.Empty;
    //    private string m_csn = string.Empty;
    //    private string m_csnHex = string.Empty;
    //    public CardWerkHelper(CardHandle aCard)
    //    {
    //        if (aCard == null)
    //        {
    //            throw new ArgumentNullException("invalid card handle");
    //        }
    //        m_aCard = aCard;
    //        CardPcscPart3 pcscPart3Info = new CardPcscPart3(aCard.GetATR());
    //        if (pcscPart3Info.isValid)
    //        {
    //            m_isContactless = pcscPart3Info.isContactless;
    //            m_cardInfo += "PC/SC 2.01 compliant ATR detected\n";
    //            m_cardInfo += "interface:  ";
    //            if (m_isContactless == true)
    //            {
    //                m_cardInfo += "contactless\n";
    //            }
    //            else
    //            {
    //                m_cardInfo += "contact\n";
    //            }
    //            m_cardInfo += "protocol:  " + pcscPart3Info.CardProtocol + "\n";
    //            m_cardInfo += "card type: " + pcscPart3Info.CardName + "\n";
    //        }
    //        else
    //        {
    //            //m_cardInfo += "ATR is not PC/SC 2.01 part 3 compliant\n";
    //            //m_cardInfo += "processor card or proprietary storage card\n";
    //        }
           

            
    //        // at this time we know: it is NOT a contactless or contact storage card as defined in PC/SC part 3
    //        // Let's try to find out more by analyzing the reader name. We may get lucky. Note though, that there is 
    //        // no clean, standards-based way to determine the card interface this way.

    //        if (m_isContactless == false)
    //        {
    //            if (aCard.Slot.CardTerminalName.Contains("OMNIKEY") &&
    //               aCard.Slot.CardTerminalName.Contains("CL") )
    //            {
    //                if (aCard.Slot.CardTerminalName.Contains("5x25"))
    //                {
    //                    m_isProxViaATR = true;
    //                    m_cardInfo += "125 KHz PROX via ATR historical bytes\n";
    //                }
    //                else
    //                {
    //                    m_isContactless = true;
    //                    m_cardInfo += "contactless based on reader name\n";
    //                }
    //            }
    //        }
            
    //        if(m_isContactless==false)
    //        {

    //            if(aCard.Slot.CardTerminalName.ToUpper().Contains("CONTACTLESS") == true) // SCM readers contain this string
    //            {
    //                m_isContactless = true;
    //                m_cardInfo += "contactless based on reader name\n";
    //            }
    //        }

    //        if(m_isContactless==false && m_isProxViaATR==false)
    //        {

    //           // we could start an analysis based onm an ATR mask here
    //            m_cardInfo += "unknown card interface (fall back)\n";
    //        }

    //        if (m_isContactless == true)
    //        {
    //            // =========================== APDU EXCHANGE ==================================
    //            // Now we can try to get a unique identifier (UID). Any contactless card with a 
    //            // PC/C 2.01 compliant card reader should be able to generate a UID. But never mind, 
    //            // even if this fails it still shows how to create a command APDU with our SmartCardAPI 
    //            // frameqwork and get a response APDU back from a card.
    //            //
    //            // Known issues:
    //            // SendCommand with CLA=0xFF can cause an exception with some smart card systems,  
    //            // triggered by an "Unknown Error" (-2146435025) on PC/SC level. 
    //            // Therefore this code should only be run if we are accessing a contactless reader
    //            // interface that is PC/SC 2.01 compliant
    //            // ============================================================================
    //            byte CL_CLA = 0xFF;
    //            byte CL_INS_GET_UID = 0xCA;
    //            byte P1 = 0;
    //            byte P2 = 0;
    //            CardCommandAPDU aCmdAPDU = new CardCommandAPDU(CL_CLA, CL_INS_GET_UID, P1, P2, 256);
    //            CardResponseAPDU aRespAPDU;
    //            aRespAPDU = aCard.SendCommand(aCmdAPDU);
    //            if (!aRespAPDU.IsSuccessful)
    //            {

    //            }
    //            else
    //            {
    //                byte[] uidWithSw12 = aRespAPDU.GenerateBytes();
    //                if (uidWithSw12.Length >= 2)
    //                {
    //                    m_uid = CardHex.FromByteArray(uidWithSw12, 0, uidWithSw12.Length - 2);
    //                    m_csnHex = m_uid.Substring(0, 8);
    //                    BitConverter.ToInt32(uidWithSw12, 0);
    //                    m_csn = BitConverter.ToUInt32(uidWithSw12, 0).ToString();
    //                }
    //            }
    //        }
    //        // let us know if you are using a reader that could be handled here
    //        // support@smartcard-api.com
    //        m_cardInfo += "end of card info ";
    //    }

    //    /// </summary>
    //    /// <param name="aCard"></param>
    //    /// <returns></returns>
    //    public bool IsContactless
    //    {
    //        get
    //        {
    //            return m_isContactless;
    //        }
    //    }

    //    /// </summary>
    //    /// <param name="aCard"></param>
    //    /// <returns></returns>
    //    public bool IsProprietaryProx
    //    {
    //        get
    //        {
    //            return m_isProxViaATR;
    //        }
    //    }

    //    public string CardInfo
    //    {
    //        get
    //        {
    //            return m_cardInfo;
    //        }
    //    }

    //    public string Uid
    //    { get { return m_uid; } }

    //    public string CsnHex
    //    { get { return m_csnHex; } }
    //    public string Csn
    //    { get { return m_csn; } }
    //} // class
    public class CardWerkHelper
    {
        CardHandle m_aCard = null;
        bool m_isContactless = false;
        bool m_isSeos = false;
        bool m_isProxViaATR = false; // HID PROX via OMNIKEY 5x25
        string m_cardInfo = "card info:\n";
        private string m_uid = string.Empty;
        private string m_csn = string.Empty;
        private string m_csnHex = string.Empty;
        public CardWerkHelper(CardHandle aCard)
        {
            if (aCard == null)
            {
                throw new ArgumentNullException("invalid card handle");
            }
            m_aCard = aCard;

            byte[] atr = aCard.GetATR();
            byte[] seosATR = CardHex.ToByteArray("3B80800101");
            if (CardHex.IsEqual(atr, seosATR))
            {
                SeosCard seos = new SeosCard(aCard);
                if (seos.IsReady)
                {
                    m_isContactless = true;
                    m_isSeos = true;
                    m_cardInfo += "SEOS ATR detected\n";
                    byte[] randomUID = seos.GetCardSerialNumber();
                    if (randomUID == null)
                    {
                        m_cardInfo += "ERROR: no UID\n";
                    }
                    else
                    {
                        m_csn = CardHex.FromByteArray(randomUID);
                        m_uid = m_csn;
                        m_csnHex = m_uid.Substring(0, 8);
                        m_cardInfo += "SEOS random UID: " + m_csn + "\n";
                    }
                }
            }
            else
            {
                CardPcscPart3 pcscPart3Info = new CardPcscPart3(atr);
                if (pcscPart3Info.isValid)
                {
                    m_isContactless = pcscPart3Info.isContactless;
                    m_cardInfo += "PC/SC 2.01 compliant ATR detected\n";
                    m_cardInfo += "interface:  ";
                    if (m_isContactless == true)
                    {
                        m_cardInfo += "contactless\n";
                    }
                    else
                    {
                        m_cardInfo += "contact\n";
                    }
                    m_cardInfo += "protocol:  " + pcscPart3Info.CardProtocol + "\n";
                    m_cardInfo += "card type: " + pcscPart3Info.CardName + "\n";
                }
                else
                {
                    //m_cardInfo += "ATR is not PC/SC 2.01 part 3 compliant\n";
                    //m_cardInfo += "processor card or proprietary storage card\n";
                }
            }


            // at this time we know: it is NOT a contactless or contact storage card as defined in PC/SC part 3
            // Let's try to find out more by analyzing the reader name. We may get lucky. Note though, that there is 
            // no clean, standards-based way to determine the card interface this way.

            if (m_isContactless == false)
            {
                if (aCard.Slot.CardTerminalName.Contains("OMNIKEY") &&
                   aCard.Slot.CardTerminalName.Contains("CL"))
                {
                    if (aCard.Slot.CardTerminalName.Contains("5x25"))
                    {
                        m_isProxViaATR = true;
                        m_cardInfo += "125 KHz PROX via ATR historical bytes\n";
                    }
                    else
                    {
                        m_isContactless = true;
                        m_cardInfo += "contactless based on reader name\n";
                    }
                }
            }

            if (m_isContactless == false)
            {

                if (aCard.Slot.CardTerminalName.ToUpper().Contains("CONTACTLESS") == true) // SCM readers contain this string
                {
                    m_isContactless = true;
                    m_cardInfo += "contactless based on reader name\n";
                }
            }

            if (m_isContactless == false && m_isProxViaATR == false)
            {

                // we could start an analysis based onm an ATR mask here
                m_cardInfo += "unknown card interface (fall back)\n";
            }

            if (m_isContactless == true && m_isSeos == false)
            {
                // =========================== APDU EXCHANGE ==================================
                // Now we can try to get a unique identifier (UID). Any contactless card with a 
                // PC/C 2.01 compliant card reader should be able to generate a UID. But never mind, 
                // even if this fails it still shows how to create a command APDU with our SmartCardAPI 
                // frameqwork and get a response APDU back from a card.
                //
                // Known issues:
                // SendCommand with CLA=0xFF can cause an exception with some smart card systems,  
                // triggered by an "Unknown Error" (-2146435025) on PC/SC level. 
                // Therefore this code should only be run if we are accessing a contactless reader
                // interface that is PC/SC 2.01 compliant
                // ============================================================================
                byte CL_CLA = 0xFF;
                byte CL_INS_GET_UID = 0xCA;
                byte P1 = 0;
                byte P2 = 0;
                CardCommandAPDU aCmdAPDU = new CardCommandAPDU(CL_CLA, CL_INS_GET_UID, P1, P2, 256);
                CardResponseAPDU aRespAPDU;
                aRespAPDU = aCard.SendCommand(aCmdAPDU);
                if (!aRespAPDU.IsSuccessful)
                {

                }
                else
                {
                    byte[] uidWithSw12 = aRespAPDU.GenerateBytes();
                    if (uidWithSw12.Length >= 2)
                    {
                        m_uid = CardHex.FromByteArray(uidWithSw12, 0, uidWithSw12.Length - 2);
                        m_csnHex = m_uid.Substring(0, 8);
                        BitConverter.ToInt32(uidWithSw12, 0);
                        m_csn = BitConverter.ToUInt32(uidWithSw12, 0).ToString();
                    }
                }
            }
            // let us know if you are using a reader that could be handled here
            // support@smartcard-api.com
            m_cardInfo += "end of card info ";
        }

        /// </summary>
        /// <param name="aCard"></param>
        /// <returns></returns>
        public bool IsContactless
        {
            get
            {
                return m_isContactless;
            }
        }

        /// </summary>
        /// <param name="aCard"></param>
        /// <returns></returns>
        public bool IsProprietaryProx
        {
            get
            {
                return m_isProxViaATR;
            }
        }

        public bool IsSeos
        {
            get { return m_isSeos; }
        }

        public string CardInfo
        {
            get
            {
                return m_cardInfo;
            }
        }

        public string Uid
        { get { return m_uid; } }

        public string CsnHex
        { get { return m_csnHex; } }
        public string Csn
        { get { return m_csn; } }
    } // class


}
