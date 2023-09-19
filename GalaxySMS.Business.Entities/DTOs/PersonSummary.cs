using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{      
    public class PersonSummary
    {
    	public System.Guid PersonUid { get; set; }
    	public string PersonId { get; set; }
    	public string FirstName { get; set; }
    	public string MiddleName { get; set; }
    	public string LastName { get; set; }
    	public string NickName { get; set; }
    	public string LegalName { get; set; }
    	public string FullName { get; set; }
    	public string PreferredName { get; set; }
    	public string Company { get; set; }
    	public bool Trace { get; set; }
    	public bool VeryImportantPerson { get; set; }
    	public bool HasPhysicalDisability { get; set; }
        public string EntityName { get; set; }
        public Guid EntityId { get; set; }
        public string DepartmentName { get; set; }
        public string ActiveStatus { get; set; }
        public string RecordType { get; set; }
    	public Nullable<System.DateTimeOffset> ActivationDateTime { get; set; }
    	public Nullable<System.DateTimeOffset> ExpirationDateTime { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public PersonPhoto Photo { get; set; }
    }
}
