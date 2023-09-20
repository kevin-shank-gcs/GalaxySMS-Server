using System;
using GalaxySMS.Business.Entities;

namespace GalaxySMS.Business.Entities
{
    public interface IHasBinaryResource
    {
        String Name { get; set; }
        gcsBinaryResource gcsBinaryResource { get; set; }
        Guid? BinaryResourceUid { get; set; }
    }
}