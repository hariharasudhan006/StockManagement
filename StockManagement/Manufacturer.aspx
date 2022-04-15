<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manufacturer.aspx.cs" Inherits="StockManagement.Manufacturer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" 
        rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
</head>
<body class="p-2 bg-light bg-gradient position-relative">
    <h4 class="position-absolute start-50 translate-middle mt-3">Stock Management System</h4>
    <div class="container bg-light bg-gradient mt-4" runat="server">
        <ul class="nav nav-tabs" runat="server">
            <li class="nav-item" runat="server">
                <a class="nav-link" aria-current="page" href="Home.aspx">Home</a>
            </li>
            <li class="nav-item" runat="server">
                <a class="nav-link" aria-current="page" href="StockInsert.aspx">Add Stock</a>
            </li>
            <li class="nav-item" runat="server">
               <a class="nav-link active" aria-current="page" href="#">Add Manufacturer</a>
            </li>
            <li class="nav-item" runat="server">
               <a class="nav-link" aria-current="page" href="Login.aspx">Logout</a>
            </li>
        </ul>
     </div>
    <div>
        <form runat="server">
        <div class="container bg-light bg-gradient shadow p-3 mt-5 bg-white rounded w-50">
        <center><h4>Enter the Manufactorer details</h4></center>
        <asp:TextBox ID="ManufacturerID" runat="server" TextMode="Number" class="form-control mt-4" placeholder="Manufacturer ID"></asp:TextBox>
        <asp:TextBox ID="ManufacturerName" runat="server" class="form-control mt-4" placeholder="Manufacturer Name"></asp:TextBox>
        <div class="input-group">
            <span class="input-group-text mt-4">Address</span>
            <asp:TextBox Id="Address" TextMode="multiline" Rows="5" runat="server" class="form-control mt-4" />
        </div>
        <center><asp:Button ID="SubmitBtn" runat="server" class="lgnbtn btn btn-secondary w-75 mt-4" Text="Continue"  OnClick="SubmitBtn_Click"/></center>
             <asp:CustomValidator ID="ManufacturerIdValidator" runat="server" ControlToValidate="ManufacturerID" ErrorMessage="Manufacturer ID already exists" 
                Display="Dynamic" ForeColor="Red" OnServerValidate="ManufacturerId_ServerValidate"></asp:CustomValidator>
             <asp:CustomValidator ID="ManfacturerNameValidator" runat="server" ControlToValidate="ManufacturerName" ErrorMessage="Manufacturer name already exists" 
                Display="Dynamic" ForeColor="Red" OnServerValidate="ManfacturerNameValidator_ServerValidate"></asp:CustomValidator>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Address" 
                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter the Address">
            </asp:RequiredFieldValidator>
    </div>
    </form>
    </div>
</body>
</html>