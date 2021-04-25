using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Diagnostics;
using System.ComponentModel;
using TaskManager.Models;
using System.Timers;

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

        public void KillProcess()
        {
            if (SelectedProcess != null)
            {
                MoveProcess(SelectedProcess);
                SelectedProcess.Kill();
            }
        }

        public void CloseProcess()
        {
            if (SelectedProcess != null)
            {
                MoveProcess(SelectedProcess);
                SelectedProcess.CloseMainWindow();
            }
        }

        public void UpdateProcesses()
        {
            Processes.Clear();

            Process[] localAll = Process.GetProcesses();

            foreach (var process in localAll)
            {
                Processes.Add(process);
            }
        }

        private void MoveProcess(Process process)
        {
            ShellViewModel.Processes.Add(process);
            Processes.Remove(process);
        }
    }
}