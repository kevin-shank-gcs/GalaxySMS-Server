﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Geography.DataClasses
{
    public class RequestTimeZoneInformationForLocationParameters
    {
        public string UserName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
