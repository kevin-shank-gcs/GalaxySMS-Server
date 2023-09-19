////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Extensions\MefExtensions.cs
//
// summary:	Implements the MEF extensions class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

namespace GCS.Core.Common.Extensions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A MEF extensions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class MefExtensions
    {
        /// <summary>   The container. </summary>
        public static CompositionContainer Container;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A CompositionContainer extension method that gets exported value by type. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="container">    The container to act on. </param>
        /// <param name="type">         The type. </param>
        ///
        /// <returns>   The exported value by type. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static object GetExportedValueByType(this CompositionContainer container, Type type)
        {
            foreach (var PartDef in container.Catalog.Parts)
            {
                foreach (var ExportDef in PartDef.ExportDefinitions)
                {
                    if (ExportDef.ContractName == type.FullName)
                    {
                        var contract = AttributedModelServices.GetContractName(type);
                        var definition = new ContractBasedImportDefinition(contract, contract, null, ImportCardinality.ExactlyOne,
                                                                           false, false, CreationPolicy.Any);
                        return container.GetExports(definition).FirstOrDefault().Value;
                    }
                }
            }

            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the exported values by types in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="container">    The container to act on. </param>
        /// <param name="type">         The type. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process the exported values by types in this
        /// collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<object> GetExportedValuesByType(this CompositionContainer container, Type type)
        {
            foreach (var PartDef in container.Catalog.Parts)
            {
                foreach (var ExportDef in PartDef.ExportDefinitions)
                {
                    if (ExportDef.ContractName == type.FullName)
                    {
                        var contract = AttributedModelServices.GetContractName(type);
                        var definition = new ContractBasedImportDefinition(contract, contract, null, ImportCardinality.ExactlyOne,
                                                                           false, false, CreationPolicy.Any);
                        return container.GetExports(definition);
                    }
                }
            }

            return new List<object>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A CompositionContainer extension method that gets exported value. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="container">    The container to act on. </param>
        /// <param name="predicate">    The predicate. </param>
        ///
        /// <returns>   The exported value. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static T GetExportedValue<T>(this CompositionContainer container,
            Func<IDictionary<string, object>, bool> predicate)
        {
            foreach (var PartDef in container.Catalog.Parts)
            {
                foreach (var ExportDef in PartDef.ExportDefinitions)
                {
                    if (ExportDef.ContractName == typeof(T).FullName)
                    {
                        if (predicate(ExportDef.Metadata))
                            return (T)PartDef.CreatePart().GetExportedValue(ExportDef);
                    }
                }
            }
            return default(T);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// A CompositionContainer extension method that gets exported value by type.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="container">    The container to act on. </param>
        /// <param name="type">         The type. </param>
        ///
        /// <returns>   The exported value by type. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static T GetExportedValueByType<T>(this CompositionContainer container, string type)
        {
            foreach (var PartDef in container.Catalog.Parts)
            {
                foreach (var ExportDef in PartDef.ExportDefinitions)
                {
                    if (ExportDef.ContractName == type)
                        return (T)PartDef.CreatePart().GetExportedValue(ExportDef);
                }
            }
            return default(T);
        }
    }
}
