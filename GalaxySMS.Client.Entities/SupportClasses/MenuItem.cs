using System;
using System.Collections.ObjectModel;

namespace GalaxySMS.Client.Entities
{
    public class MenuItem
    {
        public MenuItem()
        {
            this.SubItems = new ObservableCollection<MenuItem>();
        }
        public string Text
        {
            get;
            set;
        }
        public string ToolTip
        {
            get;
            set;
        }
        public Guid CommandUid { get; set; }
        public Guid DeviceUid { get; set; }

        public Uri IconUrl
        {
            get;
            set;
        }

        //public BitmapImage Icon
        //{
        //    get
        //    {
        //        return new BitmapImage()
        //        {
        //            Source = new BitmapImage(IconUrl)
        //        };
        //    }
        //}

        public double IconColumnWidth { get; set; }
        public ObservableCollection<MenuItem> SubItems
        {
            get;
            set;
        }
    }

}
