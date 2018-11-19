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
    /// Interaction logic for UpdateAlbumPage.xaml
    /// </summary>
    public partial class UpdateAlbumPage : Page
    {
        public UpdateAlbumPage()
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
                    artistComboBox.ItemsSource = ArtistRepository.GetArtists();
                    genreComboBox.ItemsSource = GenreRepository.GetGenres();

                    artistComboBox.SelectedValue = ArtistRepository.GetArtistNameById(album.ArtistId);
                    genreComboBox.SelectedValue = GenreRepository.GetGenreById(album.GenreId);

                    int artistIndex = 0;

                    foreach (Artist a in artistComboBox.Items)
                    {
                        if (a.ArtistId == album.ArtistId)
                        {
                            artistComboBox.SelectedIndex = artistIndex;
                        }
                        artistIndex++;
                    }
                    int genreIndex = 0;

                    foreach (Genre a in genreComboBox.Items)
                    {
                        if (a.GenreId == album.GenreId)
                        {
                            genreComboBox.SelectedIndex = genreIndex;
                        }
                        genreIndex++;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You did not enter a number");
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
