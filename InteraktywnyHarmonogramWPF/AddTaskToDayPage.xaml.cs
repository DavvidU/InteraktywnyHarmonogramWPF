using InteraktywnyHarmonogramWPF.Models;
using InteraktywnyHarmonogramWPF.ViewModels;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Media.Animation;

namespace InteraktywnyHarmonogramWPF
{
    /// <summary>
    /// Logika interakcji dla klasy AddTaskToDayPage.xaml
    /// </summary>
    public partial class AddTaskToDayPage : Page
    {
        public AddTaskToDayPage()
        {
            InitializeComponent();
            Loaded += AddTaskToDayPage_Loaded;
        }

        private void AddTaskToDayPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)FindResource("ColorAnimationStoryboard");
            sb.Begin(AnimatedTextBlockTask);

            var viewModel = (AddTaskToDayViewModel)DataContext;
            viewModel.TaskSaved += ViewModel_TaskSaved;
        }

        private void ViewModel_TaskSaved(Zadanie task)
        {
            NavigationService.Navigate(new CalendarPage());
        }
    }
}
