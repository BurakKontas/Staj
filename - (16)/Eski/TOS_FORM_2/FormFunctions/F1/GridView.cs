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
    internal class GridView
    {
        internal void onCellDoubleClick(DataGridView dataGridView, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && Form1.mode == "bankDetails")
            {
                string designID = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                SQLiteConnection connection = SQL.Connect("bankDesigns");
                DataSet designData = SQL.LoadData(connection, $"SELECT * FROM '{designID}'");
                if(designData != null)
                {
                    dataGridView.Rows.Clear();
                    dataGridView.Columns.Clear();
                    Combo.AddDataSetToGridView(designData, dataGridView);
                    Form1.mode = "bankDesign";
                }
                else
                {
                    MessageBox.Show("Böyle Bir DesenID Bulunmamaktadır.", "Hata!");
                }
            }
        }

        internal void onDeletingRows(DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bu kayıdı silmek istediğine emin misin ?\n(Veri tabanından da silinecek)", "İşlem Onayı", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
                //sql delete command
            }
            else
            {
                e.Cancel = true;
            }
        }

        internal void onEndEditCell(DataGridViewCellEventArgs e)
        {
            
        }

        internal void Validating(bool isReadOnly, DataGridViewCellValidatingEventArgs e)
        {
            if (!isReadOnly && Form1.mode == "bankDesignAdd")
            {
                if (e.FormattedValue.ToString() == "") return; //to let use have it blank for a while
                //validating control
                if (e.ColumnIndex == 0)
                {
                    if (!int.TryParse(e.FormattedValue.ToString(), out _))
                    {
                        MessageBox.Show("Öncelik Bir Sayı Olmalıdır!", "Hata");
                        e.Cancel = true;
                    }
                }
                else if (e.ColumnIndex == 2)
                {
                    string type = e.FormattedValue.ToString();
                    List<string> validTypes = new List<string>() { "INTEGER", "TEXT" };
                    if (!validTypes.Contains(type.ToUpper()))
                    {
                        MessageBox.Show("Tür Integer yada Text Olmalıdır!", "Hata");
                        e.Cancel = true;
                    }
                }
                else if (e.ColumnIndex == 3)
                {
                    if (!int.TryParse(e.FormattedValue.ToString(), out _))
                    {
                        MessageBox.Show("Alfanümerik Bir Sayı Olmalıdır! (0-1)", "Hata");
                        e.Cancel = true;
                    }
                    if (Convert.ToInt32(e.FormattedValue.ToString()) != 1 && Convert.ToInt32(e.FormattedValue.ToString()) != 0)
                    {
                        MessageBox.Show("Alfanümerik 0 yada 1 Olmalıdır!", "Hata");
                        e.Cancel = true;
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    if (!int.TryParse(e.FormattedValue.ToString(), out _))
                    {
                        MessageBox.Show("Uzunluk Bir Sayı Olmalıdır!", "Hata");
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}
