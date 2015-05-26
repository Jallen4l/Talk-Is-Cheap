<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            $('#btnHelp').tipsy({ gravity: 'e', fallback: "Help" });
            $('#btnLogout').tipsy({ gravity: 'w', fallback: "Logout" });
        });
       </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
		<div class="header">
            <asp:Label ID="lblTitle" runat="server" style="z-index: 3; left: 0px; top: 18px; position: relative;" Text="Talk-Is-Cheap" Width="960px" Height="58px" CssClass="rockwell title"></asp:Label>
			<asp:Button ID="btnHome" runat="server" style="z-index: 5; left: 0px; top: -31px; position: relative" Text="" CssClass="button std home" />
            <asp:Button ID="btnMail" runat="server" style="z-index: 5; left: 5px; top: -31px; position: relative" Text="" CssClass="button std mail"/>
            <asp:Button ID="btnHelp" runat="server" style="z-index: 5; right: -751px; top: -31px; position: relative" Text="" CssClass="button std help"/>
            <asp:Button ID="btnLogout" runat="server" style="z-index: 5; right: -756px; top: -31px; position: relative" Text="" CssClass="button std logout"/>
		</div>

		<div class="content">
			<asp:Panel ID="pnlDetails" runat="server" style="z-index: 1; left: 0px; top: 0px; position: relative; height: 275px; width: 340px">
                <asp:Label ID="lblWelcome" runat="server" style="z-index: 1; left: 0px; top: 0px; position: relative; width: 353px;" Text="Welcome back, Jack." CssClass="rockwell welcome" Width="350px"></asp:Label>
             
                <asp:Label ID="lblPhoneNoTitle" runat="server" style="z-index: 1; font-weight: 700; width: 113px;" Text="Phone number:" CssClass="details"></asp:Label>
                <asp:Label ID="lblPhoneNo" runat="server" style="z-index: 1; width: 147px;" Text="07123456789" CssClass="details"></asp:Label>

                <asp:Label ID="lblContractTitle" runat="server" style="z-index: 1; font-weight: 700; width: 103px;" Text="Contract type:" CssClass="details"></asp:Label>
                <asp:Label ID="lblContactType" runat="server" style="z-index: 1; width: 147px;" Text="International" CssClass="details"></asp:Label>

                <asp:Label ID="lblContractEndTitle" runat="server" style="z-index: 1; font-weight: 700; width: 135px;" Text="Contract End Date:" CssClass="details"></asp:Label>
                <asp:Label ID="lblContractEnd" runat="server" style="z-index: 1; width: 177px;" Text="18/12/2013" CssClass="details"></asp:Label>

                <asp:Label ID="lblEmailTitle" runat="server" style="z-index: 1; font-weight: 700; width: 48px;" Text="Email:" CssClass="details"></asp:Label>
                <asp:Label ID="lblEmail" runat="server" style="z-index: 1; width: 260px;" Text="jack@email.com" CssClass="details"></asp:Label>


                <asp:Button ID="btnEdit" runat="server" style="z-index: 1; left: 0px; top: 56px; position: relative" Text="Edit your details" CssClass="button std edit"/>


            </asp:Panel>
		    <asp:Panel ID="pnlStats" runat="server" style="z-index: 1; left: 346px; top: -275px; position: relative; height: 275px; width: 538px">
                <asp:Panel ID="pnlMinutesLeft" runat="server" CssClass="stat big">
                    <asp:Label ID="lblMinutesLeft" runat="server" Text="0" CssClass="largestat" Width="206px"></asp:Label>
                    <asp:Label ID="lblMinuteText" runat="server" Text="minutes left this month" CssClass="stattext" Width="206px"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnlTextsLeft" runat="server" CssClass="stat big">
                    <asp:Label ID="lblTextsLeft" runat="server" Text="3" CssClass="largestat" Width="206px"></asp:Label>
                    <asp:Label ID="lblTextsText" runat="server" Text="texts left this month" CssClass="stattext" Width="206px"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnlDaysLeft" runat="server" CssClass="stat date" style="padding: 20px 0 0; position: relative; top: 7px;">
                    <asp:Label ID="lblDaysLeft" runat="server" Text="31" CssClass="smallstat" Width="98px" style="margin: 0px 0 0;"></asp:Label>
                    <asp:Label ID="lblDaysText" runat="server" Text="days left in this month" CssClass="stattext" Width="78px" style="padding: 0 10px;"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnlCallsMade" runat="server" CssClass="stat big">
                    <asp:Label ID="lblCallsMade" runat="server" Text="7" CssClass="largestat" Width="206px"></asp:Label>
                    <asp:Label ID="lblCallsText" runat="server" Text="calls made this month" CssClass="stattext" Width="206px"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnlTextsMade" runat="server" CssClass="stat big">
                    <asp:Label ID="lblTextsMade" runat="server" Text="297" CssClass="largestat" Width="206px"></asp:Label>
                    <asp:Label ID="lblTextsMadeText" runat="server" Text="texts sent this month" CssClass="stattext" Width="206px"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnlBill" runat="server" CssClass="stat bill">
                    <asp:Label ID="lblBil" runat="server" CssClass="smallstat" Width="98px"></asp:Label>
                    <asp:Label ID="lblBillText" runat="server" Text="bill for this month" CssClass="stattext" Width="78px" style="padding: 0 10px;"></asp:Label>
                </asp:Panel>

                <asp:Button ID="btnActivity" runat="server" style="z-index: 1; left: 333px; top: 0px; position: relative" Text="View indepth activity log" CssClass="button std activity"/>

            </asp:Panel>
		</div>
	</div>
    </form>
</body>
</html>
