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
    public partial class Barang : System.Web.UI.Page
    {
        private string strConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        private string message;

        public void dataLoad()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    SqlCommand cmd = new SqlCommand("select a.IdBarang, a.[Nama Barang], a.Qty, a.Harga From tblBarang a", con);
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataLoad();
            }
        }

        protected void GridResult_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridResult.EditIndex = -1;
            dataLoad();
        }

        protected void GridResult_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridResult.EditIndex = e.NewEditIndex;
            dataLoad();
        }

        protected void GridResult_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label IdBarang = (Label)GridResult.Rows[e.RowIndex].FindControl("lblIdBarang");
            TextBox txtNamaBarang = (TextBox)GridResult.Rows[e.RowIndex].FindControl("txtNamaBarang");
            TextBox txtQty = (TextBox)GridResult.Rows[e.RowIndex].FindControl("txtQty");
            TextBox txtHarga = (TextBox)GridResult.Rows[e.RowIndex].FindControl("txtHarga");

            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    if (String.IsNullOrEmpty(txtNamaBarang.Text.Trim()))
                    {
                        string script = "alert(\"Nama Barang Kosong, Silahkan isi!\");";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", script, true);
                    }
                    else if (String.IsNullOrEmpty(txtQty.Text.Trim()))
                    {
                        string script = "alert(\"Qty Belum diisi, Silahkan isi!\");";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", script, true);
                    }
                    else if (String.IsNullOrEmpty(txtHarga.Text.Trim()))
                    {
                        string script = "alert(\"Harga belum diisi, Silahkan isi!\");";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", script, true);
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spUpdateBarang";
                        cmd.Parameters.Add("@IdBarang", SqlDbType.VarChar).Value = IdBarang.Text.Trim();
                        cmd.Parameters.Add("@NamaBarang", SqlDbType.VarChar).Value = txtNamaBarang.Text.Trim();
                        cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = txtQty.Text.Trim();
                        cmd.Parameters.Add("@Harga", SqlDbType.Float).Value = txtHarga.Text.Trim();
                        cmd.Connection = con;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        GridResult.EditIndex = -1;
                        dataLoad();
                    }
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
                string NamaBarang, Qty, Harga;

                NamaBarang = textNamabarang.Text.Trim();
                Qty = textQty.Text.Trim();
                Harga = textharga.Text.Trim();


                using (SqlConnection con = new SqlConnection(strConString))
                {
                    if (String.IsNullOrEmpty(textNamabarang.Text.Trim()))
                    {
                        string script = "alert(\"Nama Barang Kosong, Silahkan isi!\");";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", script, true);
                    }
                    else if (String.IsNullOrEmpty(textQty.Text.Trim()))
                    {
                        string script = "alert(\"Qty belum diisi, Silahkan isi!\");";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", script, true);
                    }
                    else if (String.IsNullOrEmpty(textharga.Text.Trim()))
                    {
                        string script = "alert(\"Harga belum diisi, Silahkan isi!\");";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", script, true);
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spInsertBarang";
                        cmd.Parameters.Add("@NamaBarang", SqlDbType.VarChar).Value = textNamabarang.Text.Trim();
                        cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = textQty.Text.Trim();
                        cmd.Parameters.Add("@Harga", SqlDbType.Float).Value = textharga.Text.Trim();
                        cmd.Connection = con;

                        con.Open();
                        cmd.ExecuteNonQuery();

                        this.textNamabarang.Text = "";
                        this.textQty.Text = "";
                        this.textharga.Text = "";

                        dataLoad();
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
    }
}