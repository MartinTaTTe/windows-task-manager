using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Diagnostics;
using System.ComponentModel;
using TaskManager.Models;
using System.Timers;
using System.Windows;

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

            UpdateProcesses();
        }

        public void KillProcess()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(
                "Are you sure you want to force this process to terminate?",
                "Force Kill Confirmation",
                MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes && SelectedProcess != null)
            {
                SelectedProcess.Kill();
                MoveProcess(SelectedProcess);
            }
        }

        public void CloseProcess()
        {
            try
            {
                if (SelectedProcess != null)
                {
                    SelectedProcess.CloseMainWindow();
                    if (SelectedProcess.WaitForExit(500))
                        MoveProcess(SelectedProcess);
                }
            }
            catch
            {
                return;
            }
            
        }

        public void UpdateProcesses()
        {
            Processes.Clear();

            Process[] localAll = Process.GetProcesses();

            foreach (var process in localAll)
            {
                Processes.Add(process);
            }
        }

        private void MoveProcess(Process process)
        {
            ShellViewModel.Processes.Add(process);
            Processes.Remove(process);
        }
    }
}