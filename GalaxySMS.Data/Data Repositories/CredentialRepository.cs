using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Enums;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Reflection;
using GCS.Core.Common.Utils;
using GCS.Framework.CredentialProcessor;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using GalaxySMS.Common.Constants;
using GCS.Core.Common.Validation;

namespace GalaxySMS.Data
{
    [Export(typeof(ICredentialRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CredentialRepository : DataRepositoryBase<Credential>, ICredentialRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;
        [Import] private ICredentialFormatRepository _credentialFormatRepository;
        [Import] private ICredential26BitStandardRepository _credential26BitStandardRepository;
        [Import] private ICredentialBqt36BitRepository _credentialBqt36BitRepository;
        [Import] private ICredentialCorporate1K35BitRepository _credentialCorporate1K35BitRepository;
        [Import] private ICredentialCorporate1K48BitRepository _credentialCorporate1K48BitRepository;
        [Import] private ICredentialCypress37BitRepository _credentialCypress37BitRepository;
        [Import] private ICredentialDataRepository _credentialDataRepository;
        [Import] private ICredentialH1030437BitRepository _credentialH1030437BitRepository;
        [Import] private ICredentialH1030237BitRepository _credentialH1030237BitRepository;
        [Import] private ICredentialSoftwareHouse37BitRepository _credentialSoftwareHouse37BitRepository;
        [Import] private ICredentialPIV75BitRepository _credentialPIV75BitRepository;
        [Import] private ICredentialXceedId40BitRepository _credentialXceedId40BitRepository;

        public Credential SaveCredential(Credential entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity == null)
                throw new NullReferenceException("CredentialRepository.SaveCredential entity parameter is null");

            if (entity.CredentialFormat == null || entity.CredentialFormat.CredentialFormatUid != entity.CredentialFormatUid)
            {
                if (entity.CredentialFormatUid != Guid.Empty)
                    entity.CredentialFormat = _credentialFormatRepository.Get(entity.CredentialFormatUid, sessionData, new GetParametersWithPhoto() { UniqueId = entity.CredentialFormatUid });

                if (entity.CredentialFormat == null)
                {
                    var cfs = _credentialFormatRepository.GetAll(sessionData, new GetParametersWithPhoto());
                    if (entity.Standard26Bit != null)
                        entity.CredentialFormat = cfs.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.Standard26Bit);
                    else if (entity.Corporate1K35Bit != null)
                        entity.CredentialFormat = cfs.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.Corporate1K35Bit);
                    else if (entity.Corporate1K48Bit != null)
                        entity.CredentialFormat = cfs.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.Corporate1K48Bit);
                    else if (entity.Cypress37Bit != null)
                        entity.CredentialFormat = cfs.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.Cypress37Bit);
                    else if (entity.H1030237Bit != null)
                        entity.CredentialFormat = cfs.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.H1030237Bit);
                    else if (entity.H1030437Bit != null)
                        entity.CredentialFormat = cfs.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.H1030437Bit);
                    else if (entity.SoftwareHouse37Bit != null)
                        entity.CredentialFormat = cfs.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.SoftwareHouse37Bit);
                    else if (entity.XceedId40Bit != null)
                        entity.CredentialFormat = cfs.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.XceedId40Bit);
                    else if (entity.Bqt36Bit != null)
                        entity.CredentialFormat = cfs.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.Bqt36Bit);
                    else if (entity.CardNumberIsHex && !string.IsNullOrEmpty(entity.CardNumber))
                        entity.CredentialFormat = cfs.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.USGovernmentID);
                    else if (entity.CardNumberIsHex == false && !string.IsNullOrEmpty(entity.CardNumber))
                        entity.CredentialFormat = cfs.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.NumericCardCode);
                    //else if (entity.CredentialPIV75Bit != null)
                    //    entity.CredentialFormat = cfs.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.PIV75Bit);
                    //else if (entity.CredentialCorporate1K48Bit != null)
                    //    entity.CredentialFormat = cfs.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.HIDCorp1K48Bit);
                    //else if (entity.CredentialCorporate1K48Bit != null)
                    //    entity.CredentialFormat = cfs.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.HIDCorp1K48Bit);
                    //else if (entity.CredentialCorporate1K48Bit != null)
                    //    entity.CredentialFormat = cfs.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.HIDCorp1K48Bit);
                    //else if (entity.CredentialCorporate1K48Bit != null)
                    //    entity.CredentialFormat = cfs.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.HIDCorp1K48Bit);

                }
            }
            if (entity.CredentialFormat == null)
                throw new NullReferenceException("CredentialFormat is null");

            entity.CardNumberIsHex = false;
            switch (entity.CredentialFormat.CredentialFormatCode)
            {
                case CredentialFormatCodes.NumericCardCode:
                case CredentialFormatCodes.MagneticStripeBarcodeAba:
                case CredentialFormatCodes.BasIpQr:
                case CredentialFormatCodes.BtFarpointeConektMobile:
                case CredentialFormatCodes.BtHidMobileAccess:
                case CredentialFormatCodes.BtStidMobileId:
                case CredentialFormatCodes.BtAllegion:
                case CredentialFormatCodes.BtBasIp:
                    var credNumericFormat = new CredentialNumericFormat(entity.CardNumber);
                    entity.CardBinaryData = credNumericFormat.BinaryDataExtended;
                    entity.CardNumberIsHex = HexEncoding.IsHexFormat(entity.CardNumber);
                    break;

                case CredentialFormatCodes.USGovernmentID:
                    var credNumericUsGovernmentFormat = new CredentialNumericFormat(entity.CardNumber);
                    entity.CardBinaryData = credNumericUsGovernmentFormat.BinaryDataExtended;
                    entity.CardNumberIsHex = HexEncoding.IsHexFormat(entity.CardNumber);
                    break;

                case CredentialFormatCodes.GalaxyKeypad:
                    break;

                case CredentialFormatCodes.Standard26Bit:
                    var cred26BitFormat = new Credential26BitWiegandFormat((ushort)entity.Standard26Bit.FacilityCode, entity.Standard26Bit.IdCode);
                    entity.CardNumber = cred26BitFormat.FCC;
                    entity.CardBinaryData = cred26BitFormat.BinaryDataExtended;
                    entity.BitCount = (short)cred26BitFormat.BitCount;
                    break;
                case CredentialFormatCodes.Corporate1K35Bit:
                    var credCorp1K35BitFormat = new CredentialHIDCorporate1K35BitFormat((uint)entity.Corporate1K35Bit.CompanyCode, (uint)entity.Corporate1K35Bit.IdCode);
                    entity.CardNumber = credCorp1K35BitFormat.FCC;
                    entity.CardBinaryData = credCorp1K35BitFormat.BinaryDataExtended;
                    entity.BitCount = (short)credCorp1K35BitFormat.BitCount;
                    break;
                case CredentialFormatCodes.PIV75Bit:
                    var credPiv75BitFormat = new CredentialPIV75BitFormat((uint)entity.PIV75Bit.AgencyCode, (uint)entity.PIV75Bit.SiteCode, (uint)entity.PIV75Bit.CredentialCode);
                    entity.CardNumber = credPiv75BitFormat.FCC;
                    entity.CardBinaryData = credPiv75BitFormat.BinaryDataExtended;
                    entity.BitCount = (short)credPiv75BitFormat.BitCount;
                    break;
                case CredentialFormatCodes.Bqt36Bit:
                    var credBqt36BitFormat = new CredentialBQT36BitFormat((uint)entity.Bqt36Bit.FacilityCode, (uint)entity.Bqt36Bit.IdCode, (uint)entity.Bqt36Bit.IssueCode);
                    entity.CardNumber = credBqt36BitFormat.FCC;
                    entity.CardBinaryData = credBqt36BitFormat.BinaryDataExtended;
                    entity.BitCount = (short)credBqt36BitFormat.BitCount;
                    break;
                case CredentialFormatCodes.XceedId40Bit:
                    var credXceed40BitFormat = new CredentialXceedId40BitFormat((ushort)entity.XceedId40Bit.SiteCode, (ushort)entity.XceedId40Bit.IdCode);
                    entity.CardNumber = credXceed40BitFormat.FCC;
                    entity.CardBinaryData = credXceed40BitFormat.BinaryDataExtended;
                    entity.BitCount = (short)credXceed40BitFormat.BitCount;
                    break;
                case CredentialFormatCodes.Corporate1K48Bit:
                    var credCorp1K48BitFormat = new CredentialHIDCorporate1K48BitFormat((uint)entity.Corporate1K48Bit.CompanyCode, (uint)entity.Corporate1K48Bit.IdCode);
                    entity.CardNumber = credCorp1K48BitFormat.FCC;
                    entity.CardBinaryData = credCorp1K48BitFormat.BinaryDataExtended;
                    entity.BitCount = (short)credCorp1K48BitFormat.BitCount;
                    break;
                case CredentialFormatCodes.Cypress37Bit:
                    var credCypress37BitFormat = new CredentialCypress37BitFormat((ushort)entity.Cypress37Bit.FacilityCode, (ushort)entity.Cypress37Bit.IdCode);
                    entity.CardNumber = credCypress37BitFormat.FCC;
                    entity.CardBinaryData = credCypress37BitFormat.BinaryDataExtended;
                    entity.BitCount = (short)credCypress37BitFormat.BitCount;
                    break;
                case CredentialFormatCodes.H1030437Bit:
                    var credH1030437BitFormat = new CredentialHIDH1030437BitFormat((ushort)entity.H1030437Bit.FacilityCode, (ushort)entity.H1030437Bit.IdCode);
                    entity.CardNumber = credH1030437BitFormat.FCC;
                    entity.CardBinaryData = credH1030437BitFormat.BinaryDataExtended;
                    entity.BitCount = (short)credH1030437BitFormat.BitCount;
                    break;
                case CredentialFormatCodes.H1030237Bit:
                    var credH1030237BitFormat = new CredentialHIDH1030237BitFormat(entity.H1030237Bit.IdCode);
                    entity.CardNumber = credH1030237BitFormat.FCC;
                    entity.CardBinaryData = credH1030237BitFormat.BinaryDataExtended;
                    entity.BitCount = (short)credH1030237BitFormat.BitCount;
                    break;
                case CredentialFormatCodes.SoftwareHouse37Bit:
                    var credSoftwareHouse37BitFormat = new CredentialSoftwareHouse37BitFormat((short)entity.SoftwareHouse37Bit.FacilityCode, entity.SoftwareHouse37Bit.SiteCode, entity.SoftwareHouse37Bit.IdCode);
                    entity.CardNumber = credSoftwareHouse37BitFormat.FCC;
                    entity.CardBinaryData = credSoftwareHouse37BitFormat.BinaryDataExtended;
                    entity.BitCount = (short)credSoftwareHouse37BitFormat.BitCount;
                    break;

                case CredentialFormatCodes.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            UpdateTableEntityBaseProperties(entity, sessionData);

            var eventDataMgr = new Credential_GetActivityEventDataPDSAManager();
            eventDataMgr.Entity.CardBinaryData = entity.CardBinaryData;
            var credData = eventDataMgr.BuildCollection();
            if (credData != null && credData.Count > 0)
            {
                var existingCred = credData.FirstOrDefault();
                if (existingCred.CredentialUid != entity.CredentialUid)
                {
                    throw new DuplicateIndexException($"Credential cannot be saved because the card number or card binary data is a duplicate. CardBinaryData:0x{entity.CardBinaryData.ToHexString((char)0)}; CardNumber:{entity.CardNumber}. The credential is assigned to PersonUid:{existingCred.PersonUid}, LastName:{existingCred.LastName}, FirstName:{existingCred.FirstName}, Entity:{existingCred.EntityName}");
                }
            }
            //var getParams = new GetParametersWithPhoto<Credential>();
            //getParams.Data.CardBinaryData = entity.CardBinaryData;

            //var existingCredentials = GetByCredentialValues(sessionData, getParams);
            //if (existingCredentials.Any())
            //{
            //    var existingCredential = existingCredentials.FirstOrDefault();
            //    if (existingCredential.CredentialUid != entity.CredentialUid)
            //    {
            //        throw new DuplicateIndexException($"Duplicate CardBinaryData/CardNumber {entity.CardBinaryData}/{entity.CardNumber}.");
            //    }
            //}

            if (entity.CredentialUid == Guid.Empty)
            {
                entity.CredentialUid = GuidUtilities.GenerateComb();
                return AddEntity(entity, sessionData, saveParams);
            }
            return UpdateEntity(entity, sessionData, saveParams);
        }

        protected override Credential AddEntity(Credential entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                if (entity.CredentialFormatUid == Guid.Empty && entity.CredentialFormat != null)
                    entity.CredentialFormatUid = entity.CredentialFormat.CredentialFormatUid;

                var mgr = new CredentialPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.CredentialUid, sessionData, null);
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        result = GetEntityByGuidId(entity.CredentialUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = true });
                    }
                    return result;
                }
                return entity;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialRepository::AddEntity", ex);
                throw;
            }
        }

        protected override Credential UpdateEntity(Credential entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.CredentialUid, sessionData, null);
                var mgr = new CredentialPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.CredentialUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if CredentialFormatUid is = Guid.Empty or null, then use the value from the original record
                    //entity.CredentialFormatUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.CredentialFormatUid, entity.CredentialFormatUid);

                    //if(string.IsNullOrEmpty(entity.CardNumber))
                    //    entity.CardNumber = mgr.Entity.CardNumber;

                    //if( entity.CardBinaryData == null || entity.CardBinaryData.Length != 32)
                    //    entity.CardBinaryData= mgr.Entity.CardBinaryData;

                    if (entity.BitCount == 0)
                        entity.BitCount = mgr.Entity.BitCount;

                    mgr.InitEntityObject(entity);
                    //int rowsUpdated = mgr.DataObject.Update();
                    //if (rowsUpdated > 0)
                    int rowsUpdated = 0;
                    rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.CredentialUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        updatedEntity = GetEntityByGuidId(entity.CredentialUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = true });
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.CredentialUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MagicExceptionStrings.no_rows_updated, StringComparison.OrdinalIgnoreCase) && entity.IndexValue != -1)
                {
                    DataValidationException dve = null;
                    if ( string.IsNullOrEmpty(entity.MyPropertyName))
                        dve = new DataValidationException(new ValidationRule($"{entity.OwnerPropertyName}[{entity.IndexValue}].{nameof(entity.ConcurrencyValue)}", Resources.Resources.ExceptionMessage_ConcurrencyValueWrong));
                    else
                        dve = new DataValidationException(new ValidationRule($"{entity.OwnerPropertyName}[{entity.IndexValue}].{entity.MyPropertyName}.{nameof(entity.ConcurrencyValue)}", Resources.Resources.ExceptionMessage_ConcurrencyValueWrong));
                    throw dve;
                }
                else
                {
                    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                    throw;
                }
            }

            //catch (Exception ex)
            //{
            //    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialRepository::UpdateEntity", ex);
            //    throw;
            //}
        }

        protected override int DeleteEntity(Credential entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {

                _credential26BitStandardRepository.Remove(entity.CredentialUid, sessionData);
                _credentialCorporate1K48BitRepository.Remove(entity.CredentialUid, sessionData);
                _credentialCorporate1K35BitRepository.Remove(entity.CredentialUid, sessionData);
                _credentialXceedId40BitRepository.Remove(entity.CredentialUid, sessionData);
                _credentialPIV75BitRepository.Remove(entity.CredentialUid, sessionData);
                _credentialH1030437BitRepository.Remove(entity.CredentialUid, sessionData);
                _credentialH1030237BitRepository.Remove(entity.CredentialUid, sessionData);
                _credentialCypress37BitRepository.Remove(entity.CredentialUid, sessionData);
                _credentialSoftwareHouse37BitRepository.Remove(entity.CredentialUid, sessionData);
                _credentialBqt36BitRepository.Remove(entity.CredentialUid, sessionData);
                _credentialDataRepository.Remove(entity.CredentialUid, sessionData);

                var mgr = new CredentialPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.CredentialUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                _credential26BitStandardRepository.Remove(id, sessionData);
                _credentialCorporate1K48BitRepository.Remove(id, sessionData);
                _credentialCorporate1K35BitRepository.Remove(id, sessionData);
                _credentialXceedId40BitRepository.Remove(id, sessionData);
                _credentialPIV75BitRepository.Remove(id, sessionData);
                _credentialH1030437BitRepository.Remove(id, sessionData);
                _credentialH1030237BitRepository.Remove(id, sessionData);
                _credentialCypress37BitRepository.Remove(id, sessionData);
                _credentialSoftwareHouse37BitRepository.Remove(id, sessionData);
                _credentialBqt36BitRepository.Remove(id, sessionData);
                _credentialDataRepository.Remove(id, sessionData);

                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new CredentialPDSAManager();

                // PDSA Audit Tracking setup phase
                int rowsDeleted = 0;
                int rowsLoaded = mgr.DataObject.LoadByPK(id); // must read the original record from the database so the PDSA object can detect changes
                if (rowsLoaded == 1 && originalEntity != null)
                {
                    rowsDeleted = mgr.DataObject.DeleteByPK(id);
                    if (rowsDeleted > 0)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Delete, sessionData, originalEntity, null, mgr.DataObject.AuditRowAsXml);
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialRepository::Remove", ex);
                throw;
            }
        }

        // GetAllCredentials
        protected override IEnumerable<Credential> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new CredentialPDSAManager();
                mgr.DataObject.SelectFilter = CredentialPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<Credential> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, CredentialPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (Credential entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<Credential> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new CredentialPDSAManager();
                mgr.DataObject.SelectFilter = CredentialPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<Credential> GetByCredentialValues(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<Credential> getParameters)
        {
            try
            {
                var mgr = new CredentialPDSAManager();
                if (getParameters.Data.Standard26Bit != null)
                {
                    mgr.DataObject.SelectFilter = CredentialPDSAData.SelectFilters.By26BitWiegandCodes;
                    mgr.Entity.FacilityCode = getParameters.Data.Standard26Bit.FacilityCode;
                    mgr.Entity.IdCode = getParameters.Data.Standard26Bit.IdCode;
                }
                else if (getParameters.Data.Bqt36Bit != null)
                {
                    mgr.DataObject.SelectFilter = CredentialPDSAData.SelectFilters.ByBqt36BitCodes;
                    mgr.Entity.FacilityCode = getParameters.Data.Bqt36Bit.FacilityCode;
                    mgr.Entity.IdCode = getParameters.Data.Bqt36Bit.IdCode;
                }
                else if (getParameters.Data.Corporate1K35Bit != null)
                {
                    mgr.DataObject.SelectFilter = CredentialPDSAData.SelectFilters.ByCorporate1K35BitCodes;
                    mgr.Entity.CompanyCode = getParameters.Data.Corporate1K35Bit.CompanyCode;
                    mgr.Entity.IdCode = getParameters.Data.Corporate1K35Bit.IdCode;
                }
                else if (getParameters.Data.Corporate1K48Bit != null)
                {
                    mgr.DataObject.SelectFilter = CredentialPDSAData.SelectFilters.ByCorporate1K48BitCodes;
                    mgr.Entity.CompanyCode = getParameters.Data.Corporate1K48Bit.CompanyCode;
                    mgr.Entity.IdCode = getParameters.Data.Corporate1K48Bit.IdCode;
                }
                else if (getParameters.Data.Cypress37Bit != null)
                {
                    mgr.DataObject.SelectFilter = CredentialPDSAData.SelectFilters.ByCypress37BitCodes;
                    mgr.Entity.FacilityCode = getParameters.Data.Cypress37Bit.FacilityCode;
                    mgr.Entity.IdCode = getParameters.Data.Cypress37Bit.IdCode;
                }
                else if (getParameters.Data.CredentialData != null)
                {
                    mgr.DataObject.SelectFilter = CredentialPDSAData.SelectFilters.ByCredentialDataNumbers;
                    mgr.Entity.Number1 = (int)getParameters.Data.CredentialData.Number1;
                    if (getParameters.Data.CredentialData.Number2.HasValue)
                        mgr.Entity.Number2 = (int)getParameters.Data.CredentialData.Number2.Value;
                    if (getParameters.Data.CredentialData.Number3.HasValue)
                        mgr.Entity.Number3 = (int)getParameters.Data.CredentialData.Number3.Value;
                    if (getParameters.Data.CredentialData.Number4.HasValue)
                        mgr.Entity.Number4 = (int)getParameters.Data.CredentialData.Number4.Value;
                    if (getParameters.Data.CredentialData.Number5.HasValue)
                        mgr.Entity.Number5 = (int)getParameters.Data.CredentialData.Number5.Value;
                }
                else if (getParameters.Data.H1030437Bit != null)
                {
                    mgr.DataObject.SelectFilter = CredentialPDSAData.SelectFilters.ByH1030437BitCodes;
                    mgr.Entity.FacilityCode = getParameters.Data.H1030437Bit.FacilityCode;
                    mgr.Entity.IdCode = getParameters.Data.H1030437Bit.IdCode;
                }
                else if (getParameters.Data.PIV75Bit != null)
                {
                    mgr.DataObject.SelectFilter = CredentialPDSAData.SelectFilters.ByPiv75BitCodes;
                    mgr.Entity.AgencyCode = getParameters.Data.PIV75Bit.AgencyCode;
                    mgr.Entity.SiteCode = getParameters.Data.PIV75Bit.SiteCode;
                    mgr.Entity.CredentialCode = getParameters.Data.PIV75Bit.CredentialCode;
                }
                else if (getParameters.Data.XceedId40Bit != null)
                {
                    mgr.DataObject.SelectFilter = CredentialPDSAData.SelectFilters.ByXceed40BitCodes;
                    mgr.Entity.SiteCode = getParameters.Data.XceedId40Bit.SiteCode;
                    mgr.Entity.IdCode = getParameters.Data.XceedId40Bit.IdCode;
                }
                else if (!string.IsNullOrEmpty(getParameters.Data.CardNumber))
                {
                    mgr.DataObject.SelectFilter = CredentialPDSAData.SelectFilters.ByCardNumber;
                    mgr.Entity.CardNumber = getParameters.Data.CardNumber;
                }
                else if (getParameters.Data.CardBinaryData != null)
                {
                    mgr.DataObject.SelectFilter = CredentialPDSAData.SelectFilters.ByCardBinaryData;
                    mgr.Entity.CardBinaryData = getParameters.Data.CardBinaryData;
                }
                return GetIEnumerable(sessionData, new GetParametersWithPhoto(getParameters), mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialRepository::GetEntities", ex);
                throw;
            }
        }

        protected override Credential GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override Credential GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new CredentialPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    Credential result = new Credential();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(result, sessionData, getParameters);
                    return result;
                }
                return null;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        public Credential_ActivityEventData GetActivityEventData(byte[] credentialBinaryData)
        {
            try
            {
                var mgr = new Credential_GetActivityEventDataPDSAManager();
                if (credentialBinaryData?.Length < GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Extended256Bits)
                    credentialBinaryData = HexEncoding.PadByteArray(credentialBinaryData, GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Extended256Bits, false);
                mgr.Entity.CardBinaryData = credentialBinaryData;
                var result = mgr.BuildCollection();
                if (result != null && result.Count >= 1)
                {
                    var returnData = new Credential_ActivityEventData();
                    SimpleMapper.PropertyMap(result[0], returnData);
                    return returnData;
                }
                return null;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialRepository::GetActivityEventData", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, Credential originalEntity, Credential newEntity, string auditXml)
        {
            try
            {
                if (!string.IsNullOrEmpty(auditXml))
                    auditXml = auditXml.EncodeForXml();
                var mgr = new gcsAudit_InsertPDSAManager();

                switch (operationType)
                {
                    case OperationType.Update:
                        if (newEntity == null)
                            throw new ArgumentNullException("newEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        List<String> propertiesToIgnore = new List<string>();
                        propertiesToIgnore.Add("UpdateDate");
                        propertiesToIgnore.Add("UpdateName");
                        propertiesToIgnore.Add("ConcurrencyValue");
                        propertiesToIgnore.Add("Credential26BitStandard");
                        propertiesToIgnore.Add("CredentialFormat");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "CredentialUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.CredentialUid;
                        mgr.Entity.RecordTag = newEntity.CredentialUid.ToString();
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;

                        if (string.IsNullOrEmpty(auditXml) == false)
                        {
                            mgr.Entity.AuditXml = auditXml;
                            mgr.Execute();
                        }


                        mgr.Entity.AuditXml = null;

                        SimpleObjectDifferenceDetector.CompareResults differences = SimpleObjectDifferenceDetector.CompareObjects(originalEntity, newEntity, propertiesToIgnore);
                        foreach (var property in differences.PropertyChanges)
                        {
                            //System.Diagnostics.Trace.WriteLine(property.ToString());
                            mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                            mgr.Entity.ColumnName = property.Value.PropertyName;
                            if (property.Value.PropertyType == typeof(System.Byte[]))
                            {
                                mgr.Entity.OriginalValue = null;
                                mgr.Entity.NewValue = null;
                                mgr.Entity.OriginalBinaryValue = property.Value.OriginalValue as byte[];
                                mgr.Entity.NewBinaryValue = property.Value.NewValue as byte[];
                            }
                            else
                            {
                                mgr.Entity.OriginalValue = property.Value.OriginalValue?.ToString();
                                mgr.Entity.NewValue = property.Value.NewValue?.ToString();
                                mgr.Entity.OriginalBinaryValue = null;
                                mgr.Entity.NewBinaryValue = null;
                            }
                            mgr.Execute();
                        }
                        break;

                    case OperationType.Insert:
                        if (newEntity == null)
                            throw new ArgumentNullException("newEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "CredentialUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.CredentialUid;
                        mgr.Entity.RecordTag = newEntity.CredentialUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;

                    case OperationType.Delete:
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "CredentialUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.CredentialUid;
                        mgr.Entity.RecordTag = originalEntity.CredentialUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(Credential entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
            var p = new GetParametersWithPhoto(getParameters);
            p.IncludeMemberCollections = false;
            entity.CredentialFormat = _credentialFormatRepository.Get(entity.CredentialFormatUid, sessionData, p);
            if (entity.CredentialFormat != null)
            {
                switch (entity.CredentialFormat.CredentialFormatCode)
                {
                    case Common.Enums.CredentialFormatCodes.NumericCardCode:
                    case Common.Enums.CredentialFormatCodes.MagneticStripeBarcodeAba:
                    case Common.Enums.CredentialFormatCodes.GalaxyKeypad:
                    case Common.Enums.CredentialFormatCodes.USGovernmentID:
                    case CredentialFormatCodes.BasIpQr:
                    case CredentialFormatCodes.BtFarpointeConektMobile:
                    case CredentialFormatCodes.BtHidMobileAccess:
                    case CredentialFormatCodes.BtStidMobileId:
                    case CredentialFormatCodes.BtAllegion:
                    case CredentialFormatCodes.BtBasIp:
                        break;
                    case Common.Enums.CredentialFormatCodes.Standard26Bit:
                        entity.Standard26Bit = _credential26BitStandardRepository.Get(entity.CredentialUid, sessionData, p);
                        break;
                    case Common.Enums.CredentialFormatCodes.Corporate1K35Bit:
                        entity.Corporate1K35Bit = _credentialCorporate1K35BitRepository.Get(entity.CredentialUid, sessionData, p);
                        break;
                    case Common.Enums.CredentialFormatCodes.Corporate1K48Bit:
                        entity.Corporate1K48Bit = _credentialCorporate1K48BitRepository.Get(entity.CredentialUid, sessionData, p);
                        break;
                    case Common.Enums.CredentialFormatCodes.Bqt36Bit:
                        entity.Bqt36Bit = _credentialBqt36BitRepository.Get(entity.CredentialUid, sessionData, p);
                        break;
                    case Common.Enums.CredentialFormatCodes.XceedId40Bit:
                        entity.XceedId40Bit = _credentialXceedId40BitRepository.Get(entity.CredentialUid, sessionData, p);
                        break;
                    case Common.Enums.CredentialFormatCodes.Cypress37Bit:
                        entity.Cypress37Bit = _credentialCypress37BitRepository.Get(entity.CredentialUid, sessionData, p);
                        break;
                    case Common.Enums.CredentialFormatCodes.H1030437Bit:
                        entity.H1030437Bit = _credentialH1030437BitRepository.Get(entity.CredentialUid, sessionData, p);
                        break;
                    case Common.Enums.CredentialFormatCodes.H1030237Bit:
                        entity.H1030237Bit = _credentialH1030237BitRepository.Get(entity.CredentialUid, sessionData, p);
                        break;
                    case Common.Enums.CredentialFormatCodes.SoftwareHouse37Bit:
                        entity.SoftwareHouse37Bit = _credentialSoftwareHouse37BitRepository.Get(entity.CredentialUid, sessionData, p);
                        break;
                    default:
                        entity.CredentialData = _credentialDataRepository.Get(entity.CredentialUid, sessionData, p);
                        break;
                }

            }
        }

        private void EnsureChildRecordsExist(Credential entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {

            switch (entity.CredentialFormat.CredentialFormatCode)
            {
                case Common.Enums.CredentialFormatCodes.NumericCardCode:
                case Common.Enums.CredentialFormatCodes.MagneticStripeBarcodeAba:
                case Common.Enums.CredentialFormatCodes.GalaxyKeypad:
                case Common.Enums.CredentialFormatCodes.USGovernmentID:
                case CredentialFormatCodes.BasIpQr:
                case CredentialFormatCodes.BtFarpointeConektMobile:
                case CredentialFormatCodes.BtHidMobileAccess:
                case CredentialFormatCodes.BtStidMobileId:
                case CredentialFormatCodes.BtAllegion:
                case CredentialFormatCodes.BtBasIp:
                    _credentialDataRepository.Remove(entity.CredentialUid, sessionData);
                    break;

                case Common.Enums.CredentialFormatCodes.Standard26Bit:
                    entity.Standard26Bit.CredentialUid = entity.CredentialUid;
                    //entity.Standard26Bit.IndexValue = entity.IndexValue;
                    entity.Standard26Bit.OwnerPropertyName = $"{entity.OwnerPropertyName}[{entity.IndexValue}].{entity.MyPropertyName}";
                    entity.Standard26Bit.MyPropertyName = nameof(entity.Standard26Bit);
                    entity.Standard26Bit = _credential26BitStandardRepository.Save(entity.Standard26Bit, sessionData, saveParams);
                    _credentialDataRepository.Remove(entity.CredentialUid, sessionData);
                    break;
                case Common.Enums.CredentialFormatCodes.Corporate1K35Bit:
                    entity.Corporate1K35Bit.CredentialUid = entity.CredentialUid;
                    entity.Corporate1K35Bit.OwnerPropertyName = $"{entity.OwnerPropertyName}[{entity.IndexValue}].{entity.MyPropertyName}";
                    entity.Corporate1K35Bit.MyPropertyName = nameof(entity.Corporate1K35Bit);
                    entity.Corporate1K35Bit = _credentialCorporate1K35BitRepository.Save(entity.Corporate1K35Bit, sessionData, saveParams);
                    _credentialDataRepository.Remove(entity.CredentialUid, sessionData);
                    break;
                case Common.Enums.CredentialFormatCodes.Corporate1K48Bit:
                    entity.Corporate1K48Bit.CredentialUid = entity.CredentialUid;
                    entity.Corporate1K48Bit.OwnerPropertyName = $"{entity.OwnerPropertyName}[{entity.IndexValue}].{entity.MyPropertyName}";
                    entity.Corporate1K48Bit.MyPropertyName = nameof(entity.Corporate1K48Bit);
                    entity.Corporate1K48Bit = _credentialCorporate1K48BitRepository.Save(entity.Corporate1K48Bit, sessionData, saveParams);
                    _credentialDataRepository.Remove(entity.CredentialUid, sessionData);
                    break;
                case Common.Enums.CredentialFormatCodes.Bqt36Bit:
                    entity.Bqt36Bit.CredentialUid = entity.CredentialUid;
                    entity.Bqt36Bit.OwnerPropertyName = $"{entity.OwnerPropertyName}[{entity.IndexValue}].{entity.MyPropertyName}";
                    entity.Bqt36Bit.MyPropertyName = nameof(entity.Bqt36Bit);
                    entity.Bqt36Bit = _credentialBqt36BitRepository.Save(entity.Bqt36Bit, sessionData, saveParams);
                    _credentialDataRepository.Remove(entity.CredentialUid, sessionData);
                    break;
                case Common.Enums.CredentialFormatCodes.XceedId40Bit:
                    entity.XceedId40Bit.CredentialUid = entity.CredentialUid;
                    entity.XceedId40Bit.OwnerPropertyName = $"{entity.OwnerPropertyName}[{entity.IndexValue}].{entity.MyPropertyName}";
                    entity.XceedId40Bit.MyPropertyName = nameof(entity.XceedId40Bit);
                    entity.XceedId40Bit = _credentialXceedId40BitRepository.Save(entity.XceedId40Bit, sessionData, saveParams);
                    _credentialDataRepository.Remove(entity.CredentialUid, sessionData);
                    break;
                case Common.Enums.CredentialFormatCodes.Cypress37Bit:
                    entity.Cypress37Bit.CredentialUid = entity.CredentialUid;
                    entity.Cypress37Bit.OwnerPropertyName = $"{entity.OwnerPropertyName}[{entity.IndexValue}].{entity.MyPropertyName}";
                    entity.Cypress37Bit.MyPropertyName = nameof(entity.Cypress37Bit);
                    entity.Cypress37Bit = _credentialCypress37BitRepository.Save(entity.Cypress37Bit, sessionData, saveParams);
                    _credentialDataRepository.Remove(entity.CredentialUid, sessionData);
                    break;
                case Common.Enums.CredentialFormatCodes.H1030437Bit:
                    entity.H1030437Bit.CredentialUid = entity.CredentialUid;
                    entity.H1030437Bit.OwnerPropertyName = $"{entity.OwnerPropertyName}[{entity.IndexValue}].{entity.MyPropertyName}";
                    entity.H1030437Bit.MyPropertyName = nameof(entity.H1030437Bit);
                    entity.H1030437Bit = _credentialH1030437BitRepository.Save(entity.H1030437Bit, sessionData, saveParams);
                    _credentialDataRepository.Remove(entity.CredentialUid, sessionData);
                    break;
                case Common.Enums.CredentialFormatCodes.H1030237Bit:
                    entity.H1030237Bit.CredentialUid = entity.CredentialUid;
                    entity.H1030237Bit.OwnerPropertyName = $"{entity.OwnerPropertyName}[{entity.IndexValue}].{entity.MyPropertyName}";
                    entity.H1030237Bit.MyPropertyName = nameof(entity.H1030237Bit);
                    entity.H1030237Bit = _credentialH1030237BitRepository.Save(entity.H1030237Bit, sessionData, saveParams);
                    _credentialDataRepository.Remove(entity.CredentialUid, sessionData);
                    break;
                case Common.Enums.CredentialFormatCodes.SoftwareHouse37Bit:
                    entity.SoftwareHouse37Bit.CredentialUid = entity.CredentialUid;
                    entity.SoftwareHouse37Bit.OwnerPropertyName = $"{entity.OwnerPropertyName}[{entity.IndexValue}].{entity.MyPropertyName}";
                    entity.SoftwareHouse37Bit.MyPropertyName = nameof(entity.SoftwareHouse37Bit);
                    entity.SoftwareHouse37Bit = _credentialSoftwareHouse37BitRepository.Save(entity.SoftwareHouse37Bit, sessionData, saveParams);
                    _credentialDataRepository.Remove(entity.CredentialUid, sessionData);
                    break;
                default:
                    entity.CredentialData.CredentialUid = entity.CredentialUid;
                    entity.CredentialData.OwnerPropertyName = $"{entity.OwnerPropertyName}[{entity.IndexValue}].{entity.MyPropertyName}";
                    entity.CredentialData.MyPropertyName = nameof(entity.CredentialData);
                    entity.CredentialData = _credentialDataRepository.Save(entity.CredentialData, sessionData, saveParams);
                    break;
            }

            if (entity.CredentialFormat.CredentialFormatCode != Common.Enums.CredentialFormatCodes.Standard26Bit)
                _credential26BitStandardRepository.Remove(entity.CredentialUid, sessionData);
            if (entity.CredentialFormat.CredentialFormatCode != Common.Enums.CredentialFormatCodes.Corporate1K35Bit)
                _credentialCorporate1K35BitRepository.Remove(entity.CredentialUid, sessionData);
            if (entity.CredentialFormat.CredentialFormatCode != Common.Enums.CredentialFormatCodes.Corporate1K48Bit)
                _credentialCorporate1K48BitRepository.Remove(entity.CredentialUid, sessionData);
            if (entity.CredentialFormat.CredentialFormatCode != Common.Enums.CredentialFormatCodes.Bqt36Bit)
                _credentialBqt36BitRepository.Remove(entity.CredentialUid, sessionData);
            if (entity.CredentialFormat.CredentialFormatCode != Common.Enums.CredentialFormatCodes.XceedId40Bit)
                _credentialXceedId40BitRepository.Remove(entity.CredentialUid, sessionData);
            if (entity.CredentialFormat.CredentialFormatCode != Common.Enums.CredentialFormatCodes.Cypress37Bit)
                _credentialCypress37BitRepository.Remove(entity.CredentialUid, sessionData);
            if (entity.CredentialFormat.CredentialFormatCode != Common.Enums.CredentialFormatCodes.H1030437Bit)
                _credentialH1030437BitRepository.Remove(entity.CredentialUid, sessionData);
            if (entity.CredentialFormat.CredentialFormatCode != Common.Enums.CredentialFormatCodes.H1030237Bit)
                _credentialH1030237BitRepository.Remove(entity.CredentialUid, sessionData);
            if (entity.CredentialFormat.CredentialFormatCode != Common.Enums.CredentialFormatCodes.SoftwareHouse37Bit)
                _credentialSoftwareHouse37BitRepository.Remove(entity.CredentialUid, sessionData);
        }


        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("Credential", "CredentialUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("Credential", "CredentialUid", id);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool IsEntityReferenced(int id)
        {
            return false;
        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(Credential entity)
        {
            var mgr = new IsCredentialUniquePDSAManager();
            mgr.Entity.CredentialUid = entity.CredentialUid;
            mgr.Entity.CardBinaryData = entity.CardBinaryData;
            mgr.Entity.CardNumber = entity.CardNumber;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("Credential", "CredentialUid", id);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool DoesEntityExist(int id)
        {
            return false;
        }

        protected override bool CanEntityBeDeleted(Guid id)
        {
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("Credential", "CredentialUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}
