
using MusicFiles.Models;
using MusicFiles.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MusicFiles.Persistence.Repositories
{
    public class DirectoryRepository
    {
        private MusicFilesDb db;


        public DirectoryRepository()
        {
            db = new MusicFilesDb();
        }

        /// <summary>
        /// Returns the paths of all directories
        /// </summary>
        /// <returns>A list of stringts with the absolute paths of each directory</returns>
        public ICollection<MusicDirectory> GetDirectories()
        {
            ICollection<MusicDirectory> directories = new List<MusicDirectory>();
            using (SQLiteConnection connection = db.Connect())
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    connection.Open();

                    command.CommandText = "SELECT * FROM " + Tables.DIRECTORY_TABLE;
                    command.ExecuteNonQuery();

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string path = (string)reader[Tables.DIRECTORY_TABLE_PATH];
                            directories.Add(new MusicDirectory(path));
                        }
                    }
                }
                connection.Close();
            }

            return directories;
        }

        /// <summary>
        /// Adds a directory path to the database
        /// </summary>
        /// <param name="path">The path to add</param>
        /// <exception cref="ArgumentException">When the path parameter is empty or invalid</exception>
        public void AddDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("The path cannot be empty.");
            }

            using (SQLiteConnection connection = db.Connect())
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();

                    command.CommandText = $"INSERT INTO {Tables.DIRECTORY_TABLE} ({Tables.DIRECTORY_TABLE_PATH}) VALUES ('{path}')";
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void RemoveDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("The path cannot be empty.");
            }

            using (SQLiteConnection connection = db.Connect())
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();

                    command.CommandText = $"DELETE FROM {Tables.DIRECTORY_TABLE} WHERE {Tables.DIRECTORY_TABLE_PATH} = '{path}'";
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void EditDirectory(string oldPath, string newPath)
        {
            using (SQLiteConnection connection = db.Connect())
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = $"UPDATE {Tables.DIRECTORY_TABLE} SET {Tables.DIRECTORY_TABLE_PATH} = '{newPath}' WHERE {Tables.DIRECTORY_TABLE_PATH} = '{oldPath}'";
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}