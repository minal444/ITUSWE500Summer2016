<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CampusConnectApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: ivory; color: grey; padding-left: 100px; padding-right: 400px">
    <header>
        <h2><i>Carpooling Account Login</i></h2>
    </header>

    <section style="padding: 10px;">
        <form id="form1" runat="server">
            <div>

                <fieldset>
                    <legend align="center"><i>Login</i></legend>
                    <br />

                    <label for="username">Enter Your UserName: </label>
                    <br />
                    
                    <asp:TextBox runat="server" ID="txtusername" MaxLength="100" Width="200px" required="required" ></asp:TextBox><br/><br/>

                    <label for="pswrd">Enter Your Password: </label>
                    <br />
                    <asp:TextBox ID="txtpassword" runat="server" MaxLength="100" TextMode="Password" Width="200px" required="required" ></asp:TextBox><br/><br/><br/>
                    


                    
                    <asp:Button Text="Login" runat="server" OnClick="btnSubmit_Click" Style="background-color: blue; color: white;" /><br/><br/>
                    
                    <br /><br />
                    <asp:HyperLink ID="hlForgotPassword" runat="server"  NavigateUrl="Login.aspx" Text="Forgot Password?"></asp:HyperLink>
                    
                    <asp:Label ID="lblErrorMsg" ForeColor="red" runat="server" Text=""></asp:Label>
                    <br /><br />
                    <asp:HyperLink ID="hlRegistration" runat="server"  NavigateUrl="~/Registration.aspx" Text="Click here for Sign up"></asp:HyperLink>
                </fieldset>
            </div>
        </form>
    </section>
    
</body>
</html>
