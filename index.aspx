<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication1.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#txtsdate").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                onClose: function (selectedDate) {
                    $("#txtedate").datepicker("option", "minDate", selectedDate);
                }
            });

            $("#txtedate").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                onClose: function (selectedDate) {
                    $("#txtsdate").datepicker("option", "maxDate", selectedDate);
                }

            });
        })
    </script>
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
      <li runat="server" id="Wyloguj" visible="false"><a  href="#" runat="server" onserverclick="OnClickLogout">Wyloguj
          </a></li>
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
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DbRent %>" SelectCommand="SELECT [Udogodnienia_2ID], [Nazwa] FROM [Udogodnienia_2]"></asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DbRent %>" SelectCommand="SELECT DISTINCT [TypKrainyGeograficznej] FROM [Miejsce]"></asp:SqlDataSource>

            
           
            <div>

                 

            <div class="rcorners1">
                
                
                <table style="width:100%;">
                    <tr>
                        <td>

                            <div style ="width: 100%; margin-left:auto; margin-right: auto">

                                <table>
                    <tr>
                        
                        <td>Nazwa obiektu:</td>
                        <td><asp:TextBox ID="Filtr_Nazwa" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Cena:&nbsp;&nbsp;&nbsp; od
                        </td>

                        <td><asp:TextBox ID="Filtr_CenaOD" runat="server"></asp:TextBox></td>
                        <td>do</td>
                        <td><asp:TextBox ID="Filtr_CenaDO" runat="server"></asp:TextBox></td>
                    </tr>
                                      <tr>
                        <td>Metraż:&nbsp; od
                        </td>

                        <td><asp:TextBox ID="Filtr_MetrazOD" runat="server"></asp:TextBox></td>
                        <td>do</td>
                        <td><asp:TextBox ID="Filtr_MetrazDO" runat="server"></asp:TextBox></td>
                    </tr>
                                  <tr>
                        <td style="width: 25%">Liczba ludzi:&nbsp; od
                        </td>

                        <td><asp:TextBox ID="Filtr_LudzieOD" runat="server" ></asp:TextBox></td>
                        <td >do</td>
                        <td><asp:TextBox ID="Filtr_LudzieDO" runat="server"></asp:TextBox></td>
                    </tr>

                                        </table>

</div>

                        </td>
                        <td>

                            <div style ="width: 100%; margin-left:auto; margin-right: auto">Udogodnienia:                <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Nazwa" DataValueField="Nazwa" RepeatColumns="2" RepeatDirection="Horizontal"></asp:CheckBoxList>
</div>

                        </td>
                        <td style="margin-top: 1px">

                            <div style ="width: 100%; margin-left:auto; margin-right: auto">Region:  <br />                          <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource2" DataTextField="TypKrainyGeograficznej" DataValueField="TypKrainyGeograficznej" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="True" Width="150px"></asp:ListBox>
<asp:ListBox ID="ListBox2" runat="server" Width="220px"></asp:ListBox>                
</div>

                        </td>
                        <td>
                            Termin: <br />
                        <div style="width: 100%"><table>
                    <tr>
                        
                        <td>Start Date:</td>
                        <td><asp:TextBox ID="txtsdate" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>End Date:
                        </td>

                        <td><asp:TextBox ID="txtedate" runat="server"></asp:TextBox></td>
                    </tr>

                                        </table>
                            <br />
        </div>    
                        </td>
                    </tr>
                    
                                        </table>
                
                <asp:Button ID="Resetuj" runat="server" Text="Resetuj" width="120px" OnClientClick="Resetuj_Click" OnClick="Resetuj_Click" />
                
                
                <asp:Button ID="Filtruj" runat="server" Text="Filtruj" width="120px" OnClientClick="Filtruj_Click" OnClick="Filtruj_Click1" />

                
                <asp:Label ID="TB" runat="server" Text="Label" style="text-align: right" ForeColor="Red"></asp:Label>

                
            </div>
      
      <!-- The first DataPager control. -->
      

      <asp:ListView ID="ProductsListView" 
        OnPagePropertiesChanged="OnChangeList"
        GroupItemCount="1"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" width="80%" id="tbl1" runat="server" style="margin-left:auto; margin-right:auto;">
            <tr>
              <th colspan="5">Dostępne obiekty</th>
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
          <td align="center" runat="server" style="color: white; background-color: #91919138">
            
              <table>
    <tr>
        <td style =" width: 22%" > <asp:Image ID="ProductImage" runat="server"
              ImageUrl='<%#"~/Upload/Images/obiekt_" + Eval("ObiektID") + "-0.jpg" %>' style="width: 350px;
    max-height: 200px;"/></td>
        <td style="width: 55%">
            <b style="font-size: xx-large; font-family: Papyrus, fantasy;"><%# Eval("NazwaObiektu")%> </b> <br />
            <br />
  
            <b>Region:</b> <%# Eval("Region")%> <br />
            <b>Max. ilość miejsc:</b> <%# Eval("IloscMiejsc")%> <br />
            <b>Metraż:</b> <%# Eval("Metraz", "{0}")%> [&#13217]<br />
            <b>Udogodnienia:</b> <%# Eval("Udogodnienia")%> <br />
            <b>Cena za dobę:</b> <%# Eval("CenaZaDobe", "{0:c}")%> <br />
           
        </td>
        <td style="width: 12%">
            <a href="<%#"Book.aspx?Oferta=" + Eval("OfertaID") %>">
                <asp:Image ID="Image1" runat="server"
              ImageUrl='<%#"~/images/book.png" %>' style="height: auto;
    max-width: 120px;"/>
            </a>
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
                   <asp:DataPager runat="server" ID="BeforeListDataPager"
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
