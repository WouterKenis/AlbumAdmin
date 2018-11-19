using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreData
{
    public class ArtistRepository
    {
        public static Artist GetArtistNameById(int artistId)
        {
            Artist artist = null;

            string selectAlbums = "SELECT ArtistId, Name FROM Artist WHERE ArtistId = @ArtistId";

            SqlConnection connection = MusicStoreDB.GetSqlConnection();

            SqlCommand selectCommand = new SqlCommand
            {
                CommandText = selectAlbums,
                Connection = connection
            };
            selectCommand.Parameters.AddWithValue("@ArtistId", artistId);

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    artist = new Artist
                    {
                        ArtistId = (int)reader["ArtistId"],
                        Name = reader["Name"].ToString(),
                    };


                }

            }
            finally
            {
                connection?.Close();
                reader?.Close();
            }

            return artist;
        }

        public static IList<Artist> GetArtists()
        {
            var artists = new List<Artist>();

            string selectGenres = "SELECT ArtistId, Name FROM Artist ORDER BY Name";

            SqlConnection connection = MusicStoreDB.GetSqlConnection();

            SqlCommand selectCommand = new SqlCommand
            {
                CommandText = selectGenres,
                Connection = connection
            };

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Artist artist = new Artist
                    {
                        ArtistId = (int)reader["ArtistId"],
                        Name = reader["Name"].ToString()
                    };
                    artists.Add(artist);
                }

            }
            finally
            {
                connection?.Close();
                reader?.Close();
            }

            return artists;
        }

    }
}
