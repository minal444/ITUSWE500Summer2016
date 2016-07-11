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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblErrorMsg.Text = "";
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();

            con = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["CampusConnectDB"]));
            try
            {


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = txtfirstname.Value;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = txtlastname.Value;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = txtemail.Value;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtpassword.Value;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtemail.Value;
                cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = txtstudentid.Value;
                cmd.Parameters.Add("@AddressLine1", SqlDbType.VarChar).Value = txtaddress1.Value;
                cmd.Parameters.Add("@AddressLine2", SqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = txtcity.Value;
                cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = txtstate.Value;
                cmd.Parameters.Add("@Zipcode", SqlDbType.VarChar).Value = txtzipcode.Value;
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = txtphone.Value;
                cmd.Parameters.Add("@CarpoolingPreference", SqlDbType.VarChar).Value = cpPreference.Value;
                cmd.Parameters.Add("@CreditCardNumber", SqlDbType.VarChar).Value = txtCCNumber.Value;
                cmd.Parameters.Add("@CreditCardType", SqlDbType.VarChar).Value = cctype.Value;
                cmd.Parameters.Add("@CreditCardExpiration", SqlDbType.VarChar).Value = txtCCExpire.Value;
                cmd.Parameters.Add("@CCVNumber", SqlDbType.Int).Value = 0;



                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_InsertUser";
                int returnval = cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();


                Response.Redirect("Login.aspx");

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "User already exist.";
            }
            finally
            {
                con.Dispose();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

    }
}