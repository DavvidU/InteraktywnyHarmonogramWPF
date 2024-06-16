using InteraktywnyHarmonogramWPF.Models;
using InteraktywnyHarmonogramWPF.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace InteraktywnyHarmonogramWPF
{
    /// <summary>
    /// Logika interakcji dla klasy TaskDetailsPage.xaml
    /// </summary>
    public partial class TaskDetailsPage : Page
    {
        public TaskDetailsPage(Zadanie zadanie, string kategoria, EisenhowerMatrixViewModel matrixViewModel)
        {
            InitializeComponent();
            var viewModel = new TaskDetailsViewModel(zadanie, kategoria, matrixViewModel);
            viewModel.ActionCompleted += ViewModel_ActionCompleted;
            DataContext = viewModel;
            Loaded += TaskDetailsPage_Loaded;
        }

        private void TaskDetailsPage_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)FindResource("ColorAnimationStoryboard");
            sb.Begin(AnimatedTextBlockDetails);
        }

        private void ViewModel_ActionCompleted()
        {
            NavigationService.GoBack();
        }
    }
}
