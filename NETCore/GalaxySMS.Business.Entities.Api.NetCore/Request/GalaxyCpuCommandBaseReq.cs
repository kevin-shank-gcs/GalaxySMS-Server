
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities;
using GalaxySMS.Business.Entities.Api.NetCore;
using GCS.Core.Common.Core;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy CPU command base. </summary>
    ///
    /// <remarks>   Kevin, 1/21/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public partial class GalaxyCpuCommandBaseReq: GalaxyCpuCommandSingleBaseReq// : ObjectBase
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuCommandBaseReq()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ///
        /// <param name="o">    The GalaxyCpuCommandAction to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuCommandBaseReq(GalaxyCpuCommandBaseReq o):base()
        {
            Init();

            if (o == null)
                return;

            //this.ClusterUid = o.ClusterUid;
            //this.GalaxyPanelUid = o.GalaxyPanelUid;
            //this.CpuUid = o.CpuUid;
            ////this.CommandUid = o.CommandUid;

            if (o.ClusterUids != null)
                this.ClusterUids = o.ClusterUids.ToList();
            if (o.GalaxyPanelUids != null)
                this.GalaxyPanelUids = o.GalaxyPanelUids.ToList();
            if (o.CpuUids != null)
                this.CpuUids = o.CpuUids.ToList();
            //if (o.ClusterAddresses != null)
            //    this.ClusterAddresses = o.ClusterAddresses.ToList();
            //if (o.CpuAddresses != null)
            //    this.CpuAddresses = o.CpuAddresses.ToList();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyCpuCommandAction. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            base.Init();
            ClusterUids = new List<Guid>();
            GalaxyPanelUids = new List<Guid>();
            CpuUids = new List<Guid>();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster uids. </summary>
        ///
        /// <value> The cluster uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<Guid> ClusterUids { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel uids. </summary>
        ///
        /// <value> The galaxy panel uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<Guid> GalaxyPanelUids { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the CPU uids. </summary>
        ///
        /// <value> The CPU uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<Guid> CpuUids { get; set; }

    }

    public partial class GalaxyCpuCommandSingleBaseReq// : ObjectBase
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuCommandSingleBaseReq()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ///
        /// <param name="o">    The GalaxyCpuCommandAction to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuCommandSingleBaseReq(GalaxyCpuCommandSingleBaseReq o)
        {
            Init();

            if (o == null)
                return;

            this.ClusterUid = o.ClusterUid;
            this.GalaxyPanelUid = o.GalaxyPanelUid;
            this.CpuUid = o.CpuUid;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyCpuCommandAction. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            this.ClusterUid = Guid.Empty;
            this.GalaxyPanelUid = Guid.Empty;
            this.CpuUid = Guid.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster UID. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Guid ClusterUid { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel UID. </summary>
        ///
        /// <value> The galaxy panel UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //[RequiredGuid]
        public Guid GalaxyPanelUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the CPU UID. </summary>
        ///
        /// <value> The CPU UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Guid CpuUid { get; set; }

        //[RequiredGuid(ErrorMessage = $"One of the following are required: {nameof(ClusterUid)}, {nameof(GalaxyPanelUid)}, {nameof(CpuUid)}")]
        //[SwaggerSchema(ReadOnly = true)]
        //public Guid Uid
        //{
        //    get
        //    {
        //        if( CpuUid != Guid.Empty)
        //            return CpuUid;
        //        if (GalaxyPanelUid != Guid.Empty)
        //            return GalaxyPanelUid;
        //        return ClusterUid;
        //    }
        //    internal set { }
        //}

    }
    public partial class GalaxyPanelLoadDataBaseReq// : ObjectBase
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanelLoadDataBaseReq()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ///
        /// <param name="o">    The GalaxyCpuCommandAction to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanelLoadDataBaseReq(GalaxyPanelLoadDataBaseReq o)
        {
            Init();

            if (o == null)
                return;

            //this.ClusterUid = o.ClusterUid;
            this.GalaxyPanelUid = o.GalaxyPanelUid;
            //this.CpuUid = o.CpuUid;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyCpuCommandAction. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            //this.ClusterUid = Guid.Empty;
            this.GalaxyPanelUid = Guid.Empty;
            //this.CpuUid = Guid.Empty;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the cluster UID. </summary>
        /////
        ///// <value> The cluster UID. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public Guid ClusterUid { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel UID. </summary>
        ///
        /// <value> The galaxy panel UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [RequiredGuid]
        public Guid GalaxyPanelUid { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the CPU UID. </summary>
        /////
        ///// <value> The CPU UID. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //public Guid CpuUid { get; set; }
        
    }

}