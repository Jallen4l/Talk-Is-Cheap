<%@ Page Language="VB" AutoEventWireup="false" CodeFile="admins.aspx.vb" Inherits="_Default" %>

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

		<div class="content" style="height: 320px;">
			<asp:Panel ID="pnlPerson" runat="server" style="z-index: 1; left: 0px; top: 0px; position: relative; height: 275px; width: 432px; border-right: 1px solid #666;">
                 <asp:Label ID="lblDisable" runat="server" style="z-index: 1; left: 0px; top: -4px; position: relative; width: 387px;" Text="Disable Admins:" CssClass="rockwell welcome"></asp:Label>
                <asp:ListBox ID="lstAdmins" runat="server" Height="130px" Width="400px" style="z-index: 1; left: 0px; top:-5px; position: relative;"></asp:ListBox>
                <asp:Button ID="btnDisable" runat="server" style="z-index: 1; left: 258px; top: 20px; position: relative" Text="Disable Admin" CssClass="button warning suspendbutton"/>
            </asp:Panel>


            <asp:Panel ID="pnlNumber" runat="server" style="z-index: 1; left: 426px; top: -280px; position: relative; height: 475px; width: 538px">
                
                <asp:Label ID="lblAddAdmin" runat="server" style="z-index: 1; left: 50px; top: 0px; position: relative; width: 353px;" Text="Add Admin:" CssClass="rockwell welcome" Width="350px"></asp:Label>

                <asp:Label ID="lblFirstName" runat="server" style="position: relative; left: -309px; top: 48px; height: 36px; font-weight: 700;" Text="First name:"></asp:Label>
		    <asp:TextBox ID="txtFirstname" runat="server" style="z-index: 1; position: relative; left: 196px; top: 0px; width: 210px; height: 32px"></asp:TextBox>
                
            <br />

            <asp:Label ID="lblLastName" runat="server" style="position: relative; left: 48px; top: 20px; height: 36px; font-weight: 700;" Text="Last name:"></asp:Label>
		    <asp:TextBox ID="txtLastName" runat="server" style="z-index: 1; position: relative; left: 108px; top: 20px; width: 210px; height: 32px"></asp:TextBox>

             <br />

             <asp:Label ID="lblEmail" runat="server" style="position: relative; left: 48px; top: 32px; height: 36px; font-weight: 700;" Text="Email:"></asp:Label>
		    <asp:TextBox ID="txtEmail" runat="server" style="z-index: 1; position: relative; left: 145px; top: 32px; width: 210px; height: 32px"></asp:TextBox>

             <br />

             <asp:Label ID="lblUsername" runat="server" style="position: relative; left: 48px; top: 44px; height: 36px; font-weight: 700;" Text="Username:"></asp:Label>
		    <asp:TextBox ID="txtUsername" runat="server" style="z-index: 1; position: relative; left: 110px; top: 44px; width: 210px; height: 32px"></asp:TextBox>

             <br />

            <asp:Label ID="lblConfirmError" runat="server" style="position: relative; left: 48px; top: 57px; height: 36px; width: 152px; font-weight: 700; font-style: italic;" Text=""></asp:Label>

                <asp:Button ID="btnAddAdmin" runat="server" style="z-index: 1; left: 134px; top: 54px; position: relative" Text="Add Admin" CssClass="button confirm register"/>
            </asp:Panel>
		</div>
	</div>
    </form>
</body>
</html>
