<%@ Page Title="" Language="C#" MasterPageFile="~/Insert.Master" AutoEventWireup="true" CodeBehind="ProductInsert.aspx.cs" Inherits="StockManagement.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <form runat="server">
        <div class="container bg-light bg-gradient shadow p-3 mt-5 bg-white rounded w-50">
        <center><h4>Enter the Product details</h4></center>
            <asp:TextBox ID="ProductId" TextMode="Number" runat="server" class="form-control mt-4" placeholder="Product ID"></asp:TextBox>
            <asp:TextBox ID="NoOfThisProduct" TextMode="Number" runat="server" class="form-control mt-4" placeholder="Number of this product"></asp:TextBox>
            <asp:TextBox ID="NameOfTheProduct" runat="server" class="form-control mt-4" placeholder="Name of the product"></asp:TextBox>
            <asp:TextBox ID="PricePerProduct" runat="server" TextMode="Number" class="form-control mt-4" placeholder="Price per product"></asp:TextBox>
            <center><asp:Button ID="SubmitBtn" runat="server" class="lgnbtn btn btn-secondary w-75 mt-4" Text="Continue" OnClick="SubmitBtn_Click"/></center>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ProductId" 
                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter the product Id">
            </asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="NoOfThisProduct" 
                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter the no. of products">
            </asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="NameOfTheProduct" 
                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter the product name">
            </asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="PricePerProduct" 
                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter the product price">
            </asp:RequiredFieldValidator>
            <asp:CustomValidator ID="ProductIdValidator" runat="server" ControlToValidate="ProductId" ErrorMessage="Already product ID exists" 
                Display="Dynamic" ForeColor="Red" OnServerValidate="ProductIdValidator_ServerValidate"></asp:CustomValidator>

    </div>
    </form>
</asp:Content>
