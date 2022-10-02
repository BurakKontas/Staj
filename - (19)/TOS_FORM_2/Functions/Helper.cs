using Newtonsoft.Json.Linq;
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
using System.Windows.Forms;
using TOS_FORM_2.FormFunctions.F1;

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
        public static void BankDesignQuery(List<double> priority, List<string> parameterNames, List<string> types, List<bool> isAlphaNumeric, List<int> length)
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

            SQL.Command(connection, $"CREATE TABLE '{newID}' (PRIORITY REAL, PARAMETERNAME TEXT, TYPE TEXT, ISALPHANUMERIC INTEGER, LENGTH INTEGER)");

            for(var i = 0;i < parameterNames.Count; i++)
            {
                SQL.Command(connection, $"INSERT INTO '{newID}' (PRIORITY, PARAMETERNAME, TYPE, ISALPHANUMERIC, LENGTH) VALUES ('{priority[i]}','{parameterNames[i]}','{types[i]}','{Convert.ToInt16(isAlphaNumeric[i])}','{length[i]}')");
            }
            connection.Close();
            SQLiteConnection connection2 = SQL.Connect("bankDetails");
            SQL.Command(connection2, $"INSERT INTO '{Form1.selectedBankCode}' (BANKNAME, DESIGNID) VALUES ('{Form1.selectedBankName}','{newID}')",true);
        }

        public static void BankFileCreate(List<double> priorities,string[] parameters, List<string> types, List<bool> isAlphaNumeric, List<int> length)
        {
            //bankcode = Form1.selectedBankCode
            //This function will create txt files and save them to BankFiles Folder as dynamic names (indicator+ddMMyy_[if indicator+ddMMyy exists add number 1-2-3-4-5...])
            string outputStringHeader = String.Empty;
            string outputStringDetailsAndFooter = String.Empty;
            //I took parameternames with order in newFileAdd so I do not have to sort it again
            //The parameters which have 1.x priority they are header
            int i = 0;
            foreach(double prio in priorities)
            {
                if(prio >= 1 && prio < 2) //between 1-1.9
                {
                    if (isAlphaNumeric[i]) outputStringHeader += parameters[i].PadRight(length[i]);
                    else outputStringHeader += parameters[i].PadLeft(length[i],'0');
                } else
                {
                    if (isAlphaNumeric[i]) outputStringDetailsAndFooter += parameters[i].PadRight(length[i]);
                    else outputStringDetailsAndFooter += parameters[i].PadLeft(length[i], '0');
                }
                i++;
            }

            string outputString = outputStringHeader + "\n" + outputStringDetailsAndFooter;

            SQLiteConnection connection = SQL.Connect("bankDetails");
            DataSet data = SQL.LoadData(connection, $"SELECT * FROM '{Form1.selectedBankCode}'",true);
            string indicator = data.Tables[0].AsEnumerable().Select(dataRow => dataRow.Field<string>("INDICATOR")).ToList()[Form1.selectedDesignIDRowIndex];

            Directory.CreateDirectory($"{SQL.pathMain}\\BankFiles\\{Form1.selectedBankCode}\\");

            string[] files = Directory.GetFiles($"{SQL.pathMain}\\BankFiles\\{Form1.selectedBankCode}",$"{indicator}{DateTime.Now.ToString("ddMMyy")}*.txt");

            string id = String.Empty;
            if (files.Count() > 0) id = $"_{files.Count()+1}";
            using (StreamWriter sw = File.CreateText($"{SQL.pathMain}\\BankFiles\\{Form1.selectedBankCode}\\{indicator}{DateTime.Now.ToString("ddMMyy")}{id}.txt")) //if exists overwriting
            {
                sw.WriteLine(outputString);
            }

            MessageBox.Show($"Dosya\n[{$"{SQL.pathMain}\\BankFiles\\{Form1.selectedBankCode}\\{indicator}{DateTime.Now.ToString("ddMMyy")}{id}.txt"}]\nyoluna kaydedildi.","İşlem Sonucu");
        }
    }
}
