from mythic_container.MythicCommandBase import *
import json


class Spawntox64Arguments(TaskArguments):

    def __init__(self, command_line, **kwargs):
        super().__init__(command_line, **kwargs)
        self.args = [
            CommandParameter(name="application",cli_name="Application", display_name="Path to Application", type=ParameterType.String, default_value="C:\\Windows\\System32\\rundll32.exe"),
            CommandParameter(name="arguments", cli_name="Arguments", display_name="Arguments", type=ParameterType.String, default_value="", parameter_group_info=[
                ParameterGroupInfo(
                    required=False
                )
            ]),
        ]

    def split_commandline(self):
        if self.command_line[0] == "{":
            raise Exception("split_commandline expected string, but got JSON object: " + self.command_line)
        inQuotes = False
        curCommand = ""
        cmds = []
        for x in range(len(self.command_line)):
            c = self.command_line[x]
            if c == '"' or c == "'":
                inQuotes = not inQuotes
            if (not inQuotes and c == ' '):
                cmds.append(curCommand)
                curCommand = ""
            else:
                curCommand += c
        
        if curCommand != "":
            cmds.append(curCommand)
        
        for x in range(len(cmds)):
            if cmds[x][0] == '"' and cmds[x][-1] == '"':
                cmds[x] = cmds[x][1:-1]
            elif cmds[x][0] == "'" and cmds[x][-1] == "'":
                cmds[x] = cmds[x][1:-1]

        return cmds

    async def parse_arguments(self):
        if len(self.command_line) == 0:
            raise Exception("spawnto_x64 requires a path to an executable to be passed on the command line.\n\tUsage: {}".format(Spawntox64Command.help_cmd))
        if self.command_line[0] == "{":
            self.load_args_from_json_string(self.command_line)
        else:
            parts = self.split_commandline()
            self.add_arg("application", parts[0])
            firstIndex = self.command_line.index(parts[0])
            cmdline = self.command_line[firstIndex+len(parts[0]):].strip()
            if cmdline[0] in ['"', "'"]:
                cmdline = cmdline[1:].strip()
            self.add_arg("arguments", cmdline)

        pass


class Spawntox64Command(CommandBase):
    cmd = "spawnto_x64"
    needs_admin = False
    help_cmd = "spawnto_x64 [path] [args]"
    description = "Change the default binary used in post exploitation jobs to [path]. If [args] provided, the process is launched with those arguments."
    version = 2
    author = "@djhohnstein"
    argument_class = Spawntox64Arguments
    attackmapping = ["T1055"]

    async def create_go_tasking(self, taskData: PTTaskMessageAllData) -> PTTaskCreateTaskingMessageResponse:
        response = PTTaskCreateTaskingMessageResponse(
            TaskID=taskData.Task.ID,
            Success=True,
        )
        args = taskData.args.get_arg("arguments")
        response.DisplayParams = "-Application {}".format(taskData.args.get_arg("application"))
        if args:
            response.DisplayParams += " -Arguments {}".format(args)
        return response

    async def process_response(self, task: PTTaskMessageAllData, response: any) -> PTTaskProcessResponseMessageResponse:
        resp = PTTaskProcessResponseMessageResponse(TaskID=task.Task.ID, Success=True)
        return resp