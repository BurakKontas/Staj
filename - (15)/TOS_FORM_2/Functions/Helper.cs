using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TOS_FORM_2.Functions
{
    internal class Helper
    {
        /// <summary>
        /// This functions merges values and types for sql query values
        /// </summary>
        /// <returns>SQL Query Values String</returns>
        public static string MergeValueAndType(List<string> values, List<string> types)
        {
            string parameterString = String.Empty;
            int i = 0;
            foreach(var value in values)
            {
                parameterString = $"{((i == 0) ? "" : ",")} {value} {((i < types.Count) ? types[i].ToUpper() : "TEXT")}";
                i++;
            }
            return parameterString;
        }

        /// <summary>
        /// This function creates new bank design for SQL (all list lengths must be equal)
        /// </summary>
        public static void BankDesignQuery(List<int> priority, List<string> parameterNames, List<string> types, List<bool> isAlphaNumeric, List<int> length)
        {
            SQLiteConnection connection = SQL.Connect("bankDesigns");
            DataSet tableCount = SQL.LoadData(connection, $"SELECT MAX(name) FROM sqlite_master WHERE type = 'table'");
            int newID = 0;
            try
            {
                newID = Convert.ToInt16(tableCount.Tables[0].Rows[0].ItemArray[0]) + 1;
            } catch 
            {
                newID++;
            }

            SQL.Command(connection, $"CREATE TABLE {newID} (PRIORITY INTEGER, PARAMETERNAME TEXT, TYPE TEXT, ISALPHANUMERIC INTEGER, LENGTH INTEGER)");

            for(var i = 0;i < parameterNames.Count; i++)
            {
                SQL.Command(connection, $"INSERT INTO {newID} (PRIORITY, PARAMETERNAME, TYPE, ISALPHANUMERIC, LENGTH) VALUES ({priority[i]},{parameterNames[i]},{types[i]},{Convert.ToInt16(isAlphaNumeric[i])},{length[i]})");
            }
            connection.Close();
        }
    }
}
