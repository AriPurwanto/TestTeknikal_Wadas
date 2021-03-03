using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebApplication1;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {
        //private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        //private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        //private string _antiXsrfTokenValue;
        private string strConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        //protected void page_init(object sender, eventargs e)
        //{
        //    // the code below helps to protect against xsrf attacks
        //    var requestcookie = request.cookies[antixsrftokenkey];
        //    guid requestcookieguidvalue;
        //    if (requestcookie != null && guid.tryparse(requestcookie.value, out requestcookieguidvalue))
        //    {
        //        // use the anti-xsrf token from the cookie
        //        _antixsrftokenvalue = requestcookie.value;
        //        page.viewstateuserkey = _antixsrftokenvalue;
        //    }
        //    else
        //    {
        //        // generate a new anti-xsrf token and save to the cookie
        //        _antixsrftokenvalue = guid.newguid().tostring("n");
        //        page.viewstateuserkey = _antixsrftokenvalue;

        //        var responsecookie = new httpcookie(antixsrftokenkey)
        //        {
        //            httponly = true,
        //            value = _antixsrftokenvalue
        //        };
        //        if (formsauthentication.requiressl && request.issecureconnection)
        //        {
        //            responsecookie.secure = true;
        //        }
        //        response.cookies.set(responsecookie);
        //    }

        //    page.preload += master_page_preload;
        //}

        //protected void master_page_preload(object sender, eventargs e)
        //{
        //    if (!ispostback)
        //    {
        //        // set anti-xsrf token
        //        viewstate[antixsrftokenkey] = page.viewstateuserkey;
        //        viewstate[antixsrfusernamekey] = context.user.identity.name ?? string.empty;
        //    }
        //    else
        //    {
        //        // validate the anti-xsrf token
        //        if ((string)viewstate[antixsrftokenkey] != _antixsrftokenvalue
        //            || (string)viewstate[antixsrfusernamekey] != (context.user.identity.name ?? string.empty))
        //        {
        //            throw new invalidoperationexception("validation of anti-xsrf token failed.");
        //        }
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else if (!IsPostBack)
            {
                GetMenuAccess();
            }
        }

        private void GetMenuAccess()
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spGetAccessMenu";
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = Session["userid"];
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];

                DataRow[] drowpar = dt.Select();

                int inc = 0;

                foreach (DataRow dr in drowpar)
                {
                    Menu1.Items.Add(new MenuItem(dr["Tittle"].ToString(),
                    dr["IdMenuAccess"].ToString(),
                    dr["MenuAddress"].ToString(),
                    dr["MenuAddress"].ToString()));
                    inc++;
                }

                con.Close();
                if (drowpar.Length == 0) PanelControl.Visible = false;
            }
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Logout.aspx");
        }
    }
}