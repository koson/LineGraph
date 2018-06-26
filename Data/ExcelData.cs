using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace LineGraph.Data
{
    public class ExcelData
    {
        public DataTable table;
        public void RunExcelData()
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "xls文件（*.xls）|*.xls;";
                openFile.DefaultExt = "xls";
                if (openFile.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                String strExcelPath = openFile.FileName;
                String ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + strExcelPath + ";Extended Properties=Excel 8.0";

                //导入excel坐标点数据
                OleDbConnection connection = new OleDbConnection(ConnectionString);
                OleDbDataAdapter da = new OleDbDataAdapter("select * from [Sheet1$]", connection);
                DataSet ds = new DataSet();
                da.Fill(ds, "Book1");
                table = ds.Tables["Book1"];
                da.Dispose();
                ds.Dispose();
                connection.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}
