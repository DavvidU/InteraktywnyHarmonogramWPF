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
using InteraktywnyHarmonogramWPF.Helpers;
using InteraktywnyHarmonogramWPF.ViewModels;

namespace InteraktywnyHarmonogramWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            Inicjalizacja init = new Inicjalizacja();
            InitializeComponent();
            DataContext = new MainWindowViewModel(MainContent);
        }
    }
}
