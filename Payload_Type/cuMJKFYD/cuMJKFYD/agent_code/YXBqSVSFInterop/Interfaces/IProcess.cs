using YXBqSVSFInterop.Structs.YXBqSVSFStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YXBqSVSFInterop.Interfaces
{
    public interface IProcess
    {
        bool Inject(byte[] code, string arguments = "");
        void WaitForExit();
        void WaitForExit(int milliseconds);

        bool Start();
        bool StartWithCredentials(YXBqSVSFLogonInformation logonInfo);

        bool StartWithCredentials(IntPtr hToken);

    }
}
