using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using GalaxySMS.Data.Contracts;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Logger;

namespace GalaxySMS.Data
{
    [Export(typeof(IDataRepositoryFactory))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        T IDataRepositoryFactory.GetDataRepository<T>()
        {
            IEnumerable<T> ret = null;
            try
            {
                //                return ObjectBase.Container.GetExportedValue<T>();
                //var t = typeof(T);
                //if(t == typeof(IGalaxyInterfaceBoardRepository))
                //        this.Log().Info($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: type T:{typeof(T)}");//
                //this.Log().Info($"StaticObjects.Container.GetExportedValue<{t}>");
                //if (StaticObjects.Container?.Catalog?.Parts?.FirstOrDefault(o => o.ExportDefinitions.) == null)
                //    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: type T:{typeof(T)} StaticObjects.Container == null");//IDataRepositoryFactory.GetDataRepository", e);


                //var ret = StaticObjects.Container.GetExportedValue<T>();
                // return ret;
                ret = StaticObjects.Container.GetExportedValues<T>();

                if (ret.Count() > 1)
                    this.Log().Info($"StaticObjects.Container.GetExportedValues returned {ret.Count()} items.");

                return ret.FirstOrDefault();
            }
            catch (NullReferenceException ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: type T:{typeof(T)} {ex.ToString()}. StaticObjects.Container.Catalog count: {StaticObjects.Container.Catalog.Parts.Count()}");//IDataRepositoryFactory.GetDataRepository", e);
                throw;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: type T:{typeof(T)} {ex.ToString()}. StaticObjects.Container.Catalog count: {StaticObjects.Container.Catalog.Parts.Count()}");//IDataRepositoryFactory.GetDataRepository", e);
                throw;
            }
        }

        T IDataRepositoryFactory.GetDataInsertRepository<T>()
        {
            try
            {
                //return ObjectBase.Container.GetExportedValue<T>();
                return StaticObjects.Container.GetExportedValue<T>();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//IDataRepositoryFactory.GetDataInsertRepository", e);
                throw;
            }
        }

        T IDataRepositoryFactory.GetRepository<T>()
        {
            try
            {
                //return ObjectBase.Container.GetExportedValue<T>();
                return StaticObjects.Container.GetExportedValue<T>();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//IDataRepositoryFactory.GetDataInsertRepository", e);
                throw;
            }
        }
    }
}
