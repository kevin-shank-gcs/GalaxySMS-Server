//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Client.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using GCS.Core.Common.Core;
    using FluentValidation;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A brand. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public partial class Brand : DbObjectBase, IHasBinaryResource
    {

        /*	// Move to partial class
        using System;
        using System.Collections.Generic;
        using System.Runtime.Serialization;
        using GCS.Core.Common.Core;
        using FluentValidation;
        using System.Collections.ObjectModel;
        using GCS.Core.Common.Extensions;

        namespace GalaxySMS.Client.Entities
        {
            public partial class Brand
            {
                public Brand()
                {
                    Initialize();
                }

                public Brand(Brand e)
                {
                    Initialize(e);
                }

                public void Initialize()
                {
            }

                public void Initialize(Brand e)
                {
                    Initialize();
                    if( e == null )
                        return;
                    this.BrandUid = e.BrandUid;
                    this.BinaryResourceUid = e.BinaryResourceUid;
                    this.BrandName = e.BrandName;
                    this.CompanyName = e.CompanyName;
                    this.Category = e.Category;
                    this.InsertName = e.InsertName;
                    this.InsertDate = e.InsertDate;
                    this.UpdateName = e.UpdateName;
                    this.UpdateDate = e.UpdateDate;
                    this.ConcurrencyValue = e.ConcurrencyValue;

                }

                public Brand Clone(Brand e)
                {
                    return new Brand(e);
                }

                public bool Equals(Brand other)
                {
                    return base.Equals(other);
                }

                public bool IsPrimaryKeyEqual(Brand other)
                {
                    if( other == null ) 
                        return false;

                    if(other.BrandUid != this.BrandUid )
                        return false;
                    return true;
                }

                public override int GetHashCode()
                {
                    return base.GetHashCode();
                }

                public override string ToString()
                {
                    return base.ToString();
                }
            }
        }
        */


        /// <summary>   The brand UID. </summary>
        private System.Guid _brandUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the brand UID. </summary>
        ///
        /// <value> The brand UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.Guid BrandUid
        {
            get { return _brandUid; }
            set
            {
                if (_brandUid != value)
                {
                    _brandUid = value;
                    OnPropertyChanged(() => BrandUid);
                }
            }
        }

        /// <summary>   The binary resource UID. </summary>
        private Nullable<System.Guid> _binaryResourceUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the binary resource UID. </summary>
        ///
        /// <value> The binary resource UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<System.Guid> BinaryResourceUid
        {
            get { return _binaryResourceUid; }
            set
            {
                if (_binaryResourceUid != value)
                {
                    _binaryResourceUid = value;
                    OnPropertyChanged(() => BinaryResourceUid);
                }
            }
        }

        /// <summary>   Name of the brand. </summary>
        private string _brandName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the brand. </summary>
        ///
        /// <value> The name of the brand. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string BrandName
        {
            get { return _brandName; }
            set
            {
                if (_brandName != value)
                {
                    _brandName = value;
                    OnPropertyChanged(() => BrandName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Name
        {
            get { return BrandName; }
            set
            {
                if (Name != value)
                {
                    BrandName = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }

        /// <summary>   Name of the company. </summary>
        private string _companyName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the company. </summary>
        ///
        /// <value> The name of the company. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                if (_companyName != value)
                {
                    _companyName = value;
                    OnPropertyChanged(() => CompanyName);
                }
            }
        }

        /// <summary>   The category. </summary>
        private string _category;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the category. </summary>
        ///
        /// <value> The category. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Category
        {
            get { return _category; }
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged(() => Category);
                }
            }
        }

        /// <summary>   Name of the insert. </summary>
        private string _insertName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the insert. </summary>
        ///
        /// <value> The name of the insert. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string InsertName
        {
            get { return _insertName; }
            set
            {
                if (_insertName != value)
                {
                    _insertName = value;
                    OnPropertyChanged(() => InsertName);
                }
            }
        }

        /// <summary>   The insert date. </summary>
        private System.DateTimeOffset _insertDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the insert date. </summary>
        ///
        /// <value> The insert date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.DateTimeOffset InsertDate
        {
            get { return _insertDate; }
            set
            {
                if (_insertDate != value)
                {
                    _insertDate = value;
                    OnPropertyChanged(() => InsertDate);
                }
            }
        }

        /// <summary>   Name of the update. </summary>
        private string _updateName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the update. </summary>
        ///
        /// <value> The name of the update. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string UpdateName
        {
            get { return _updateName; }
            set
            {
                if (_updateName != value)
                {
                    _updateName = value;
                    OnPropertyChanged(() => UpdateName);
                }
            }
        }

        /// <summary>   The update. </summary>
        private Nullable<System.DateTimeOffset> _updateDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the update. </summary>
        ///
        /// <value> The update date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<System.DateTimeOffset> UpdateDate
        {
            get { return _updateDate; }
            set
            {
                if (_updateDate != value)
                {
                    _updateDate = value;
                    OnPropertyChanged(() => UpdateDate);
                }
            }
        }

        /// <summary>   The concurrency value. </summary>
        private Nullable<short> _concurrencyValue;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the concurrency value. </summary>
        ///
        /// <value> The concurrency value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<short> ConcurrencyValue
        {
            get { return _concurrencyValue; }
            set
            {
                if (_concurrencyValue != value)
                {
                    _concurrencyValue = value;
                    OnPropertyChanged(() => ConcurrencyValue);
                }
            }
        }


        /// <summary>   The gcs binary resource. </summary>
        private gcsBinaryResource _gcsBinaryResource;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gcs binary resource. </summary>
        ///
        /// <value> The gcs binary resource. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public virtual gcsBinaryResource gcsBinaryResource
        {
            get { return _gcsBinaryResource; }
            set
            {
                if (_gcsBinaryResource != value)
                {
                    _gcsBinaryResource = value;
                    OnPropertyChanged(() => gcsBinaryResource);
                }
            }
        }
    }

}
