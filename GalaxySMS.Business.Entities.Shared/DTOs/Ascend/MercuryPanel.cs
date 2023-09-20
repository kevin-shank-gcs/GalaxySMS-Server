using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GalaxySMS.Common.Shared.Enums;

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

    public class MercuryPanel : IControlledDevice//: SerializableObject, IControlledDevice
    {
        #region Implementation of IControlledDevice

#if NetCoreApi
#else
        [DataMember]
#endif
            public string Guid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
            public string MacAddress { get; set; }

#if NetCoreApi
#else
            [DataMember]
#endif
            public string Name { get; set; }

#if NetCoreApi
#else
            [DataMember]
#endif
            public string Description { get; set; }

#if NetCoreApi
#else
            [DataMember]
#endif
            public bool? Online { get; set; }

#if NetCoreApi
#else
            [DataMember]
#endif
            public bool? Authorized { get; set; }

#if NetCoreApi
#else
            [DataMember]
#endif
            public DeviceManufacturer DeviceManufacturer { get; set; }

#if NetCoreApi
#else
            [DataMember]
#endif
            public DateTime LastConnected { get; set; }
        #endregion

        /// <summary>Mercury Panel Type of this panel</summary>

#if NetCoreApi
#else
        [DataMember]
#endif
            public MercuryPanelType PanelType { get; set; }
        /// <summary>Mercury Panel Serial Number</summary>

#if NetCoreApi
#else
        [DataMember]
#endif
            public ulong Serialnumber { get; set; }

            public MercuryPanel()
            {
            }
        }

}
