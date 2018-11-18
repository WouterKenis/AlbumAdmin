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
    /// Interaction logic for SelectAlbumPage.xaml
    /// </summary>
    public partial class SelectAlbumPage : Page
    {
        private MainWindow mainWindow;
        public SelectAlbumPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            IList<Album> albums = AlbumRepository.GetAllAlbums();
            Album album = null;
            //should be getalbumbyid method
            foreach (Album a in albums)
            {
                if (a.AllbumId == Convert.ToInt32(albumIdTextBox.Text))
                {
                    album = a;
                    DataContext = a;
                }
            }
        }
    }
}
