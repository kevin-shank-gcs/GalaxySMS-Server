//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public partial class ClusterGalaxyPanelMinimal
    {
        public ClusterGalaxyPanelMinimal()
        {
            GalaxyPanels = new HashSet<GalaxyPanelMinimal>();
        }

        [DataMember]
        public System.Guid ClusterUid { get; set; }

        [DataMember]
        public ICollection<GalaxyPanelMinimal> GalaxyPanels { get; set; }

    }
}
