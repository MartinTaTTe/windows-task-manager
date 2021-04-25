using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    class IdleProcessesViewModel
    {
        public BindableCollection<Process> Processes { get; set; }
        public Process SelectedProcess { get; set; }
        public string CustomProcess { get; set; } = "";

        public IdleProcessesViewModel(BindableCollection<Process> processes)
        {
            Processes = processes;

            SelectedProcess = null;
        }

        public void StartProcess()
        {
            try
            {
                if (SelectedProcess != null)
                {
                    SelectedProcess.StartInfo.FileName = SelectedProcess.ProcessName + ".exe";
                    SelectedProcess.Start();
                    Processes.Remove(SelectedProcess);
                }
            }
            catch
            {
                Processes.Remove(SelectedProcess);
            }
        }

        public void StartCustomProcess()
        {
            try
            {
                if (!CustomProcess.EndsWith(".exe"))
                    CustomProcess += ".exe";
                Process.Start(CustomProcess);
            }
            catch
            {
                return;
            }
        }
    }
}
