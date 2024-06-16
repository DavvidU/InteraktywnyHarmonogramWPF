using InteraktywnyHarmonogramWPF.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InteraktywnyHarmonogramWPF
{
    /// <summary>
    /// Logika interakcji dla klasy CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage : Page
    {
        public CalendarPage()
        {
            InitializeComponent();
        }

        private void CalendarControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CalendarControl.SelectedDate.HasValue)
            {
                DateTime selectedDate = CalendarControl.SelectedDate.Value;
                var detailsPage = new DayPage { DataContext = new DayViewModel(selectedDate) };
                this.NavigationService.Navigate(detailsPage);
            }
        }
    }
}
