<%@ Page Language="VB" AutoEventWireup="false" CodeFile="forgot.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../assets/css/main.css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnSend">
        <div id="wrapper" style="width: 460px; margin: 40px auto;">
		<div class="header">
            <asp:Label ID="lblTitle" runat="server" style="z-index: 3; left: 0px; top: 18px; position: relative;" Text="Talk-Is-Cheap" Width="460px" Height="58px" CssClass="rockwell title"></asp:Label>
		</div>

		<div class="content thin" style="height: 220px;">

            <asp:Label ID="lblHeader" runat="server" style="z-index: 1; left: 0px; top: 0px; position: relative; text-align: center; font-size: 28px;" Text="Forgot your password?" Width="380px" CssClass="rockwell"></asp:Label>

			<asp:Label ID="lblEmail" runat="server" style="position: relative; left:  0px; top: 30px; height: 36px; width: 380px; font-weight: 700; text-align: center;" Text="Please enter the email address associated with your account:"></asp:Label>
		    <asp:TextBox ID="txtEmail" runat="server" style="z-index: 1; position: relative; left: 0px; top: 40px; width: 380px; height: 32px"></asp:TextBox>
            <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 0px; top: 50px; position: relative; text-align: center; color: #bd362f;" Text="" Width="380px"></asp:Label>

            <asp:Button ID="btnCancel" runat="server" style="z-index: 1; left: 0px; top: 60px; position: relative" Text="Cancel" CssClass="button warning cancel" />
            <asp:Button ID="btnSend" runat="server" style="z-index: 1; left: 119px; top: 60px; position: relative" Text="Send me an email" CssClass="button confirm login" />
		    </div>
	    </div>
    </form>
</body>
</html>
