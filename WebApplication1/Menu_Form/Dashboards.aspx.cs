using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using FusionCharts.DataEngine;
using FusionCharts.Visualization;

namespace WebApplication1.Menu_Form
{
    public partial class Dashboards : System.Web.UI.Page
    {
        private string strConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        private string message;

        protected void Page_Load(object sender, EventArgs e)
        {
            ViewChart();
        }

        public void ViewChart()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    SqlCommand cmd = new SqlCommand("select * From tblTransaksi", con);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);                   
                    con.Close();

                    //----ViewChart----//
                    //DataTable primaryData = new DataTable();

                    //dt.Columns.Add("Language", typeof(System.String));
                    //dt.Columns.Add("User", typeof(System.Double));

                    //dt.Rows.Add("Java", 62000);
                    //dt.Rows.Add("Python", 46000);
                    //dt.Rows.Add("Javascript", 38000);
                    //dt.Rows.Add("C++", 31000);
                    //dt.Rows.Add("C#", 27000);
                    //dt.Rows.Add("php", 14000);
                    //dt.Rows.Add("Perl", 14000);

                    StaticSource source = new StaticSource(dt);
                    DataModel model = new DataModel();
                    model.DataSources.Add(source);

                    PageLevelTheme.Theme = FusionChartsTheme.ThemeName.FUSION;

                    Charts.PieChart pie = new Charts.PieChart("first_3D_chart");
                    pie.ThreeD = true;
                    pie.Width.Pixel(600);
                    pie.Height.Pixel(450);
                    pie.Data.Source = model;
                    pie.Data.CategoryField("[Nama Perusahaan]");
                    pie.Data.SeriesFields("[Nama Barang]");

                    pie.Caption.Text = "Transaction Tables";
                    pie.Values.Show = false;

                    //Chart newChart = new Chart("column2d", "simplechart", "600", "400", "jsonurl", "data.json");
                    //chart.Text = newChart.Render();

                    //ViewData["Chart"] = pie.Render();

                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Oops!! following error occured : " + message.ToString() + "');", true);
            }
        }
    }
}