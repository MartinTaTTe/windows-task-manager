using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Diagnostics;
using System.ComponentModel;
using TaskManager.Models;

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

            Process[] localAll = Process.GetProcesses();

            foreach (var process in localAll)
            {
                Processes.Add(process);
            }
        }

        public void KillProcess()
        {
            if (SelectedProcess != null)
            {
                SelectedProcess.Kill();
            }
        }
    }
}