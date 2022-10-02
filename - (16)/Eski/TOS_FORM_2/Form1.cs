using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOS_FORM_2.FormFunctions.F1;
using TOS_FORM_2.Functions;

namespace TOS_FORM_2
{
    public partial class Form1 : Form
    {
        public static string mode = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Load load = new Load();
            load.FirstChecks();
            load.FillComboBox(comboBox1);
            mode = "bankDetails";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Combo combo = new Combo();
            combo.selectedBankCode = comboBox1.SelectedItem.ToString();
            combo.GetBankDetails(combo.selectedBankCode,label1);
            //fill dataset
            combo.FillGridView(dataGridView1);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool isReadOnly = dataGridView1.ReadOnly;
            if(isReadOnly)
            {
                GridView gridView = new GridView();
                gridView.onCellDoubleClick(dataGridView1, e);
            }
        }

        private void dataGridView1_UserDeletingRows(object sender, DataGridViewRowCancelEventArgs e)
        {
            bool isReadOnly = dataGridView1.ReadOnly;
            if (isReadOnly)
            {
                GridView gridView = new GridView();
                gridView.onDeletingRows(e);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GridView gridView = new GridView();
            gridView.onEndEditCell(e);
        }

        private void dataGridView1_Validating(object sender,DataGridViewCellValidatingEventArgs e)
        {
            GridView gridView = new GridView();
            bool isReadOnly = dataGridView1.ReadOnly;
            gridView.Validating(isReadOnly, e);
            
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            ButtonPress buttonPress = new ButtonPress();
            buttonPress.NewButtonClick(e,dataGridView1);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ButtonPress buttonPress = new ButtonPress();
            buttonPress.SaveButtonClick(e, dataGridView1);

        }
    }
}
