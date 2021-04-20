using System;
using System.Windows.Controls;
using System.Windows;

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
        }

        private void ProcessesListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;

            var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth - 10; // take into account vertical scrollbar, 10 is a mystery number

            // Relative width of columns
            var name = 0.20;
            var description = 0.80;

            gView.Columns[0].Width = workingWidth * name;
            gView.Columns[1].Width = workingWidth * description;
        }
    }
}
