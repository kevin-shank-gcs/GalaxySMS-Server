using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{

#if NetCoreApi
#else
    [DataContract]
#endif
	public class StringObjectPairBase
    {
        public StringObjectPairBase()
        {
            StringValue = string.Empty;
        }

        public StringObjectPairBase(String s)
        {
            StringValue = s;
        }

        public StringObjectPairBase(String s, object o)
        {
            StringValue = s;
            ObjectValue = o;
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string StringValue { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public object ObjectValue { get; set; }
        public override string ToString()
        {
            return StringValue;
        }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class StringShortPair : StringObjectPairBase
    {
        public StringShortPair():base()
        {

        }

        public StringShortPair(String s) :base(s)
        {
        }

        public StringShortPair(String s, short o) :base(s,o)
        {
            Value = o;
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public short Value { get; set; }
    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class StringUShortPair : StringObjectPairBase
    {
        public StringUShortPair():base()
        {

        }

        public StringUShortPair(String s) :base(s)
        {
        }

        public StringUShortPair(String s, ushort o) :base(s,o)
        {
            Value = o;
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ushort Value { get; set; }
    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class StringUIntPair : StringObjectPairBase
    {
        public StringUIntPair():base()
        {

        }

        public StringUIntPair(String s) :base(s)
        {
        }

        public StringUIntPair(String s, uint o) :base(s,o)
        {
            Value = o;
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public uint Value { get; set; }
    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class StringIntPair : StringObjectPairBase
    {
        public StringIntPair():base()
        {

        }

        public StringIntPair(String s) :base(s)
        {
        }

        public StringIntPair(String s, int o) :base(s,o)
        {
            Value = o;
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public int Value { get; set; }
    }
}
