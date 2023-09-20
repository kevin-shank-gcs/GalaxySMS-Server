////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\FromPanel\PanelActivityLogMessageCredential.cs
//
// summary:	Implements the panel activity log message credential class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A panel credential activity log message. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class PanelCredentialActivityLogMessage : PanelActivityLogMessage
    {
        /// <summary>   The credential in bytes. </summary>
        private byte[] _credentialBytes;
        /// <summary>   The credential number. </summary>
        private string _credentialNumber;
        /// <summary>   The pin. </summary>
        private uint _pin;
        /// <summary>   Number of bits. </summary>
        private uint _bitCount;
        /// <summary>   The alarm panel zone. </summary>
        private uint _alarmPanelZone;
        /// <summary>   Size of the credential. </summary>
        private const Int32 CredentialSize = 32;
        /// <summary>   The person UID. </summary>
        private Guid _PersonUid;
        /// <summary>   The credential UID. </summary>
        private Guid _CredentialUid;
        /// <summary>   Information describing the person. </summary>
        private string _PersonDescription;
        /// <summary>   Information describing the credential. </summary>
        private string _CredentialDescription;
        /// <summary>   True to trace. </summary>
        private bool _Trace;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PanelCredentialActivityLogMessage()
            : base()
        {
            CredentialBytes = new Byte[CredentialSize];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="l">    The PanelActivityLogMessage to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PanelCredentialActivityLogMessage(PanelActivityLogMessage l)
            : base(l)
        {
            CredentialBytes = new Byte[CredentialSize];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="c">    The PanelCredentialActivityLogMessage to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PanelCredentialActivityLogMessage(PanelCredentialActivityLogMessage c)
            : base(c)
        {
            CredentialBytes = new Byte[c.CredentialBytes.Length];
            Array.Copy(c.CredentialBytes, CredentialBytes, c.CredentialBytes.Length);
            Pin = c.Pin;
            BitCount = c.BitCount;
            AlarmPanelZone = c.AlarmPanelZone;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential bytes. </summary>
        ///
        /// <value> The credential bytes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Byte[] CredentialBytes
        {
            get { return _credentialBytes; }
            set
            {
                if (_credentialBytes != value)
                {
                    _credentialBytes = value;
                    OnPropertyChanged(() => CredentialBytes);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential number. </summary>
        ///
        /// <value> The credential number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string CredentialNumber
        {
            get { return _credentialNumber; }
            set
            {
                if (_credentialNumber != value)
                {
                    _credentialNumber = value;
                    OnPropertyChanged(() => CredentialNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the pin. </summary>
        ///
        /// <value> The pin. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UInt32 Pin
        {
            get { return _pin; }
            set
            {
                if (_pin != value)
                {
                    _pin = value;
                    OnPropertyChanged(() => Pin);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of bits. </summary>
        ///
        /// <value> The number of bits. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UInt32 BitCount
        {
            get { return _bitCount; }
            set
            {
                if (_bitCount != value)
                {
                    _bitCount = value;
                    OnPropertyChanged(() => BitCount);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the alarm panel zone. </summary>
        ///
        /// <value> The alarm panel zone. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UInt32 AlarmPanelZone
        {
            get { return _alarmPanelZone; }
            set
            {
                if (_alarmPanelZone != value)
                {
                    _alarmPanelZone = value;
                    OnPropertyChanged(() => AlarmPanelZone);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person UID. </summary>
        ///
        /// <value> The person UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid PersonUid
        {
            get { return _PersonUid; }
            set
            {
                if (_PersonUid != value)
                {
                    _PersonUid = value;
                    OnPropertyChanged(() => PersonUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential UID. </summary>
        ///
        /// <value> The credential UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid CredentialUid
        {
            get { return _CredentialUid; }
            set
            {
                if (_CredentialUid != value)
                {
                    _CredentialUid = value;
                    OnPropertyChanged(() => CredentialUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the person. </summary>
        ///
        /// <value> Information describing the person. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string PersonDescription
        {
            get { return _PersonDescription; }
            set
            {
                if (_PersonDescription != value)
                {
                    _PersonDescription = value;
                    OnPropertyChanged(() => PersonDescription);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the credential. </summary>
        ///
        /// <value> Information describing the credential. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string CredentialDescription
        {
            get { return _CredentialDescription; }
            set
            {
                if (_CredentialDescription != value)
                {
                    _CredentialDescription = value;
                    OnPropertyChanged(() => CredentialDescription);
                }
            }
        }


        private string _firstName;

        [DataMember]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }

        private string _lastName;

        [DataMember]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(() => LastName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the trace. </summary>
        ///
        /// <value> True if trace, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool Trace
        {
            get { return _Trace; }
            set
            {
                if (_Trace != value)
                {
                    _Trace = value;
                    OnPropertyChanged(() => Trace, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets a value indicating whether this PanelCredentialActivityLogMessage is not in panel memory
        /// event.
        /// </summary>
        ///
        /// <value>
        /// True if this PanelCredentialActivityLogMessage is not in panel memory event, false if not.
        /// </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsNotInPanelMemoryEvent
        {
            get
            {
                return this.PanelActivityType == Common.Enums.PanelActivityEventCode.CredentialNotInPanelMemory || PanelActivityType == Common.Enums.PanelActivityEventCode.CredentialNotInPanelMemoryReverse;
            }
        }
    }

}
