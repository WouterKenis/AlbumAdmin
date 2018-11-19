using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreData
{
    public class AlbumDB
    {
        public static bool UpdateAlbum(Album album)
        {
            SqlConnection connection = MusicStoreDB.GetSqlConnection();
            var updateCommand = CreateUpdateCommand(album, connection);

            try
            {
                connection.Open();

                int numberOfRowsAffected = updateCommand.ExecuteNonQuery();
                return numberOfRowsAffected > 0;
            }
            finally
            {
                connection?.Close();
            }
        }

        private static SqlCommand CreateUpdateCommand(Album album, SqlConnection connection)
        {
            string updateStatement =
                "Update Album SET " +
                "GenreId = @newGenreId, " +
                "ArtistId = @newArtistId, " +
                "Title = @newTitle, " +
                "Price = @newPrice, " +
                "AlbumArtUrl = @newAlbumArtUrl " +
                "WHERE AlbumId = @AlbumId ";

            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);

            if (album.AlbumArtUrl == "")
            {
                updateCommand.Parameters.AddWithValue("@newAlbumArtUrl", DBNull.Value);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@newAlbumArtUrl", album.AlbumArtUrl);
            }

            updateCommand.Parameters.AddWithValue("@newGenreId", album.GenreId);
            updateCommand.Parameters.AddWithValue("@newArtistId", album.ArtistId);
            updateCommand.Parameters.AddWithValue("@newTitle", album.Title);
            updateCommand.Parameters.AddWithValue("@newPrice", album.Price);
            updateCommand.Parameters.AddWithValue("@AlbumId", album.AlbumId);


            return updateCommand;
        }
    }
}
