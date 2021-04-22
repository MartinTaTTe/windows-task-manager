using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Diagnostics;
using System.ComponentModel;

namespace TaskManager.ViewModels
{
    class RunningProcessesViewModel
    {
        public BindableCollection<Process> Processes { get; set; }

        public RunningProcessesViewModel()
        {
            Processes = new BindableCollection<Process>();

            Process[] localAll = Process.GetProcesses();

            foreach (var process in localAll)
            {
                Processes.Add(process);
            }
        }

        
    }
}