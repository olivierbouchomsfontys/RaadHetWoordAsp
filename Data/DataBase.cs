﻿using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;

namespace Data
{
    internal class DataBase
    {
        /// <summary>
        /// SqlConnection object that is used in all the MSSQL contexts.
        /// </summary>
        /// <returns>A SqlConnection object</returns>
        internal static SqlConnection MsSql => new SqlConnection(DataBaseResources.MsSqlConnection);

        /// <summary>
        /// SqlConnection object for logging all exceptions
        /// </summary>
        internal static SQLiteConnection SqLite => new SQLiteConnection(GenerateSqLiteConnectionString());

        private static string FileName => DataBaseResources.SqLiteFile;

        private static string GenerateSqLiteConnectionString()
        {
            var directory = Directory.GetCurrentDirectory().Replace("RaadHetWoordGit", "Data");
            directory = directory.Replace("Tests", "Data");
            for (int i = 0; i < 3; i++)
            {
                directory = directory.Remove(directory.LastIndexOf("\\"));
            }
            return $"Data Source={directory}\\{FileName};Version=3";
        }
    }
}
