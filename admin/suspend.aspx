<%@ Page Language="VB" AutoEventWireup="false" CodeFile="suspend.aspx.vb" Inherits="_Default" %>

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
            <asp:Panel ID="pnlPerson" runat="server" style="z-index: 1; left: 0px; top: 0px; position: relative; height: 275px; width: 432px; border-right: 1px solid #666;">
                 <asp:Label ID="lblSuspended" runat="server" style="z-index: 1; left: 0px; top: -4px; position: relative; width: 387px;" Text="Suspended Phone Numbers:" CssClass="rockwell welcome"></asp:Label>
                <asp:ListBox ID="lstSuspended" runat="server" Height="130px" Width="400px" style="z-index: 1; left: 0px; top:-5px; position: relative;"></asp:ListBox>
                <asp:Button ID="btnUnsuspend" runat="server" style="z-index: 1; left: 188px; top: 20px; position: relative" Text="Unsuspend Phone Number" CssClass="button warning suspendbutton"/>
            </asp:Panel>


            <asp:Panel ID="pnlNumber" runat="server" style="z-index: 1; left: 346px; top: -280px; position: relative; height: 275px; width: 538px">
                
                <asp:Label ID="lblPhoneNumberTitle" runat="server" style="z-index: 1; left: 130px; top: 0px; position: relative; width: 353px;" Text="Suspend by phone no.:" CssClass="rockwell welcome" Width="350px"></asp:Label>

                <asp:Label ID="lblPhoneNumber" runat="server" style="position: relative; left: -229px; top: 68px; height: 36px; font-weight: 700;" Text="Phone number:"></asp:Label>
		    <asp:TextBox ID="txtPhoneNumber" runat="server" style="z-index: 1; position: relative; left: 266px; top: 20px; width: 210px; height: 32px"></asp:TextBox>
                
            <br />

            <asp:Label ID="lblReason" runat="server" style="position: relative; left: 128px; top: 40px; height: 36px; font-weight: 700;" Text="Reason:"></asp:Label>
		    <asp:TextBox ID="txtReason" runat="server" style="z-index: 1; position: relative; left: 198px; top: 40px; width: 210px; height: 32px"></asp:TextBox>

                  <br />

            <asp:Label ID="lblConfirmError" runat="server" style="position: relative; left: 128px; top: 57px; height: 36px; width: 152px; font-weight: 700; font-style: italic;" Text=""></asp:Label>

                <asp:Button ID="btnSuspendNumber" runat="server" style="z-index: 1; left: 126px; top: 64px; position: relative" Text="Suspend Phone Number" CssClass="button warning suspendbutton"/>
            </asp:Panel>

		</div>
	</div>
    </form>
</body>
</html>
