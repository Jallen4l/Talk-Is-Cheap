<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../assets/css/main.css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnLogin">
        <div id="wrapper" style="width: 460px; margin: 40px auto;">
		<div class="header">
            <asp:Label ID="lblTitle" runat="server" style="z-index: 3; left: 0px; top: 18px; position: relative;" Text="Talk-Is-Cheap" Width="460px" Height="58px" CssClass="rockwell title"></asp:Label>
		</div>

		<div runat="server" class="content thin" id="ChangeHeight" style="height: 290px;">

            <asp:Label ID="lblHeader" runat="server" style="z-index: 1; left: 0px; top: 0px; position: relative; text-align: center" Text="Welcome to Talk-Is-Cheap, the UK's fasted growing telecommunications company." Width="380px"></asp:Label>
            <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 0px; top: 6px; position: relative; text-align: center; color: #bd362f;" Text="" Width="380px"></asp:Label>

            <br />

			<asp:Label ID="lblUsername" runat="server" style="position: relative; left:  30px; top: 30px; height: 36px; font-weight: 700;" Text="Username:"></asp:Label>
		    <asp:TextBox ID="txtUsername" runat="server" style="z-index: 1; position: relative; left: 41px; top: 30px; width: 210px; height: 32px"></asp:TextBox>

            <asp:Label ID="lblPassword" runat="server" style="position: relative; left: 30px; top: 44px; height: 36px; font-weight: 700;" Text="Password:"></asp:Label>
		    <asp:TextBox ID="txtPassword" runat="server" style="z-index: 1; position: relative; left: 42px; top: 44px; width: 210px; height: 32px" TextMode="Password"></asp:TextBox>
            <asp:Button ID="btnPasswordReminder" runat="server" style="z-index: 1; left: 236px; top: 34px; position: relative" Text="Forgot your password?" CssClass="button forgot" />

            <asp:Button ID="btnLogin" runat="server" style="z-index: 1; left: 141px; top: 88px; position: relative" Text="Log in" CssClass="button confirm login" />
            <asp:Button ID="btnRegister" runat="server" style="z-index: 1; left: -179px; top: 88px; position: relative" Text="Register" CssClass="button std register"/>


		    


		</div>
	</div>
    </form>
</body>
</html>
