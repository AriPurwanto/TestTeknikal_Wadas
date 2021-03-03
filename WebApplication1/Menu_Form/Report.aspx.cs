using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.Menu_Form
{
    public partial class Report : System.Web.UI.Page
    {
        private string strConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        private string message;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

        protected void btnAddBarang_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    string data = null;
                    int i = 0;
                    int j = 0;

                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    SqlCommand cmd = new SqlCommand("select * From tblBarang ", con);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                        {
                            data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                            xlWorkSheet.Cells[i + 1, j + 1] = data;
                        }
                    }

            xlWorkBook.SaveAs("D:\\PT. Wahana Datarindo Solution\\Project\\WebApplication1\\Report_Barang.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            //Show("Excel file created , you can find the file c:\\csharp.net-informations.xls");
                    
                    con.Close();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Excel file created , you can find the file D:\\PT. Wahana Datarindo Solution\\Project\\WebApplication1\\Report_Barang.xls";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Oops!! following error occured : " + message.ToString() + "');", true);
            }
        }

        protected void btnAddPerus_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    string data = null;
                    int i = 0;
                    int j = 0;

                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    SqlCommand cmd = new SqlCommand("select * From tblPerusahaan", con);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                        {
                            data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                            xlWorkSheet.Cells[i + 1, j + 1] = data;
                        }
                    }

                    xlWorkBook.SaveAs("D:\\PT. Wahana Datarindo Solution\\Project\\WebApplication1\\Report_Perusahaan.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);

                    //Show("Excel file created , you can find the file c:\\csharp.net-informations.xls");

                    con.Close();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Excel file created , you can find the file D:\\PT. Wahana Datarindo Solution\\Project\\WebApplication1\\Report_Perusahaan.xls";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Oops!! following error occured : " + message.ToString() + "');", true);
            }
        }

        protected void btnAddTrans_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    string data = null;
                    int i = 0;
                    int j = 0;

                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    SqlCommand cmd = new SqlCommand("select * From tblPerusahaan", con);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                        {
                            data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                            xlWorkSheet.Cells[i + 1, j + 1] = data;
                        }
                    }

                    xlWorkBook.SaveAs("D:\\PT. Wahana Datarindo Solution\\Project\\WebApplication1\\Report_Transaksi.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);

                    //Show("Excel file created , you can find the file c:\\csharp.net-informations.xls");

                    con.Close();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Excel file created , you can find the file D:\\PT. Wahana Datarindo Solution\\Project\\WebApplication1\\Report_Transaksi.xls";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Oops!! following error occured : " + message.ToString() + "');", true);
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                message = ex.Message;
                //MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Exception Occured while releasing object " + message.ToString() + "');", true);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}