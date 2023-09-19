using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GalaxySMS.Common.Shared.Enums;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    public class PersonSearchTypeData
    {
        public PersonSearchType SearchType { get; set; }
        public string Title { get; set; }
        public string ToolTip { get; set; }
    }

    public class DateComparisonType
    {
        public string Display { get; set; }
        public string ComparisonOperator { get; set; }
    }

    public class TextSearchTypeData
    {
        public TextSearchType SearchType { get; set; }
        public string Title { get; set; }
        public string ToolTip { get; set; }
    }

    public class AndOrData
    {
        public AndOr Operation { get; set; }
        public string Title { get; set; }
        public string ToolTip { get; set; }
    }

    public class PersonSearchData : ObjectBase
    {
        #region Private fields

        private UserDefinedProperty _selectedSearchProperty;
        private PersonSearchTypeData _selectedSearchType;
        private TextSearchTypeData _selectedTextSearchType;
        private AndOrData _selectedAndOrOperationType;
        private string _searchStringValue;
        private UInt32 _searchUInt32Value;
        private UInt64 _searchUInt64Value;
        private DateTimeOffset _searchDateTimeValue = DateTimeOffset.Now.Today();
        private bool _searchBoolValue;
        private Guid _searchGuidValue;
        private ObservableCollection<UserDefinedProperty> _personSearchProperties;
        private DateComparisonType _selectedDateComparisonType;
        private Credential _searchCredential = new Credential();
        private UserDefinedProperty _lastNameProperty;
        private UserDefinedProperty _firstNameProperty;
        private string _lastName;
        private string _firstName;
        #endregion


        public PersonSearchTypeData SelectedSearchType
        {
            get { return _selectedSearchType; }
            set
            {
                if (_selectedSearchType != value)
                {
                    _selectedSearchType = value;
                    OnPropertyChanged(() => SelectedSearchType, false);
                    switch (_selectedSearchType.SearchType)
                    {
                        case PersonSearchType.AllRecords:
                            break;
                        case PersonSearchType.ByPersonUid:
                            SelectedSearchProperty = PersonSearchProperties.FirstOrDefault(p => p.PropertyName == "PersonUid");
                            break;
                        case PersonSearchType.ByPersonId:
                            SelectedSearchProperty = PersonSearchProperties.FirstOrDefault(p => p.PropertyName == "PersonId");
                            break;
                        case PersonSearchType.ByPersonActiveStatusTypeUid:
                            SelectedSearchProperty = PersonSearchProperties.FirstOrDefault(p => p.PropertyName == "PersonActiveStatusTypeUid");
                            break;
                        case PersonSearchType.ByDepartmentUid:
                            SelectedSearchProperty = PersonSearchProperties.FirstOrDefault(p => p.PropertyName == "DepartmentUid");
                            break;
                        case PersonSearchType.ByPersonRecordTypeUid:
                            SelectedSearchProperty = PersonSearchProperties.FirstOrDefault(p => p.PropertyName == "PersonRecordTypeUid");
                            break;
                        case PersonSearchType.ByLastFirstName:
                            LastNameProperty = PersonSearchProperties.FirstOrDefault(p => p.PropertyName == "LastName");
                            FirstNameProperty = PersonSearchProperties.FirstOrDefault(p => p.PropertyName == "FirstName");
                            break;
                        case PersonSearchType.ByAnyNameField:
                            break;
                        case PersonSearchType.ByFields:
                            break;
                        case PersonSearchType.ByCredentialNumber:
                            break;
                        case PersonSearchType.ByCredentialFieldValues:
                            break;
                        case PersonSearchType.ByCredentialFieldValue:
                            break;

                        case PersonSearchType.ByAccessProfileUid:
                            SelectedSearchProperty = PersonSearchProperties.FirstOrDefault(p => p.PropertyName == "AccessProfileUid");
                            break;

                        case PersonSearchType.ByOriginId:
                            SelectedSearchProperty = PersonSearchProperties.FirstOrDefault(p => p.PropertyName == "OriginId");
                            break;
                        case PersonSearchType.ByLastUpdatedDate:
                            SelectedSearchProperty = PersonSearchProperties.FirstOrDefault(p => p.PropertyName == "UpdateDate");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        public TextSearchTypeData SelectedTextSearchType
        {
            get { return _selectedTextSearchType; }
            set
            {
                if (_selectedTextSearchType != value)
                {
                    _selectedTextSearchType = value;
                    OnPropertyChanged(() => SelectedTextSearchType, false);
                }
                
            }
        }

        public AndOrData SelectedAndOrOperationType
        {
            get { return _selectedAndOrOperationType; }
            set
            {
                if (_selectedAndOrOperationType != value)
                {
                    _selectedAndOrOperationType = value;
                    OnPropertyChanged(() => SelectedAndOrOperationType, false);
                }

            }
        }


        public Entities.UserDefinedProperty SelectedSearchProperty
        {
            get { return _selectedSearchProperty; }
            set
            {
                if (_selectedSearchProperty != value)
                {
                    _selectedSearchProperty = value;
                    OnPropertyChanged(() => SelectedSearchProperty, false);
                }
            }
        }

        public ObservableCollection<Entities.UserDefinedProperty> PersonSearchProperties
        {
            get { return _personSearchProperties; }
            set
            {
                if (_personSearchProperties != value)
                {
                    _personSearchProperties = value;
                    OnPropertyChanged(() => PersonSearchProperties, false);
                }
            }
        }

        
        public string SearchStringValue
        {
            get { return _searchStringValue; }
            set
            {
                if (_searchStringValue != value)
                {
                    _searchStringValue = value;
                    OnPropertyChanged(() => SearchStringValue, false);
                }
            }
        }

        public UInt32 SearchUInt32Value
        {
            get { return _searchUInt32Value; }
            set
            {
                if (_searchUInt32Value != value)
                {
                    _searchUInt32Value = value;
                    OnPropertyChanged(() => SearchUInt32Value, false);
                }
            }
        }


        public UInt64 SearchUInt64Value
        {
            get { return _searchUInt64Value; }
            set
            {
                if (_searchUInt64Value != value)
                {
                    _searchUInt64Value = value;
                    OnPropertyChanged(() => SearchUInt64Value, false);
                }
            }
        }

        public DateTimeOffset SearchDateTimeValue
        {
            get { return _searchDateTimeValue; }
            set
            {
                if (_searchDateTimeValue != value)
                {
                    _searchDateTimeValue = value;
                    OnPropertyChanged(() => SearchDateTimeValue, false);
                }
            }
        }

        public bool SearchBoolValue
        {
            get { return _searchBoolValue; }
            set
            {
                if (_searchBoolValue != value)
                {
                    _searchBoolValue = value;
                    OnPropertyChanged(() => SearchBoolValue, false);
                }
            }
        }

        public Guid SearchGuidValue
        {
            get { return _searchGuidValue; }
            set
            {
                if (_searchGuidValue != value)
                {
                    _searchGuidValue = value;
                    OnPropertyChanged(() => SearchGuidValue, false);
                }
            }
        }

        public DateComparisonType SelectedDateComparisonType
        {
            get { return _selectedDateComparisonType; }
            set
            {
                if (_selectedDateComparisonType != value)
                {
                    _selectedDateComparisonType = value;
                    OnPropertyChanged(() => SelectedDateComparisonType, false);
                }
            }
        }


        public UserDefinedProperty LastNameProperty
        {
            get { return _lastNameProperty; }
            set
            {
                if (_lastNameProperty != value)
                {
                    _lastNameProperty = value;
                    OnPropertyChanged(() => LastNameProperty, false);
                }
            }
        }

        public UserDefinedProperty FirstNameProperty
        {
            get { return _firstNameProperty; }
            set
            {
                if (_firstNameProperty != value)
                {
                    _firstNameProperty = value;
                    OnPropertyChanged(() => FirstNameProperty, false);
                }
            }
        }


        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(() => LastName, false);
                }
            }
        }


        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(() => FirstName, false);
                }
            }
        }


        public Credential SearchCredential
        {
            get { return _searchCredential; }
            set
            {
                if (_searchCredential != value)
                {
                    _searchCredential = value;
                    OnPropertyChanged(() => SearchCredential, false);
                }
            }
        }


        //public bool ExactMatch
        //{
        //    get { return _exactMatch; }
        //    set
        //    {
        //        if (_exactMatch != value)
        //        {
        //            _exactMatch = value;
        //            OnPropertyChanged(() => ExactMatch, false);
        //        }
        //    }
        //}


        //public bool AnywhereWithin
        //{
        //    get { return _anywhereWithin; }
        //    set
        //    {
        //        if (_anywhereWithin != value)
        //        {
        //            _anywhereWithin = value;
        //            OnPropertyChanged(() => AnywhereWithin, false);
        //        }
        //    }
        //}
    }
}
