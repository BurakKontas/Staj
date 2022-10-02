using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOS_FORM_2.Functions;
using Label = System.Windows.Forms.Label;

namespace TOS_FORM_2.FormFunctions.F1
{
    internal class Combo
    {
        public string selectedBankCode = null;

        public static void AddDataSetToGridView(DataSet dataset, DataGridView dataGridView)
        {
            foreach (DataColumn column in dataset.Tables[0].Columns)
            {
                dataGridView.Columns.Add(column.ToString(), column.ToString());
            }
            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                dataGridView.Rows.Add(row.ItemArray);
            }
        }

        internal void FillGridView(DataGridView dataGridView)
        {
            SQLiteConnection connection = SQL.Connect("bankDetails");
            DataSet dataset = SQL.LoadData(connection, $"SELECT * FROM '0010'");
            AddDataSetToGridView(dataset, dataGridView);
        }

        /// <returns> An Array [0] BankName [1] Design Code [2] Comment </returns>
        internal void GetBankDetails(string bankCode,Label bankNameLabel)
        {
            SQLiteConnection connection = SQL.Connect("bankDetails");
            DataSet data = SQL.LoadData(connection,$"SELECT * FROM '{bankCode}'",true);
            List<List<object>> list = new List<List<object>>();
            foreach(DataRow row in data.Tables[0].Rows)
            {
                list.Add(row.ItemArray.ToList());
            }
            bankNameLabel.Text = list[0][0].ToString(); // all the bank names are same
        }
    }
}
