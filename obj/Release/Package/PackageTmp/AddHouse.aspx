<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddHouse.aspx.cs" Inherits="WebApplication1.AddHouse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="style/navbar.css" />
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
        .auto-style2 {
            height: 22px;
            color: #FFFFFF;
            width: 98px;
        }
    </style>
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
      <li runat="server" id ="Obiekty" visible="false"><a href="MyHouse.aspx">Moje obiekty</a></li>
      <li runat="server" id="Rezerwacje" visible="false"><a href="MyRent.aspx">Moje Rezerwacje</a></li>
        <li></li>
      <li runat="server" id="Login"><a href="Logowanie.aspx">Zaloguj</a></li>
      <li runat="server" id="Signup"><a href="Rejestracja.aspx">Rejestracja</a></li>
      <li runat="server" id="Wyloguj" visible="false"><a  href="#" runat="server" onserverclick="OnClickLogout">Wyloguj</a></li>
    </ul>
      
  </nav>
  <label for="nav-toggle" class="nav-toggle-label">
    <span></span>
  </label>
</header>
        <div><br /><br /><br /><br /><br />
           <center> 
               
               

               <table border="0">
  <tr>
    <td class="auto-style2">Nazwa obiektu</td>
    
    <td class="auto-style1"><asp:TextBox ID="Nazwa" runat="server" ></asp:TextBox></td>
      <td class="auto-style2"></td>
      <td class="auto-style2">Udogodnienia</td>
      <td class="auto-style2">
          
          <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Nazwa" DataValueField="Udogodnienia_2ID" CellPadding="2" CellSpacing="20" RepeatColumns="3">
          </asp:CheckBoxList>
          
      </td>
  </tr>
  <tr>
    <td class="auto-style2">Cena za dobę</td>
    
    <td class="auto-style1"><asp:TextBox ID="Cena" runat="server"></asp:TextBox></td>
  </tr>
                   <tr>
    <td class="auto-style2">Metraż</td>
    
    <td class="auto-style1"><asp:TextBox ID="Metraz" runat="server"></asp:TextBox></td>
  </tr>
                   <tr>
    <td class="auto-style2">Ilość miejsc</td>
    
    <td class="auto-style1"><asp:TextBox ID="Miejsca" runat="server"></asp:TextBox></td>
                       <td class="auto-style2">
                           &nbsp;</td>
                       <td class="auto-style2">Kraina Geograficzna</td>
                       <td class="auto-style2" style="width: 300px;"><asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource2" DataTextField="TypKrainyGeograficznej" DataValueField="TypKrainyGeograficznej" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox><asp:ListBox ID="ListBox2" runat="server"></asp:ListBox></td>
                        
  </tr>
                   <tr>
    <td class="auto-style2">Adres</td>
    
    <td class="auto-style1"><asp:TextBox ID="Adres" runat="server"  ></asp:TextBox></td>
  </tr>
                   <tr>
    <td class="auto-style2">Kod-Pocztowy</td>
    
    <td class="auto-style1"><asp:TextBox ID="Kod" runat="server" ></asp:TextBox></td>
  </tr>
                   <tr>
    <td class="auto-style2">Kraj</td>
    
    <td class="auto-style1">
        <asp:TextBox ID="Kraj" runat="server"></asp:TextBox>
                       </td>
                       <td style="color: white">
                           
                       </td>
                       <td style="color: white">
                           Dodaj fotografie reprezentujaca obiekt
                       </td>
  </tr>

</table>


               <br />
               <asp:FileUpload ID="InputDoc" AllowMultiple="true" runat="server" FileSize="1 048 576" accept="image/*" BackColor="White" ForeColor="Black" style ="margin-left: 12.5%;"/>
               <br />
               <asp:Label ID="Span1" runat="server" ForeColor="#CC9900" Text="Label"></asp:Label>
               <br />
               <br />


               <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Dodaj obiekt" />

               <br />
               <br />

           </center>
        </div>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DbRent %>" SelectCommand="SELECT [Udogodnienia_2ID], [Nazwa] FROM [Udogodnienia_2]"></asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DbRent %>" SelectCommand="SELECT DISTINCT [TypKrainyGeograficznej] FROM [Miejsce]"></asp:SqlDataSource>
    </form>
</body>
</html>
