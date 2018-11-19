using MusicStoreData;
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

namespace AlbumAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void allAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new AllAlbums());
        }

        private void selectAlbumButton_Click(object sender, RoutedEventArgs e) => MainFrame.NavigationService.Navigate(new SelectAlbumPage());
        private void updateAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new UpdateAlbumPage());
        }
    }
}
