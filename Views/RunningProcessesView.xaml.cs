using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using TaskManager.Models;
using TaskManager.ViewModels;

namespace TaskManager.Views
{
    /// <summary>
    /// Interaction logic for RunningProcessesView.xaml
    /// </summary>
    public partial class RunningProcessesView : UserControl
    {
        public RunningProcessesView()
        {
            InitializeComponent();
            DataContext = new RunningProcessesViewModel();
        }

        private void ProcessesListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;

            var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth - 10; // take into account vertical scrollbar, 10 is a mystery number

            // Relative width of columns
            var name = 0.40;
            var description = 0.60;

            gView.Columns[0].Width = workingWidth * name;
            gView.Columns[1].Width = workingWidth * description;
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null)
            {
                var process = item.Content as Process;
                var vm = (RunningProcessesViewModel)DataContext;
                vm.SelectedProcess = process;
            }
        }
    }
}
