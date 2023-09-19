using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Entities;

namespace GalaxySMS.Prism.Infrastructure.Events
{
    public class ChangeCurrentEntityForSession
    {
        public ChangeCurrentEntityForSession(UserEntity entity)
        {
            UserEntity = entity;

        }
        public UserEntity UserEntity { get; internal set; }

    }
}
