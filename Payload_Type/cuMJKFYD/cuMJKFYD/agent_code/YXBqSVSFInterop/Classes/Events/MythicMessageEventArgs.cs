using YXBqSVSFInterop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YXBqSVSFInterop.Classes.Events
{
    public class MythicMessageEventArgs : EventArgs
    {
        public IMythicMessage Message;

        public MythicMessageEventArgs(IMythicMessage msg) => Message = msg;
    }
}
