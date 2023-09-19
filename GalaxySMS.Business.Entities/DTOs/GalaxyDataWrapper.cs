using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Business.Entities
{
    //[DataContract]
    //public class GalaxyDataWrapper : EntityBase
    //{
    //    //public enum DataDirection { OutputToPanel, InputFromPanel }

    //    private object _data;
    //    private Type _bodyType;

    //    [DataMember]
    //    public Guid ClusterUid { get; set; }
    //    [DataMember]
    //    public Guid GalaxyPanelUid { get; set; }
    //    [DataMember]
    //    public Guid GalaxyCpuUid { get; set; }
    //    [DataMember]
    //    public int ClusterGroupId { get; set; }
    //    [DataMember]
    //    public int ClusterNumber { get; set; }
    //    [DataMember]
    //    public int PanelNumber { get; set; }
    //    [DataMember]
    //    public uint CpuNumber { get; set; }

    //    //[DataMember]
    //    //public string BodyTypeString { get; internal set; }

    //    //public Type BodyType
    //    //{
    //    //    get
    //    //    {
    //    //        if (string.IsNullOrEmpty(BodyTypeString))
    //    //            return typeof(object);

    //    //        return Type.GetType(BodyTypeString);
    //    //    }

    //    //    set
    //    //    {
    //    //        BodyTypeString = value.ToString();
    //    //    }
    //    //}
    //    [DataMember]
    //    public Type DataType
    //    {
    //        get { return Data.GetType(); }
    //    }

    //    [DataMember]
    //    public string MessageType { get; set; }

    //    public TBody DataAs<TBody>()
    //    {
    //        return (TBody)Data;
    //    }

    //    [DataMember]
    //    public object Data
    //    {
    //        get => _data;
    //        set
    //        {
    //            _data = value;
    //            MessageType = _data.GetMessageType();
    //        }
    //    }

    //    [DataMember]
    //    public DataDirection Direction { get; set; }


    //    //public static GalaxyDataWrapper FromJson(Stream jsonStream)
    //    //{
    //    //    var dataWrapper = jsonStream.ReadFromJson<GalaxyDataWrapper>();
    //    //    //the body is a JObject at this point - deserialize to the real message type:
    //    //    dataWrapper.Data = dataWrapper.Data.ToString().ReadFromJson(dataWrapper.MessageType);
    //    //    return dataWrapper;
    //    //}

    //    //public static GalaxyDataWrapper FromJson(string json)
    //    //{
    //    //    var dataWrapper = json.ReadFromJson<GalaxyDataWrapper>();
    //    //    //the body is a JObject at this point - deserialize to the real message type:
    //    //    dataWrapper.Data = dataWrapper.Data.ToString().ReadFromJson(dataWrapper.MessageType);
    //    //    return dataWrapper;
    //    //}

    //    //public object ConvertDataFromJObject()
    //    //{
    //    //    return Data;
    //    //}
    //}
}
