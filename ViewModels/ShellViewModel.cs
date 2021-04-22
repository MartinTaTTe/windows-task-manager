using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TaskManager.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public Process SelectedProcess { get; set; }

        public void LoadRunningProcesses()
        {
            ActivateItem(new RunningProcessesViewModel());
        }
    }
}

