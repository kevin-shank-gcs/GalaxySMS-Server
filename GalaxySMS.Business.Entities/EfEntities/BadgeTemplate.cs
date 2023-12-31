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
    public partial class BadgeTemplate : EntityBase, IIdentifiableEntity, IEquatable<BadgeTemplate>, ITableEntityBase, IHasEntityMappingList
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class BadgeTemplate
        {
        	public BadgeTemplate()
        	{
        		Initialize();
        	}
        
        	public BadgeTemplate(BadgeTemplate e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(BadgeTemplate e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.BadgeTemplateUid = e.BadgeTemplateUid;
        		this.EntityId = e.EntityId;
        		this.TemplateName = e.TemplateName;
        		this.Description = e.Description;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.TemplateId = e.TemplateId;
        		
        	}
        
        	public bool IsAnythingDirty
        	{
        		get
        		{
        			//foreach( var o in InterfaceBoardSections)
        			//{
        			//	if (o.IsAnythingDirty == true)
        			//		return true;
        			//}
        			return IsDirty;                
        		}
        	}
        
        	public BadgeTemplate Clone(BadgeTemplate e)
        	{
        		return new BadgeTemplate(e);
        	}
        
        	public bool Equals(BadgeTemplate other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(BadgeTemplate other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.BadgeTemplateUid != this.BadgeTemplateUid )
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
    	public System.Guid BadgeTemplateUid { get; set; }
    	public System.Guid EntityId { get; set; }
        public Guid BadgeSystemTypeUid { get; set; }
        public string TemplateName { get; set; }
    	public string Description { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    	public string TemplateId { get; set; }
    
    	public gcsEntity gcsEntity { get; set; }
        public ICollection<Guid> EntityIds { get; set; }
        public ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels { get; set; }

    }
}
