+++
title = "Process Injection"
chapter = false
weight = 102
+++

## Process Injection in YXBqSVSF

YXBqSVSF has abstracted process injection into its own project and has the following techniques implemented:
- CreateRemoteThread
- QueueUserAPC (early bird)
- NtCreateThreadEx (via Syscalls)

As an operator, sometimes one injection technique is more desirable than another. To facilitate this, the [`get_injection_techniques`](/agents/cuMJKFYD/commands/get_injection_techniques) command will list all currently loaded injection techniques the agent knows about. Similarly, [`set_injection_technique`](/agents/cuMJKFYD/commands/set_injection_technique) will update the currently used injection technique throughout all post-exploitation jobs.

## Commands Leveraging Injection

All of YXBqSVSF's [fork and run commands](/agents/cuMJKFYD/opsec/forkandrun/) use injection to inject into a sacrificial process; however, there are additional commands that inject into other processes. Those commands are:

- [`assembly_inject`](/agents/cuMJKFYD/commands/assembly_inject/)
- [`inject`](/agents/cuMJKFYD/commands/inject/)
- [`keylog_inject`](/agents/cuMJKFYD/commands/keylog/)
- [`psinject`](/agents/cuMJKFYD/commands/psinject/)
- [`shinject`](/agents/cuMJKFYD/commands/shinject/)
- [`screenshot_inject`](/agents/cuMJKFYD/commands/screenshot_inject)

{{% notice info %}}
Some injection techniques are incompatible with the aforementioned commands. For example: If QueueUserAPC is in use, the above commands will fail as it leverages the early bird version of QueueUserAPC, not the APC bombing technique. 
{{% /notice %}}