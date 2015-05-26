﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="send.aspx.vb" Inherits="_Default" %>

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

		<div class="content" style="height: 290px;">
            <asp:Panel ID="pnlMessages" runat="server" style="z-index: 1; left: 0px; top: 0px; position: relative; height: 275px; width: 680px">
            <asp:Label ID="lblSendTo" runat="server" style="z-index: 1; left: 0px; top: -10px; position: relative; width: 880px;" Text="Sending to: All Admins"></asp:Label>
            <asp:TextBox ID="txtMessage" runat="server" Height="203px" Width="878px" style="z-index: 1; left: 0; top:10px; position: relative;" TextMode="MultiLine" MaxLength="280"></asp:TextBox>
            <asp:Button ID="btnSend" runat="server" style="z-index: 1; left: 782px; top:30px; position: relative" Text="Send" CssClass="button confirm send"/>

            </asp:Panel>
           
		</div>
	</div>
    </form>
</body>
</html>