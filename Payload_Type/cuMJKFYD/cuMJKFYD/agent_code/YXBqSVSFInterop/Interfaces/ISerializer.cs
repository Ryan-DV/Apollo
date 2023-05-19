using YXBqSVSFInterop.Enums.YXBqSVSFEnums;
using YXBqSVSFInterop.Structs.YXBqSVSFStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YXBqSVSFInterop.Constants;

namespace YXBqSVSFInterop.Interfaces
{
    public interface ISerializer
    {
        string Serialize(object obj);
        T Deserialize<T>(string msg);

        IPCChunkedData[] SerializeDelegateMessage(string message, MessageType mt, int block_size = IPC.SEND_SIZE / 2);

        // This is so we can serialize/deserialize things across named pipes, but technically
        IPCChunkedData[] SerializeIPCMessage(IMythicMessage message, int block_size = IPC.SEND_SIZE);
        IMythicMessage DeserializeIPCMessage(byte[] data, MessageType mt);
    }
}
