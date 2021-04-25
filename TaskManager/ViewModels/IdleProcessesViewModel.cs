using Caliburn.Micro;
using System.Diagnostics;

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

        // Start the currently selected process
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

        // Delete the currently selected process from the list
        public void DeleteProcess()
        {
            Processes.Remove(SelectedProcess);
        }

        // Start the process named in the text box
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
