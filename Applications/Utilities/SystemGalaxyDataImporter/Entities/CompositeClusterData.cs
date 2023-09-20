using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Entities;
using GCS.Core.Common.Core;
using GCS.WebApi.SysGal.Entities;

namespace SystemGalaxyDataImporter.Entities
{
    public class CompositeClusterData : ObjectBase
    {
        private LOOPS _fullSgClusterData;
        private ClusterDataEx _sgClusterData;
        private Cluster _smsCluster;

        public CompositeClusterData(ClusterData clusterData)
        {
            SgClusterData = new ClusterDataEx(clusterData);
        }

        public ClusterDataEx SgClusterData
        {
            get => _sgClusterData;
            set
            {
                if (_sgClusterData != value)
                {
                    _sgClusterData = value;
                    OnPropertyChanged(() => SgClusterData, false);
                }
            }
        }

        public LOOPS FullSgClusterData
        {
            get => _fullSgClusterData;
            set
            {
                if (_fullSgClusterData != value)
                {
                    _fullSgClusterData = value;
                    OnPropertyChanged(() => FullSgClusterData, false);
                }
            }
        }

        public Cluster SmsCluster
        {
            get => _smsCluster;
            set
            {
                if (_smsCluster != value)
                {
                    _smsCluster = value;
                    OnPropertyChanged(() => SmsCluster, false);
                    if( this.SgClusterData != null && SmsCluster != null)
                    {
                        foreach( var c in SgClusterData.ControllersEx)
                        {
                            c.ClusterUid = SmsCluster.ClusterUid;
                            var sgPanel = SmsCluster.GalaxyPanels.FirstOrDefault(o=>o.PanelNumber == c.UnitNumber);
                            if( sgPanel != null)
                                c.HasBeenImported = true;
                        }
                    }
                }
            }
        }


    }
}
