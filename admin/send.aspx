<%@ Page Language="VB" AutoEventWireup="false" CodeFile="send.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../assets/css/main.css" />
    <link rel="stylesheet" href="../assets/css/admin.css" />
    <link rel="stylesheet" href="../assets/css/tipsy.css" />
  
    <script src="../assets/js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../assets/js/jquery.tipsy.js" type="text/javascript">
        
    </script>
    <script type='text/javascript'>
        $(function () {
            $('#btnHome').tipsy({ gravity: 'e', fallback: "Home" });
            $('#btnMail').tipsy({ gravity: 'w', fallback: "Messages" });
            $('#btnSuspend').tipsy({ gravity: 'e', fallback: "Suspend Person/Phone Number" });
            $('#btnLogout').tipsy({ gravity: 'w', fallback: "Logout" });
        });
       </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
		<div class="header">
            <asp:Label ID="lblTitle" runat="server" style="z-index: 3; left: 0px; top: 18px; position: relative;" Text="Talk-Is-Cheap" Width="960px" Height="58px" CssClass="rockwell title"></asp:Label>
			<asp:Button ID="btnHome" runat="server" style="z-index: 5; left: 0px; top: -31px; position: relative" Text="" CssClass="button std home"/>
            <asp:Button ID="btnMail" runat="server" style="z-index: 5; left: 5px; top: -31px; position: relative" Text="" CssClass="button std mail"/>
            <asp:Button ID="btnSuspend" runat="server" style="z-index: 5; right: -751px; top: -31px; position: relative" Text="" CssClass="button warning suspend"/>
            <asp:Button ID="btnLogout" runat="server" style="z-index: 5; right: -756px; top: -31px; position: relative" Text="" CssClass="button std logout"/>
		</div>

		<div class="content">
            <asp:Panel ID="pnlMessages" runat="server" style="z-index: 1; left: 0px; top: 0px; position: relative; height: 275px; width: 680px">
		    <asp:Button ID="btnChoose" runat="server" style="z-index: 1; left: 0px; top:0px; position: relative" Text="Choose Recipient" CssClass="button std message"/>
            <asp:Label ID="lblSendTo" runat="server" style="z-index: 1; left: 170px; top: -30px; position: relative; width: 880px;" Text="Sending to:"></asp:Label>

            <asp:Button ID="btnSend" runat="server" style="z-index: 1; left: 785px; top:-60px; position: relative" Text="Send" CssClass="button confirm send"/>
            <asp:TextBox ID="txtMessage" runat="server" Height="203px" Width="878px" style="z-index: 1; left: 0; top:-40px; position: relative;" TextMode="MultiLine" MaxLength="280"></asp:TextBox>

            </asp:Panel>

            <asp:Panel ID="pnlChoose" runat="server" style="z-index: 1; left: 0px; top: -276px; position: relative; height: 275px; width: 881px; background-color: #FFF;">

            <asp:Panel ID="pnlDetails" runat="server" style="z-index: 1; left: 0px; top: 0px; position: relative; height: 275px; width: 432px; border-right: 1px solid #666;">

                <asp:Label ID="lblDetails" runat="server" style="z-index: 1; left: 26px; top: -20px; position: relative; width: 353px;" Text="(1) Search for recipient:" CssClass="rockwell welcome" Width="350px"></asp:Label>

                <asp:Label ID="lblPhoneNo" runat="server" style="position: relative; left: 18px; top: -16px; height: 36px; font-weight: 700;" Text="Phone No.:"></asp:Label>
		    <asp:TextBox ID="txtPhoneNo" runat="server" style="z-index: 1; position: relative; left: 37px; top: -16px; width: 210px; height: 32px"></asp:TextBox>

            <br />
<asp:Label ID="lblOr1" runat="server" style="position: relative; left: 18px; top: -16px; height: 36px;" Text="OR"></asp:Label>
            <br />
            
            <asp:Label ID="lblLastname" runat="server" style="position: relative; left: 18px; top: -26px; height: 36px; font-weight: 700;" Text="Last name:"></asp:Label>
		    <asp:TextBox ID="txtLastname" runat="server" style="z-index: 1; position: relative; left: 38px; top: -26px; width: 210px; height: 32px"></asp:TextBox>

            <br />
<asp:Label ID="lblOr2" runat="server" style="position: relative; left: 18px; top: -26px; height: 36px;" Text="OR"></asp:Label>
            <br />
            
            <asp:Label ID="lblPostcode" runat="server" style="position: relative; left: 18px; top: -37px; height: 36px; font-weight: 700;" Text="Postcode:"></asp:Label>
		    <asp:TextBox ID="txtPostcode" runat="server" style="z-index: 1; position: relative; left: 44px; top: -37px; width: 210px; height: 32px"></asp:TextBox>

                <asp:Button ID="btnCancel" runat="server" style="z-index: 1; left: -284px; top: 16px; position: relative" Text="Cancel" CssClass="button warning cancel"/>
                <asp:Button ID="btnSearch" runat="server" style="z-index: 1; left: 153px; top: -30px; position: relative" Text="Search For Recipient" CssClass="button std search"/>
            </asp:Panel>


            <asp:Panel ID="pnlResults" runat="server" style="z-index: 1; left: 346px; top: -280px; position: relative; height: 275px; width: 538px">
                
                <asp:Label ID="lblResults" runat="server" style="z-index: 1; left: 130px; top: -18px; position: relative; width: 353px;" Text="(2) Search Results:" CssClass="rockwell welcome" Width="350px"></asp:Label>

                <asp:ListBox ID="lstSearchResults" runat="server" Height="74px" Width="413px" style="z-index: 1; left: 120px; top:-16px; position: relative;"></asp:ListBox>

                <asp:Button ID="btnSelect" runat="server" style="z-index: 1; left: 384px; top: 0px; position: relative" Text="Select recipient" CssClass="button confirm register"/>
                <asp:Label ID="lblOr3" runat="server" style="position: relative; left: 300px; top: 55px; height: 36px; font-weight: 700;" Text="Or"></asp:Label>
                <asp:Button ID="btnAllClients" runat="server" style="z-index: 1; left: 200px; top: 105px; position: relative" Text="Send to all Clients" CssClass="button confirm register"/>
                <asp:Button ID="btnAdmins" runat="server" style="z-index: 1; left: 120px; top: -45px; position: relative" Text="Choose Admin Recipient" CssClass="button std register"/>
            </asp:Panel>

                
                </asp:Panel>
		</div>
	</div>
    </form>
</body>
</html>
