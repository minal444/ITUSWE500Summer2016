<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="CampusConnectApplication.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <body style="background-color:ivory; color:grey;padding-left: 100px;padding-right:400px" >
<header>
<h2><i>Carpooling Account Creation Form</i></h2>
</header>

<section style="padding:10px;" >
	<form id="form1" runat="server">

  		<fieldset>
		<legend align ="center"><i>Create Account for Participant Type</i></legend><br/>
		<fieldset>
			<legend align ="center">Personal Details</legend><br/>
			
            <asp:Label ID="lblErrorMsg" ForeColor="red" runat="server" Text=""></asp:Label>
            <br />
            <br />
			<label for="first">Enter Your First Name: </label><br/>
			<input type="text" name="first" id="txtfirstname" runat="server" size=35 maxlength=30 value="" required="required" /><br/>

			<label for="last">Enter Your last Name: </label><br/>
			<input type="text" name="last" size=35 id="txtlastname" runat="server"  maxlength=30  value="" required="required" /><br/>

			<label for="idStudent">Enter Your Student ID: </label><br/>
			<input type="number" name="idStudent" runat="server"  id="txtstudentid" size=5 maxlength=5 value="" required="required" /><br/><br/>

            <label for="email">Email Address: </label><br/>
			<input type="email" name="email" id="txtemail" runat="server" size=35 maxlength=40 value="" required="required" /><br/>

			<label for="username">ITU Email address is username</label><br/><br/>
			<%--<input type="text" name="username" runat="server" id="txtusername"  size=35 maxlength=30 value=""/><br/>--%>

			<label for="pswrd">Enter Your Password: </label><br/>
			<input type="password" name="pswrd" id="txtpassword" runat="server"  size=35 maxlength=30 value="" required="required" /><br/>
			<label for="repswrd">Re-Enter Your Password: </label><br/>
			<input type="password" name="repswrd" id="txtrepassword" runat="server"  size=35 maxlength=30 value="" required="required" /><br/>

            <label for="phone">Phone Number: </label><br/>
			<input type="tel" name="phone" id="txtphone" runat="server"  size=12 maxlength=12 value="" required="required" /><br/>
			
			
			
		</fieldset>
		<fieldset>
			<legend align ="center">Address</legend><br/>
			<label for="address">Enter Your Home Address: </label><br/>
			<input type="text" name="address" runat="server"  id="txtaddress1" size=35 maxlength=30 value="" required="required" /><br/>

			<label for="city">City: </label><br/>
			<input type="text" name="city" runat="server"  id="txtcity" size=35 maxlength=30 value="" required="required" /><br/>

			<label for="state">State: </label><br/>
			<input type="text" name="state" runat="server"  id="txtstate" size=2 maxlength=2 value="" required="required" /><br/>

			<label for="zipcode">Zipcode: </label><br/>
			<input type="number" name="zipcode" runat="server"  id="txtzipcode" size=9 maxlength=9 value="" required="required" /><br/><br/>
		</fieldset>
		<br/>
		<fieldset>
		<legend align ="center"><i>Other Details</i></legend><br/>
			
			<label for="cpPreference">Car Pooling Preference: </label><br/>
				<select name="cpPreference" runat="server" id="cpPreference">
				<option value="0">Car Owner(Only)</option>
				<option value="1">Ride Seeker(Only)</option>
				<option value="2">Both(Drive and Ride)</option>
				</select><br/>
	

			<label for="ccnum">Credit Card Number: </label><br/>
			<input type="text" size=16 runat="server" id="txtCCNumber"  name="ccnum" maxlength=16 value="" required="required" /><br/>
			<label for="cctype">Credit Card Type: </label><br/>
			<select name="cctype" runat="server" id="cctype">
					<option value="0">Visa</option>
					<option value="1">Master Card</option>
					<option value="2">Discover Card</option>
			</select><br/>

			<label for="ccexpire">Credit Card Expiration </label><br/>
			<input type="text" name="ccexpire" id="txtCCExpire" runat="server"  size=7 maxlength=7 placeholder="mm/yyyy" required="required" /><br/>
			
            
		</fieldset>
		<br/><br/>

		
		</fieldset>
		<br/>
		<asp:Button Text="Register" runat="server" OnClick="btnRegister_Click" ID="btnRegister" Style="background-color: blue; color: white;" />
		<asp:Button Text="Cancel" runat="server" OnClick="btnCancel_Click" ID="btnCancel" Style="background-color: blue; color: white;" /><br/><br/>
	</form>
</section>

</body>
</html>
 