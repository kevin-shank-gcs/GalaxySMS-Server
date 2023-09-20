using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GalaxySMS.TelerikWPF.Infrastructure.Prism;

namespace GalaxySMS.MonitorManager.ViewModels
{
    [Export(typeof(DocumentPaneViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [XmlRoot("DocumentPaneViewModel")]
    public class DocumentPaneViewModel : PaneViewModel
    {
    }
}
