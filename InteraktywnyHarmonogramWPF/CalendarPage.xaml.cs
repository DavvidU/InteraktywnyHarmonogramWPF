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
    /// Logika interakcji dla klasy Kalendarz.xaml
    /// </summary>
    public partial class CalendarPage : Page
    {
        public CalendarPage()
        {
            InitializeComponent();
        }
        private void CalendarControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement fe && fe.DataContext is DateTime)
            {
                DateTime selectedDate = (DateTime)fe.DataContext;
                var detailsPage = new DayPage { DataContext = new DayViewModel(selectedDate) };
                this.NavigationService.Navigate(detailsPage);
            }
        }
    }
}
