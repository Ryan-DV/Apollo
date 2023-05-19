using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YXBqSVSFInterop.Types.Delegates;
using YXBqSVSFInterop.Structs.MythicStructs;
using YXBqSVSFInterop.Enums.YXBqSVSFEnums;

namespace YXBqSVSFInterop.Interfaces
{
    public interface ITaskManager
    {
        string[] GetExecutingTaskIds();
        bool CancelTask(string taskId);

        bool CreateTaskingMessage(OnResponse<TaskingMessage> onResponse);

        bool ProcessMessageResponse(MessageResponse resp);

        void AddTaskResponseToQueue(TaskResponse message);

        void AddDelegateMessageToQueue(DelegateMessage delegateMessage);

        void AddSocksDatagramToQueue(MessageDirection dir, SocksDatagram dg);

        bool LoadTaskModule(byte[] taskAsm, string[] commands);
    }
}
