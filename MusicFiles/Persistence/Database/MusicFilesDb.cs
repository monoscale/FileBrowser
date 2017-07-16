using System.Data.SQLite;
using System.IO;

namespace MusicFiles.Persistence.Database
{
    public class MusicFilesDb
    {
        private const string dbName = "musicfiles.sqlite";
        private const string sqliteVersion = "3";
        private const string connectionString = "Data Source=" + dbName + ";Version=" + sqliteVersion;


        private const string folderTable =
            "CREATE TABLE IF NOT EXISTS " + "[" + Tables.DIRECTORY_TABLE + "] " +
            "([" + Tables.DIRECTORY_TABLE_PATH + "] VARCHAR(100))";

        private const string extensionTable =
            "CREATE TABLE IF NOT EXISTS [" + Tables.EXTENSION_TABLE + "]" +
            " ([" + Tables.EXTENSION_TABLE_EXTENSION + "] VARCHAR(8))";


        /// <summary>
        /// Default constructor for MusicFilesDb
        /// </summary>
        public MusicFilesDb()
        {
            CreateDatabaseIfNotExists();
        }

        /// <summary>
        /// Creates the SQLite database file if it does not yet exist on the filesystem
        /// </summary>
        public void CreateDatabaseIfNotExists()
        {
            if (File.Exists(dbName))
            {
                return;
            }

            SQLiteConnection.CreateFile(dbName);
            using (SQLiteConnection connection = Connect())
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();

                    command.CommandText = folderTable;
                    command.ExecuteNonQuery();

                    command.CommandText = extensionTable;
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        /// <summary>
        /// Returns a SQLite connection
        /// </summary>
        /// <returns></returns>
        public SQLiteConnection Connect()
        {
            return new SQLiteConnection(connectionString);
        }
    }
}