using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOS_Form.Models.Bank_Models;

namespace TOS_Form
{
    public partial class Form3 : Form
    {
        public static string selectedNodeBankName = null;
        public static string selectedNodeID = null;
        private List<string> banks = Functions.GetAllBankModels();
        public static SQLiteConnection connection = null;
        public bool IsDelete = false;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (IsDelete)
            {
                Form3_SelectButton.Text = "Delete";
            }

            var selectedBank = Form1.SelectedBank.ToString();
            var i = 0;

            var parameterNames = Functions.GetParameterNames(selectedBank);

            banks.ForEach(bank =>
            {
                Form3_TreeView.Nodes.Add(bank);
                connection = Functions.SQLConnect("database");
                string query = $"SELECT * FROM {bank}";
                var datas = Functions.SQLLoadData(connection, bank, query,true);
                if (datas.Tables.Count != 0)
                {
                    var k = 0;
                    foreach (DataRow data in datas.Tables[0].Rows)
                    {
                        var array = data.ItemArray;
                        Form3_TreeView.Nodes[i].Nodes.Add((array[0]).ToString());
                        for(var j = 1; j < array.Length-1; j++)
                        {
                            string pushData = null;
                            if(array[j].ToString() == "") pushData = "null"; 
                            else pushData = array[j].ToString();
                            Form3_TreeView.Nodes[i].Nodes[k].Nodes.Add(parameterNames[j]);
                            Form3_TreeView.Nodes[i].Nodes[k].Nodes[j-1].Nodes.Add(pushData);
                        }
                        k++;
                    }
                    i++;
                }
            });
        }

        private void Form3_SelectButton_Click(object sender, EventArgs e)
        {
            if(selectedNodeID == null)
            {
                MessageBox.Show("Select an Node or press Back button!", "Error");
            } else
            {
                if (IsDelete)
                {
                    connection = Functions.SQLConnect("database");
                    var query = $"DELETE FROM {selectedNodeBankName} WHERE id={selectedNodeID}";
                    Functions.SQLCommand(connection, $"DELETE FROM {selectedNodeBankName} WHERE id={selectedNodeID}");
                    Functions.SQLCommand(connection, $"INSERT INTO LOG(date,mode,user,sqlcommand) VALUES ('{DateTime.Now.ToString("ddMMyyyyTHHmmss")}','INFO','{Form1.user}','{query}');",true);
                    new Form1().Show();
                    Hide();
                } else
                {
                    var form2 = new Form2();
                    form2.updateMode = true;
                    form2.Show();
                    Hide();
                }
            }
        }

        private void Form3_TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(Form3_TreeView.SelectedNode.Level == 1)
            {
                selectedNodeBankName = Form3_TreeView.SelectedNode.Parent.Text;
                selectedNodeID = Form3_TreeView.SelectedNode.Text;
            }
        }

        private void Form3_BackButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            selectedNodeBankName = null;
            selectedNodeID = null;
            Hide();
        }
    }
}
