<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="WebApplication1.Book" %>

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
      <li runat="server" id ="Obiekty" visible="false"><a href="MyHouse.aspx">Moje obiekty</a></li>
      <li runat="server" id="Rezerwacje" visible="false"><a href="MyRent.aspx">Moje Rezerwacje
          </a></li>
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
        <div><br /><br /> <br /> <br />
            <div runat="server" class="container" style="margin-left: 25%;
    margin-right: auto;
    text-align: center;
    float: left;" id ="Szczegoly">
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
<td style="width: 34.8703%;"><asp:Label ID="Label17" runat="server" Text="Udogodnienia" Font-Size="Medium" Font-Bold="True"></asp:Label></td>
<td style="width: 64.1297%;"><asp:Label ID="Label18" runat="server" Text="Nazwa" Font-Size="Medium"></asp:Label></td>
</tr>
    
</tbody>
</table>
              <asp:Label ID="CountDays" runat="server" Text="Liczba dni: 0"></asp:Label><br />
              <asp:Label ID="PriceSum" runat="server" Text="Suma za pobyt: 0"></asp:Label>
                <asp:ImageButton id="imagebutton1" runat="server"
           AlternateText="Book button"
           
           ImageUrl="images/book.png"
           OnClick="ImageButton_Click"
                    style="width: 160px; height: auto;display: block;
  margin-left: auto;
  margin-right: auto;" />
                
        </div>
            <div style ="text-align:left"><br /><br /><br /><font color="white"" > Data Przyjazdu</font>
                <asp:Calendar ID="Calendar1" runat="server" SelectionMode="Day" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender" BackColor="Beige" >
                <OtherMonthDayStyle ForeColor="#b0b0b0" />
            <DayStyle CssClass="myCalendarDay" ForeColor="#2d3338" />
            <DayHeaderStyle CssClass="myCalendarDayHeader" ForeColor="#2d3338" />
<SelectedDayStyle Font-Bold="True" Font-Size="12px" CssClass="myCalendarSelector" />
            <TodayDayStyle CssClass="myCalendarToday" />
            <SelectorStyle CssClass="myCalendarSelector" />
            <NextPrevStyle CssClass="myCalendarNextPrev" />
            <TitleStyle CssClass="myCalendarTitle" /></asp:Calendar><br />
               
                <font color="white" > Data Wyjazdu</font>
                <asp:Calendar ID="Calendar2" runat="server" SelectionMode="Day" OnSelectionChanged="Calendar2_SelectionChanged"  OnDayRender="Calendar1_DayRender" BackColor="Beige">

                    <OtherMonthDayStyle ForeColor="#b0b0b0" />
            <DayStyle CssClass="myCalendarDay" ForeColor="#2d3338" />
            <DayHeaderStyle CssClass="myCalendarDayHeader" ForeColor="#2d3338" />
<SelectedDayStyle Font-Bold="True" Font-Size="12px" CssClass="myCalendarSelector" />
            <TodayDayStyle CssClass="myCalendarToday" />
            <SelectorStyle CssClass="myCalendarSelector" />
            <NextPrevStyle CssClass="myCalendarNextPrev" />
            <TitleStyle CssClass="myCalendarTitle" />

                </asp:Calendar>
                <font color="white" style="font-size: smaller" > Legenda: <br /> Czarny kolor - dni dostępne<br /> Czerwony kolor - dni zajęte przez innych gości
                </font>
            </div>
        </div>
    </form>
</body>
</html>
