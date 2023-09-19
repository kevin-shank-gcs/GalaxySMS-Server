using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KellermanSoftware.CompareNetObjects;

namespace GCS.Core.Common.Shared.Utils
{
    public static class ObjectComparer
    {
        public static bool AreAnyPublicPropertiesDifferent<T, TU>(T a, TU b, IEnumerable<string> membersToInclude = null, IEnumerable<string> membersToIgnore = null)
        {
            if( a == null && b == null )
                return false;
            if( a == null )
                return true;
            if( b == null )
                return true;
            var config = new ComparisonConfig()
            {
                IgnoreObjectTypes = true,
            };

            config.MembersToIgnore.Add("IndexValue");
            config.MembersToIgnore.Add("IsDirty");
            config.MembersToIgnore.Add("IsAnythingDirty");
            config.MembersToIgnore.Add("IsPanelDataDirty");
            config.MembersToIgnore.Add("InsertName");
            config.MembersToIgnore.Add("InsertDate");
            config.MembersToIgnore.Add("UpdateName");
            config.MembersToIgnore.Add("UpdateDate");
            config.MembersToIgnore.Add("ConcurrencyValue");
            config.MembersToIgnore.Add("OwnerPropertyName");
            config.MembersToIgnore.Add("MyPropertyName");
            config.MembersToIgnore.Add("ExtensionData");

            if (membersToIgnore != null && membersToIgnore.Any())
                config.MembersToIgnore.AddRange(membersToIgnore);

            if (membersToInclude != null && membersToInclude.Any())
                config.MembersToInclude.AddRange(membersToInclude);
            //This is the comparison class
            var compareLogic = new CompareLogic(config);

            var result = compareLogic.Compare(a, b);

            return !result.AreEqual;
            //These will be different, write out the differences
            if (!result.AreEqual)
                Console.WriteLine(result.DifferencesString);
        }

        public static IEnumerable<Difference> GetPublicPropertyDifferences<T, TU>(T a, TU b, IEnumerable<string> membersToInclude = null, IEnumerable<string> membersToIgnore = null)
        {
            var config = new ComparisonConfig()
            {
                IgnoreObjectTypes = true,
            };
            //This is the comparison class
            var compareLogic = new CompareLogic(config);

            if (membersToIgnore != null && membersToIgnore.Any())
                config.MembersToIgnore.AddRange(membersToIgnore);

            if (membersToInclude != null && membersToInclude.Any())
                config.MembersToInclude.AddRange(membersToInclude);

            var result = compareLogic.Compare(a, b);

            return result.Differences;
            //These will be different, write out the differences
            if (!result.AreEqual)
                Console.WriteLine(result.DifferencesString);
        }

        public static bool AreByteArraysEqual(byte[] ba1, byte[] ba2)
        {
            return System.Collections.StructuralComparisons.StructuralEqualityComparer.Equals(ba1, ba2);
        }
    }
}
