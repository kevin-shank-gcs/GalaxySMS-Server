using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class UserDefinedListPropertyItem
    {
        public UserDefinedListPropertyItem()
        {
            Initialize();
        }

        public UserDefinedListPropertyItem(UserDefinedListPropertyItem e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(UserDefinedListPropertyItem e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.UserDefinedListPropertyItemUid = e.UserDefinedListPropertyItemUid;
            this.UserDefinedPropertyUid = e.UserDefinedPropertyUid;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.ItemValue = e.ItemValue;
            this.DisplayOrder = e.DisplayOrder;
            this.ItemImage = e.ItemImage;
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

        public UserDefinedListPropertyItem Clone(UserDefinedListPropertyItem e)
        {
            return new UserDefinedListPropertyItem(e);
        }

        public bool Equals(UserDefinedListPropertyItem other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(UserDefinedListPropertyItem other)
        {
            if (other == null)
                return false;

            if (other.UserDefinedListPropertyItemUid != this.UserDefinedListPropertyItemUid)
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
