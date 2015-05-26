<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

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
			<asp:Panel ID="pnlDetails" runat="server" style="z-index: 1; left: 0px; top: 0px; position: relative; height: 275px; width: 340px">
                <asp:Label ID="lblWelcome" runat="server" style="z-index: 1; left: 0px; top: 0px; position: relative; width: 353px;" Text="Welcome back, Scott." CssClass="rockwell welcome" Width="350px"></asp:Label>
             
                <asp:Label ID="lblEmailTitle" runat="server" style="z-index: 1; font-weight: 700; width: 48px;" Text="Email:" CssClass="details"></asp:Label>
                <asp:Label ID="lblEmail" runat="server" style="z-index: 1; width: 260px;" Text="xx@xx.com" CssClass="details"></asp:Label>

                <asp:Label ID="lblLastTitle" runat="server" style="z-index: 1; font-weight: 700; width: 78px;" Text="Last login:" CssClass="details"></asp:Label>
                <asp:Label ID="lblLast" runat="server" style="z-index: 1; width: 240px;" Text="xx/xx/xxxx" CssClass="details"></asp:Label>

                <asp:Label ID="lblNumbersTitle" runat="server" style="z-index: 1; font-weight: 700; width: 150px;" Text="Phones suspended:" CssClass="details"></asp:Label>
                <asp:Label ID="lblNumbers" runat="server" style="z-index: 1; width: 80px;" Text="x" CssClass="details"></asp:Label>


                <asp:Button ID="btnEdit" runat="server" style="z-index: 1; left: 0px; top: 74px; position: relative" Text="Edit your details" CssClass="button std edit"/>


            </asp:Panel>
		    <asp:Panel ID="pnlStats" runat="server" style="z-index: 1; left: 346px; top: -275px; position: relative; height: 275px; width: 538px">
                <asp:Panel ID="pnlNewUsers" runat="server" CssClass="stat big">
                    <asp:Label ID="lblNewUsers" runat="server" Text="x" CssClass="largestat" Width="206px"></asp:Label>
                    <asp:Label ID="lblNewText" runat="server" Text="new users this month" CssClass="stattext" Width="206px"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnlCalls" runat="server" CssClass="stat big">
                    <asp:Label ID="lblCalls" runat="server" Text="x" CssClass="largestat" Width="206px"></asp:Label>
                    <asp:Label ID="lblCallsText" runat="server" Text="calls made by users this month" CssClass="stattext white" Width="206px"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnlDate" runat="server" CssClass="stat date" style="padding: 26px 0 0; position: relative; top: -3px;">
                    <asp:Label ID="lblDate" runat="server" Text="x" CssClass="smallstat" Width="98px" style="margin: 0px 0 0;"></asp:Label>
                    <asp:Label ID="lblDateText" runat="server" Text="days left in this month" CssClass="stattext" Width="78px" style="padding: 0 10px;"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnlReturning" runat="server" CssClass="stat big">
                    <asp:Label ID="lblReturning" runat="server" Text="x" CssClass="largestat" Width="206px"></asp:Label>
                    <asp:Label ID="lblReturningText" runat="server" Text="returning users this month" CssClass="stattext" Width="206px"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnlTexts" runat="server" CssClass="stat big">
                    <asp:Label ID="lblTexts" runat="server" Text="x" CssClass="largestat" Width="206px"></asp:Label>
                    <asp:Label ID="lblTextsText" runat="server" Text="texts sent by users this month" CssClass="stattext white" Width="206px"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnlMessages" runat="server" CssClass="stat msg">
                    <asp:Label ID="lblMessages" runat="server" Text="0" CssClass="smallstat" Width="98px"></asp:Label>
                    <asp:Label ID="lblMessagesText" runat="server" Text="new messages" CssClass="stattext" Width="78px" style="padding: 0 10px;"></asp:Label>
                </asp:Panel>

                <asp:Button ID="btnAddAdmin" runat="server" style="z-index: 1; left: 174px; top: 0px; position: relative" Text="Add/Disable Admin" CssClass="button std register"/>
                <asp:Button ID="btnReports" runat="server" style="z-index: 1; left: 180px; top: 0px; position: relative" Text="Go to Reports Portal" CssClass="button std reports"/>

            </asp:Panel>
		</div>
	</div>
    </form>
</body>
</html>
