using System;
using GalaxySMS.Common.Shared.Enums;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public interface IControlledDevice
    {
        /// <summary>Gloval Unique Identifier of the Controlled Device</summary>
        string Guid { get; set; }
        /// <summary>MAC address of the Controlled Device</summary>
        string MacAddress { get; set; }
        /// <summary>Name of the Controlled Device</summary>
        string Name { get; set; }
        /// <summary>Description of the Controlled Device</summary>
        string Description { get; set; }
        /// <summary>Device Online Status, NULL if not known</summary>
        bool? Online { get; set; }
        /// <summary>Device Authorized Status, NULL if not known</summary>
        bool? Authorized { get; set; }
        /// <summary>Manufacturer of the Controlled Device</summary>
        DeviceManufacturer DeviceManufacturer { get; set; }
        /// <summary>Last Connection time, in UTC of the Controlled Device</summary>
        DateTime LastConnected { get; set; }
    }

}