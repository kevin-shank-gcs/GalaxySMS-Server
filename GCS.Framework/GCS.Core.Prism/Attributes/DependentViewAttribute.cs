using System;

namespace GCS.Core.Prism
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependentViewAttribute : Attribute
    {
        public DependentViewAttribute(Type viewType, string targetRegionName)
        {
            ViewType = viewType;
            TargetRegionName = targetRegionName;
        }

        public Type ViewType { get; set; }
        public string TargetRegionName { get; set; }
    }
}