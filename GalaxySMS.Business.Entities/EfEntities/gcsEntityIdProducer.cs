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
    public partial class gcsEntityIdProducer : EntityBase, IIdentifiableEntity, IEquatable<gcsEntityIdProducer>, ITableEntityBase
    {
    	public System.Guid EntityId { get; set; }
    	public string Url { get; set; }
    	public string DevUrl { get; set; }
    	public string WebClientUrl { get; set; }
    	public int SubscriptionId { get; set; }
    	public string idProducerUserName { get; set; }
    	public string idProducerPassword { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    }
}
