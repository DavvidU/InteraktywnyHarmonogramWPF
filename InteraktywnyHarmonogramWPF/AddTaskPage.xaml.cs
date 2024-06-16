using InteraktywnyHarmonogramWPF.Models;
using InteraktywnyHarmonogramWPF.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
namespace InteraktywnyHarmonogramWPF
{
    /// <summary>
    /// Logika interakcji dla klasy AddTaskPage.xaml
    /// </summary>
    public partial class AddTaskPage : Page
    {
        public AddTaskPage()
        {
            InitializeComponent();
            Loaded += AddTaskPage_Loaded;
        }
        private void AddTaskPage_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)FindResource("ColorAnimationStoryboard");
            sb.Begin(AnimatedTextBlockTask);

            var viewModel = (AddTaskViewModel)DataContext;
            viewModel.TaskSaved += ViewModel_TaskSaved;
        }
        private void ViewModel_TaskSaved(string sender, Zadanie task)
        {

            NavigationService.GoBack();
        }
    }
}
