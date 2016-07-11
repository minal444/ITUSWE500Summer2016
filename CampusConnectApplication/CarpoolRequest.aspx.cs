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
    public partial class CarpoolRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUSer.Text = "User: " + Session["username"].ToString();
                lblErrorMsg.Text = "";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();

            con = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["CampusConnectDB"]));
            try
            {


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Session["username"].ToString();
                cmd.Parameters.Add("@CarpoolingPreference", SqlDbType.VarChar).Value = cpPreference.Value;
                cmd.Parameters.Add("@PickUpLocation", SqlDbType.VarChar).Value = txtpickup.Value;
                cmd.Parameters.Add("@DropLocation", SqlDbType.VarChar).Value = txtdrop.Value;
                cmd.Parameters.Add("@Date", SqlDbType.VarChar).Value = txtDate.Value;
                cmd.Parameters.Add("@Time", SqlDbType.VarChar).Value = timeslot.Value;
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = txtComment.Value;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = 0;



                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_InsertCarpoolingRequest";
                int returnval = cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                Response.Redirect("ViewCarpoolRequest.aspx");
                
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "Request is already exist";
            }
            finally
            {
                
                con.Dispose();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCarpoolRequest.aspx");
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}