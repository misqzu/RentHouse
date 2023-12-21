<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logowanie.aspx.cs" Inherits="WebApplication1.Logowanie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="style/navbar.css" />
</head>
<body>
    <form id="form1" runat="server">

<header>
  <h1 class="logo"><img src="/images/house.png" style="
    height: 30px;
"> HouseRent</h1>
  <input type="checkbox" id="nav-toggle" class="nav-toggle" />
  <nav>
    <ul>
      <li><a href="index.aspx">Home</a></li>
        <li></li>
        <li></li>
        <li></li>
        <li></li>
      <li runat="server" id="Rejestracja"><a href="Rejestracja.aspx">Rejestracja</a></li>
      

      

      
    </ul>
      
  </nav>
  <label for="nav-toggle" class="nav-toggle-label">
    <span></span>
  </label>
</header>




        <div style="position: fixed;
    top: 33%;
    right: 49%;">
        <center>
            <div>
                <asp:Label ID="Label1" ForeColor="#FFFFFF" runat="server" Text="Login   "></asp:Label>
                <input id="txtlogin" type="text" runat="server" /></div>
            <br />
            <br />
            <div>
                <asp:Label ID="Label2" ForeColor="#FFFFFF" runat="server" Text="Hasło"></asp:Label>
                <input id="txtpassword" type="password" runat="server"/>

            </div>
            <br />
            <asp:Label ID="wrongpass" runat="server" BorderColor="Red" ForeColor="Red" Text="Nieprawidłowe dane logowania"></asp:Label>
            <br />
            <br />
  <asp:Button ID="Button1" runat="server" Text="Zaloguj" OnClick="Button1_Click" />
        </center>
            </div>
      
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DbRent %>" SelectCommand="SELECT * FROM [dbo].[Uzytkownik]"></asp:SqlDataSource>

      
    </form>
    </body>
</html>
