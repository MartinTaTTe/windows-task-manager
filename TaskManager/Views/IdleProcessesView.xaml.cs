﻿using Caliburn.Micro;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TaskManager.ViewModels;

namespace TaskManager.Views
{
    /// <summary>
    /// Interaction logic for IdleProcessesView.xaml
    /// </summary>
    public partial class IdleProcessesView : UserControl
    {
        public IdleProcessesView()
        {
            InitializeComponent();
            DataContext = new IdleProcessesViewModel(new BindableCollection<Process>());
        }

        // Update the width of the list columns upon change of window size
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

        // Set the SelectedProcess variable
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            var vm = (IdleProcessesViewModel)DataContext;
            if (item != null)
            {
                var process = item.Content as Process;
                
                vm.SelectedProcess = process;
            }
        }
    }
}
