using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Data.Support
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class AuditRecord
    {

        private AuditRecordColumn[] columnField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Column")]
        public AuditRecordColumn[] Column
        {
            get
            {
                return this.columnField;
            }
            set
            {
                this.columnField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AuditRecordColumn
    {

        private string nameField;

        private string insertedValueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string insertedValue
        {
            get
            {
                return this.insertedValueField;
            }
            set
            {
                this.insertedValueField = value;
            }
        }
    }


}
