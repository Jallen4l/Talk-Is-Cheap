<%@ Page Language="VB" AutoEventWireup="false" CodeFile="details.aspx.vb" Inherits="_Default" %>

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

		<div class="content" style="height: 300px;">
            <asp:Panel ID="pnlDetails" runat="server" style="z-index: 1; left: 0px; top: 0px; position: relative; height: 275px; width: 432px; border-right: 1px solid #666;">
                <asp:Label ID="lblDetails" runat="server" style="z-index: 1; left: 26px; top: 0px; position: relative; width: 353px;" Text="Change your details:" CssClass="rockwell welcome" Width="350px"></asp:Label>

                <asp:Label ID="lblUsername" runat="server" style="position: relative; left: 18px; top: 14px; height: 36px; font-weight: 700;" Text="Username:"></asp:Label>
		    <asp:TextBox ID="txtUsername" runat="server" style="z-index: 1; position: relative; left: 37px; top: 14px; width: 210px; height: 32px"></asp:TextBox>

                <br />

            <asp:Label ID="lblLastName" runat="server" style="position: relative; left: 18px; top: 27px; height: 36px; font-weight: 700;" Text="Last name:"></asp:Label>
		    <asp:TextBox ID="txtLastName" runat="server" style="z-index: 1; position: relative; left: 36px; top: 27px; width: 210px; height: 32px"></asp:TextBox>

            <br />

            <asp:Label ID="lblEmail" runat="server" style="position: relative; left: 18px; top: 40px; height: 36px; font-weight: 700;" Text="Email:"></asp:Label>
		    <asp:TextBox ID="txtEmail" runat="server" style="z-index: 1; position: relative; left: 73px; top:40px; width: 210px; height: 32px"></asp:TextBox>

                <asp:Button ID="btnSaveDetails" runat="server" style="z-index: 1; left: -86px; top: 102px; position: relative" Text="Save new details" CssClass="button confirm save"/>
            </asp:Panel>


            <asp:Panel ID="pnlPassword" runat="server" style="z-index: 1; left: 346px; top: -280px; position: relative; height: 275px; width: 538px">
                
                <asp:Label ID="lblChangePassword" runat="server" style="z-index: 1; left: 130px; top: 0px; position: relative; width: 353px;" Text="Change your password:" CssClass="rockwell welcome" Width="350px"></asp:Label>

                <asp:Label ID="lblOldPassword" runat="server" style="position: relative; left: -229px; top: 68px; height: 36px; font-weight: 700;" Text="Old Password:"></asp:Label>
		    <asp:TextBox ID="txtPassword" runat="server" style="z-index: 1; position: relative; left: 266px; top: 20px; width: 210px; height: 32px"></asp:TextBox>

            <br />

            <asp:Label ID="lblNewPassword" runat="server" style="position: relative; left: 128px; top: 40px; height: 36px; font-weight: 700;" Text="New Password:"></asp:Label>
		    <asp:TextBox ID="txtNew" runat="server" style="z-index: 1; position: relative; left: 141px; top: 40px; width: 210px; height: 32px"></asp:TextBox>

             <br />

            <asp:Label ID="lblConfirmNew" runat="server" style="position: relative; left: 128px; top: 50px; height: 36px; font-weight: 700;" Text="Confirm <br />New Password:"></asp:Label>
		    <asp:TextBox ID="txtConfirmNew" runat="server" style="z-index: 1; position: relative; left: 141px; top: 40px; width: 210px; height: 32px"></asp:TextBox>

                <asp:Button ID="btnSavePassword" runat="server" style="z-index: 1; left: -35px; top: 104px; position: relative" Text="Save new password" CssClass="button confirm save"/>
            </asp:Panel>
		</div>
	</div>
    </form>
</body>
</html>
