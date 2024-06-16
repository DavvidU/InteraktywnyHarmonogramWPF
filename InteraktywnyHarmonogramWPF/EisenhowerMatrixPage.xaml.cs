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
using System.Windows.Media.Animation;

namespace InteraktywnyHarmonogramWPF
{
    /// <summary>
    /// Logika interakcji dla klasy Macierz.xaml
    /// </summary>
    public partial class EisenhowerMatrixPage : Page
    {
        public EisenhowerMatrixPage()
        {
            InitializeComponent();
            DataContext = new EisenhowerMatrixViewModel();
            Loaded += EisenhowerMatrixPage_Loaded;
        }
        private void EisenhowerMatrixPage_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)FindResource("ColorAnimationStoryboard");
            sb.Begin(AnimatedTextBlock);
        }
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem item && item.DataContext is Zadanie selectedTask)
            {
                var listView = FindAncestor<ListView>(item);
                string category = GetCategoryByListView(listView);
                var matrixViewModel = (EisenhowerMatrixViewModel)this.DataContext;
                var detailsPage = new TaskDetailsPage(selectedTask, category, matrixViewModel);
                this.NavigationService.Navigate(detailsPage);
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            while (current != null && !(current is T))
            {
                current = VisualTreeHelper.GetParent(current);
            }
            return current as T;
        }

        private string GetCategoryByListView(ListView listView)
        {
            if (listView == null)
                return string.Empty;

            if (listView.Name == "PilneWazneListView")
                return "PW";
            else if (listView.Name == "NiepilneWazneListView")
                return "NW";
            else if (listView.Name == "PilneNiewazneListView")
                return "PN";
            else if (listView.Name == "NiepilneNiewazneListView")
                return "NN";

            return string.Empty;
        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var target = button.Tag.ToString();
            if (target == "MainWindow")
            {
                NavigationService?.GoBack();
            }
            else
            {
                var pageType = Type.GetType("InteraktywnyHarmonogramWPF." + target);
                if (pageType != null)
                {
                    NavigationService?.Navigate(Activator.CreateInstance(pageType));
                }
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
