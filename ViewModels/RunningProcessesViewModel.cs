using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    class RunningProcessesViewModel
    {
        public BindableCollection<ProcessModel> Processes { get; set; }

        public RunningProcessesViewModel()
        {
            Processes = new BindableCollection<ProcessModel> {
                new ProcessModel("Windows")
           };
        }
    }
}