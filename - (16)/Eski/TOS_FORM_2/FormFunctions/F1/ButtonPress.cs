using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOS_FORM_2.Functions;

namespace TOS_FORM_2.FormFunctions.F1
{
    internal class ButtonPress
    {
        public void NewButtonClick(EventArgs e, DataGridView dataGridView)
        {
            if (Form1.mode == "bankDesignAdd")
            {
                dataGridView.Rows.Add();
            }
            else
            {
                //PRIORITY, PARAMETERNAME, TYPE, ISALPHANUMERIC, LENGTH
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                dataGridView.Columns.Add("PRIORITY", "Öncelik");
                dataGridView.Columns.Add("PARAMETERNAME", "İsim");
                dataGridView.Columns.Add("TYPE", "Tip");
                dataGridView.Columns.Add("ISALPHANUMERIC", "Alfanümerik");
                dataGridView.Columns.Add("LENGTH", "Uzunluk");
                Form1.mode = "bankDesignAdd";
                dataGridView.ReadOnly = false;
            }

        }

        public void SaveButtonClick(EventArgs e, DataGridView dataGridView)
        {
            List<int> priority = new List<int>();
            List<string> parameterNames = new List<string>();
            List<string> types = new List<string>();
            List<bool> isAlphaNumeric = new List<bool>();
            List<int> length = new List<int>();

            int j = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                for(int i = 0; i < 5;i++)
                {
                    if (row.Cells[i].EditedFormattedValue == String.Empty)
                    {
                        MessageBox.Show($"[{j}][{i}] Boş!", "Hata!");
                        return;
                    }
                }
                DataGridViewCellCollection cells = row.Cells;
                priority.Add(Convert.ToInt16(cells[0].EditedFormattedValue.ToString()));
                parameterNames.Add(cells[1].EditedFormattedValue.ToString());
                types.Add(cells[2].EditedFormattedValue.ToString().ToUpper());
                isAlphaNumeric.Add(Convert.ToBoolean(Convert.ToInt16(cells[3].EditedFormattedValue.ToString())));
                length.Add(Convert.ToInt16(cells[4].EditedFormattedValue.ToString()));
                j++;
            }

            Helper.BankDesignQuery(priority, parameterNames, types, isAlphaNumeric, length);
        }
    }
}
