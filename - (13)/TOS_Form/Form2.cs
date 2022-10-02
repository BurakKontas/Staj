using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TOS_Form.Components;
using TOS_Form.Models.Bank_Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static TOS_Form.Components.EntryWithLabel;
using static TOS_Form.Functions;

namespace TOS_Form
{
    public partial class Form2 : Form
    {
        private List<InputComponent> inputComponents = new List<InputComponent>();
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string fileName = "";
        private List<string> parameterNames = null;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //get parameters
            var selectedBank = Form1.SelectedBank.ToString();
            Label bankNameLabel = new Label()
            {
                Text = selectedBank,
                Location = new Point(368, 20),
                TabIndex = 10,
            };
            Controls.Add(bankNameLabel);
            ConstructorInfo[] selectedClassCtors = null;
            if (selectedBank == "AlternatifBank") selectedClassCtors = typeof(AlternatifBank).GetConstructors();
            if (selectedBank == "YapıKredi") selectedClassCtors = typeof(YapıKredi).GetConstructors();
            
            ParameterInfo[] parameters = selectedClassCtors[0].GetParameters();

            parameterNames = parameters.Select(p => p.Name).ToList();

            //GroupBox
            var containerCreator = new EntryWithLabel();
            var mainContainer = new GroupBox();
            var posx = 30;
            var posy = 50;
            var incx = 200;
            var incy = 50;
            foreach (var parameter in parameterNames)
            {
                var obj = containerCreator.Create(parameter,posx,posy,Controls);
                if (posx-30 == incx * 3)
                {
                    posy += incy;
                    posx = 30;
                }
                else
                {
                    posx += incx;
                }
                inputComponents.Add(obj);
            }
        }

        private void DataForm_Save_Button_Click(object sender, EventArgs e)
        {
            var selectedBank = Form1.SelectedBank.ToString();
            bool result = false;
            var texts = inputComponents.Select(p => p.input.Text).ToList();
            if (selectedBank == "AlternatifBank")
            {
                AlternatifBank bank = new AlternatifBank(texts[0], texts[1], texts[2], texts[3], texts[4], texts[5], texts[6], texts[7], texts[8], texts[9], texts[10], texts[11], texts[12], texts[13], texts[14], texts[15], texts[16], texts[17], texts[18], texts[19], texts[20], texts[21], texts[22], texts[23], texts[24], texts[25]);
                //mysql kaydet
                fileName = "\\TOS_Test.txt";
                result = Functions.CreateFile(bank.header, bank.details, bank.footer, path + fileName);
            }
            else if(selectedBank == "YapıKredi")
            {
                YapıKredi bank = new YapıKredi();
                fileName = "\\TOS_Test.txt";
                //result = Functions.CreateFile(bank.header, bank.details, bank.footer, path + fileName);
            }

            if (result)
            {
                MessageBox.Show("Success","Process Result");
            }
            else
            {
                MessageBox.Show("An error occurred", "Process Result");
                return; //if error occures returns and does not save it to db
            }

            var createTableQueryParameters = string.Join(" string, ",parameterNames);
            var insertTableParameters = string.Join(",", parameterNames);
            var textsWithNulls = new List<string>();
            texts.ForEach(r => { 
                if (r == "") textsWithNulls.Add("null"); 
                else textsWithNulls.Add(r); 
            });
            var insertTableValues = string.Join(",", textsWithNulls);

            var createTableQuery = $"CREATE TABLE IF NOT EXISTS {selectedBank} ({createTableQueryParameters});";
            var insertTableQuery = $"INSERT INTO {selectedBank}({insertTableParameters}) VALUES ({insertTableValues})";


            SQLiteConnection connection = SQLConnect("database");
            SQLCommand(connection, createTableQuery);
            SQLCommand(connection, insertTableQuery);
            SQLDisconnect(connection);

        }

        private void DataForm_BackButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
            inputComponents.Clear(); //inputcomponents is static variable its better to add this line
        }

        private void DataForm_ShowButton_Click(object sender, EventArgs e)
        {
            Process.Start(path + fileName);
        }
    }
}
