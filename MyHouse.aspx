<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyHouse.aspx.cs" Inherits="WebApplication1.MyHouse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
      <li runat="server" id ="Obiekty" ><a href="MyHouse.aspx">Moje obiekty
          </a></li>
      <li runat="server" id="Rezerwacje" ><a href="MyRent.aspx">Moje Rezerwacje</a></li>
        <li></li>
     
      <li runat="server" id="Wyloguj" ><a  href="#" runat="server" onserverclick="OnClickLogout">Wyloguj</a></li>
    </ul>
      
  </nav>
 
</header><br /><br /><br /><br /><br />
        
        <div class="container" style="float: left; margin-left: 12%; margin-right: auto; text-align: center;"><asp:Button class="button2" ID="Button1" runat="server" Text="Nowy obiekt" style="position: absolute;top: 120px;right: 56%;" OnClick="Button1_Click"/>
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    <Columns>
        
        <asp:BoundField DataField="Numer Obiektu" HeaderText="ID" ItemStyle-Width="150px" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Nazwa Obiektu" HeaderText="Nazwa Obiektu" ItemStyle-Width="250px" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Adres obiektu" HeaderText="Adres Obiektu" ItemStyle-Width="150px" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Cena za dobę" HeaderText="Cena za dobę" ItemStyle-Width="150px" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
       
        
        <asp:CommandField ButtonType="Button" ShowSelectButton="True" HeaderText="Zarządzaj" SelectText="More info" />
        
    </Columns>
</asp:GridView></div>
<div runat="server" class="container" style="float: right; margin-left: auto; margin-right: 12%; text-align: center;" id ="Szczegoly">
          <table style="width: 100%;">
<tbody>
<tr style ="height: 60px">
<td style="width: 34.8703%;"><asp:Label ID="Label1" runat="server" Text="Nazwa" Font-Size="Medium" Font-Bold="True"></asp:Label></td>
<td style="width: 64.1297%;"><asp:Label ID="Label2" runat="server" Text="Nazwa" Font-Size="Medium"></asp:Label></td>
</tr>
<tr style ="height: 60px">
<td style="width: 34.8703%;"><asp:Label ID="Label3" runat="server" Text="Adres" Font-Size="Medium" Font-Bold="True"></asp:Label></td>
<td style="width: 64.1297%;"><asp:Label ID="Label4" runat="server" Text="Nazwa" Font-Size="Medium"></asp:Label></td>
</tr>
<tr style ="height: 60px">
<td style="width: 34.8703%;"><asp:Label ID="Label5" runat="server" Text="Kraj" Font-Size="Medium" Font-Bold="True"></asp:Label></td>
<td style="width: 64.1297%;"><asp:Label ID="Label6" runat="server" Text="Nazwa" Font-Size="Medium"></asp:Label></td>
</tr>
<tr style ="height: 60px">
<td style="width: 34.8703%;"><asp:Label ID="Label7" runat="server" Text="Cena za dobę" Font-Size="Medium" Font-Bold="True"></asp:Label></td>
<td style="width: 64.1297%;"><asp:Label ID="Label8" runat="server" Text="Nazwa" Font-Size="Medium"></asp:Label></td>
</tr>
<tr style ="height: 60px">
<td style="width: 34.8703%;"><asp:Label ID="Label9" runat="server" Text="Metraż" Font-Size="Medium" Font-Bold="True"></asp:Label></td>
<td style="width: 64.1297%;"><asp:Label ID="Label10" runat="server" Text="Nazwa" Font-Size="Medium"></asp:Label></td>
</tr >
<tr style ="height: 60px">
<td style="width: 34.8703%;"><asp:Label ID="Label11" runat="server" Text="Max. ilość gości" Font-Size="Medium" Font-Bold="True"></asp:Label></td>
<td style="width: 64.1297%;"><asp:Label ID="Label12" runat="server" Text="Nazwa" Font-Size="Medium"></asp:Label></td>
</tr>
<tr style ="height: 60px">
<td style="width: 34.8703%;"><asp:Label ID="Label15" runat="server" Text="Atualny stan" Font-Size="Medium" Font-Bold="True"></asp:Label></td>
<td style="width: 64.1297%;"><asp:Label ID="Label16" runat="server" Text="Nazwa" Font-Size="Medium"></asp:Label></td>
</tr>

</tbody>
</table>
     <asp:Button ID="Publish" runat="server" Text="Publikuj" OnClick="Publish_Click" /><br /><br />
    <asp:Button ID="Down" runat="server" Text="Zdejmij" OnClick="Down_Click" />
        </div>
         
    </form>
</body>
</html>

