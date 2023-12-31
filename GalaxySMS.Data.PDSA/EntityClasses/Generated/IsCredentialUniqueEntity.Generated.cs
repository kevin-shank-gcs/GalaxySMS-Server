using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
    /// <summary>
    /// This class contains properties for each data value returned, or parameter to be input/output from the IsCredentialUniquePDSA stored procedure.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>

    public partial class IsCredentialUniquePDSA : PDSAEntityBase
    {
        #region Private Variables
        private int _Result = 0;
        private Guid _CredentialUid = Guid.Empty;
        private string _CardNumber = string.Empty;
        private byte[] _CardBinaryData = null;
        private int _RETURNVALUE = 0;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the Result value
        /// </summary>

        [DataMember]

        public int Result
        {
            get { return _Result; }
            set
            {
                if (HasValueChanged(_Result, value, "Result"))
                {
                    _Result = value;
                    RaisePropertyChanged("Result");
                }
            }
        }

        /// <summary>
        /// Get/Set the Credential Uid value
        /// </summary>

        [DataMember]

        public Guid CredentialUid
        {
            get { return _CredentialUid; }
            set
            {
                if (HasValueChanged(_CredentialUid, value, "@CredentialUid"))
                {
                    _CredentialUid = value;
                    RaisePropertyChanged("CredentialUid");
                }
            }
        }

        /// <summary>
        /// Get/Set the Card Number value
        /// </summary>

        [DataMember]

        public string CardNumber
        {
            get { return _CardNumber; }
            set
            {
                if (HasValueChanged(_CardNumber, value, "@CardNumber"))
                {
                    _CardNumber = value;
                    RaisePropertyChanged("CardNumber");
                }
            }
        }

        /// <summary>
        /// Get/Set the Card Binary Data value
        /// </summary>

        [DataMember]
        public byte[] CardBinaryData
        {
            get { return _CardBinaryData; }
            set
            {
                if (HasValueChanged(_CardBinaryData, value, "CardBinaryData"))
                {
                    _CardBinaryData = value;
                    RaisePropertyChanged("CardBinaryData");
                }
            }
        }
        /// <summary>
        /// Get/Set the return value value
        /// </summary>

        [DataMember]

        public int RETURNVALUE
        {
            get { return _RETURNVALUE; }
            set
            {
                if (HasValueChanged(_RETURNVALUE, value, "@RETURN_VALUE"))
                {
                    _RETURNVALUE = value;
                    RaisePropertyChanged("RETURNVALUE");
                }
            }
        }


        #endregion
    }
}
