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
                ShellViewModel.Processes.Add(SelectedProcess);
                SelectedProcess.Kill();
                Processes.Remove(SelectedProcess);
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
    }
}