# Task Manager for Windows

A Windows application that allows the user to view all running processes on their Windows device, as well as close or force kill any of them. It is also possible to start any process.

### Running Processes
![Running Processes](https://github.com/MartinTaTTe/windows-task-manager/blob/master/media/running_processes.png)

In the main view, all running processes are listed and can be sorted either by their name or their description. After selecting a process from the list, it can be terminated either by clicking the `Close` button or the `Force Kill` button.
- `Close` sends a request to terminate the process and might not work for all processes
- `Force Kill` immediately terminates the process

The `Refresh` button refreshes the list of running processes.

### Idle Processes
![Idle Processes](https://github.com/MartinTaTTe/windows-task-manager/blob/master/media/idle_processes.png)

The secondary view lists all processes terminated with the Task Manager during the current session. After selecting a process from the list, it can be restarted by clicking the `Start` button or removed from the list by clicking the `Delete` button.

In order to start a process not in the list, write its name into the box below and click the `Start` button next to it.

## Building
The project can be built by opening `/TaskManager/TaskManager.sln` in Visual Studio 2019.