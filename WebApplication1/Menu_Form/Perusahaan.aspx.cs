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
    public partial class Perusahaan : System.Web.UI.Page
    {
        private string strConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        private string message;

        public void dataLoad()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    SqlCommand cmd = new SqlCommand("select a.IdPerusahaan, a.[Nama Perusahaan], a.Alamat From tblPerusahaan a", con);
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
            Label IdPerusahaan = (Label)GridResult.Rows[e.RowIndex].FindControl("lblIdPerusahaan");
            TextBox txtNamaPerusahaan = (TextBox)GridResult.Rows[e.RowIndex].FindControl("txtNamaPerusahaan");
            TextBox txtAlamat = (TextBox)GridResult.Rows[e.RowIndex].FindControl("txtAlamat");

            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    if (String.IsNullOrEmpty(txtNamaPerusahaan.Text.Trim()))
                    {
                        string script = "alert(\"Nama Perusahaan Kosong, Silahkan isi!\");";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", script, true);
                    }
                    else if (String.IsNullOrEmpty(txtAlamat.Text.Trim()))
                    {
                        string script = "alert(\"Alamat kosong, Silahkan isi!\");";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", script, true);
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spUpdatePerusahaan";
                        cmd.Parameters.Add("@IdPerusahaan", SqlDbType.VarChar).Value = IdPerusahaan.Text.Trim();
                        cmd.Parameters.Add("@NamaPerusahaan", SqlDbType.VarChar).Value = txtNamaPerusahaan.Text.Trim();
                        cmd.Parameters.Add("@Alamat", SqlDbType.VarChar).Value = txtAlamat.Text.Trim();
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
                string NamaPerusahaan, Alamat;

                NamaPerusahaan = textNamaPerusahaan.Text.Trim();
                Alamat = textAlamat.Text.Trim();


                using (SqlConnection con = new SqlConnection(strConString))
                {
                    if (String.IsNullOrEmpty(textNamaPerusahaan.Text.Trim()))
                    {
                        string script = "alert(\"Nama Perusahaan Kosong, Silahkan isi!\");";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", script, true);
                    }
                    else if (String.IsNullOrEmpty(textAlamat.Text.Trim()))
                    {
                        string script = "alert(\"Alamat kosong, Silahkan isi!\");";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", script, true);
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spInsertPerusahaan";
                        cmd.Parameters.Add("@NamaPerusahaan", SqlDbType.VarChar).Value = textNamaPerusahaan.Text.Trim();
                        cmd.Parameters.Add("@Alamat", SqlDbType.VarChar).Value = textAlamat.Text.Trim();
                        cmd.Connection = con;

                        con.Open();
                        cmd.ExecuteNonQuery();

                        this.textNamaPerusahaan.Text = "";
                        this.textAlamat.Text = "";

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