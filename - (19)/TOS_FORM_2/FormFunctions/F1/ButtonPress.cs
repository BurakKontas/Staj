using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOS_FORM_2.Functions;

namespace TOS_FORM_2.FormFunctions.F1
{
    internal class ButtonPress
    {
        internal void NewBankDesignButtonClick(DataGridView dataGridView)
        {
            if (Form1.mode.First() != "bankDesignAdd")
            {
                //PRIORITY, PARAMETERNAME, TYPE, ISALPHANUMERIC, LENGTH
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                dataGridView.Columns.Add("PRIORITY", "Öncelik");
                dataGridView.Columns.Add("PARAMETERNAME", "İsim");
                dataGridView.Columns.Add("TYPE", "Tip");
                dataGridView.Columns.Add("ISALPHANUMERIC", "Alfanümerik");
                dataGridView.Columns.Add("LENGTH", "Uzunluk");
                dataGridView.Rows.Add();
                Form1.mode.Push("bankDesignAdd");
            }
        }

        internal void SaveButtonClick(DataGridView dataGridView)
        {
            string mode = Form1.mode.First();
            if (mode == "bankDesignAdd")
            {
                List<double> priority = new List<double>();
                List<string> parameterNames = new List<string>();
                List<string> types = new List<string>();
                List<bool> isAlphaNumeric = new List<bool>();
                List<int> length = new List<int>();

                int j = 0;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        if (row.Cells[i].EditedFormattedValue.ToString() == String.Empty)
                        {
                            MessageBox.Show($"[{j}][{i}] Boş!", "Hata!");
                            return;
                        }
                    }
                    DataGridViewCellCollection cells = row.Cells;
                    priority.Add(Convert.ToDouble(cells[0].EditedFormattedValue.ToString()));
                    parameterNames.Add(cells[1].EditedFormattedValue.ToString());
                    types.Add(cells[2].EditedFormattedValue.ToString().ToUpper());
                    isAlphaNumeric.Add(Convert.ToBoolean(Convert.ToInt16(cells[3].EditedFormattedValue.ToString())));
                    length.Add(Convert.ToInt16(cells[4].EditedFormattedValue.ToString()));
                    j++;
                }

