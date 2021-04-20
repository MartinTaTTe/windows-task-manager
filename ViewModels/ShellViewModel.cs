using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public void LoadRunningProcesses()
        {
            ActivateItem(new RunningProcessesViewModel());
        }
    }
}

