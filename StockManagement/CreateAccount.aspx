<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="StockManagement.CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" charset="utf-8"/>
    <link href="Login.css" rel="stylesheet" type="text/css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" 
        rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
        
</head>
<body class="bg-light bg-gradient" id="holder">
    <form id="form1" runat="server" class="frmalg">
    <div class="container bg-light bg-gradient shadow p-3 mb-5 bg-white rounded">
        <center>
            <h3>Create new account</h3>
        </center>
        <label for="uname"><b>Username</b></label>
        <asp:TextBox runat="server" ID="txt_Username" placeholder="Enter Username"></asp:TextBox>
        <label for="psw"><b>Password</b></label>
        <asp:TextBox runat="server" ID="txt_password" TextMode="Password" placeholder="Enter Password"></asp:TextBox>
        <label for="psw"><b>Re enter Password</b></label>
        <asp:TextBox runat="server" ID="txt_re_password" TextMode="Password" placeholder="Re enter Password"></asp:TextBox>
        <center><asp:Button runat="server" ID="btn_Login" CssClass="lgnbtn btn btn-secondary w-100" OnClick="btnLoginOnClick" Text="Continue" /></center>
        <center><asp:Button runat="server" ID="GotoLoginPage" class="cnbtn btn btn-dark w-100" OnClick="GotoLoginPage_Click" Text="Create an account"></asp:Button></center>
         <asp:RequiredFieldValidator ID="UsernameRequireValidator" 
            runat="server" ControlToValidate="txt_Username" 
            ErrorMessage="Enter the username" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="PasswordRequireValidator" 
            runat="server" ControlToValidate="txt_password" 
            ErrorMessage="Enter the password" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RePasswordRequireValidator" 
            runat="server" ControlToValidate="txt_re_password" 
            ErrorMessage="Re type the password" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CompareValidator runat="server" ControlToValidate="txt_re_password" ControlToCompare="txt_password"
            Display="Dynamic" ErrorMessage="Passwords mismatch" ForeColor="Red" Operator="Equal" Type="String"></asp:CompareValidator>
    </div>
</form>
</body>
</html>
