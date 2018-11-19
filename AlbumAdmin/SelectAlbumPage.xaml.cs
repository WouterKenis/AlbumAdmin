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

        public SelectAlbumPage()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int albumId = Convert.ToInt32(albumIdTextBox.Text);
                Album album = AlbumRepository.GetAllAbumById(albumId);
                if (album == null) 
                {
                    MessageBox.Show("No album found.");
                }
                else
                {
                    DataContext = album;
                    albumArtistTextBox.Text = ArtistRepository.GetArtistNameById(album.ArtistId).ToString();
                }
                } catch (Exception)
            {
                MessageBox.Show("You did not enter a number");
            }
        }
    }
}
