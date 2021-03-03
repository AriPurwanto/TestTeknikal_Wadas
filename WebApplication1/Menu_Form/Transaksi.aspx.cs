using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.Menu_Form
{
    public partial class Transaksi : System.Web.UI.Page
    {
        private string strConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        private string message;

        public void dataLoad_Grid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    SqlCommand cmd = new SqlCommand("select a.IdTransaksi, a.IdPerusahaan, a.[Nama Perusahaan] as NamaPerusahaan, a.IdBarang, a.[Nama Barang] as NamaBarang, a.Qty, a.Harga From tblTransaksi a", con);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        GridResult.DataSource = dt;
                        GridResult.DataBind();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Oops!! following error occured : " + message.ToString() + "');", true);
            }
        }

        public void dataLoad_Perusahaan()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    SqlCommand cmd = new SqlCommand("select '' as IdPerusahaan, '' as NamaPerusahaan union select IdPerusahaan, [Nama Perusahaan] from tblPerusahaan", con);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    ddNamaPerusahaan.DataSource = dt;
                    ddNamaPerusahaan.DataValueField = "NamaPerusahaan";
                    ddNamaPerusahaan.DataBind();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }

        public void dataLoad_Barang()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    SqlCommand cmd = new SqlCommand("select '' as IdBarang, '' as NamaBarang, '' as Qty, '' as Harga union select IdBarang, [Nama Barang], Qty, Harga from tblBarang", con);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    ddNamaBarang.DataSource = dt;
                    ddNamaBarang.DataValueField = "NamaBarang";
                    ddNamaBarang.DataBind();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                dataLoad_Grid();
                dataLoad_Perusahaan();
                dataLoad_Barang();
            //}
        }

        protected void GridResult_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridResult.EditIndex = -1;
            dataLoad_Grid();
            dataLoad_Perusahaan();
            dataLoad_Barang();
        }

        protected void GridResult_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridResult.EditIndex = e.NewEditIndex;
            DropDownList ddNamaPerusahaan2 = (DropDownList)GridResult.Rows[e.NewEditIndex].FindControl("ddNamaPerusahaan2");
            DropDownList ddNamaBarang2 = (DropDownList)GridResult.Rows[e.NewEditIndex].FindControl("ddNamaBarang2");

            dataLoad_Grid();

            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    SqlCommand cmd = new SqlCommand("select '' as IdPerusahaan, '' as NamaPerusahaan union select IdPerusahaan, [Nama Perusahaan] from tblPerusahaan", con);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    da.Fill(dt);
                    da.Fill(ds);

                    ddNamaPerusahaan2.DataSource = dt;
                    ddNamaPerusahaan2.DataValueField = "NamaPerusahaan";
                    ddNamaPerusahaan2.DataBind();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    SqlCommand cmd = new SqlCommand("select '' as IdBarang, '' as NamaBarang, '' as Qty, '' as Harga union select IdBarang, [Nama Barang], Qty, Harga from tblBarang", con);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    da.Fill(dt);
                    da.Fill(ds);

                    ddNamaBarang2.DataSource = dt;
                    ddNamaBarang2.DataValueField = "NamaBarang";
                    ddNamaBarang2.DataBind();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }

        protected void GridResult_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label IdTransaksi = (Label)GridResult.Rows[e.RowIndex].FindControl("lblIdTransaksi");
            Label IdPerusahaan = (Label)GridResult.Rows[e.RowIndex].FindControl("lbl2IdPerusahaan");
            DropDownList ddNamaPerusahaan2 = (DropDownList)GridResult.Rows[e.RowIndex].FindControl("ddNamaPerusahaan2");
            Label IdBarang = (Label)GridResult.Rows[e.RowIndex].FindControl("lbl2IdBarang");
            DropDownList ddNamaBarang2 = (DropDownList)GridResult.Rows[e.RowIndex].FindControl("ddNamaBarang2");
            Label LQty = (Label)GridResult.Rows[e.RowIndex].FindControl("lbl2Qty");
            Label LHarga = (Label)GridResult.Rows[e.RowIndex].FindControl("lbl2Harga");

            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spUpdateTransaksi";
                    cmd.Parameters.Add("@IdTransaksi", SqlDbType.Int).Value = IdTransaksi.Text.Trim();
                    cmd.Parameters.Add("@IdPerusahaan", SqlDbType.Int).Value = IdPerusahaan.Text.Trim();
                    cmd.Parameters.Add("@IdBarang", SqlDbType.Int).Value = IdBarang.Text.Trim();
                    cmd.Connection = con;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    GridResult.EditIndex = -1;
                    dataLoad_Grid();
                    //dataLoad_Perusahaan();
                    //dataLoad_Barang();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string IdPerusahaan, NamaPerusahaan, IdBarang, NamaBarang, Qty, Harga;

                IdPerusahaan = lblIdPerusahaan.Text.Trim();
                NamaPerusahaan = ddNamaPerusahaan.Text.Trim();
                IdBarang = lblIdBarang.Text.Trim();
                NamaBarang = ddNamaBarang.Text.Trim();
                Qty = lblQty.Text.Trim();
                Harga = lblHarga.Text.Trim();

                using (SqlConnection con = new SqlConnection(strConString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spInsertTransaksi";
                    cmd.Parameters.Add("@IdPerusahaan", SqlDbType.Int).Value = IdPerusahaan;
                    cmd.Parameters.Add("@NamaPerusahaan", SqlDbType.VarChar).Value = NamaPerusahaan;
                    cmd.Parameters.Add("@Idbarang", SqlDbType.Int).Value = IdBarang;
                    cmd.Parameters.Add("@Namabarang", SqlDbType.VarChar).Value = NamaBarang;
                    cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = Qty;
                    cmd.Parameters.Add("@Harga", SqlDbType.Float).Value = Harga;
                    cmd.Connection = con;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    dataLoad_Grid();
                    //dataLoad_Perusahaan();
                    //dataLoad_Barang();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }

        protected void ddNamaPerusahaan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //DropDownList ddNamaPerusahaan = (DropDownList)GridResult.Rows[e.NewEditIndex].FindControl("ddNamaPerusahaan");
                //DropDownList ddNamaBarang = (DropDownList)GridResult.Rows[e.NewEditIndex].FindControl("ddNamaBarang");

                using (SqlConnection con = new SqlConnection(strConString))
                {
                    SqlCommand cmd = new SqlCommand("Select * From tblPerusahaan Where [Nama Perusahaan] = '" + ddNamaPerusahaan.SelectedValue + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader DR;
                    DR = cmd.ExecuteReader();

                    while (DR.Read())
                    {
                        //string IdPerusahaan = (string)DR["IdPerusahaan"].ToString();
                        lblIdPerusahaan.Text = DR[0].ToString();
                    }

                    DR.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
    }
}