////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\EnsureOutputDeviceExistsParameters.cs
//
// summary:	Implements the ensure access portal exists parameters class
////////////////////////////////////////////////////////////////////////////////////////////////////

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
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An ensure access portal exists parameters. </summary>
    ///
    /// <remarks>   Kevin, 2/14/2017. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////


#if NetCoreApi
#else
    [DataContract]
#endif
    public class EnsureOutputDeviceExistsParameters : IHasRoleMappingList
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy hardware module type UID. </summary>
        ///
        /// <value> The galaxy hardware module type UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyHardwareModuleTypeUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy interface board section node UID. </summary>
        ///
        /// <value> The galaxy interface board section node UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxyInterfaceBoardSectionNode TheNode { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the template access portal UID. </summary>
        ///
        /// <value> The template access portal UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid TemplateOutputDeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public IEnumerable<TimeSchedule> Schedules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public IEnumerable<InputOutputGroup> InputOutputGroups { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid SiteUid { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Guid> RoleIds { get; set; }

    }
}
