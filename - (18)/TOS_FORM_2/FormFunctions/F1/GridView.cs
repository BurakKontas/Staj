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
            if (e.ColumnIndex == 1 && Form1.mode.First() == "bankDetails")
            {
                string designID = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                SQLiteConnection connection = SQL.Connect("bankDesigns");
                DataSet designData = SQL.LoadData(connection, $"SELECT * FROM '{designID}'");
                if(designData != null)
                {
                    dataGridView.Rows.Clear();
                    dataGridView.Columns.Clear();
                    Combo.AddDataSetToGridView(designData, dataGridView);
                    Form1.mode.Push("bankDesignPreview");
                    Form1.selectedDesignID = designID;
                    Form1.selectedDesignIDRowIndex = e.RowIndex;
                }
                else
                {
                    MessageBox.Show("Böyle Bir DesenID Bulunmamaktadır.", "Hata!");
                }
            }
        }

        internal void onDeletingRows(DataGridView dataGridView,DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bu kayıdı silmek istediğine emin misin ?\n(Veri tabanından da silinecek)", "İşlem Onayı", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
                string mode = Form1.mode.First();

                List<string> headerTexts = new List<string>();
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    headerTexts.Add(column.Name);
                }

                List<string> values = new List<string>();

                DataGridViewCellCollection cells = dataGridView.Rows[e.Row.Index].Cells;
                foreach(DataGridViewCell cell in cells)
                {
                    values.Add(cell.FormattedValue.ToString());
                }

                string queryWhereScript = String.Empty;

                for(int i = 0; i < values.Count; i++)
                {
                    queryWhereScript += $"{headerTexts[i]}='{values[i]}'";
                    if (i < values.Count-1) queryWhereScript += " AND ";
                }

                SQLiteConnection connection;
                string query;
                switch (mode)
                {
                    case "bankDetails":
                        connection = SQL.Connect("bankDetails");
                        query = $"DELETE FROM '{Form1.selectedBankCode}' WHERE ({queryWhereScript})";
                        break;

                    case "bankDesignPreview":
                        connection = SQL.Connect("bankDesigns");
                        query = $"DELETE FROM '{Form1.selectedDesignID}' WHERE ({queryWhereScript})";
                        break;

                    default:
                        MessageBox.Show("Bu mod silme işlemlerine eklenmemiştir lütfen yönetici ile iletişime geçiniz.", "Uyarı!");
                        e.Cancel = true;
                        return;
                }
                SQL.Command(connection, query,true);

            }
            else
            {
                e.Cancel = true;
            }
        }

        internal void onEndEditCell(DataGridViewCellEventArgs e)
        {
            
        }

        internal void Validating(DataGridViewCellValidatingEventArgs e)
        {
            if (Form1.mode.First() == "bankDesignAdd")
            {
                if (e.FormattedValue.ToString() == "") return; //to let use have it blank for a while
                //validating control
                if (e.ColumnIndex == 0)
                {
                    if (!double.TryParse(e.FormattedValue.ToString(), out _))
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
            else if(Form1.mode.First() == "newFileAdd")
            {
                SQLiteConnection connection = SQL.Connect("bankDesigns");
                DataSet data = SQL.LoadData(connection, $"SELECT * FROM '{Form1.selectedDesignID}'", true);
                List<Int64> length = data.Tables[0].AsEnumerable().Select(dataRow => dataRow.Field<Int64>("LENGTH")).ToList();
                if (Convert.ToInt32(length[e.ColumnIndex]) < e.FormattedValue.ToString().Length)
                {
                    DialogResult dResult = MessageBox.Show("Düzenlediğiniz parametrenin uzunluk sınırını geçtiniz","Uyarı");
                    e.Cancel = true;
                }
            }
        }
    }
}
