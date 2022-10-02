using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOS_FORM_2.Functions;
using ComboBox = System.Windows.Forms.ComboBox;
using Label = System.Windows.Forms.Label;

namespace TOS_FORM_2.FormFunctions.F1
{
    internal class Combo
    {
        public static void AddDataSetToGridView(DataSet dataset, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
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
            string query = "SELECT name FROM sqlite_master WHERE type='table'";
            DataSet data = SQL.LoadData(connection, query,true);
            List<string> allCodes = data.Tables[0].AsEnumerable().Select(dataRow => dataRow.Field<string>("name")).ToList();
            List<string> codesWithBankNames = new List<string>();
            DataSet temp;
            allCodes.ForEach(code =>
            {
                temp = SQL.LoadData(connection, $"SELECT * FROM '{code}'");
                if (temp.Tables[0].Rows.Count > 0) codesWithBankNames.Add(code);
                temp = null;
            });
            connection.Close();
            DataSet dataset = SQL.LoadData(connection, $"SELECT * FROM '{codesWithBankNames[0]}'");
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
            Form1.selectedBankName = bankNameLabel.Text;
        }

        internal void selectedIndexChanged(ComboBox comboBox, Label label, DataGridView dataGridView)
        {
            string query = "SELECT name FROM sqlite_master WHERE type='table'";
            SQLiteConnection connection = SQL.Connect("bankDetails");
            DataSet data = SQL.LoadData(connection, query);
            List<string> allCodes = data.Tables[0].AsEnumerable().Select(dataRow => dataRow.Field<string>("name")).ToList();
            List<string> codesWithBankNames = new List<string>();
            DataSet temp;
            allCodes.ForEach(code =>
            {
                temp = SQL.LoadData(connection, $"SELECT * FROM '{code}'");
                if (temp.Tables[0].Rows.Count > 0) codesWithBankNames.Add(code);
                temp = null;
            });
            connection.Close();
            if (Form1.mode.First() == "bankDetails")
            {
                if (codesWithBankNames.Contains(comboBox.SelectedItem.ToString()))
                {
                    Form1.selectedBankCode = comboBox.SelectedItem.ToString();
                    GetBankDetails(Form1.selectedBankCode, label);
                    //fill dataset
                    FillGridView(dataGridView);
                } 
                else
                {
                    DialogResult dResult = MessageBox.Show($"{comboBox.SelectedItem.ToString()} için bir detay eklememişsiniz.\nEklemek İster Misiniz ?", "Hata!",MessageBoxButtons.YesNo);
                    if(dResult == DialogResult.Yes)
                    {
                        ButtonPress buttonPress = new ButtonPress();
                        label.Text = "Yeni Ekleniyor";
                        comboBox.Enabled = false;
                        Form1.mode.Push("bankDetailsAdd");
                        buttonPress.NewBankDetailButtonClick(dataGridView);
                    } 
                    else
                    {
                        comboBox.SelectedItem = Form1.selectedBankCode;
                    }
;               }

            }
        }
    }
}
