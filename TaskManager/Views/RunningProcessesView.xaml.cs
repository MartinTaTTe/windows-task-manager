using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using TaskManager.Models;
using TaskManager.ViewModels;
using System.Windows.Documents;
using System.ComponentModel;

namespace TaskManager.Views
{
    /// <summary>
    /// Interaction logic for RunningProcessesView.xaml
    /// </summary>
    public partial class RunningProcessesView : UserControl
    {
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;

        public RunningProcessesView()
        {
            InitializeComponent();
            DataContext = new RunningProcessesViewModel();
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
            ListViewItem item = sender as ListViewItem;
            if (item != null)
            {
                var process = item.Content as Process;
                var vm = (RunningProcessesViewModel)DataContext;
                vm.SelectedProcess = process;
            }
        }

        // Sort the list when clicking a header
        private void lvNameColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();

            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                lvProcesses.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;

            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            lvProcesses.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }
    }
}
