
using MusicFiles.Models.Database;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MusicFiles.Models.Repositories
{
    public class ExtensionRepository
    {

        private MusicFilesDb db;


        public ExtensionRepository()
        {
            db = new MusicFilesDb();

        }


        public ICollection<string> GetExtensions()
        {
            ICollection<string> extensions = new List<string>();
            using (SQLiteConnection connection = db.Connect())
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    connection.Open();

                    command.CommandText = "SELECT * FROM " + Tables.EXTENSION_TABLE;
                    command.ExecuteNonQuery();

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            extensions.Add((string)reader[Tables.EXTENSION_TABLE_EXTENSION]);
                        }
                    }
                }
                connection.Close();
            }
            return extensions;
        }

        public void AddExtension(string extension)
        {
            using (SQLiteConnection connection = db.Connect())
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();

                    command.CommandText = $"INSERT INTO {Tables.EXTENSION_TABLE} ({Tables.EXTENSION_TABLE_EXTENSION}) VALUES ('{extension}')";
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void RemoveExtension(string extension)
        {
            using (SQLiteConnection connection = db.Connect())
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();

                    command.CommandText = $"DELETE FROM {Tables.EXTENSION_TABLE} WHERE {Tables.EXTENSION_TABLE_EXTENSION} = '{extension}'";
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}