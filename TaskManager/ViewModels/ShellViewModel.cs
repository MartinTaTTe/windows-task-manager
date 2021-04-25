using Caliburn.Micro;
using System.Diagnostics;

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

        // Open the view with running processes
        public void LoadRunningProcesses()
        {
            RunningProcessesVM.UpdateProcesses();
            ActivateItem(RunningProcessesVM);
        }

        // Open the view with idle processes
        public void LoadIdleProcesses()
        {
            ActivateItem(IdleProcessesVM);
        }

        // Update the list of running processes
        public void UpdateProcesses()
        {
            RunningProcessesVM.UpdateProcesses();
        }
    }
}

