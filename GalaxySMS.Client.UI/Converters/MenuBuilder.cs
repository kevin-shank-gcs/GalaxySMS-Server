using GalaxySMS.Client.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GalaxySMS.Client.UI
{
    public class MenuBuilder
    {
        public static ObservableCollection<MenuItem> GetMenu(IEnumerable<AccessPortalCommand> commands, Guid deviceUid, string topMenuHeader, string topMenuToolTip)
        {
            ObservableCollection<MenuItem> items = new ObservableCollection<MenuItem>();
            ObservableCollection<MenuItem> commandSubItems = new ObservableCollection<MenuItem>();
            foreach (var c in commands)
            {
                MenuItem newItem = new MenuItem()
                {
                    //IconUrl = new Uri("/Images/newFile.png", UriKind.RelativeOrAbsolute),
                    Text = c.Display,
                    ToolTip = c.Description,
                    CommandUid = c.AccessPortalCommandUid,
                    IconColumnWidth = 20,
                    DeviceUid = deviceUid
                };
                commandSubItems.Add(newItem);
            }

            MenuItem menuItem = new MenuItem()
            {
                SubItems = commandSubItems,
                Text = topMenuHeader,
                ToolTip = topMenuToolTip,
                DeviceUid = deviceUid
            };
            items.Add(menuItem);

            return items;
        }
        public static ObservableCollection<MenuItem> GetMenu(IEnumerable<InputCommand> commands, Guid deviceUid, string topMenuHeader, string topMenuToolTip)
        {
            ObservableCollection<MenuItem> items = new ObservableCollection<MenuItem>();
            ObservableCollection<MenuItem> commandSubItems = new ObservableCollection<MenuItem>();
            foreach (var c in commands)
            {
                MenuItem newItem = new MenuItem()
                {
                    //IconUrl = new Uri("/Images/newFile.png", UriKind.RelativeOrAbsolute),
                    Text = c.Display,
                    ToolTip = c.Description,
                    CommandUid = c.InputCommandUid,
                    IconColumnWidth = 20,
                    DeviceUid = deviceUid
                };
                commandSubItems.Add(newItem);
            }

            MenuItem menuItem = new MenuItem()
            {
                SubItems = commandSubItems,
                Text = topMenuHeader,
                ToolTip = topMenuToolTip,
                DeviceUid = deviceUid
            };
            items.Add(menuItem);

            return items;
        }
        public static ObservableCollection<MenuItem> GetMenu(IEnumerable<OutputCommand> commands, Guid deviceUid, string topMenuHeader, string topMenuToolTip)
        {
            ObservableCollection<MenuItem> items = new ObservableCollection<MenuItem>();
            ObservableCollection<MenuItem> commandSubItems = new ObservableCollection<MenuItem>();
            foreach (var c in commands)
            {
                MenuItem newItem = new MenuItem()
                {
                    //IconUrl = new Uri("/Images/newFile.png", UriKind.RelativeOrAbsolute),
                    Text = c.Display,
                    ToolTip = c.Description,
                    CommandUid = c.OutputCommandUid,
                    IconColumnWidth = 20,
                    DeviceUid = deviceUid
                };
                commandSubItems.Add(newItem);
            }

            MenuItem menuItem = new MenuItem()
            {
                SubItems = commandSubItems,
                Text = topMenuHeader,
                ToolTip = topMenuToolTip,
                DeviceUid = deviceUid
            };
            items.Add(menuItem);

            return items;
        }
    }
}
