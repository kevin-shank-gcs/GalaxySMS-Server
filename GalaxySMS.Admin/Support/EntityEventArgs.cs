using System;
using GalaxySMS.Client.Entities;

namespace GalaxySMS.Admin.Support
{
    public class EntityEventArgs : EventArgs
    {
        public EntityEventArgs(gcsEntity entity, bool isNew)
        {
            Entity = entity;
            IsNew = isNew;
        }

        public gcsEntity Entity { get; set; }
        public bool IsNew { get; set; }    }
}
