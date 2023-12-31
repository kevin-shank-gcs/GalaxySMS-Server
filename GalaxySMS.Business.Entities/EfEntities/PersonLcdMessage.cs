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
    public partial class PersonLcdMessage : EntityBase, IIdentifiableEntity, IEquatable<PersonLcdMessage>, ITableEntityBase
    {
    	public System.Guid PersonLcdMessageUid { get; set; }
    	public System.Guid PersonLcdMessageDisplayModeUid { get; set; }
    	public System.Guid PersonUid { get; set; }
    	public string Message { get; set; }
    	public Nullable<System.DateTimeOffset> StartingDate { get; set; }
    	public Nullable<System.DateTimeOffset> EndingDate { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
//    	public Person Person { get; set; }
    
    }
}
