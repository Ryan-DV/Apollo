using YXBqSVSFInterop.Structs.YXBqSVSFStructs;
using YXBqSVSFInterop.Structs.MythicStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace YXBqSVSFInterop.Interfaces
{
    public interface IIdentityManager
    {
        WindowsIdentity GetCurrentPrimaryIdentity();
        WindowsIdentity GetCurrentImpersonationIdentity();
        WindowsIdentity GetOriginal();

        bool GetCurrentLogonInformation(out YXBqSVSFLogonInformation logonInfo);

        void Revert();

        void SetPrimaryIdentity(WindowsIdentity identity);

        void SetPrimaryIdentity(IntPtr hToken);

        void SetImpersonationIdentity(WindowsIdentity identity);
        void SetImpersonationIdentity(IntPtr hToken);

        bool SetIdentity(YXBqSVSFLogonInformation token);

        IntegrityLevel GetIntegrityLevel();

        bool IsOriginalIdentity();
    }
}
