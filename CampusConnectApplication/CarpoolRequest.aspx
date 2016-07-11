<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarpoolRequest.aspx.cs" Inherits="CampusConnectApplication.CarpoolRequest" %>

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
                <legend align="center"><i>CarPool Request</i></legend>
                <br/>

                <br/>
                <fieldset>
                    <legend align="center"><i>Request Details</i></legend>
                    <br/>

                    <asp:Label ID="lblErrorMsg" ForeColor="red" runat="server" Text=""></asp:Label>
            <br />
            <br />

                    <label for="cpPreference">Car Pooling Preference: </label>
                    <br/>
                    <select name="cpPreference" runat="server" id="cpPreference">
                        <option value="0">Car Owner(Only)</option>
                        <option value="1">Ride Seeker(Only)</option>
                    </select><br/><br/>

                    <label for="pickup">Pickup Location: </label>
                    <br/>
                    <input name="pickup" id="txtpickup" type="text" runat="server" value="" required="required" /><br/><br/>

                    <label for="txtdrop">Drop Location: </label>
                    <br/>
                    <input name="drop" id="txtdrop" type="text" runat="server" value="" required="required" /><br/><br/>

                    <label for="dt">Date : </label>
                    <br/>
                    <input name="dt" id="txtDate" type="date" runat="server" required="required"  value=""     />
                    <br/><br/>

                    <label for="timeslot">Time Slot: </label>
                    <br/>
                    <select name="timeslot" id="timeslot" runat="server">
                        <option>9 Am</option>
                        <option>10 Am</option>
                        <option>11 Am</option>
                        <option>12 pm</option>
                        <option>1 pm</option>
                        <option>2 pm</option>
                        <option>3 pm</option>
                        <option>4 pm</option>
                        <option>5 pm</option>
                        <option>6 pm</option>
                        <option>7 pm</option>
                    </select><br/>
                </fieldset>
                <br/>
                <br/>

                <label for="comment">Comments: </label>
                <br/>
                <textarea name="comment" cols="35" row="5" runat="server" id="txtComment" wrap="physical"></textarea><br/>
                <br/>
            </fieldset>
            <br/>
            <asp:Button Text="Submit" runat="server" OnClick="btnSubmit_Click" ID="btnRegister" Style="background-color: blue; color: white;" />
		<asp:Button Text="Cancel" runat="server" OnClick="btnCancel_Click" ID="btnCancel" Style="background-color: blue; color: white;" /><br/><br/>
        </form>
    </section>

</body>
</html>
