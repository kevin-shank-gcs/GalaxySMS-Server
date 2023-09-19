using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    /// <summary>
    /// This class contains properties for each data value that makes up a GalaxyInterfaceBoardSection_PanelLoadDataPDSA.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>

    public partial class GalaxyInterfaceBoardSection_PanelLoadData
    {
        public GalaxyInterfaceBoardSection_PanelLoadData()
        {
            Initialize();
        }

        public GalaxyInterfaceBoardSection_PanelLoadData(GalaxyInterfaceBoardSection_PanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyInterfaceBoardSection_PanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;

            this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
            this.GalaxyInterfaceBoardUid = e.GalaxyInterfaceBoardUid;
            this.InterfaceBoardSectionModeUid = e.InterfaceBoardSectionModeUid;
            this.SectionNumber = e.SectionNumber;
            this.IsSectionActive = e.IsSectionActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.ClusterUid = e.ClusterUid;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.BoardNumber = e.BoardNumber;
            this.BoardSectionMode = e.BoardSectionMode;
            this.BoardSectionModeDisplay = e.BoardSectionModeDisplay;
            this.PanelModelTypeCode = e.PanelModelTypeCode;
            this.CpuTypeCode = e.CpuTypeCode;
            this.BoardTypeModel = e.BoardTypeModel;
            this.BoardTypeTypeCode = e.BoardTypeTypeCode;
            this.BoardTypeDisplay = e.BoardTypeDisplay;
        }

        public GalaxyInterfaceBoardSection_PanelLoadData Clone(GalaxyInterfaceBoardSection_PanelLoadData e)
        {
            return new GalaxyInterfaceBoardSection_PanelLoadData(e);
        }

        public bool Equals(GalaxyInterfaceBoardSection_PanelLoadData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyInterfaceBoardSection_PanelLoadData other)
        {
            if (other == null)
                return false;

            if (other.GalaxyInterfaceBoardSectionUid != this.GalaxyInterfaceBoardSectionUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
