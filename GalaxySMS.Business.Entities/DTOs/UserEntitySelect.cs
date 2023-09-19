using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    public class UserEntitySelect:UserEntity
    {
        public UserEntitySelect() :base()
        {
            Init();
        }

        public UserEntitySelect(gcsEntity e) :base(e)
        {
            Init();
        }

        protected void Init()
        {
            base.Init();
        }

        public bool Selected { get; set; }
        public Guid EntityMapPermissionLevelUid { get; set; }
        public bool IsOwner { get; set; }
    }
}