                Helper.BankDesignQuery(priority, parameterNames, types, isAlphaNumeric, length);
                MessageBox.Show("Başarıyla Kaydedildi", "Başarılı İşlem");
                Combo combo = new Combo();
                combo.FillGridView(dataGridView);
                Form1.mode.Pop();
            } 
            else if(mode == "bankCodeAdd")
            {
                List<string> codes = Load.GetBankCodes();
                SQLiteConnection connection = SQL.Connect("bankCodes");
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    DataGridViewCellCollection cells = row.Cells;
                    if (codes.Contains(cells[0].EditedFormattedValue.ToString())) continue;
                    SQL.Command(connection,$"INSERT INTO BANKCODES(CODE) VALUES('{cells[0].EditedFormattedValue.ToString()}')");
                }
                connection.Close();
            } 
            else if(mode == "bankDetailsAdd")
            {
                SQLiteConnection connection = SQL.Connect("bankDetails");
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    DataGridViewCellCollection cells = row.Cells;
                    SQL.Command(connection, $"INSERT INTO '{Form1.selectedBankCode}'(BANKNAME,DESIGNID,COMMENT,INDICATOR) VALUES('{cells[0].EditedFormattedValue.ToString()}',{cells[1].EditedFormattedValue.ToString()},'{cells[2].EditedFormattedValue.ToString()}','{cells[3].EditedFormattedValue.ToString()}')");
                }
                connection.Close();
            }
            else if(mode == "newFileAdd")
            {
                SQLiteConnection filesConnection = SQL.Connect("bankFiles");
                SQLiteConnection designConnection = SQL.Connect("bankDesigns");
                DataSet data = SQL.LoadData(designConnection, $"SELECT * FROM '{Form1.selectedDesignID}' ORDER BY PRIORITY", true);

                List<double> priorities = data.Tables[0].AsEnumerable().Select(dataRow => dataRow.Field<double>("PRIORITY")).ToList();
                List<string> parameterNames = data.Tables[0].AsEnumerable().Select(dataRow => dataRow.Field<string>("PARAMETERNAME")).ToList();
                List<string> types = data.Tables[0].AsEnumerable().Select(dataRow => dataRow.Field<string>("TYPE")).ToList();
                List<bool> isAlphaNumeric = data.Tables[0].AsEnumerable().Select(dataRow => Convert.ToBoolean(dataRow.Field<Int64>("ISALPHANUMERIC"))).ToList();
                List<int> length = data.Tables[0].AsEnumerable().Select(dataRow => Convert.ToInt32(dataRow.Field<Int64>("LENGTH"))).ToList();

                string queryValues = string.Join(" TEXT,", parameterNames) + " TEXT";

                SQL.Command(filesConnection, $"CREATE TABLE IF NOT EXISTS '{Form1.selectedBankCode}_{Form1.selectedDesignID}' (CREATEDATE TEXT,USER TEXT,{queryValues})");
                
                string valuesString = String.Empty;
                int j = 0;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    DataGridViewCellCollection cells = row.Cells;
                    for(int i = 0; i < cells.Count; i++)
                    {
                        valuesString += $"'{cells[i].Value.ToString()}' ,";
                    }
                    valuesString = valuesString.Substring(0, valuesString.Length - 1);
                    string query = $"INSERT INTO '{Form1.selectedBankCode}_{Form1.selectedDesignID}'(CREATEDATE,USER,{string.Join(",", parameterNames)}) VALUES('{DateTime.Now.ToString("ddMMyyyyTHHmmss")}', '{Form1.User}', {valuesString})";
                    SQL.Command(filesConnection, query);

                    Helper.BankFileCreate(priorities,valuesString.Replace("'","").Split(','),types,isAlphaNumeric,length);
                    j++;
                }
                filesConnection.Close();
            }
            MessageBox.Show("İşlem Başarıyla Sonlandı.", "Bilgilendirme");
            HomePageButtonClick(dataGridView, true);
        }

        internal void NewBankCodeButtonClick(DataGridView dataGridView)
        {
            Form1.mode.Push("bankCodeAdd");
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("Code", "Banka Kodu");
            dataGridView.Rows.Add();
        }

        internal void NewBankDetailButtonClick(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("BANKNAME","Banka Adı");
            dataGridView.Columns.Add("DESIGNID","Desen ID");
            dataGridView.Columns.Add("COMMENT","Açıklama");
            dataGridView.Columns.Add("INDICATOR","İndicatör");
            dataGridView.Rows.Add();
        }

        internal void NewRowButtonClick(DataGridView dataGridView)
        {
            if(!dataGridView.ReadOnly) dataGridView.Rows.Add();
        }

        internal void HomePageButtonClick(DataGridView dataGridView,bool direct = false)
        {
            if (Form1.mode.Count != 1)
            {
                string oldMode = Form1.mode.Pop();
                DialogResult dResult;
                if (Form1.editOnModes.Contains(oldMode) && !direct) dResult = MessageBox.Show("Tüm yaptıklarınız kaydetmediyseniz silinecek emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo);
                else dResult = DialogResult.Yes;
                if (dResult == DialogResult.Yes || direct)
                {
                    Form1.mode.Clear();
                    Form1.mode.Push("bankDetails");
                    Combo combo = new Combo();
                    combo.FillGridView(dataGridView);
                }
                else
                {
                    Form1.mode.Push(oldMode);
                }
            }
        }

        internal void NewFileButtonClick(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            Form1.mode.Push("newFileAdd");
            SQLiteConnection connection = SQL.Connect("bankDesigns");
            DataSet data = SQL.LoadData(connection, $"SELECT * FROM '{Form1.selectedDesignID}'",true);
            List<string> parameterNames = data.Tables[0].AsEnumerable().Select(dataRow => dataRow.Field<string>("PARAMETERNAME")).ToList();
            parameterNames.ForEach(name =>
            {
                dataGridView.Columns.Add(name,name);
            });
            dataGridView.Rows.Add();
        }

        internal void EditModeButtonClick(DataGridView dataGridView1, EventArgs e)
        {
            //we will write a query that includes all entries values in where then change all properties (same ones will remain same)
            //we'll choose table and database with Form1.mode
            //do this all in save button function... what a mess
            //this function only will change Form1.mode
            //and we will keep tracking rows at onEditEnd, Validating or onEditBegin event
        }
    }
}
