using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreData
{
    public class GenreRepository
    {
        public static Genre GetGenreById(int genreId)
        {
            Genre genre = null;

            string selectGenres = "SELECT GenreId, Name, Description FROM Genre WHERE GenreId = @GenreId ORDER BY Name";

            SqlConnection connection = MusicStoreDB.GetSqlConnection();

            SqlCommand selectCommand = new SqlCommand
            {
                CommandText = selectGenres,
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
                    genre = new Genre
                    {
                        GenreId = (int)reader["GenreId"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    };
                }
            }
            finally
            {
                connection?.Close();
                reader?.Close();
            }

            return genre;
        }

        public static IList<Genre> GetGenres()
        {
            var genres = new List<Genre>();



            string selectGenres = "SELECT GenreId, Name, Description FROM Genre ORDER BY Name";

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
                    Genre genre = new Genre
                    {
                        GenreId = (int)reader["GenreId"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    };
                    genres.Add(genre);
                }

            }
            finally
            {
                connection?.Close();
                reader?.Close();
            }

            return genres;
        }
    }
}
