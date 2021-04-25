using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public static BindableCollection<Process> Processes { get; set; }

        private RunningProcessesViewModel RunningProcessesVM { get; set; }
        private IdleProcessesViewModel IdleProcessesVM { get; set; }

        public ShellViewModel()
        {
            Processes = new BindableCollection<Process>();
            RunningProcessesVM = new RunningProcessesViewModel();
            IdleProcessesVM = new IdleProcessesViewModel(Processes);

            ActivateItem(RunningProcessesVM);
        }

        public void LoadRunningProcesses()
        {
            RunningProcessesVM.UpdateProcesses();
            ActivateItem(RunningProcessesVM);
        }

        public void LoadIdleProcesses()
        {
            ActivateItem(IdleProcessesVM);
        }

        public void UpdateProcesses()
        {
            RunningProcessesVM.UpdateProcesses();
        }
    }
}

