using Caliburn.Micro;
using System.Diagnostics;
using System.Windows;

namespace TaskManager.ViewModels
{
    class RunningProcessesViewModel
    {
        public BindableCollection<Process> Processes { get; set; }
        public Process SelectedProcess { get; set; }

        public RunningProcessesViewModel()
        {
            Processes = new BindableCollection<Process>();

            SelectedProcess = null;

            UpdateProcesses();
        }

        // Terminate a process by force
        public void KillProcess()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(
                "Are you sure you want to force this process to terminate?",
                "Force Kill Confirmation",
                MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes && SelectedProcess != null)
            {
                SelectedProcess.Kill();
                MoveProcess(SelectedProcess);
            }
        }

        // Request to terminate a process
        public void CloseProcess()
        {
            try
            {
                if (SelectedProcess != null)
                {
                    SelectedProcess.CloseMainWindow();
                    if (SelectedProcess.WaitForExit(500))
                        MoveProcess(SelectedProcess);
                }
            }
            catch
            {
                return;
            }
            
        }

        // Update the list of running processes
        public void UpdateProcesses()
        {
            Processes.Clear();

            Process[] localAll = Process.GetProcesses();

            foreach (var process in localAll)
            {
                Processes.Add(process);
            }
        }

        // Remove a process from the list of running processes and
        // it to the list of idle processes
        private void MoveProcess(Process process)
        {
            ShellViewModel.Processes.Add(process);
            Processes.Remove(process);
        }
    }
}