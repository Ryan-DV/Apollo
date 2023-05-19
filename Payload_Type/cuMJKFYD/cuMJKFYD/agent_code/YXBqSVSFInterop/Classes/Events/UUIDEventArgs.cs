using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YXBqSVSFInterop.Classes
{
    public class UUIDEventArgs : EventArgs
    {
        public readonly string UUID;
        public UUIDEventArgs(string uuid)
        {
            UUID = uuid;
        }
    }
}
