using System;
using GalaxySMS.Client.Entities;

namespace GalaxySMS.Admin.ViewModels
{
    public interface IGalaxyConnectionDebugViewModel
    {
        void Initialize(CpuConnectionInfo connInfo);

        void HandlePacket(CpuDataPacket e);
        Guid InstanceGuid { get; }

        void Activate();
    }
}
