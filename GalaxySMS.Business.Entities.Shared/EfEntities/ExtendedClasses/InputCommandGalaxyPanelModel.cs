using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class InputCommandGalaxyPanelModel
    {
        public InputCommandGalaxyPanelModel()
        {
            Initialize();
        }

        public InputCommandGalaxyPanelModel(InputCommandGalaxyPanelModel e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(InputCommandGalaxyPanelModel e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.InputCommandGalaxyPanelModelUid = e.InputCommandGalaxyPanelModelUid;
            this.InputCommandUid = e.InputCommandUid;
            this.GalaxyPanelModelUid = e.GalaxyPanelModelUid;
            this.CommandCode = e.CommandCode;
            this.IsTextCommand = e.IsTextCommand;
            this.TextCommand = e.TextCommand;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public bool IsAnythingDirty
        {
            get
            {
                //foreach( var o in InterfaceBoardSections)
                //{
                //	if (o.IsAnythingDirty == true)
                //		return true;
                //}
                return IsDirty;
            }
        }

        public InputCommandGalaxyPanelModel Clone(InputCommandGalaxyPanelModel e)
        {
            return new InputCommandGalaxyPanelModel(e);
        }

        public bool Equals(InputCommandGalaxyPanelModel other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputCommandGalaxyPanelModel other)
        {
            if (other == null)
                return false;

            if (other.InputCommandGalaxyPanelModelUid != this.InputCommandGalaxyPanelModelUid)
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
