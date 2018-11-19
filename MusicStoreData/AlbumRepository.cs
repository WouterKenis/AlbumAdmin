using MusicStoreData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreData
{
    public class AlbumRepository
    {
        public static IList<Album> GetAlbumsByGenre(int genreId)
        {
            var albums = new List<Album>();



            string selectAlbums = "SELECT GenreId, AlbumId, ArtistId, Title, Price, AlbumArtUrl FROM Album WHERE GenreId = @GenreId ORDER BY Title";

            SqlConnection connection = MusicStoreDB.GetSqlConnection();

            SqlCommand selectCommand = new SqlCommand
            {
                CommandText = selectAlbums,
                Connection = connection
            };
            selectCommand.Parameters.AddWithValue("@GenreId", genreId);

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Album album = new Album
                    {
                        AlbumId = (int)reader["AlbumId"],
                        GenreId = (int)reader["Genre"],
                        Title = reader["Title"].ToString(),
                        ArtistId = (int)reader["ArtistId"],
                        Price = (decimal)reader["Price"],
                        AlbumArtUrl = reader["AlbumArtUrl"].ToString()
                    };
                    albums.Add(album);
                }

            }
            finally
            {
                connection?.Close();
                reader?.Close();
            }

            return albums;
        }

        public static IList<Album> GetAllAlbums()
        {
            var albums = new List<Album>();

            string selectAlbums = "SELECT GenreId, AlbumId, ArtistId, Title, Price, AlbumArtUrl FROM Album ORDER BY Title";

            SqlConnection connection = MusicStoreDB.GetSqlConnection();

            SqlCommand selectCommand = new SqlCommand
            {
                CommandText = selectAlbums,
                Connection = connection
            };

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Album album = new Album
                    {
                        AlbumId = (int)reader["AlbumId"],
                        GenreId = (int)reader["GenreId"],
                        Title = reader["Title"].ToString(),
                        ArtistId = (int)reader["ArtistId"],
                        Price = (decimal)reader["Price"],
                        AlbumArtUrl = reader["AlbumArtUrl"].ToString()
                    };
                    albums.Add(album);
                }

            }
            finally
            {
                connection?.Close();
                reader?.Close();
            }

            return albums;
        }
        public static Album GetAllAbumById(int albumId)
        {
            Album album = null;

            string selectAlbum = "SELECT GenreId, AlbumId, ArtistId, Title, Price, AlbumArtUrl FROM Album WHERE AlbumId = @AlbumId";

            SqlConnection connection = MusicStoreDB.GetSqlConnection();

            SqlCommand selectCommand = new SqlCommand
            {
                CommandText = selectAlbum,
                Connection = connection
            };

            selectCommand.Parameters.AddWithValue("@AlbumId", albumId);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                     album = new Album
                    {
                        AlbumId = (int)reader["AlbumId"],
                        GenreId = (int)reader["GenreId"],
                        Title = reader["Title"].ToString(),
                        ArtistId = (int)reader["ArtistId"],
                        Price = (decimal)reader["Price"],
                        AlbumArtUrl = reader["AlbumArtUrl"].ToString()
                    };
                    
                }

            }
            finally
            {
                connection?.Close();
                reader?.Close();
            }

            return album;
        }
    }
}