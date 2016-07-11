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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblErrorMsg.Text = "";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adp = new SqlDataAdapter();



            try
            {

                con = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["CampusConnectDB"]));
                DataSet ds = new DataSet();
                cmd.CommandText = "spGetUserDetails";
                cmd.Connection = con;
                cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = txtusername.Text.Trim();
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtpassword.Text.Trim();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                adp.SelectCommand = cmd;
                
                adp.Fill(ds, "UserDetails");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblErrorMsg.Text = "Invalid useername or password";
                }
                else
                {
                    Session.Add("username", txtusername.Text);
                    Response.Redirect("Home.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Dispose();
                cmd.Dispose();
                adp.Dispose();
            }
            
        }

    }
}