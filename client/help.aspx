<%@ Page Language="VB" AutoEventWireup="false" CodeFile="help.aspx.vb" Inherits="_Default" %>

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
			<asp:Button ID="btnHome" runat="server" style="z-index: 5; left: 0px; top: -31px; position: relative" Text="" CssClass="button std home"/>
            <asp:Button ID="btnMail" runat="server" style="z-index: 5; left: 5px; top: -31px; position: relative" Text="" CssClass="button std mail"/>
            <asp:Button ID="btnHelp" runat="server" style="z-index: 5; right: -751px; top: -31px; position: relative" Text="" CssClass="button std help"/>
            <asp:Button ID="btnLogout" runat="server" style="z-index: 5; right: -756px; top: -31px; position: relative" Text="" CssClass="button std logout"/>
		</div>

		<div class="content" style="height: auto;">
			<asp:Panel ID="pnlFAQ" runat="server" style="z-index: 1;">
            <asp:Label ID="lblFAQ" runat="server" style="z-index: 1;" Text="Frequently Asked Questions" CssClass="rockwell welcome" Width="900px"></asp:Label>

		    <strong>Am I able to recover my password?</strong>
            <p>Yes, you will fine a button on the login page that will say 'Forgot your password?'. Once clicked you will be required to enter a few details and have your password sent to you via E-Mail.</p>

            <strong>Can I change me details at anytime?</strong>
            <p>Yes, once you are on the home page you will see a button called 'Edit your details' once on the edit details page you can see all your details in boxes. Simply change the detail(s) you like and save.</p>

            <strong>Am I able to change my password?</strong>
            <p>Yes, [see question 2] once you are on the edit details page, there's a change password section. Enter your current password then enter your new password twice, hit save if correct your password will have changed.</p>
            
            <strong>Am I able to contact someone if necessary?</strong>
            <p>Yes, once you are on the home page you will see a 'Mail' icon in the top left click on this. Once on the mail page you have the ability to send an enquiry to all our admin. When you next log in, on the home page if the mail button is orange you have a reply.</p>
            </asp:Panel>
		</div>
	</div>
    </form>
</body>
</html>
