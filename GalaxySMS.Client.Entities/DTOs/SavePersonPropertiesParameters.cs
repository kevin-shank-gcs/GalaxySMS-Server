using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class PropertyValue<T>
    {
        [DataMember]
        public string PropertyName { get; set; }

        [DataMember]
        public T Value { get; set; }
    }


    [DataContract]
    public class ObjectProperties
    {
        public ObjectProperties()
        {
            Uid = Guid.Empty;
            TextProperties = new HashSet<PropertyValue<string>>();
            BoolProperties = new HashSet<PropertyValue<bool>>();
            GuidProperties = new HashSet<PropertyValue<Guid>>();
            IntProperties = new HashSet<PropertyValue<int?>>();
            DateTimeProperties = new HashSet<PropertyValue<DateTimeOffset?>>();
        }

        [DataMember]
        public Guid Uid { get; set; }

        [DataMember]
        public ICollection<PropertyValue<string>> TextProperties { get; set; }

        [DataMember]
        public ICollection<PropertyValue<bool>> BoolProperties { get; set; }

        [DataMember]
        public ICollection<PropertyValue<Guid>> GuidProperties { get; set; }

        [DataMember]
        public ICollection<PropertyValue<int?>> IntProperties { get; set; }

        [DataMember]
        public ICollection<PropertyValue<DateTimeOffset?>> DateTimeProperties { get; set; }

    }


    [DataContract]
    public class SavePersonPropertiesParameters
    {
        public SavePersonPropertiesParameters()
        {
            PersonUid = Guid.Empty;
            Properties = new ObjectProperties();
            PersonAccessControlProperties = new ObjectProperties();
        }


        [DataMember]
        public Guid PersonUid { get; set; }

        [DataMember]
        public ObjectProperties Properties { get; set; }

        [DataMember]
        public ObjectProperties PersonAccessControlProperties { get; set; }
    }
}
