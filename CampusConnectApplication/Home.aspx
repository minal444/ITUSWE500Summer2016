<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CampusConnectApplication.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <section>
        <article>
            <div>
                <h1>
                    Welcome to Campus Connect Application
                </h1>
                <br />
                <br />
                <br />
                <asp:Label ID="lblUSer" runat="server" Text=""   ></asp:Label>
                <br />
                <br />
                <p>
                    <asp:HyperLink ID="hlCarpooling" runat="server"  NavigateUrl="~/ViewCarpoolRequest.aspx" Text="Carpooling"></asp:HyperLink>
                </p>
                <asp:Button Text="Sign Out" runat="server" OnClick="btnSignOut_Click" ID="SignOut" Style="background-color: blue; color: white;" /><br />
            </div>
        </article>
    </section>
    </div>
    </form>
</body>
</html>
