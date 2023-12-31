//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Business.Entities
{
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    public partial class OutputDevice : EntityBase, IIdentifiableEntity, IEquatable<OutputDevice>, ITableEntityBase, IHasBinaryResource, IHasEntityMappingList
    {

        public System.Guid OutputDeviceUid { get; set; }
    	public Nullable<System.Guid> BinaryResourceUid { get; set; }
    	public System.Guid EntityId { get; set; }
    	public System.Guid SiteUid { get; set; }
    	public string OutputName { get; set; }
    	public string Location { get; set; }
    	public string ServiceComment { get; set; }
    	public string CriticalityComment { get; set; }
    	public string Comment { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    	public bool IsTemplate { get; set; }
    
    	public gcsBinaryResource gcsBinaryResource { get; set; }
    	public OutputDeviceGalaxyHardwareAddress GalaxyHardwareAddress { get; set; }
          public string Name
        {
            get { return OutputName; }

            set { OutputName = value; }
        }
        public string RegionName { get; set; }
        public string SiteName { get; set; }

        public ICollection<Guid> EntityIds { get; set; }
        public ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels { get; set; }
    }
}
