<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rejestracja.aspx.cs" Inherits="WebApplication1.Rejestracja" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="style/navbar.css" />
    <title></title>
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
      <li runat="server" id="Login"><a href="Logowanie.aspx">Zaloguj</a></li>

      

      
    </ul>
      
  </nav>
  <label for="nav-toggle" class="nav-toggle-label">
    <span></span>
  </label>
</header>



        <div style="display: flex;">
            <table style="left: 35px; position: fixed;
  top: 33%;
  width: 100%;
  text-align: center;" >
<tbody>
<tr>
<td style="color: #ffffff;text-align: right;position: fixed;right: 55%;">Imię</td>
<td><asp:TextBox ID="Box_Imie" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td style="color: #ffffff;text-align: right;position: fixed;right: 55%;">Nazwisko</td>
<td><asp:TextBox ID="Box_Nazwisko" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td style="color: #ffffff;text-align: right;position: fixed;right: 55%;">NumerTelefonu</td>
<td><asp:TextBox ID="Box_Tel" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td style="color: #ffffff;text-align: right;position: fixed;right: 55%;">Adres E-Mail</td>
<td><asp:TextBox ID="Box_Email" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td style="color: #ffffff;text-align: right;position: fixed;right: 55%;">Hasło</td>
<td><asp:TextBox ID="Box_Password" runat="server" TextMode="Password"></asp:TextBox></td>
</tr>
<tr>
<td style="color: #ffffff;text-align: right;position: fixed;right: 55%;"><asp:Button Visible="false" ID="GoLoginPage" runat="server" Text="Logowanie" /></td>
    <Br />
<td><asp:Button ID="SignUP" runat="server" Text="Zarejestruj" OnClick="SignUP_Click" style="position: fixed;right: 48.61%; top: 55%"/></td>
</tr>
</tbody>
</table>
            
            <br />
            
            <br />
            
            <br />
            
            <br />
            
            <br />
            <br />
            
            
            
        </div>
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:Label ID="Error" runat="server" Text="Label" Font-Bold="True" ForeColor="Red" ></asp:Label>
    </div>
            </form>
    
</body>
</html>
