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
            IList<Artist> allArtists = ArtistRepository.GetArtists();
            IList<Genre> allGenres = GenreRepository.GetGenres();

            Album updatedAlbum = new Album();

            updatedAlbum.AlbumArtUrl = albumArtUrlTextBox.Text;
            updatedAlbum.AlbumId = Int32.Parse(albumIdTextBox.Text);
            //need ArtistId
            //need GenreId
            string bla = albumPriceTextBox.Text.Replace('.', ',');
            decimal d = decimal.Parse(bla);
            updatedAlbum.Price = Convert.ToDecimal(d);
            updatedAlbum.Title = albumTitleTextBox.Text;

            foreach (Artist a in allArtists)
            {
                var currentArtist = (Artist)artistComboBox.SelectedItem;
                if (a.ArtistId == currentArtist.ArtistId)
                {
                    updatedAlbum.ArtistId = currentArtist.ArtistId;
                }
            }
            foreach (Genre g in allGenres)
            {
                var currentGenre = (Genre)genreComboBox.SelectedItem;
                if (g.GenreId == currentGenre.GenreId)
                {
                    updatedAlbum.GenreId = currentGenre.GenreId;
                }
            }
            bool succeeded = AlbumDB.UpdateAlbum(updatedAlbum);

            if (succeeded)
            {
                MessageBox.Show("Done.");
            }
            else
            {
                MessageBox.Show("Failed.");
            }
        }
    }
}
