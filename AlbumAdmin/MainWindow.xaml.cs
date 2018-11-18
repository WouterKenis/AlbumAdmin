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
        private SelectAlbumPage selectAlbumPage;
        private AllAlbums allAlbums;
        public MainWindow()
        {
            InitializeComponent();

            selectAlbumPage = new SelectAlbumPage(this);
            allAlbums = new AllAlbums(this);
        }

        private void allAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(allAlbums);
        }

        private void selectAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(selectAlbumPage);
        }
        private void updateAlbumButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
