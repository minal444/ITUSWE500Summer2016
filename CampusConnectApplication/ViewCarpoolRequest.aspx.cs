using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampusConnectApplication
{
    public partial class ViewCarpoolRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUSer.Text = "User: " + Session["username"].ToString();
                FillCarpoolRequest();
            }

        }

        private void FillCarpoolRequest()
        { 
            SqlConnection con = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adp = new SqlDataAdapter();

                try
                {


                    con = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["CampusConnectDB"]));
                    DataSet ds = new DataSet();
                    cmd.CommandText = "spGetCarpoolingRequest";
                    cmd.Connection = con;
                    cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Session["username"].ToString();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    adp.SelectCommand = cmd;
                    adp.Fill(ds, "dsCarpoolingRequest");
                    gvDetails.DataSource = ds.Tables[0];
                    gvDetails.DataBind();

                    GridView1.DataSource = ds.Tables[1];
                    GridView1.DataBind();

                    GridView2.DataSource = ds.Tables[2];
                    GridView2.DataBind();


                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Dispose();
                    cmd.Dispose();
                    adp.Dispose();
                }
        
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarpoolRequest.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }


        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Accept") return;

            SqlConnection con = new SqlConnection();

            con = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["CampusConnectDB"]));
            try
            {

                
                int id = Convert.ToInt32(e.CommandArgument);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.Parameters.Add("@RequestId", SqlDbType.Int).Value = e.CommandArgument;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Session["username"].ToString();

                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateCarpoolingRequest";
                int returnval = cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                FillCarpoolRequest();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Dispose();
            }


        }
    }
}