using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Entities;

namespace GalaxySMS.Prism.Infrastructure.Events
{
    public class CurrentSiteForSessionChanged
    {
        public CurrentSiteForSessionChanged(Site site)
        {
            CurrentSite = site;

        }
        public Site CurrentSite { get; internal set; }

    }
}
