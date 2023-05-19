+++
title = "Fork and Run Commands"
chapter = false
weight = 102
+++

## What is Fork and Run?

"Fork and Run" is an agent architecture that spawns sacrificial processes in a suspended state to inject shellcode into.

## Fork and Run in YXBqSVSF

YXBqSVSF uses the fork and run architecture for a variety of jobs. These jobs will all first spawn a new process specified by the [`spawnto_x86`](/agents/cuMJKFYD/commands/spawnto_x86) or [`spawnto_x64`](/agents/cuMJKFYD/commands/spawnto_x64) commands. The parent process of these new processes is specified by the [`ppid`](/agents/cuMJKFYD/commands/ppid/) command. Once the process is spawned, YXBqSVSF will use the currently set injection technique to inject into the remote process.

The following commands use the fork and run architecture:

- [`execute_assembly`](/agents/cuMJKFYD/commands/execute_assembly/)
- [`mimikatz`](/agents/cuMJKFYD/commands/mimikatz/)
- [`powerpick`](/agents/cuMJKFYD/commands/powerpick/)
- [`printspoofer`](/agents/cuMJKFYD/commands/printspoofer/)
- [`pth`](/agents/cuMJKFYD/commands/pth/)
- [`dcsync`](/agents/cuMJKFYD/commands/pth/)
- [`spawn`](/agents/cuMJKFYD/commands/spawn/)
- [`execute_pe`](/agents/cuMJKFYD/commands/execute_pe/)