using YXBqSVSFInterop.Enums.YXBqSVSFEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YXBqSVSFInterop.Types
{
    namespace Delegates
    {
        public delegate bool OnResponse<T>(T message);
        public delegate bool DispatchMessage(byte[] data, MessageType mt);
    }
}
