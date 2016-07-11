<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCarpoolRequest.aspx.cs" Inherits="CampusConnectApplication.ViewCarpoolRequest" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: ivory; color: grey; padding-left: 100px; padding-right: 400px">

    <section style="padding: 10px;">
        <form id="form1" runat="server">
            <header>

                <asp:Button Text="Sign Out" runat="server" OnClick="btnSignOut_Click" ID="SignOut" Style="background-color: blue; color: white;" /><br />
                <br />
                <asp:Label ID="lblUSer" runat="server" Text=""   ></asp:Label>
                <h2><i>Carpooling Request Form</i></h2>
            </header>

            <fieldset>
                <legend align="center"><i>Your CarPool Request</i></legend>
                <br />
                <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="false" Width="100%" >
                    <AlternatingRowStyle BackColor="#f0f0f0" HorizontalAlign="Left" Font-Size="Small" />
                    <RowStyle Font-Size="Small" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#f0f0f0" Font-Size="Small" Font-Bold="true" />
                    <Columns>
                        <asp:BoundField DataField="RequestId" HeaderText="RequestId" HeaderStyle-HorizontalAlign="Left"
                            Visible="false" />
                        <asp:BoundField DataField="UserId" HeaderText="UserId" HeaderStyle-HorizontalAlign="Left"
                            Visible="false" />
                        <asp:BoundField DataField="CarpoolingPreference" HeaderText="Carpooling Preference" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PickUpLocation" HeaderText="PickUp Location" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="DropLocation" HeaderText="Drop Location" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Date" HeaderText="Date" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Time" HeaderText="Time" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Comment" HeaderText="Comment" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="AcceptedBy" HeaderText="Accepted By" HeaderStyle-HorizontalAlign="Left" />

                    </Columns>
                </asp:GridView>
                <br />

            </fieldset>
            <br />
            <br />
            <fieldset>
                <legend align="center"><i>CarPool Owners</i></legend>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%">
                    <AlternatingRowStyle BackColor="#f0f0f0" HorizontalAlign="Left" Font-Size="Small" />
                    <RowStyle Font-Size="Small" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#f0f0f0" Font-Size="Small" Font-Bold="true" />
                    <Columns>
                        <asp:BoundField DataField="RequestId" HeaderText="RequestId" HeaderStyle-HorizontalAlign="Left"
                            Visible="false" />
                        <asp:BoundField DataField="UserId" HeaderText="UserId" HeaderStyle-HorizontalAlign="Left"
                            Visible="false" />
                        <asp:BoundField DataField="FullName" HeaderText="Full Name" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="CarpoolingPreference" HeaderText="Carpooling Preference" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PickUpLocation" HeaderText="PickUp Location" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="DropLocation" HeaderText="Drop Location" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Date" HeaderText="Date" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Time" HeaderText="Time" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Comment" HeaderText="Comment" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-HorizontalAlign="Left" />

                    </Columns>
                </asp:GridView>
                <br />

            </fieldset>
            <br />
            <br />
            <fieldset>
                <legend align="center"><i>Ride Seekers</i></legend>
                <br />
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" Width="100%" OnRowCommand="GridView1_OnRowCommand">
                    <AlternatingRowStyle BackColor="#f0f0f0" HorizontalAlign="Left" Font-Size="Small" />
                    <RowStyle Font-Size="Small" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#f0f0f0" Font-Size="Small" Font-Bold="true" />
                    <Columns>
                        <asp:BoundField DataField="RequestId" HeaderText="RequestId" HeaderStyle-HorizontalAlign="Left"
                            Visible="false" />
                        <asp:BoundField DataField="UserId" HeaderText="UserId" HeaderStyle-HorizontalAlign="Left"
                            Visible="false" />
                        <asp:BoundField DataField="FullName" HeaderText="Full Name" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="CarpoolingPreference" HeaderText="Carpooling Preference" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="PickUpLocation" HeaderText="PickUp Location" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="DropLocation" HeaderText="Drop Location" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Date" HeaderText="Date" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Time" HeaderText="Time" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Comment" HeaderText="Comment" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-HorizontalAlign="Left" />
                        
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="btnAccept" runat="server" CausesValidation="false" CommandName="Accept"
                                    Text="Accept" CommandArgument='<%# Eval("RequestId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                <br />

            </fieldset>
            <br />
            <asp:Button Text="Add Request" runat="server" OnClick="btnAdd_Click" ID="btnAddRegister" Style="background-color: blue; color: white;" />
            <asp:Button Text="Cancel" runat="server" OnClick="btnCancel_Click" ID="btnCancel" Style="background-color: blue; color: white;" /><br />
            <br />
        </form>
    </section>

</body>
</html>
