////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\TimePeriodInterval.cs
//
// summary:	Implements the time period interval class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GCS.Framework.Security;
using FluentValidation;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class TimePeriod 
    {
        public TimePeriod()
        {
            StartTime = TimeSpan.MinValue;
            EndTime = TimeSpan.MinValue;
        }

        [DataMember]
        public TimeSpan StartTime { get; set; }

        [DataMember]
        public TimeSpan EndTime { get; set; }
    }
}
