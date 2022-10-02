using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TOS_FORM_2.FormFunctions.F1;

namespace TOS_FORM_2
{
    public partial class Form1 : Form
    {
        private ButtonPress buttonPress = new ButtonPress();
        private GridView gridView = new GridView();
        private Combo combo = new Combo();
        private Load load = new Load();

        public static string selectedBankCode = null;
        public static string selectedBankName = null;
        public static string selectedDesignID = null;
        public static int selectedDesignIDRowIndex = -1;
        public static string User = "Manager";

        public static readonly List<string> editOnModes = new List<string>() { "bankDesignAdd", "bankDesignUpdate", "bankCodeAdd", "bankDetailsAdd", "newFileAdd" };

        public void InitTimer()
        {
            Timer timer1 = new Timer();
            timer1.Tick += new EventHandler(IsEditMode);
            timer1.Interval = 100; // in miliseconds
            timer1.Start();
        }

        private void IsEditMode(object sender, EventArgs e)
        {
            if (editOnModes.Contains(mode.First()))
            {
                dataGridView1.ReadOnly = false;
                NewRowButton.Enabled = true;
                comboBox1.Enabled = false;
                NewBankCodeButton.Enabled = false;
                NewBankDesignButton.Enabled = false;
                NewBankDetailButton.Enabled = false;
                EditModeButton.Enabled = false;
            }
            else
            {
                dataGridView1.ReadOnly = true;
                NewRowButton.Enabled = false;
                comboBox1.Enabled = true;
                NewBankCodeButton.Enabled = true;
                NewBankDesignButton.Enabled = true;
                NewBankDetailButton.Enabled = true;
                EditModeButton.Enabled = true;
            }
            if (mode.First() == "bankDesignPreview")
            {
                NewFileButton.Enabled = true;
                TransferBankFileButton.Enabled = true;
            } 
            else
            {
                NewFileButton.Enabled = false;
                TransferBankFileButton.Enabled = false;
            }
            EditOnOffLabel.Text = ((dataGridView1.ReadOnly) ? "Kapalı" : "Açık");
        }

        /// <summary>
        /// Possible values = bankDetails,bankDesignAdd,bankDesignPreview,bankDesignUpdate,bankCodeAdd, bankDetailsAdd
        /// </summary>
        public static Stack<string> mode = new Stack<string>();

        public Form1()
        {
            InitializeComponent();
            InitTimer();
        }

        public static void ResetMode()
        {
            mode.Clear();
            mode.Push("bankDetails");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mode.Push("bankDetails");
            load.FirstChecks();
            load.FillComboBox(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo.selectedIndexChanged(comboBox1,label1,dataGridView1);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool isReadOnly = dataGridView1.ReadOnly;
            if(isReadOnly)
            {
                gridView.onCellDoubleClick(dataGridView1, e);
            }
        }

        private void dataGridView1_UserDeletingRows(object sender, DataGridViewRowCancelEventArgs e)
        {
            bool isReadOnly = dataGridView1.ReadOnly;
            if (isReadOnly) //maybe only in edit mode
            {
                gridView.onDeletingRows(dataGridView1,e);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            gridView.onEndEditCell(e);
        }

        private void dataGridView1_Validating(object sender,DataGridViewCellValidatingEventArgs e)
        {
            gridView.Validating(e);  
        }

        private void NewBankDesignButton_Click(object sender, EventArgs e)
        {
            buttonPress.NewBankDesignButtonClick(dataGridView1);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            buttonPress.SaveButtonClick(dataGridView1);
        }

        private void NewBankCodeButton_Click(object sender, EventArgs e)
        {
            buttonPress.NewBankCodeButtonClick(dataGridView1);
        }

        private void NewBankDetailButton_Click(object sender, EventArgs e)
        {
            buttonPress.NewBankDetailButtonClick(dataGridView1);
        }

        private void NewRowButton_Click(object sender, EventArgs e)
        {
            buttonPress.NewRowButtonClick(dataGridView1);
        }

        private void EditModeButton_Click(object sender, EventArgs e)
        {
            buttonPress.EditModeButtonClick(dataGridView1,e);
        }

        private void HomePageButton_Click(object sender, EventArgs e)
        {
            buttonPress.HomePageButtonClick(dataGridView1);
        }

        private void NewFileButton_Click(object sender, EventArgs e)
        {
            buttonPress.NewFileButtonClick(dataGridView1);
        }

        private void TransferBankFileButton_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
