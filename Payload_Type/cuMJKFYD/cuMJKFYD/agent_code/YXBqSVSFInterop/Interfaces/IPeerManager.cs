using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YXBqSVSFInterop.Classes.P2P;
using YXBqSVSFInterop.Structs.MythicStructs;
namespace YXBqSVSFInterop.Interfaces
{
    public interface IPeerManager
    {
        Peer AddPeer(PeerInformation info);
        bool Remove(string uuid);
        bool Remove(IPeer peer);
        bool Route(DelegateMessage msg);
    }
}
