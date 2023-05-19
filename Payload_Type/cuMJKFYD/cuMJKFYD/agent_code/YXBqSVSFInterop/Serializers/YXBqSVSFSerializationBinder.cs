using YXBqSVSFInterop.Structs.YXBqSVSFStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace YXBqSVSFInterop.Serializers
{
    public class YXBqSVSFSerializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            if (typeName == "YXBqSVSFInterop.Structs.YXBqSVSFStructs.PeerMessage")
            {
                return typeof(PeerMessage);
            }
            else
            {
                return typeof(Nullable);
            }
        }
    }
}
