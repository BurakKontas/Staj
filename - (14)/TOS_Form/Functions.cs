using TOS_Form.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using TOS_Form.Models.Bank_Models;
using System.Reflection;

namespace TOS_Form
{
    internal class Functions
    {
        private static string pathMain = Environment.CurrentDirectory.Replace("\\bin\\Debug", "");

        public static DataSet SQLLoadData(SQLiteConnection connection, string tableName, string query,bool close = false)
        {
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query,connection);
            DataSet dataSet = new DataSet();
            try
            {
                dataAdapter.Fill(dataSet,tableName);
            } catch { }
            if (close) connection.Close();
            return dataSet;
        }

        public static SQLiteConnection SQLConnect(string dataSource)
        {
            try
            {
                var filePath = $"{pathMain}\\Databases\\{dataSource.Replace(".db", "")}.db";
                var connection = new SQLiteConnection($"Data Source={filePath};Version=3;");
                connection.Open();
                return connection;
            } catch
            {
                return null;
            }
        }

        public static bool SQLCommand(SQLiteConnection connection, string query,bool close = false)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(query, connection)
                {
                    CommandText = query
                };
                command.ExecuteNonQuery();
                if(close) connection.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool SQLDisconnect(SQLiteConnection connection)
        {
            try
            {
                connection.Close();
                return true;
            } catch
            {
                return false;
            }

        }

        public static List<string> GetAllBankModels()
        {
            var path = pathMain + "\\Models\\Bank Models\\";
            var test = Directory.GetFiles(path, "*.cs").ToList();
            var classes = new List<string>();
            test.ForEach(r =>
            {
                classes.Add(r.Replace(path,"").Replace(".cs",""));
            });
            return classes;
        }
        public static bool CreateFile(Header header, Details details, Footer footer, string path)
        {
            try
            {
                List<string> headerList = Enumerable.Repeat(String.Empty, header.Sira.Count).ToList();
                List<string> detailsList = Enumerable.Repeat(String.Empty, details.Sira.Count).ToList();
                List<string> footerList = Enumerable.Repeat(String.Empty, footer.Sira.Count).ToList();

                foreach (var prop in header.GetType().GetProperties())
                {
                    if (prop.GetValue(header, null) != null && prop.GetValue(header, null).GetType() == typeof(Field))
                    {
                        Field value = (Field)prop.GetValue(header, null);
                        if (value._IsAlphaNumeric)
                            value._Data = value._Data.PadRight(value._Length);
                        else
                            value._Data = value._Data.PadLeft(value._Length, '0');

                        if (header.Sira.Contains(prop.Name)) //düzgün şekilde yapılırsa else ye düşmemeli
                        {
                            var index = header.Sira.IndexOf(prop.Name);
                            headerList[index] = value._Data;
                        }
                        else
                            headerList.Add(value._Data);
                    }
                }

                foreach (var prop in details.GetType().GetProperties())
                {
                    if (prop.GetValue(details, null) != null && prop.GetValue(details, null).GetType() == typeof(Field))
                    {
                        Field value = (Field)prop.GetValue(details, null);
                        if (value._IsAlphaNumeric)
                            value._Data = value._Data.PadRight(value._Length);
                        else
                            value._Data = value._Data.PadLeft(value._Length, '0');

                        if (details.Sira.Contains(prop.Name))
                        {
                            var index = details.Sira.IndexOf(prop.Name);
                            detailsList[index] = value._Data;
                        }
                        else
                            detailsList.Add(value._Data);
                    }
                }

                foreach (var prop in footer.GetType().GetProperties())
                {
                    if (prop.GetValue(footer, null) != null && prop.GetValue(footer, null).GetType() == typeof(Field))
                    {
                        Field value = (Field)prop.GetValue(footer, null);
                        if (value._IsAlphaNumeric)
                            value._Data = value._Data.PadRight(value._Length);
                        else
                            value._Data = value._Data.PadLeft(value._Length, '0');

                        if (footer.Sira.Contains(prop.Name))
                        {
                            var index = footer.Sira.IndexOf(prop.Name);
                            footerList[index] = value._Data;
                        }
                        else
                            footerList.Add(value._Data);
                    }
                }

                string headerString = String.Join(String.Empty, headerList.ToArray());
                string detailsString = String.Join(String.Empty, detailsList.ToArray());
                string footerString = String.Join(String.Empty, footerList.ToArray());

                string outputString = headerString + "\n" + detailsString + footerString;

                using (StreamWriter sw = File.CreateText(path)) //if exists overwriting
                {
                    sw.WriteLine(outputString);
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static List<string> GetParameterNames(string selectedBank)
        {
            ConstructorInfo[] selectedClassCtors = null;
            if (selectedBank == "AlternatifBank") selectedClassCtors = typeof(AlternatifBank).GetConstructors();
            if (selectedBank == "YapıKredi") selectedClassCtors = typeof(YapıKredi).GetConstructors();
            
            ParameterInfo[] parameters = selectedClassCtors[0].GetParameters();
            var parameterNames = parameters.Select(p => p.Name).ToList();

            return parameterNames;

        }
    }
}
