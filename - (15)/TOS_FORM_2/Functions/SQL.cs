using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOS_FORM_2.Functions
{
    internal class SQL
    {
        private static readonly string pathMain = Environment.CurrentDirectory.Replace("\\bin\\Debug", "");

        public static DataSet LoadData(SQLiteConnection connection, string query, bool close = false)
        {
            try
            {
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, connection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Data");
                return dataSet;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (close) connection.Close();
            }


        }

        public static SQLiteConnection Connect(string dataSource)
        {
            try
            {
                string filePath = $"{pathMain}\\Databases\\{dataSource.Replace(".db", "")}.db";
                SQLiteConnection connection = new SQLiteConnection($"Data Source={filePath};Version=3;");
                connection.Open();
                return connection;
            }
            catch
            {
                return null;
            }
        }

        public static bool Command(SQLiteConnection connection, string query, bool close = false)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(query, connection)
                {
                    CommandText = query
                };
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            } 
            finally
            {
                if (close) connection.Close();

            }

        }

        public static bool Disconnect(SQLiteConnection connection)
        {
            try
            {
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
