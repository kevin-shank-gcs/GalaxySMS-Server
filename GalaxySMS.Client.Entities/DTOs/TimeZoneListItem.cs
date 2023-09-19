using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities

{
    [DataContract]
    public class TimeZoneListItem
    {

        public TimeZoneListItem()
        {
            Id = string.Empty;
            DisplayName = string.Empty;

        }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

    }
}
