<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyRent.aspx.cs" Inherits="WebApplication1.MyRent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="style/navbar.css" />
    <title></title>
   
    <style type="text/css">        
      th
      {
        background-color:#eef4fa;
        border-top:solid 1px #9dbbcc;
        border-bottom:solid 1px #9dbbcc;
      }
      .itemSeparator { border-right: 1px solid #ccc }
      .groupSeparator
      {
        height: 1px;
        background-color: #cccccc;
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
    

        <br /><br /><br /><br /><br />
        <div>
            <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DbRent %>" SelectCommand="SELECT obw.NazwaObiektu, m.MiejsceID,
TypKrainyGeograficznej + ', ' + NazwaKrainyGeograficznej as 'Region',
(select u2.nazwa  + ', '
from Udogodnienia_2 u2 INNER JOIN Udogodnienia u ON u.Udogodnienia_2ID=u2.Udogodnienia_2ID, Obiektdowynajecia obw
WHERE u.ObiektID=obw.ObiektdowynajeciaID AND u.Udogodnienia_2ID=u2.Udogodnienia_2ID
for xml path('')) as 'Udogodnienia',
obw.IloscMiejsc,
obw.Metraz,
obw.ObiektdowynajeciaID as 'ObiektID',
obw.CenaZaDobe,
ofe.OfertaID


                



FROM Obiektdowynajecia obw INNER JOIN Miejsce m ON obw.MiejsceID=m.MiejsceID INNER JOIN Oferta ofe ON ofe.ObiektdowynajeciaID=obw.ObiektdowynajeciaID WHERE ofe.ObiektdowynajeciaID = obw.ObiektdowynajeciaID

"></asp:SqlDataSource>

            

            <div>

      
      <!-- The first DataPager control. -->
      

      <asp:ListView ID="ProductsListView" 
        OnPagePropertiesChanged="OnChangeList"
        GroupItemCount="1"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" width="80%" id="tbl1" runat="server" style="margin-left:auto; margin-right:auto;">
            <tr>
              <th colspan="5">Lista moich rezerwacji</th>
            </tr>
            <tr runat="server" id="groupPlaceholder"></tr>
          </table>
        </LayoutTemplate>
        <GroupTemplate>
          <tr runat="server" id="tr1">
            <td runat="server" id="itemPlaceholder"></td>
          </tr>
        </GroupTemplate>
        <GroupSeparatorTemplate>
          <tr runat="server">
            <td colspan="5">
                <div class="groupSeparator"><hr></div>
              </td>
          </tr>
        </GroupSeparatorTemplate>
        <ItemTemplate>
          <td align="center" runat="server" style="color: white">
            
              <table>
    <tr>
        <td style =" width: 22%" > <asp:Image ID="ProductImage" runat="server"
              ImageUrl='<%#"~/Upload/Images/obiekt_" + Eval("ObiektID") + "-0.jpg" %>' style="width: 350px;
    max-height: 200px;"/></td>
        <td style="width: 22.5%">
            <b style="font-size: xx-large; font-family: Papyrus, fantasy;"><%# Eval("NazwaObiektu")%> </b> <br />
            <br />
            <b>Adres:</b> <%# Eval("AdresO")%> <br />
            <br />
            <b>Region:</b> <%# Eval("Region")%> <br />
            <b>Max. ilość miejsc:</b> <%# Eval("IloscMiejsc")%> <br />
            <b>Metraż:</b> <%# Eval("Metraz", "{0}")%> [&#13217]<br />
            <b>Udogodnienia:</b> <%# Eval("Udogodnienia")%> <br />
            

            
            

        </td>
         <td style="width: 22.5%">
            <b style="font-size: xx-large; font-family: Papyrus, fantasy;"><%# ("")%> </b> <br />
            <br />
  
            
            <b>Przyjazd:</b> <%# Eval("Przyjazd", "{0:dd/MM/yyyy}")%> <br />
            <b>Wyjazd:</b> <%# Eval("Wyjazd", "{0:dd/MM/yyyy}")%> <br />
            <b>Cena za nocleg:</b> <%# Eval("CenaRezerwacji", "{0}") + "zł"%> <br /><br />
            <b>Zarządca obiektu:</b> <%# Eval("Wlasciciel")%><br />
            <b>Numer telefonu:</b> <%# Eval("NrTelefonu")%> <br />
            
            

        </td>
        <td style="width: 12%">

                <asp:ImageButton ID="Przycisk" runat="server"
                    CommandName="ThisBtnClick" OnClick="MyBtnHandler" CommandArgument='<%# Eval("OfertaID") %>'
              ImageUrl='<%#"~/images/cancel.png" %>' style="height: auto; max-width: 120px; mix-blend-mode: color; filter: brightness(0.5);"></asp:ImageButton>

        </td>
    </tr>
    
</table>
          </td>
        </ItemTemplate>
        <ItemSeparatorTemplate>
          <td class="itemSeparator" runat="server">&nbsp;</td>
        </ItemSeparatorTemplate>
      </asp:ListView>

               <br /> <div style="margin-left: auto; margin-right: auto; text-align: center;">
                   <asp:DataPager runat="server" ID="DataPager1"
        PagedControlID="ProductsListView" 
        PageSize="10" >
        <Fields>
          <asp:NextPreviousPagerField ButtonType="Image"
            ShowFirstPageButton="false"
            ShowNextPageButton="false"
            ShowPreviousPageButton="true"
            PreviousPageImageUrl="~/images/left.png" />
          <asp:NumericPagerField ButtonCount="10" />
          <asp:NextPreviousPagerField ButtonType="Image"
            ShowLastPageButton="false"
            ShowNextPageButton="true"
            ShowPreviousPageButton="false"
            NextPageImageUrl="~/images/right.png" />
        </Fields>
      </asp:DataPager><br />
                   <asp:Label  ID="Errr" runat="server" BorderColor="#CC3300" ForeColor="Red" Text="Label"></asp:Label>
                   </div>
        </div>
        
    </form>
</body>
</html>
