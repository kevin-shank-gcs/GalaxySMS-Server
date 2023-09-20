using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace GalaxySMS.TelerikWPF.Infrastructure.Prism
{
    public class CustomDockingPanesFactory : DockingPanesFactory
    {
        //protected override void AddPane(RadDocking radDocking, RadPane pane)
        //{
        //    var paneModel = pane.DataContext as IPaneViewModel;
        //    if (paneModel != null && paneModel.Header == null && pane.Header != null)
        //        paneModel.Header = pane.Header.ToString();

        //    if (paneModel != null && !(paneModel.IsDocument))
        //    {
        //        RadPaneGroup group = null;
        //        switch (paneModel.DockPosition)
        //        {
        //            case DockState.DockedRight:
        //                group = radDocking.SplitItems.ToList().FirstOrDefault(i => i.Control.Name == "rightGroup") as RadPaneGroup;
        //                if (group != null)
        //                {
        //                    group.Items.Add(pane);

        //                }
        //                return;
        //            case DockState.DockedBottom:
        //                group = radDocking.SplitItems.ToList().FirstOrDefault(i => i.Control.Name == "bottomGroup") as RadPaneGroup;
        //                if (group != null)
        //                {
        //                    group.Items.Add(pane);
        //                }
        //                return;
        //            case DockState.DockedLeft:
        //                group = radDocking.SplitItems.ToList().FirstOrDefault(i => i.Control.Name == "leftGroup") as RadPaneGroup;
        //                if (group != null)
        //                {
        //                    group.Items.Add(pane);
        //                }
        //                return;
        //            case DockState.FloatingDockable:
        //                var fdSplitContainer = radDocking.GeneratedItemsFactory.CreateSplitContainer();
        //                group = radDocking.GeneratedItemsFactory.CreatePaneGroup();
        //                fdSplitContainer.Items.Add(group);
        //                group.Items.Add(pane);
        //                radDocking.Items.Add(fdSplitContainer);
        //                pane.MakeFloatingDockable();
        //                return;
        //            case DockState.FloatingOnly:
        //                var foSplitContainer = radDocking.GeneratedItemsFactory.CreateSplitContainer();
        //                group = radDocking.GeneratedItemsFactory.CreatePaneGroup();
        //                foSplitContainer.Items.Add(group);
        //                group.Items.Add(pane);
        //                radDocking.Items.Add(foSplitContainer);
        //                pane.MakeFloatingOnly();
        //                return;
        //            case DockState.DockedTop:
        //            default:
        //                return;
        //        }
        //    }

        //    base.AddPane(radDocking, pane);
        //}
        protected override void AddPane(RadDocking radDocking, RadPane pane)
        {
            var paneViewModel = pane.DataContext as IPaneViewModel;

            if (paneViewModel != null && paneViewModel.Header == null )
                paneViewModel.Header = pane.Header.ToString();

            if (paneViewModel != null && !(paneViewModel.IsDocument) )
            {
                RadPaneGroup group = null;
                switch (paneViewModel.DockPosition)
                {
                    case DockState.DockedRight:
                        group = radDocking.SplitItems.ToList().FirstOrDefault(i => i.Control.Name == "rightGroup") as RadPaneGroup;
                        if (group != null)
                        {
                            group.Items.Add(pane);

                        }
                        return;
                    case DockState.DockedBottom:
                        group = radDocking.SplitItems.ToList().FirstOrDefault(i => i.Control.Name == "bottomGroup") as RadPaneGroup;
                        if (group != null)
                        {
                            group.Items.Add(pane);
                        }
                        return;
                    case DockState.DockedLeft:
                        group = radDocking.SplitItems.ToList().FirstOrDefault(i => i.Control.Name == "leftGroup") as RadPaneGroup;
                        if (group != null)
                        {
                            group.Items.Add(pane);
                        }
                        return;
                    case DockState.FloatingDockable:
                        var fdSplitContainer = radDocking.GeneratedItemsFactory.CreateSplitContainer();
                        group = radDocking.GeneratedItemsFactory.CreatePaneGroup();
                        fdSplitContainer.Items.Add(group);
                        group.Items.Add(pane);
                        radDocking.Items.Add(fdSplitContainer);
                        pane.MakeFloatingDockable();
                        return;
                    case DockState.FloatingOnly:
                        var foSplitContainer = radDocking.GeneratedItemsFactory.CreateSplitContainer();
                        group = radDocking.GeneratedItemsFactory.CreatePaneGroup();
                        foSplitContainer.Items.Add(group);
                        group.Items.Add(pane);
                        radDocking.Items.Add(foSplitContainer);
                        pane.MakeFloatingOnly();
                        return;
                    case DockState.DockedTop:
                    default:
                        return;
                }
            }

            base.AddPane(radDocking, pane);
        }

        protected override RadPane CreatePaneForItem(object item)
        {
            var viewModel = item as PaneViewModel;
            if (viewModel != null)
            {
                var pane = viewModel.IsDocument ? new RadDocumentPane() : new RadPane();
                pane.DataContext = item;
                RadDocking.SetSerializationTag(pane, viewModel.Header);
                if (viewModel.ContentType != null)
                {
                    pane.Content = Activator.CreateInstance(viewModel.ContentType);
                    viewModel.Content = pane.Content;
                }

                return pane;
            }

            return base.CreatePaneForItem(item);
        }

        protected override void RemovePane(RadPane pane)
        {
            pane.DataContext = null;
            pane.Content = null;
            pane.ClearValue(RadDocking.SerializationTagProperty);
            pane.RemoveFromParent();
        }
    }
}
