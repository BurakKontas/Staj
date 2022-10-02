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
            if (e.ColumnIndex == 1)
            {
                string designID = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                SQLiteConnection connection = SQL.Connect("bankDesigns");
                DataSet designData = SQL.LoadData(connection, $"SELECT * FROM '{designID}'");
                if(designData != null)
                {
                    Combo.AddDataSetToGridView(designData, dataGridView);
                } else
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
    }
}
