using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GCS.Framework.Farpointe.Conekt.Entities
{
    public enum StatusCode
    {
        Unknown,
        IN_PROGRESS,
        COMPLETED,
        FAILED
    }

    public class OrderStatus
    {
        public int orderId { get; set; }
        public string status { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? completedAt { get; set; }
        public Credentialcontents credentialContents { get; set; }
        public Credential[] credentials { get; set; }

        [JsonIgnore]
        public StatusCode StatusCode
        {
            get
            {
                if( string.IsNullOrEmpty( status ) )
                    return StatusCode.Unknown;
                if( status.ToUpper() == StatusCode.IN_PROGRESS.ToString())
                    return StatusCode.IN_PROGRESS;
                if (status.ToUpper() == StatusCode.COMPLETED.ToString())
                    return StatusCode.COMPLETED;
                if (status.ToUpper() == StatusCode.FAILED.ToString())
                    return StatusCode.FAILED;
                return StatusCode.Unknown;
            }
        }

        [JsonIgnore]
        public TimeSpan TotalTime
        {
            get
            {
                if( completedAt.HasValue )
                    return completedAt.Value - createdAt;
                return TimeSpan.Zero;
            }
        }
    }

    public class Credentialcontents
    {
        public int FacilityCode { get; set; }
    }

    public class Credential
    {
        public string registrationKey { get; set; }
        public int credentialId { get; set; }
    }

}
