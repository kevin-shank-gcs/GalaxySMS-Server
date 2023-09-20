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
    public partial class PersonAccessControlProperty : EntityBase, IIdentifiableEntity, IEquatable<PersonAccessControlProperty>, ITableEntityBase
    {
        public System.Guid PersonUid { get; set; }
        public System.Guid AccessProfileUid { get; set; }
    	public bool PINExempt { get; set; }
    	public bool PassbackExempt { get; set; }
    	public bool CanToggleLockState { get; set; }
    	public bool IsActive { get; set; }
    	public Nullable<int> PIN { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	//public Person Person { get; set; }
    
    }
}
