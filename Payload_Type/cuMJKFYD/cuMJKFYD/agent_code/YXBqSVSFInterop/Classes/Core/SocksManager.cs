using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YXBqSVSFInterop.Interfaces;
using YXBqSVSFInterop.Structs.MythicStructs;

namespace YXBqSVSFInterop.Classes
{
    public abstract class SocksManager : ISocksManager
    {
        protected IAgent _agent;

        public SocksManager(IAgent agent)
        {
            _agent = agent;
        }

        public virtual bool Route(SocksDatagram dg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
