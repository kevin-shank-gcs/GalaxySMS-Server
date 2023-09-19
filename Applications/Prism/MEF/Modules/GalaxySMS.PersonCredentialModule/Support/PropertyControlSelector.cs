using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaxySMS.Client.Entities;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.PersonCredential.Support
{
    public class PropertyControlSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if (item is UserDefinedProperty)
            {
                var udp = item as UserDefinedProperty;
                var propEnum = EnumExtensions.GetOne<PersonStandardPropertyNames>(udp.PropertyName);
                switch (propEnum)
                {
                    case PersonStandardPropertyNames.PersonUid:
                        return PersonUidTemplate;
                    case PersonStandardPropertyNames.CountryOfBirthUid:
                        return CountryOfBirthTemplate;
                    case PersonStandardPropertyNames.PersonActiveStatusTypeUid:
                        return PersonActiveStatusTypeTemplate;
                    case PersonStandardPropertyNames.GenderUid:
                        return GenderTemplate;
                    case PersonStandardPropertyNames.DepartmentUid:
                        return DepartmentTemplate;
                    case PersonStandardPropertyNames.PersonRecordTypeUid:
                        return PersonRecordTypeTemplate;
                    case PersonStandardPropertyNames.EntityId:
                        return EntityIdTemplate;
                    case PersonStandardPropertyNames.RowOrigin:
                        return RowOriginTemplate;
                    case PersonStandardPropertyNames.OriginId:
                        return OriginIdTemplate;
                    case PersonStandardPropertyNames.PersonId:
                        return PersonIdTemplate;
                    case PersonStandardPropertyNames.LastName:
                        return LastNameTemplate;
                    case PersonStandardPropertyNames.FirstName:
                        return FirstNameTemplate;
                    case PersonStandardPropertyNames.MiddleName:
                        return MiddleNameTemplate;
                    case PersonStandardPropertyNames.Initials:
                        return InitialsTemplate;
                    case PersonStandardPropertyNames.NickName:
                        return NickNameTemplate;
                    case PersonStandardPropertyNames.LegalName:
                        return LegalNameTemplate;
                    case PersonStandardPropertyNames.FullName:
                        return FullNameTemplate;
                    case PersonStandardPropertyNames.PreferredName:
                        return PreferredNameTemplate;
                    case PersonStandardPropertyNames.Company:
                        return CompanyTemplate;
                    case PersonStandardPropertyNames.HomeOfficeLocation:
                        return HomeOfficeLocationTemplate;
                    case PersonStandardPropertyNames.JobTitle:
                        return JobTitleTemplate;
                    case PersonStandardPropertyNames.Race:
                        return RaceTemplate;
                    case PersonStandardPropertyNames.Nationality:
                        return NationalityTemplate;
                    case PersonStandardPropertyNames.Ethnicity:
                        return EthnicityTemplate;
                    case PersonStandardPropertyNames.PrimaryLanguage:
                        return PrimaryLanguageTemplate;
                    case PersonStandardPropertyNames.SecondaryLanguage:
                        return SecondaryLanguageTemplate;
                    case PersonStandardPropertyNames.NationalIdentificationNumber:
                        return NationalIdentificationNumberTemplate;
                    case PersonStandardPropertyNames.DateOfBirth:
                        return DateOfBirthTemplate;
                    case PersonStandardPropertyNames.EmploymentDate:
                        return EmploymentDateTemplate;
                    case PersonStandardPropertyNames.TerminationDate:
                        return TerminationDateTemplate;
                    case PersonStandardPropertyNames.ActivationDateTime:
                        return ActivationDateTimeTemplate;
                    case PersonStandardPropertyNames.ExpirationDateTime:
                        return ExpirationDateTimeTemplate;
                    case PersonStandardPropertyNames.Trace:
                        return TraceTemplate;
                    case PersonStandardPropertyNames.TextData1:
                        return TextData1Template;
                    case PersonStandardPropertyNames.TextData2:
                        return TextData2Template;
                    case PersonStandardPropertyNames.TextData3:
                        return TextData3Template;
                    case PersonStandardPropertyNames.TextData4:
                        return TextData4Template;
                    case PersonStandardPropertyNames.TextData5:
                        return TextData5Template;
                    case PersonStandardPropertyNames.TextData6:
                        return TextData6Template;
                    case PersonStandardPropertyNames.TextData7:
                        return TextData7Template;
                    case PersonStandardPropertyNames.TextData8:
                        return TextData8Template;
                    case PersonStandardPropertyNames.TextData9:
                        return TextData9Template;
                    case PersonStandardPropertyNames.TextData10:
                        return TextData10Template;
                    case PersonStandardPropertyNames.TextData11:
                        return TextData11Template;
                    case PersonStandardPropertyNames.TextData12:
                        return TextData12Template;
                    case PersonStandardPropertyNames.TextData13:
                        return TextData13Template;
                    case PersonStandardPropertyNames.TextData14:
                        return TextData14Template;
                    case PersonStandardPropertyNames.TextData15:
                        return TextData15Template;
                    case PersonStandardPropertyNames.TextData16:
                        return TextData16Template;
                    case PersonStandardPropertyNames.TextData17:
                        return TextData17Template;
                    case PersonStandardPropertyNames.TextData18:
                        return TextData18Template;
                    case PersonStandardPropertyNames.TextData19:
                        return TextData19Template;
                    case PersonStandardPropertyNames.TextData20:
                        return TextData20Template;
                    case PersonStandardPropertyNames.TextData22:
                        return TextData22Template;
                    case PersonStandardPropertyNames.TextData23:
                        return TextData23Template;
                    case PersonStandardPropertyNames.TextData24:
                        return TextData24Template;
                    case PersonStandardPropertyNames.TextData25:
                        return TextData25Template;
                    case PersonStandardPropertyNames.TextData26:
                        return TextData26Template;
                    case PersonStandardPropertyNames.TextData27:
                        return TextData27Template;
                    case PersonStandardPropertyNames.TextData28:
                        return TextData28Template;
                    case PersonStandardPropertyNames.TextData29:
                        return TextData29Template;
                    case PersonStandardPropertyNames.TextData21:
                        return TextData21Template;
                    case PersonStandardPropertyNames.TextData30:
                        return TextData30Template;
                    case PersonStandardPropertyNames.TextData31:
                        return TextData31Template;
                    case PersonStandardPropertyNames.TextData32:
                        return TextData32Template;
                    case PersonStandardPropertyNames.TextData33:
                        return TextData33Template;
                    case PersonStandardPropertyNames.TextData34:
                        return TextData34Template;
                    case PersonStandardPropertyNames.TextData35:
                        return TextData35Template;
                    case PersonStandardPropertyNames.TextData36:
                        return TextData36Template;
                    case PersonStandardPropertyNames.TextData37:
                        return TextData37Template;
                    case PersonStandardPropertyNames.TextData38:
                        return TextData38Template;
                    case PersonStandardPropertyNames.TextData39:
                        return TextData39Template;
                    case PersonStandardPropertyNames.TextData40:
                        return TextData40Template;
                    case PersonStandardPropertyNames.TextData41:
                        return TextData41Template;
                    case PersonStandardPropertyNames.TextData42:
                        return TextData42Template;
                    case PersonStandardPropertyNames.TextData43:
                        return TextData43Template;
                    case PersonStandardPropertyNames.TextData44:
                        return TextData44Template;
                    case PersonStandardPropertyNames.TextData45:
                        return TextData45Template;
                    case PersonStandardPropertyNames.TextData46:
                        return TextData46Template;
                    case PersonStandardPropertyNames.TextData47:
                        return TextData47Template;
                    case PersonStandardPropertyNames.TextData48:
                        return TextData48Template;
                    case PersonStandardPropertyNames.TextData49:
                        return TextData49Template;
                    case PersonStandardPropertyNames.TextData50:
                        return TextData50Template;
                    case PersonStandardPropertyNames.SysGalEmployeeId:
                        return SysGalEmployeeIdTemplate;
                    case PersonStandardPropertyNames.VeryImportantPerson:
                        return VeryImportantPersonTemplate;
                    case PersonStandardPropertyNames.HasPhysicalDisability:
                        return HasPhysicalDisabilityTemplate;
                    case PersonStandardPropertyNames.HasVertigo:
                        return HasVertigoTemplate;
                    case PersonStandardPropertyNames.ActivityEventText:
                        return ActivityEventTextTemplate;

                    case PersonStandardPropertyNames.InsertName:
                        return InsertNameTemplate;
                    case PersonStandardPropertyNames.InsertDate:
                        return InsertDateTemplate;
                    case PersonStandardPropertyNames.UpdateName:
                        return UpdateNameTemplate;
                    case PersonStandardPropertyNames.UpdateDate:
                        return UpdateDateTemplate;
                    case PersonStandardPropertyNames.ConcurrencyValue:
                        return ConcurrencyValueTemplate;
                    case PersonStandardPropertyNames.AccessProfileUid:
                        return AccessProfileTemplate;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                //switch (udp.PropertyName.ToLower())
                //{
                //    case "company":
                //        return CompanyTemplate;

                //    case "textdata1":
                //        return TextData1Template;
                //}

            }
            return null;
        }

        public DataTemplate PersonUidTemplate { get; set; }
        public DataTemplate CountryOfBirthTemplate { get; set; }
        public DataTemplate PersonActiveStatusTypeTemplate { get; set; }
        public DataTemplate GenderTemplate { get; set; }
        public DataTemplate DepartmentTemplate { get; set; }
        public DataTemplate PersonRecordTypeTemplate { get; set; }
        public DataTemplate EntityIdTemplate { get; set; }
        public DataTemplate RowOriginTemplate { get; set; }
        public DataTemplate OriginIdTemplate { get; set; }
        public DataTemplate PersonIdTemplate { get; set; }
        public DataTemplate FirstNameTemplate { get; set; }
        public DataTemplate MiddleNameTemplate { get; set; }
        public DataTemplate LastNameTemplate { get; set; }
        public DataTemplate InitialsTemplate { get; set; }
        public DataTemplate NickNameTemplate { get; set; }
        public DataTemplate LegalNameTemplate { get; set; }
        public DataTemplate FullNameTemplate { get; set; }
        public DataTemplate PreferredNameTemplate { get; set; }
        public DataTemplate CompanyTemplate { get; set; }
        public DataTemplate HomeOfficeLocationTemplate { get; set; }
        public DataTemplate JobTitleTemplate { get; set; }
        public DataTemplate RaceTemplate { get; set; }
        public DataTemplate NationalityTemplate { get; set; }
        public DataTemplate EthnicityTemplate { get; set; }
        public DataTemplate PrimaryLanguageTemplate { get; set; }
        public DataTemplate SecondaryLanguageTemplate { get; set; }
        public DataTemplate NationalIdentificationNumberTemplate { get; set; }
        public DataTemplate DateOfBirthTemplate { get; set; }
        public DataTemplate EmploymentDateTemplate { get; set; }
        public DataTemplate TerminationDateTemplate { get; set; }
        public DataTemplate ActivationDateTimeTemplate { get; set; }
        public DataTemplate ExpirationDateTimeTemplate { get; set; }
        public DataTemplate TraceTemplate { get; set; }
        public DataTemplate TextData1Template { get; set; }
        public DataTemplate TextData2Template { get; set; }
        public DataTemplate TextData3Template { get; set; }
        public DataTemplate TextData4Template { get; set; }
        public DataTemplate TextData5Template { get; set; }
        public DataTemplate TextData6Template { get; set; }
        public DataTemplate TextData7Template { get; set; }
        public DataTemplate TextData8Template { get; set; }
        public DataTemplate TextData9Template { get; set; }
        public DataTemplate TextData10Template { get; set; }
        public DataTemplate TextData11Template { get; set; }
        public DataTemplate TextData12Template { get; set; }
        public DataTemplate TextData13Template { get; set; }
        public DataTemplate TextData14Template { get; set; }
        public DataTemplate TextData15Template { get; set; }
        public DataTemplate TextData16Template { get; set; }
        public DataTemplate TextData17Template { get; set; }
        public DataTemplate TextData18Template { get; set; }
        public DataTemplate TextData19Template { get; set; }
        public DataTemplate TextData20Template { get; set; }
        public DataTemplate TextData21Template { get; set; }
        public DataTemplate TextData22Template { get; set; }
        public DataTemplate TextData23Template { get; set; }
        public DataTemplate TextData24Template { get; set; }
        public DataTemplate TextData25Template { get; set; }
        public DataTemplate TextData26Template { get; set; }
        public DataTemplate TextData27Template { get; set; }
        public DataTemplate TextData28Template { get; set; }
        public DataTemplate TextData29Template { get; set; }
        public DataTemplate TextData30Template { get; set; }
        public DataTemplate TextData31Template { get; set; }
        public DataTemplate TextData32Template { get; set; }
        public DataTemplate TextData33Template { get; set; }
        public DataTemplate TextData34Template { get; set; }
        public DataTemplate TextData35Template { get; set; }
        public DataTemplate TextData36Template { get; set; }
        public DataTemplate TextData37Template { get; set; }
        public DataTemplate TextData38Template { get; set; }
        public DataTemplate TextData39Template { get; set; }
        public DataTemplate TextData40Template { get; set; }
        public DataTemplate TextData41Template { get; set; }
        public DataTemplate TextData42Template { get; set; }
        public DataTemplate TextData43Template { get; set; }
        public DataTemplate TextData44Template { get; set; }
        public DataTemplate TextData45Template { get; set; }
        public DataTemplate TextData46Template { get; set; }
        public DataTemplate TextData47Template { get; set; }
        public DataTemplate TextData48Template { get; set; }
        public DataTemplate TextData49Template { get; set; }
        public DataTemplate TextData50Template { get; set; }
        public DataTemplate SysGalEmployeeIdTemplate { get; set; }
        public DataTemplate VeryImportantPersonTemplate { get; set; }
        public DataTemplate HasPhysicalDisabilityTemplate { get; set; }
        public DataTemplate HasVertigoTemplate { get; set; }
        public DataTemplate ActivityEventTextTemplate { get; set; }
        public DataTemplate InsertNameTemplate { get; set; }
        public DataTemplate InsertDateTemplate { get; set; }
        public DataTemplate UpdateNameTemplate { get; set; }
        public DataTemplate UpdateDateTemplate { get; set; }
        public DataTemplate ConcurrencyValueTemplate { get; set; }
        public DataTemplate AccessProfileTemplate { get; set; }

    }

}
