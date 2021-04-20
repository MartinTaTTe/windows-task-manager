using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using TaskManager.Models;
using System.Diagnostics;
using System.ComponentModel;

namespace TaskManager.ViewModels
{
    class RunningProcessesViewModel
    {
        public BindableCollection<ProcessModel> Processes { get; set; }

        public RunningProcessesViewModel()
        {
            Processes = new BindableCollection<ProcessModel>();

            Process[] localAll = Process.GetProcesses();

            foreach (var process in localAll)
            {
                Processes.Add(new ProcessModel(process.ProcessName, process.MainWindowTitle));
            }
        }

        
    }
}