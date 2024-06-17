using InteraktywnyHarmonogramWPF.Models;
using InteraktywnyHarmonogramWPF.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace InteraktywnyHarmonogramWPF
{
    /// <summary>
    /// Logika interakcji dla klasy TaskDetailsForDayPage.xaml
    /// </summary>
    public partial class TaskDetailsForDayPage : Page
    {
        public TaskDetailsForDayPage(Zadanie zadanie, DayViewModel dayViewModel)
        {
            InitializeComponent();
            var viewModel = new TaskDetailsForDayViewModel(zadanie, dayViewModel);
            viewModel.ActionCompleted += ViewModel_ActionCompleted;
            DataContext = viewModel;
            Loaded += TaskDetailsForDayPage_Loaded;
        }

        private void TaskDetailsForDayPage_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)FindResource("ColorAnimationStoryboard");
            sb.Begin(AnimatedTextBlockDetails);
        }

        private void ViewModel_ActionCompleted()
        {
            NavigationService.Navigate(new CalendarPage());
        }
    }
}
