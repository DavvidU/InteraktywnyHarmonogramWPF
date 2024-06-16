using InteraktywnyHarmonogramWPF.Models;
using InteraktywnyHarmonogramWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InteraktywnyHarmonogramWPF
{
    /// <summary>
    /// Logika interakcji dla klasy DayPage.xaml
    /// </summary>
    public partial class DayPage : Page
    {
        public DayPage()
        {
            InitializeComponent();
        }
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem item && item.DataContext is Zadanie selectedTask)
            {
                var category = "PW"; // Determine the actual category based on the context
                var matrixViewModel = (EisenhowerMatrixViewModel)this.DataContext; // Assuming this is set correctly
                var detailsPage = new TaskDetailsPage(selectedTask, category, matrixViewModel);
                this.NavigationService.Navigate(detailsPage);
            }
        }
        private void AddTask_Click(object sender, RoutedEventArgs e) 
        {
            Button clickedAddTaskButton = sender as Button;

            var addTaskPage = new AddTaskPage { DataContext = new AddTaskViewModel(clickedAddTaskButton.Tag.ToString()) };
            NavigationService.Navigate(addTaskPage);
        }
    }
}
