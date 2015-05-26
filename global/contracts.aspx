<%@ Page Language="VB" AutoEventWireup="false" CodeFile="contracts.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../assets/css/main.css" />
    <link rel="stylesheet" href="../assets/css/tipsy.css" />
  
    <script src="../assets/js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../assets/js/jquery.tipsy.js" type="text/javascript">
        
    </script>
    <script type='text/javascript'>
        $(function () {
            $('#btnSelectBasic').tipsy({ gravity: 'n', fallback: "Choose the 'Basic' contract" });
            $('#btnSelectStandard').tipsy({ gravity: 'n', fallback: "Choose the 'Standard' contract" });
            $('#btnSelectPremium').tipsy({ gravity: 'n', fallback: "Choose the 'Premium' contract" });
            $('#btnSelectUnlimited').tipsy({ gravity: 'n', fallback: "Choose the 'Unlimited' contract" });
            $('#btnSelectInternational').tipsy({ gravity: 'n', fallback: "Choose the 'International' contract" });
            $('#btnCancel').tipsy({ gravity: 'e', fallback: "Go back to the registration page" });
        });
       </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper" style="width: 960px; margin: 40px auto;">
		<div class="header">
            <asp:Label ID="lblTitle" runat="server" style="z-index: 3; left: 0px; top: 18px; position: relative;" Text="Talk-Is-Cheap" Width="960px" Height="58px" CssClass="rockwell title"></asp:Label>
		</div>

		<div class="content wide" style="height: 670px;">
            <h1 class="rockwell contractheader"><asp:Label ID="lblContract" runat="server" style="z-index: 3; left: 0px; top: 18px; position: relative;" Text="Please Choose Your Contract"></asp:Label></h1>
            <div class="contract">
                <div class="basic"></div>
                <h1>Basic</h1>
                <p>Lorem ipsum dolor sit amet, cu sed illum feugait blandit.</p>
                <p class="detail">Minutes per month</p>
                <p class="number">25</p>
                <p class="detail">Texts per month</p>
                <p class="number">25</p>
                <p class="detail">Price per month</p>
                <p class="number bigger">£5</p>
		            <asp:Button ID="btnSelectBasic" runat="server" style="z-index: 1; left: 29px; top: 10px; position: relative" Text="Select" CssClass="button confirm select"/>
            </div>
            <div class="contract">
		        <div class="standard"></div>
                <h1>Standard</h1>
                <p>Lorem ipsum dolor sit amet, cu sed illum feugait blandit.</p>
                <p class="detail">Minutes per month</p>
                <p class="number">100</p>
                <p class="detail">Texts per month</p>
                <p class="number">200</p>
                <p class="detail">Price per month</p>
                <p class="number bigger">£20</p>
		            <asp:Button ID="btnSelectStandard" runat="server" style="z-index: 1; left: 29px; top: 10px; position: relative" Text="Select" CssClass="button confirm select"/>
            </div>
            <div class="contract">
		        <div class="premium"></div>
                <h1>Premium</h1>
               <p>Lorem ipsum dolor sit amet, cu sed illum feugait blandit.</p>
                <p class="detail">Minutes per month</p>
                <p class="number">200</p>
                <p class="detail">Texts per month</p>
                <p class="number">∞</p>
                <p class="detail">Price per month</p>
                <p class="number bigger">£30</p>
		            <asp:Button ID="btnSelectPremium" runat="server" style="z-index: 1; left: 29px; top: 10px; position: relative" Text="Select" CssClass="button confirm select"/>
            </div>
            <div class="contract">
		        <div class="unlimited"></div>
                <h1>Unlimited</h1>
                <p>Lorem ipsum dolor sit amet, cu sed illum feugait blandit.</p>
                <p class="detail">Minutes per month</p>
                <p class="number">∞</p>
                <p class="detail">Texts per month</p>
                <p class="number">∞</p>
                <p class="detail">Price per month</p>
                <p class="number bigger">£50</p>
		            <asp:Button ID="btnSelectUnlimited" runat="server" style="z-index: 1; left: 29px; top: 10px; position: relative" Text="Select" CssClass="button confirm select"/>
            </div>
            <div class="contract">
		        <div class="international"></div>
                <h1>International</h1>
                <p>Lorem ipsum dolor sit amet, cu sed illum feugait blandit.</p>
                <p class="detail">Minutes per month</p>
                <p class="number">400</p>
                <p class="detail">Texts per month</p>
                <p class="number">200</p>
                <p class="detail">Price per month</p>
                <p class="number bigger">£40</p>
		            <asp:Button ID="btnSelectInternational" runat="server" style="z-index: 1; left: 29px; top: 10px; position: relative" Text="Select" CssClass="button confirm select"/>
            </div>
            <asp:Button ID="btnCancel" runat="server" style="z-index: 1; left: 388px; top: 20px; position: relative" Text="Cancel" CssClass="button warning cancel"/>
		</div>
	</div>
    </form>
</body>
</html>
