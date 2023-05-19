using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YXBqSVSFInterop.Structs.MythicStructs;

namespace YXBqSVSFInterop.Interfaces
{
    public interface ISocksManager
    {
        bool Route(SocksDatagram dg);

        bool Remove(int id);
    }
}
