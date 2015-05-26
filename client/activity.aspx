<%@ Page Language="VB" AutoEventWireup="false" CodeFile="activity.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../assets/css/main.css" />
    <link rel="stylesheet" href="../assets/css/client.css" />
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
            <asp:Button ID="btnHelp" runat="server" style="z-index: 5; right: -751px; top: -31px; position: relative" Text="" CssClass="button std help"/>
            <asp:Button ID="btnLogout" runat="server" style="z-index: 5; right: -756px; top: -31px; position: relative" Text="" CssClass="button std logout"/>
		</div>

		<div class="content">
            <asp:Panel ID="pnlPerson" runat="server" style="z-index: 1; left: 0px; top: 0px; position: relative; height: 275px; width: 432px; border-right: 1px solid #666;">
                 <asp:Label ID="lblOldReports" runat="server" style="z-index: 1; left: 0px; top: -4px; position: relative; width: 387px;" Text="Previous Reports:" CssClass="rockwell welcome"></asp:Label>
                <asp:ListBox ID="lstOldReports" runat="server" Height="130px" Width="400px" style="z-index: 1; left: 0px; top:-5px; position: relative;"></asp:ListBox>
                <asp:Button ID="btnDelete" runat="server" style="z-index: 1; left: 0px; top: 20px; position: relative" Text="Delete" CssClass="button warning delete"/>
                <asp:Label ID="lblConfirmError" runat="server" style="position: relative; left: 10px; top: 20px; height: 36px; width: 130px; font-weight: 700; font-style: italic; color: #CC0000;" Text=" "></asp:Label>
                <asp:Button ID="btnOpen" runat="server" style="z-index: 1; left: 20px; top: 20px; position: relative" Text="Open Report" CssClass="button std open"/>
            </asp:Panel>


            <asp:Panel ID="pnlNumber" runat="server" style="z-index: 1; left:426px; top: -280px; position: relative; height: 275px; width: 538px">
                
            <asp:Label ID="lblNewReports" runat="server" style="z-index: 1; left: 30px; top: 0px; position: relative; width: 353px;" Text="Produce New Report:" CssClass="rockwell welcome" Width="350px"></asp:Label>
                
                <br />

            <asp:Button ID="btnOutgoingCalls" runat="server" style="z-index: 1; left: 30px; top: 0px; position: relative" Text="All Outgoing Calls" CssClass="button confirm report"/>
            <asp:Button ID="btnIncomingCalls" runat="server" style="z-index: 1; left: 40px; top: 0px; position: relative" Text="All Incoming Calls" CssClass="button confirm report"/>
            <br />
            <asp:Button ID="btnSentSMS" runat="server" style="z-index: 1; left: 30px; top: 16px; position: relative" Text="All Sent Texts" CssClass="button confirm report"/>
            <asp:Button ID="btnRecievedSMS" runat="server" style="z-index: 1; left: 40px; top: 16px; position: relative" Text="All Recieved Texts" CssClass="button confirm report"/>
            <br />
            <asp:Button ID="btnLastOutgoing" runat="server" style="z-index: 1; left: 30px; top: 30px; position: relative" Text="Last Months Outgoing" CssClass="button confirm report"/>
            <asp:Button ID="btnLastIncoming" runat="server" style="z-index: 1; left: 40px; top: 30px; position: relative" Text="Last Months Incoming" CssClass="button confirm report"/>
            <br />
            <asp:Button ID="btnLastSent" runat="server" style="z-index: 1; left: 30px; top: 46px; position: relative" Text="Last Months Sent" CssClass="button confirm report"/>
            <asp:Button ID="btnLastRecieved" runat="server" style="z-index: 1; left: 40px; top: 46px; position: relative" Text="Last Months Recieved" CssClass="button confirm report"/>

            </asp:Panel>

		</div>
	</div>
    </form>
</body>
</html>
