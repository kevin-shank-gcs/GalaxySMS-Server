using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Api.Support
{

    public class SavePersonExamples : IExamplesProvider<SaveParams<PersonReq>>
    {
        SaveParams<PersonReq> IExamplesProvider<SaveParams<PersonReq>>.GetExamples()
        {
            var p = new PersonReq()
            {
                PersonUid = Guid.Empty,
                PersonId = "Unique Person ID Value 1",
                LastName = "Doe",
                FirstName = "John",
                PersonAccessControlProperty = new PersonAccessControlPropertyReq()
                {
                    IsActive = true,
                },
                PersonCredentials = new List<PersonCredentialReq>(),
                PersonClusterPermissions = new List<PersonClusterPermissionReq>(),
                Notes = new List<NoteReq>(),
                PersonPhotos = new List<PersonPhotoReq>(),
                IncludePhotos = new List<string>(),
                PersonEmailAddresses = new List<PersonEmailAddressReq>(),
                PersonPhoneNumbers = new List<PersonPhoneNumberReq>(),
            };

            p.PersonCredentials.Add(new PersonCredentialReq()
            {
                Credential = new CredentialReq()
                {
                    Standard26Bit = new Credential26BitStandardReq()
                    {
                        FacilityCode = 23,
                        IdCode = 1139
                    },
                },
                CredentialDescription = "Sample Standard26Bit",
                IsActive = true,
            });

            p.PersonCredentials.Add(new PersonCredentialReq()
            {
                Credential = new CredentialReq()
                {
                    Corporate1K35Bit = new CredentialCorporate1K35BitReq()
                    {
                        CompanyCode = 23,
                        IdCode = 1139
                    },
                },
                CredentialDescription = "Sample Corporate1K35Bit",
                IsActive = true,
            });

            p.PersonCredentials.Add(new PersonCredentialReq()
            {
                Credential = new CredentialReq()
                {
                    Corporate1K48Bit = new CredentialCorporate1K48BitReq()
                    {
                        CompanyCode = 23,
                        IdCode = 1139
                    },
                },
                CredentialDescription = "Sample Corporate1K48Bit",
                IsActive = true,
            });

            p.PersonCredentials.Add(new PersonCredentialReq()
            {
                Credential = new CredentialReq()
                {
                    H1030237Bit = new CredentialH1030237BitReq()
                    {
                        IdCode = 231139
                    },
                },
                CredentialDescription = "Sample H1030237Bit",
                IsActive = true,
            });

            p.PersonCredentials.Add(new PersonCredentialReq()
            {
                Credential = new CredentialReq()
                {
                    H1030437Bit = new CredentialH1030437BitReq()
                    {
                        FacilityCode = 23,
                        IdCode = 1139
                    },
                },
                CredentialDescription = "Sample H1030437Bit",
                IsActive = true,
            });

            p.PersonCredentials.Add(new PersonCredentialReq()
            {
                Credential = new CredentialReq()
                {
                    Cypress37Bit = new CredentialCypress37BitReq()
                    {
                        FacilityCode = 23,
                        IdCode = 1139
                    },
                },
                CredentialDescription = "Sample Cypress37Bit",
                IsActive = true,
            });

            p.PersonCredentials.Add(new PersonCredentialReq()
            {
                Credential = new CredentialReq()
                {
                    SoftwareHouse37Bit = new CredentialSoftwareHouse37BitReq()
                    {
                        FacilityCode = 23,
                        SiteCode = 9,
                        IdCode = 1139
                    },
                },
                CredentialDescription = "Sample SoftwareHouse37Bit",
                IsActive = true,
            });

            p.PersonCredentials.Add(new PersonCredentialReq()
            {
                Credential = new CredentialReq()
                {
                    XceedId40Bit = new CredentialXceedId40BitReq()
                    {
                        SiteCode = 23,
                        IdCode = 1139
                    },
                },
                CredentialDescription = "Sample XceedId40Bit",
                IsActive = true,
            });

            p.PersonCredentials.Add(new PersonCredentialReq()
            {
                Credential = new CredentialReq()
                {
                    Bqt36Bit = new CredentialBqt36BitReq()
                    {
                        FacilityCode = 23,
                        IdCode = 1139,
                        IssueCode = 1
                    },
                },
                CredentialDescription = "Sample Bqt36Bit",
                IsActive = true,
            });

            p.PersonCredentials.Add(new PersonCredentialReq()
            {
                Credential = new CredentialReq()
                {
                    CardNumber = 12345678.ToString(),
                },
                CredentialDescription = "Sample Card Code",
                IsActive = true,
            });
            p.PersonCredentials.Add(new PersonCredentialReq()
            {
                Credential = new CredentialReq()
                {
                    CardNumber = "0x12345678",
                },
                CredentialDescription = "Sample Hex Card Code",
                IsActive = true,
            });

            p.Notes.Add(new NoteReq()
            {
                Category = "Some Category Identifier",
                NoteText = "Some note text, "
            });

            var photoBase64 = "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";

            p.PersonPhotos.Add(new PersonPhotoReq()
            {
                Tag = "Main Photo",
                PhotoImage = photoBase64.ConvertBase64StringToByteArray()
            });

            p.PersonEmailAddresses.Add(new PersonEmailAddressReq()
            {
                Label = "Primary Email Address",
                EmailAddress = "John.Doe@company.com"
            });

            p.PersonPhoneNumbers.Add(new PersonPhoneNumberReq()
            {
                Label = "Primary Mobile",
                PhoneNumber = "###-###-####",
                SmsPermitted = true,
            });

            p.PersonPhoneNumbers.Add(new PersonPhoneNumberReq()
            {
                Label = "Office",
                PhoneNumber = "###-###-####",
                SmsPermitted = false,
            });


            var pcp = new PersonClusterPermissionReq()
            {
                PersonAccessGroups = new List<PersonAccessGroupReq>(),
                PersonInputOutputGroups = new List<PersonInputOutputGroupReq>(),
                PersonPersonalAccessGroup = new PersonPersonalAccessGroupReq()
            };
            pcp.PersonAccessGroups.Add(new PersonAccessGroupReq()
            {   // Personal doors
                AccessGroupUid = new Guid("fb6af455-de98-46b6-bcea-ab72009639ce"),
                OrderNumber = 1,
            });

            pcp.PersonAccessGroups.Add(new PersonAccessGroupReq()
            {   // AG 300
                AccessGroupUid = new Guid("e9097b8f-b571-4f27-beb2-ab7c00ad7701"),
                OrderNumber = 2,
            });
            pcp.PersonAccessGroups.Add(new PersonAccessGroupReq()
            {   // unlimited
                AccessGroupUid = new Guid("563ae0cb-42ef-42b2-8799-ab72009639be"),
                OrderNumber = 3,
            });

            pcp.PersonAccessGroups.Add(new PersonAccessGroupReq()
            {   // no access
                AccessGroupUid = new Guid("32f5dcf6-32b9-42fd-9a67-ab720096399b"),
                OrderNumber = 4,
            });
            p.PersonClusterPermissions.Add(pcp);

            return new SaveParams<PersonReq>()
            {
                Data = p,
            };
        }
    }

    public class SaveApiEntitiesPersonExamples : IExamplesProvider<SaveParams<PersonPutReq>>
    {
        SaveParams<PersonPutReq> IExamplesProvider<SaveParams<PersonPutReq>>.GetExamples()
        {
            var putParams = new SaveParams<PersonPutReq>()
            {
                Data = new PersonPutReq()
                {
                    PersonUid = Guid.Empty,
                    PersonId = "Unique Person ID Value 1",
                    LastName = "Doe",
                    FirstName = "John",
                    ConcurrencyValue = 0,
                }
            };
            putParams.Data.PersonCredentials = new HashSet<PersonCredentialPutReq>();
            putParams.Data.PersonCredentials.Add(new PersonCredentialPutReq()
            {
                CredentialDescription = "Sample Corp1K 48 Bit",
                Credential = new CredentialPutReq()
                {
                    CredentialFormatUid = GalaxySMS.Common.Constants.CredentialFormatIds.Corporate1K48Bit,
                    Corporate1K48Bit = new CredentialCorporate1K48BitPutReq()
                    {
                        CompanyCode = 96,
                        IdCode = 1234
                    }
                }
            });
            putParams.Data.PersonCredentials.Add(new PersonCredentialPutReq()
            {
                CredentialDescription = "Sample Barcode/MagStripe",
                Credential = new CredentialPutReq()
                {
                    CredentialFormatUid = GalaxySMS.Common.Constants.CredentialFormatIds.MagneticStripeBarcodeAba,
                    CardNumber = "124567"
                }
            });

            putParams.Data.PersonClusterPermissions = new HashSet<PersonClusterPermissionPutReq>();
            var pcp = new PersonClusterPermissionPutReq()
            {
                PersonAccessGroups = new List<PersonAccessGroupPutReq>(),
                PersonInputOutputGroups = new List<PersonInputOutputGroupPutReq>(),
                PersonPersonalAccessGroup = new PersonPersonalAccessGroupPutReq()
            };
            pcp.PersonAccessGroups.Add(new PersonAccessGroupPutReq()
            {   // Personal doors
                AccessGroupUid = new Guid("fb6af455-de98-46b6-bcea-ab72009639ce"),
                OrderNumber = 1,
            });

            pcp.PersonAccessGroups.Add(new PersonAccessGroupPutReq()
            {   // AG 300
                AccessGroupUid = new Guid("e9097b8f-b571-4f27-beb2-ab7c00ad7701"),
                OrderNumber = 2,
            });
            pcp.PersonAccessGroups.Add(new PersonAccessGroupPutReq()
            {   // unlimited
                AccessGroupUid = new Guid("563ae0cb-42ef-42b2-8799-ab72009639be"),
                OrderNumber = 3,
            });

            pcp.PersonAccessGroups.Add(new PersonAccessGroupPutReq()
            {   // no access
                AccessGroupUid = new Guid("32f5dcf6-32b9-42fd-9a67-ab720096399b"),
                OrderNumber = 4,
            });
            pcp.PersonInputOutputGroups.Add(new PersonInputOutputGroupPutReq()
            {   // Personal doors
                OrderNumber = 1,
            });

            pcp.PersonInputOutputGroups.Add(new PersonInputOutputGroupPutReq()
            {   // AG 300
                OrderNumber = 2,
            });
            pcp.PersonInputOutputGroups.Add(new PersonInputOutputGroupPutReq()
            {   // unlimited
                OrderNumber = 3,
            });

            pcp.PersonInputOutputGroups.Add(new PersonInputOutputGroupPutReq()
            {   // no access
                OrderNumber = 4,
            });

            putParams.Data.PersonClusterPermissions.Add(pcp);

            return putParams;
        }
    }


    public class SearchPersonExamples : IExamplesProvider<PersonSummarySearchParametersReq>
    {
        PersonSummarySearchParametersReq IExamplesProvider<PersonSummarySearchParametersReq>.GetExamples()
        {
            return new PersonSummarySearchParametersReq()
            {
                SearchType = PersonSearchType.AllRecords,
                TextSearchType = TextSearchType.StartsWith,
                MultipleFieldSearchRelationship = Common.Shared.Enums.AndOr.AND,
                SearchCredential = new CredentialReq()
                {

                }
            };
        }
    }
}