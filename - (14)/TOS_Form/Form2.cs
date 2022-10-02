using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TOS_Form.Components;
using TOS_Form.Models.Bank_Models;

namespace TOS_Form
{
    public partial class Form2 : Form
    {
        public static List<EntryWithLabel.InputComponent> inputComponents = new List<EntryWithLabel.InputComponent>();
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string fileName = "";
        private static List<string> parameterNames = null;
        public bool updateMode = false;
        private string selectedID = null;
        public static SQLiteConnection connection = null;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var selectedBank = Form1.SelectedBank.ToString();
            //if came from form3
            if (Form3.selectedNodeID != null)
            {
                selectedID = Form3.selectedNodeID;
                selectedBank = Form3.selectedNodeBankName;
                Form3.selectedNodeBankName = null;
                Form3.selectedNodeID = null;
                updateMode = true;
            }
            //get parameters
            Label bankNameLabel = new Label()
            {
                Text = selectedBank,
                Location = new Point(368, 20),
                TabIndex = 10,
            };
            Controls.Add(bankNameLabel);
            DataSet datas = null;
            connection = Functions.SQLConnect("database");
            var query = $"SELECT * FROM {selectedBank} WHERE id={selectedID};";
            if (updateMode) datas = Functions.SQLLoadData(connection, selectedID, query,true);

            parameterNames = Functions.GetParameterNames(selectedBank);

            //GroupBox
            var containerCreator = new EntryWithLabel();
            var posx = 30;
            var posy = 50;
            var incx = 200;
            var incy = 50;
            var i = 1;
            foreach (var parameter in parameterNames)
            {
                var obj = containerCreator.Create(parameter, posx, posy, Controls);
                if(updateMode) obj.input.Text = datas.Tables[0].Rows[0].ItemArray[i].ToString();
                if (posx - 30 == incx * 3)
                {
                    posy += incy;
                    posx = 30;
                }
                else
                {
                    posx += incx;
                }
                inputComponents.Add(obj);
                i++;
            }
        }

        private void DataForm_Save_Button_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedBank = Form1.SelectedBank.ToString();
                bool result = false;
                List<string> texts = new List<string>();
                texts = inputComponents.Select(p => p.input.Text).ToList();
                if (selectedBank == "AlternatifBank")
                {
                    AlternatifBank bank = new AlternatifBank(texts[0], texts[1], texts[2], texts[3], texts[4], texts[5], texts[6], texts[7], texts[8], texts[9], texts[10], texts[11], texts[12], texts[13], texts[14], texts[15], texts[16], texts[17], texts[18], texts[19], texts[20], texts[21], texts[22], texts[23], texts[24], texts[25]);
                    fileName = "\\TOS_Test.txt";
                    result = Functions.CreateFile(bank.header, bank.details, bank.footer, path + fileName);
                }
                else if (selectedBank == "YapıKredi")
                {
                    YapıKredi bank = new YapıKredi(texts[0], texts[1], texts[2], texts[3], texts[4], texts[5], texts[6]);
                    fileName = "\\TOS_Test.txt";
                    result = Functions.CreateFile(bank.header, bank.details, bank.footer, path + fileName);
                }

                var createTableQueryParameters = string.Join(" TEXT, ", parameterNames);
                var insertTableParameters = string.Join(",", parameterNames);
                var textsWithNulls = new List<string>();
                texts.ForEach(r =>
                {
                    if (r == "") textsWithNulls.Add("null");
                    else textsWithNulls.Add(r);
                });
                var insertTableValues = string.Join(",", textsWithNulls);
                connection = Functions.SQLConnect("database");
                var maxIDTable = Functions.SQLLoadData(connection, "MaxID" ,$"SELECT MAX(id) as max_id FROM {selectedBank}",true);
                var id = 1;
                try
                {
                    id = Convert.ToInt32(maxIDTable.Tables[0].Rows[0].ItemArray[0]) + 1;
                }
                catch
                {
                    id = 1;
                }

                DialogResult dResult = DialogResult.Cancel;

                if (updateMode) 
                {
                    dResult = MessageBox.Show("Want update record ?","Update ?", MessageBoxButtons.YesNo);
                    if(dResult == DialogResult.No) return;
                } else
                {
                    dResult = MessageBox.Show("Save record ?", "Save ?", MessageBoxButtons.YesNoCancel);
                }
                if (dResult == DialogResult.Yes)
                {
                    var createTableQuery = $"CREATE TABLE IF NOT EXISTS {selectedBank} (id TEXT,{createTableQueryParameters} TEXT);";
                    var createLogTableQuery = $"CREATE TABLE IF NOT EXISTS LOG (date TEXT,mode TEXT,user TEXT,sqlcommand TEXT);";
                    var insertTableQuery = $"INSERT INTO {selectedBank}(id,{insertTableParameters}) VALUES ({id},{insertTableValues})";
                    if (updateMode)
                    {
                        var updateQueryString = "";
                        var i = 0;
                        foreach(var parameter in parameterNames)
                        {
                            updateQueryString += $"{parameter}={textsWithNulls[i]},";
                            i++;
                        }
                        updateQueryString = updateQueryString.Substring(0,updateQueryString.Length-1); //deleted last comma
                        insertTableQuery = $"UPDATE {selectedBank} SET {updateQueryString} WHERE id={selectedID};";
                    }

                    connection = Functions.SQLConnect("database");
                    Functions.SQLCommand(connection, createTableQuery);
                    Functions.SQLCommand(connection, createLogTableQuery);
                    Functions.SQLCommand(connection, $"INSERT INTO LOG(date,mode,user,sqlcommand) VALUES ('{DateTime.Now.ToString("ddMMyyyyTHHmmss")}','INFO','{Form1.user}','{insertTableQuery}');");
                    Functions.SQLCommand(connection, insertTableQuery,true);
                    DataForm_BackButton_Click(sender, e);

                    MessageBox.Show("Succesfull", "Process Result");
                }
            }
            catch
            {
                MessageBox.Show("An error occurred", "Process Result");
            }
        }

        private void DataForm_BackButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
            inputComponents.Clear(); //inputcomponents is static variable its better to add this line
            updateMode = false;
        }

        private void DataForm_ShowButton_Click(object sender, EventArgs e)
        {
            Process.Start(path + fileName);
        }
    }
}
