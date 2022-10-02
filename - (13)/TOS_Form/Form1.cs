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
    }
}
