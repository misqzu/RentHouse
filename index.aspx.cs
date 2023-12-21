using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class index : System.Web.UI.Page
    {
        public string SearchSQL;
        public string nazwa;
        public string cena;
        public string metraz;
        public string ludzie;
        public string udogodnienia;
        public string region;
        public string data;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Errr.Visible = false;
                DbBind();
                FirstBind();
                TB.Visible = false;

            }

            if (User.Identity.IsAuthenticated)
            {
                Page.Title = "Home page for " + User.Identity.Name;
                Login.Visible = false;
                Signup.Visible = false;
                Obiekty.Visible = true;
                Rezerwacje.Visible = true;
                Wyloguj.Visible = true;

            }
            else
            {
                Page.Title = "Home page for guest user.";

            }

        }


        protected void OnClickLogout(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();

            Response.Redirect(Request.RawUrl);


        }
        protected void OnChangeList(object sender, EventArgs e)
        {
            DbBind();
        }

        protected void DbBind()
        {
            SearchSQL = nazwa + cena + metraz + ludzie + udogodnienia + region + data;
            string KS_conn = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;

            SqlConnection KS_con = new SqlConnection(KS_conn);
            KS_con.Open();


            String sqltab = "SELECT ofe.OfertaID, obw.NazwaObiektu, m.MiejsceID,TypKrainyGeograficznej + ', ' + NazwaKrainyGeograficznej as 'Region',(select u2.nazwa  + ', ' from Udogodnienia_2 u2 INNER JOIN Udogodnienia u ON u.Udogodnienia_2ID = u2.Udogodnienia_2ID INNER JOIN Oferta ofe ON ofe.ObiektdowynajeciaID = obw.ObiektdowynajeciaID WHERE u.ObiektID = obw.ObiektdowynajeciaID AND u.Udogodnienia_2ID = u2.Udogodnienia_2ID for xml path('')) as 'Udogodnienia', obw.IloscMiejsc, obw.Metraz, obw.ObiektdowynajeciaID as 'ObiektID', obw.CenaZaDobe FROM Obiektdowynajecia obw INNER JOIN Miejsce m ON obw.MiejsceID = m.MiejsceID INNER JOIN Oferta ofe ON ofe.ObiektdowynajeciaID=obw.ObiektdowynajeciaID WHERE ofe.ObiektdowynajeciaID = obw.ObiektdowynajeciaID" + SearchSQL;

            SqlCommand cmd = new SqlCommand(sqltab, KS_con);
            SqlDataAdapter cmd1 = new SqlDataAdapter(sqltab, KS_con);
            //TB.Text = sqltab.ToString();
            if (cmd.ExecuteScalar() == null)
            {
                Errr.Visible = true;
                Errr.Text = "BRAK OBIEKTÓW SPEŁNIAJĄCYCH KRYTERIA";

            }
            else
            {
                Errr.Visible = false;
            }
            DataTable dt = new DataTable();
            cmd1.Fill(dt);
            ProductsListView.DataSource = dt;
            ProductsListView.DataBind();
            KS_con.Close();
        }
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string KS_conn = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;

            SqlConnection KS_con = new SqlConnection(KS_conn);
            KS_con.Open();
            String sqltab = "SELECT [TypKrainyGeograficznej],[NazwaKrainyGeograficznej],[MiejsceID] FROM [dbo].[Miejsce] WHERE [TypKrainyGeograficznej] = '" + ListBox1.SelectedValue.ToString() + "';";
            SqlDataAdapter cmd1 = new SqlDataAdapter(sqltab, KS_con);
            DataTable dt = new DataTable();
            cmd1.Fill(dt);
            ListBox2.DataSource = dt;
            ListBox2.DataTextField = "NazwaKrainyGeograficznej";
            ListBox2.DataValueField = "MiejsceID";
            ListBox2.DataBind();
            KS_con.Close();

        }
        protected void FirstBind()
        {
            string KS_conn = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;

            SqlConnection KS_con = new SqlConnection(KS_conn);
            KS_con.Open();
            String sqltab = "SELECT [TypKrainyGeograficznej],[NazwaKrainyGeograficznej],[MiejsceID] FROM [dbo].[Miejsce] ";
            SqlDataAdapter cmd1 = new SqlDataAdapter(sqltab, KS_con);
            DataTable dt = new DataTable();
            cmd1.Fill(dt);
            ListBox2.DataSource = dt;
            ListBox2.DataTextField = "NazwaKrainyGeograficznej";
            ListBox2.DataValueField = "MiejsceID";
            ListBox2.DataBind();
            KS_con.Close();
        }





        protected void Resetuj_Click(object sender, EventArgs e)
        {
            SearchSQL = "";
            DbBind();
            Filtr_CenaOD.Text = String.Empty;
            Filtr_CenaDO.Text = String.Empty;
            Filtr_Nazwa.Text = String.Empty;
            Filtr_MetrazOD.Text = String.Empty;
            Filtr_MetrazDO.Text = String.Empty;
            Filtr_LudzieOD.Text = String.Empty;
            Filtr_LudzieDO.Text = String.Empty;
            txtsdate.Text = String.Empty;
            txtedate.Text = String.Empty;
            ListBox1.ClearSelection();
            ListBox2.ClearSelection();
            CheckBoxList1.ClearSelection();
            TB.Visible = false;
        }

        protected void FiltrujMain()
        {
            //NAZWA
            if (!String.IsNullOrEmpty(Filtr_Nazwa.Text))
            {
                nazwa = " AND obw.NazwaObiektu LIKE '%" + Filtr_Nazwa.Text + "%'";
            }
            else
            {
                nazwa = "";
            }
            //CENA
            if (!String.IsNullOrEmpty(Filtr_CenaOD.Text) || !String.IsNullOrEmpty(Filtr_CenaDO.Text))
            {
                string cena1, cena2;

                if (!String.IsNullOrEmpty(Filtr_CenaOD.Text))
                {
                    cena1 = " AND obw.CenaZaDobe >=" + Filtr_CenaOD.Text;
                }
                else
                {
                    cena1 = "";
                }
                if (!String.IsNullOrEmpty(Filtr_CenaDO.Text))
                {
                    cena2 = " AND obw.CenaZaDobe <=" + Filtr_CenaDO.Text;
                }
                else
                {
                    cena2 = "";
                }
                cena = cena1 + cena2;
            }
            else
            {
                cena = "";
            }
            //METRAZ
            if (!String.IsNullOrEmpty(Filtr_MetrazOD.Text) || !String.IsNullOrEmpty(Filtr_MetrazDO.Text))
            {
                string metraz1, metraz2;

                if (!String.IsNullOrEmpty(Filtr_MetrazOD.Text))
                {
                    metraz1 = " AND obw.Metraz >=" + Filtr_MetrazOD.Text;
                }
                else
                {
                    metraz1 = "";
                }
                if (!String.IsNullOrEmpty(Filtr_MetrazDO.Text))
                {
                    metraz2 = " AND obw.Metraz <=" + Filtr_MetrazDO.Text;
                }
                else
                {
                    metraz2 = "";
                }
                metraz = metraz1 + metraz2;
            }
            else
            {
                metraz = "";
            }
            //Ludzie
            Errr.Visible = true;
            Errr.Text = "123";
            if (!String.IsNullOrEmpty(Filtr_LudzieOD.Text) || !String.IsNullOrEmpty(Filtr_LudzieDO.Text))
            {
                string ludzie1, ludzie2;
                Errr.Visible = true;
                Errr.Text = "234";
                if (!String.IsNullOrEmpty(Filtr_LudzieOD.Text))
                {
                    ludzie1 = " AND obw.IloscMiejsc >=" + Filtr_LudzieOD.Text;
                }
                else
                {
                    ludzie1 = "";
                }
                if (!String.IsNullOrEmpty(Filtr_LudzieDO.Text))
                {
                    ludzie2 = " AND obw.IloscMiejsc <=" + Filtr_LudzieDO.Text;
                }
                else
                {
                    ludzie2 = "";
                }
                ludzie = ludzie1 + ludzie2;
            }
            else
            {
                ludzie = "";
            }


            //Region

            if (ListBox1.SelectedValue != "" || ListBox2.SelectedValue != "")
            {


                if (ListBox1.SelectedValue != "" && ListBox2.SelectedValue != "")
                {
                    region = " AND obw.MiejsceID = " + ListBox2.SelectedValue.ToString();


                }
                else
                {
                    if (ListBox1.SelectedValue != "")
                    {
                        region = " AND m.TypKrainyGeograficznej = '" + ListBox1.SelectedValue + "'";


                    }
                    if (ListBox2.SelectedValue != "")
                    {
                        region = " AND obw.MiejsceID = " + ListBox2.SelectedValue;


                    }


                }

            }
            else
            {


                region = "";
            }

            //Udogodnienia

            if (CheckBoxList1.SelectedValue == null)
            {
                udogodnienia = "";
            }
            else
            {
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    if (item.Selected)
                    {

                        udogodnienia += " AND (select u2.nazwa  + ', ' from Udogodnienia_2 u2 INNER JOIN Udogodnienia u ON u.Udogodnienia_2ID = u2.Udogodnienia_2ID INNER JOIN Oferta ofe ON ofe.ObiektdowynajeciaID = obw.ObiektdowynajeciaID WHERE u.ObiektID = obw.ObiektdowynajeciaID AND u.Udogodnienia_2ID = u2.Udogodnienia_2ID for xml path('')) LIKE '%" + item.Value.ToString() + "%'";

                    }

                }
            }
        }
        protected void Filtruj_Click1(object sender, EventArgs e)
        {
            TB.Visible = false;

            if (txtedate.Text != String.Empty || txtedate.Text != String.Empty)
            {
                if (txtsdate.Text != String.Empty && txtedate.Text != String.Empty)
                {

                    FiltrujMain();
                    DateCheck();
                }
                else
                {
                    TB.Visible = true;
                    TB.Text = "Zaznacz początkową i końcową datę";
                }

            }
            else
            {
                FiltrujMain();
            }









            DbBind();

        }

        protected void DateCheck()
        {
            if (LiczbaRezerwacji() > 0)
            {

                string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
                SqlConnection con = new SqlConnection(ConString);

                SqlConnection con2 = new SqlConnection(ConString);

                SqlConnection con4 = new SqlConnection(ConString);

                con.Open();
                String KS_sqlpass2 = "Select Rezerwacja.OfertaID from Rezerwacja inner join Oferta on Oferta.OfertaID=Rezerwacja.OfertaID ";

                SqlCommand cmd3 = new SqlCommand(KS_sqlpass2, con);
                con2.Open();
                con4.Open();

                DateTime dzienp = DateTime.ParseExact(txtsdate.Text, "MM/dd/yyyy", null);

                DateTime dzienw = DateTime.ParseExact(txtedate.Text, "MM/dd/yyyy", null);

                TB.Text += "0";

                using (SqlDataReader rdr = cmd3.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        int id = rdr.GetInt32(0);
                        String KS_sqlpass4 = "Select Przyjazd from Rezerwacja inner join Oferta on Oferta.OfertaID=Rezerwacja.OfertaID WHERE Rezerwacja.OfertaID=" + id;
                        SqlCommand cmd4 = new SqlCommand(KS_sqlpass4, con4);


                        String KS_sqlpass3 = "Select Wyjazd from Rezerwacja inner join Oferta on Oferta.OfertaID=Rezerwacja.OfertaID WHERE Rezerwacja.OfertaID=" + id;
                        SqlCommand cmd5 = new SqlCommand(KS_sqlpass3, con2);


                        DateTime przyjazd = Convert.ToDateTime(cmd4.ExecuteScalar());
                        DateTime wyjazd = Convert.ToDateTime(cmd5.ExecuteScalar());


                        int dni = (wyjazd - przyjazd).Days + 1;

                        //TB.Text += "1"+dni.ToString();
                        if (dzienp < przyjazd && wyjazd < dzienw)
                        {
                            //TB.Text += "w trakcie";
                            data = " AND ofe.OfertaID !=" + id;
                        }

                        for (int i = 0; i < dni; i++)
                        {
                            if (przyjazd == dzienp || przyjazd == dzienw)
                            {
                                //txtedate.Text = String.Empty;
                                //TB.Text += "Jest";
                                data = " AND ofe.OfertaID !=" + id;
                            }

                            przyjazd = przyjazd.AddDays(1);
                        }


                    }
                }
                con2.Close();
                con.Close();
                con4.Close();






            }
        }
        protected int LiczbaRezerwacji()
        {
            string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
            SqlConnection con = new SqlConnection(ConString);

            con.Open();
            String KS_sqlpass2 = "Select count(przyjazd) from Rezerwacja inner join Oferta on Oferta.OfertaID=Rezerwacja.OfertaID ";
            SqlCommand cmd3 = new SqlCommand(KS_sqlpass2, con);
            int n = (Int32)cmd3.ExecuteScalar();
            con.Close();
            return n;

        }
    }

}