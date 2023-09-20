////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\ClusterAddress.cs
//
// summary:	Implements the cluster address class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A cluster address. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public class ClusterAddress: ObjectBase
	{
        /// <summary>   The cluster number. </summary>
	    private Int32 _clusterNumber;
        /// <summary>   The account code. </summary>
        private int _clusterGroupId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ClusterAddress()
		{
            //Region= new GalaxyRegion();
            //Site = new GalaxySite();
        }   

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="clusterNumber">    The cluster number. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public ClusterAddress(Int32 clusterNumber)
		{
		    ClusterNumber = clusterNumber;
            //Region = new GalaxyRegion();
            //Site = new GalaxySite();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="clusterNumber">    The cluster number. </param>
        /// <param name="clusterGroupId">   The cluster group id. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ClusterAddress(Int32 clusterNumber, Int32 clusterGroupId)
        {
            ClusterNumber = clusterNumber;
            //Region = new GalaxyRegion();
            //Site = new GalaxySite();
            ClusterGroupId = clusterGroupId;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The ClusterAddress to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ClusterAddress(ClusterAddress o)
		{
		    ClusterNumber = o.ClusterNumber;
            //Region = o.Region;
            //Site = o.Site;
            ClusterGroupId = o.ClusterGroupId;
            ClusterUid = o.ClusterUid;

        }

//		[DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public String UniqueId { get { return string.Format("{0}:{1:D3}", ClusterGroupId, ClusterNumber); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster UID. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
	    public Guid ClusterUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster number. </summary>
        ///
        /// <value> The cluster number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
	    public Int32 ClusterNumber
        {
	        get { return _clusterNumber; }
	        set
	        {
                if (_clusterNumber != value)
                {
                    _clusterNumber = value;
                    OnPropertyChanged(() => ClusterNumber);
                }
	        }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the account code. </summary>
        ///
        /// <value> The account code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int ClusterGroupId
        {
            get
            {
                return _clusterGroupId;
            }
            set
            {
                if (_clusterGroupId != value)
                {
                    _clusterGroupId = value;
                    OnPropertyChanged(() => ClusterGroupId);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the region. </summary>
        /////
        ///// <value> The region. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public GalaxyRegion Region { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the site. </summary>
        /////
        ///// <value> The site. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public GalaxySite Site { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    public override string ToString()
		{
			return UniqueId;
		}
	}
}
