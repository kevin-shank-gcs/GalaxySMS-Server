﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\EnsureOutputDeviceExistsParameters.cs
//
// summary:	Implements the ensure access portal exists parameters class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An ensure access portal exists parameters. </summary>
    ///
    /// <remarks>   Kevin, 2/14/2017. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class EnsureOutputDeviceExistsParameters
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy hardware module type UID. </summary>
        ///
        /// <value> The galaxy hardware module type UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Guid GalaxyHardwareModuleTypeUid { get; set; } 

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy interface board section node UID. </summary>
        ///
        /// <value> The galaxy interface board section node UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoardSectionNode TheNode {get;set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the template access portal UID. </summary>
        ///
        /// <value> The template access portal UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Guid TemplateOutputDeviceUid {get;set; }

        public IEnumerable<TimeSchedule> Schedules { get; set; }
        public IEnumerable<InputOutputGroup> InputOutputGroups { get; set; }
    }
}
