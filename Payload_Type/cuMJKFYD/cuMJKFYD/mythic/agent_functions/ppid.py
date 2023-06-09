from mythic_container.MythicCommandBase import *
import json


class PpidArguments(TaskArguments):

    def __init__(self, command_line, **kwargs):
        super().__init__(command_line, **kwargs)
        self.args = [
            CommandParameter(
                name="ppid",
                cli_name="PPID",
                display_name="Parent Process ID",
                type=ParameterType.Number,
                default_value=-1),
        ]

    async def parse_arguments(self):
        if len(self.command_line) == 0:
            raise Exception("No PPID given on command line.")
        if self.command_line[0] == "{":
            self.load_args_from_json_string(self.command_line)
        else:
            try:
                newppid = int(self.command_line)
                if newppid < 0 or newppid % 4 != 0:
                    raise Exception("Invalid PPID given on command line.")
                self.add_arg("ppid", newppid)
            except:
                raise Exception("Invalid integer given to PPID: {}".format(self.command_line))


class PpidCommand(CommandBase):
    cmd = "ppid"
    needs_admin = False
    help_cmd = "ppid [pid]"
    description = "Change the parent process for post-ex jobs by the specified pid."
    version = 2
    author = "@djhohnstein"
    argument_class = PpidArguments
    attackmapping = ["T1055"]

    async def create_go_tasking(self, taskData: PTTaskMessageAllData) -> PTTaskCreateTaskingMessageResponse:
        response = PTTaskCreateTaskingMessageResponse(
            TaskID=taskData.Task.ID,
            Success=True,
        )
        pid = taskData.args.get_arg("ppid")
        response.DisplayParams = "-PPID {}".format(pid)
        return response

    async def process_response(self, task: PTTaskMessageAllData, response: any) -> PTTaskProcessResponseMessageResponse:
        resp = PTTaskProcessResponseMessageResponse(TaskID=task.Task.ID, Success=True)
        return resp