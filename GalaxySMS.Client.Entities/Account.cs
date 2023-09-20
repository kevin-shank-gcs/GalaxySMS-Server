////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Account.cs
//
// summary:	Implements the account class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An account. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Account : ObjectBase
    {
        /// <summary>   Unique identifier for the account. </summary>
        Guid _accountGuid;
        /// <summary>   Identifier for the account. </summary>
        int _accountId;
        /// <summary>   The login email. </summary>
        string _loginEmail;
        /// <summary>   The person's first name. </summary>
        string _firstName;
        /// <summary>   The person's last name. </summary>
        string _lastName;
        /// <summary>   The address. </summary>
        string _address;
        /// <summary>   The city. </summary>
        string _city;
        /// <summary>   The state. </summary>
        string _state;
        /// <summary>   The zip code. </summary>
        string _zipCode;
        /// <summary>   The credit card. </summary>
        string _creditCard;
        /// <summary>   The exponent date. </summary>
        string _expDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier of the account. </summary>
        ///
        /// <value> Unique identifier of the account. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Guid AccountGuid
        {
            get { return _accountGuid; }
            set
            {
                if (_accountGuid != value)
                {
                    _accountGuid = value;
                    OnPropertyChanged(() => AccountGuid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the account. </summary>
        ///
        /// <value> The identifier of the account. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int AccountId
        {
            get { return _accountId; }
            set
            {
                if (_accountId != value)
                {
                    _accountId = value;
                    OnPropertyChanged(() => AccountId);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the login email. </summary>
        ///
        /// <value> The login email. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string LoginEmail
        {
            get { return _loginEmail; }
            set
            {
                if (_loginEmail != value)
                {
                    _loginEmail = value;
                    OnPropertyChanged(() => LoginEmail);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's first name. </summary>
        ///
        /// <value> The name of the first. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's last name. </summary>
        ///
        /// <value> The name of the last. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
        /// <summary>   Gets or sets the address. </summary>
        ///
        /// <value> The address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(() => Address);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the city. </summary>
        ///
        /// <value> The city. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged(() => City);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the state. </summary>
        ///
        /// <value> The state. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string State
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged(() => State);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the zip code. </summary>
        ///
        /// <value> The zip code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                if (_zipCode != value)
                {
                    _zipCode = value;
                    OnPropertyChanged(() => ZipCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credit card. </summary>
        ///
        /// <value> The credit card. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string CreditCard
        {
            get { return _creditCard; }
            set
            {
                if (_creditCard != value)
                {
                    _creditCard = value;
                    OnPropertyChanged(() => CreditCard);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the exponent date. </summary>
        ///
        /// <value> The exponent date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ExpDate
        {
            get { return _expDate; }
            set
            {
                if (_expDate != value)
                {
                    _expDate = value;
                    OnPropertyChanged(() => ExpDate);
                }
            }
        }
    }

}
