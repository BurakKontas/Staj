using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOS_FORM_2.Functions;
using System.Windows.Forms;

namespace TOS_FORM_2.FormFunctions.F1
{
    internal class Load
    {
        public static List<string> GetBankCodes()
        {
            SQLiteConnection connectionBankCodes = SQL.Connect("bankCodes");
            DataSet bankCodes = SQL.LoadData(connectionBankCodes, "SELECT * FROM BANKCODES", true);
            List<string> codeList = bankCodes.Tables[0].AsEnumerable().Select(dataRow => dataRow.Field<string>("CODE")).ToList();
            return codeList;
        }

        internal void FirstChecks()
        {
            SQLiteConnection connectionBankDetails = SQL.Connect("bankDetails");
            List<string> codeList = GetBankCodes();
            codeList.ForEach(bankCode =>
            {
                SQL.Command(connectionBankDetails, $"CREATE TABLE IF NOT EXISTS '{bankCode}' (BANKNAME TEXT, DESIGNID INTEGER, COMMENT TEXT)");
            });
            connectionBankDetails.Close();
        }

        internal void FillComboBox(ComboBox comboBox)
        {
            GetBankCodes().ForEach(r =>
            {
                comboBox.Items.AddRange(new object[] { r });
            });
            comboBox.SelectedIndex = 0;
        }
    }
}
