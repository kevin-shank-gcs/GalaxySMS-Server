using System;

namespace GalaxySMS.Business.Entities
{
    public interface IHasAddress
    {
        Address Address { get; set; }
        Guid? AddressUid { get; set; }

    }
}