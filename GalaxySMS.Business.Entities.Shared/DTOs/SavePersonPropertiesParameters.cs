using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public class PropertyValue<T>
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public string PropertyName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public T Value { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid Uid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PropertyValue<string>> TextProperties { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PropertyValue<bool>> BoolProperties { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PropertyValue<Guid>> GuidProperties { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PropertyValue<int?>> IntProperties { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PropertyValue<DateTimeOffset?>> DateTimeProperties { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class SavePersonPropertiesParameters
    {
        public SavePersonPropertiesParameters()
        {
            PersonUid = Guid.Empty;
            Properties = new ObjectProperties();
            PersonAccessControlProperties = new ObjectProperties();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonUid { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ObjectProperties Properties { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ObjectProperties PersonAccessControlProperties { get; set; }


        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ObjectProperties PersonOtisElevatorProperties { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<ObjectProperties> PersonAddressProperties { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<ObjectProperties> PersonEmailAddressProperties { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<ObjectProperties> PersonPhoneNumberProperties { get; set; }
    }
}
