using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
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

        public string StringValue { get; set; }
        public object ObjectValue { get; set; }
        public override string ToString()
        {
            return StringValue;
        }
    }

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

        public short Value { get; set; }
    }

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

        public ushort Value { get; set; }
    }

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
        public uint Value { get; set; }
    }

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

        public int Value { get; set; }
    }
}
