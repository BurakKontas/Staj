using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOS_Form
{

    public partial class Form1 : Form
    {
        public static object SelectedBank = null;
        public static string user = "Manager";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Functions.GetAllBankModels().ForEach(r =>
            {
                comboBox1.Items.AddRange(new object[] { r });
            });
            comboBox1.SelectedIndex = 0;
            SelectedBank = comboBox1.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Check = new Form2();
            Check.Show();
            Hide();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedBank = comboBox1.SelectedItem;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            Hide();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                if(Form2.connection != null) Form2.connection.Close();
                if(Form3.connection != null) Form3.connection.Close();
            }
            catch { }
            base.OnClosing(e);
            Environment.Exit(0);//end debug mode when we closed form
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.IsDelete = true;
            form3.Show();
            Hide();
        }
    }
}
