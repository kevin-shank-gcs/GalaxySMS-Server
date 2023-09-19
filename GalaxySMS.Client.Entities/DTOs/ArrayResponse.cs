using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class ArrayResponse<T> : PagedResultBase
    {

        [DataMember]
        public T[] Items { get; set; } = new T[0];
    }

}
