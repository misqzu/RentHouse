using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1
{

    public partial class Book : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar2.DayRender += new DayRenderEventHandler(this.Calendar_taken);
            Calendar1.DayRender += new DayRenderEventHandler(this.Calendar_taken);
            if (!IsPostBack)
            {
                SqlSelect();
                Calendar1.SelectedDate = DateTime.Now;
                Calendar2.SelectedDate = DateTime.Now;

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

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now.Date)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.LightGray;
            }






        }


        protected void Calendar_taken(object sender, DayRenderEventArgs e)
        {
            if (LiczbaRezerwacji() > 0)
            {

                string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
                SqlConnection con = new SqlConnection(ConString);
                string ConString2 = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
                SqlConnection con2 = new SqlConnection(ConString2);

                con.Open();
                String KS_sqlpass2 = "Select przyjazd from Rezerwacja inner join Oferta on Oferta.OfertaID=Rezerwacja.OfertaID WHERE Oferta.OfertaID=" + Int32.Parse(Request.QueryString["Oferta"]);

                SqlCommand cmd3 = new SqlCommand(KS_sqlpass2, con);
                con2.Open();






                using (SqlDataReader rdr = cmd3.ExecuteReader())
                {
                    while (rdr.Read())
                    {

                        DateTime przyjazd = rdr.GetDateTime(0);

                        String KS_sqlpass3 = "Select Wyjazd from Rezerwacja inner join Oferta on Oferta.OfertaID=Rezerwacja.OfertaID WHERE Rezerwacja.Przyjazd = '" + przyjazd.ToString("yyyy-MM-dd") + "'AND Oferta.OfertaID=" + Int32.Parse(Request.QueryString["Oferta"]);
                        SqlCommand cmd4 = new SqlCommand(KS_sqlpass3, con2);

                        DateTime wyjazd = (DateTime)cmd4.ExecuteScalar();

                        int dni = (wyjazd - przyjazd).Days + 1;
                        DateTime dzienp = przyjazd;

                        for (int i = 0; i < dni; i++)
                        {
                            if (e.Day.Date == dzienp)
                            {
                                e.Day.IsSelectable = false;
                                e.Cell.ForeColor = System.Drawing.Color.Red;
                            }
                            dzienp = dzienp.AddDays(1);
                        }



                    }
                }
                con2.Close();
                con.Close();






            }
        }



        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now.Date)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.LightGray;
            }
            if (e.Day.Date < Calendar1.SelectedDate)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.LightGray;
            }


        }
        protected void Calendar2DR(object sender, DayRenderEventArgs e)
        {

            if (e.Day.Date < Calendar1.SelectedDate)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.LightGray;
            }

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            Calendar2.DayRender += new DayRenderEventHandler(this.Calendar2DR);
            calc();

        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            DateTime wyjazd = Calendar1.SelectedDate;

            if ((Calendar2.SelectedDate - Calendar1.SelectedDate).Days < 0)
            {
                Calendar2.SelectedDate = Calendar1.SelectedDate;

            }
            if ((Calendar2.SelectedDate - Calendar1.SelectedDate).Days < 100)
            {
                calc();
            }
            Calendar2.DayRender += new DayRenderEventHandler(this.Calendar2DR);

        }
        protected void calc()
        {
            int dni = ((Calendar2.SelectedDate - Calendar1.SelectedDate).Days + 1);
            if (dni > 0)
            {
                CountDays.Text = "Wybrana liczba dni: " + dni;
                PriceSum.Text = "Kwota do załaty za pobyt: " + (float.Parse(Label8.Text.ToString()) * (float)dni).ToString() + "zł";
            }
            else
            {
                CountDays.Text = "Wybrałeś nie prawidłowy termin";
                PriceSum.Text = "Kwota do załaty za pobyt: Nie można obliczyć";
            }
        }


        protected void SqlSelect()
        {
            int OfferID = Int32.Parse(Request.QueryString["Oferta"]);
            string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
            SqlConnection con = new SqlConnection(ConString);

            //Nazwa
            String sqlsel2 = "SELECT obw.NazwaObiektu FROM Obiektdowynajecia obw INNER JOIN Miejsce m ON obw.MiejsceID = m.MiejsceID INNER JOIN Oferta ofe ON ofe.ObiektdowynajeciaID=obw.ObiektdowynajeciaID WHERE ofe.ObiektdowynajeciaID = obw.ObiektdowynajeciaID AND ofe.OfertaID =" + OfferID;
            SqlCommand cmd2 = new SqlCommand(sqlsel2, con);
            //Adres
            String sqlsel4 = "SELECT obw.Adres FROM Obiektdowynajecia obw INNER JOIN Miejsce m ON obw.MiejsceID = m.MiejsceID INNER JOIN Oferta ofe ON ofe.ObiektdowynajeciaID=obw.ObiektdowynajeciaID WHERE ofe.ObiektdowynajeciaID = obw.ObiektdowynajeciaID AND ofe.OfertaID =" + OfferID;
            SqlCommand cmd4 = new SqlCommand(sqlsel4, con);
            //Kraj
            String sqlsel6 = "SELECT obw.Kraj FROM Obiektdowynajecia obw INNER JOIN Miejsce m ON obw.MiejsceID = m.MiejsceID INNER JOIN Oferta ofe ON ofe.ObiektdowynajeciaID=obw.ObiektdowynajeciaID WHERE ofe.ObiektdowynajeciaID = obw.ObiektdowynajeciaID AND ofe.OfertaID =" + OfferID;
            SqlCommand cmd6 = new SqlCommand(sqlsel6, con);
            //Cena za dobe
            String sqlsel8 = "SELECT obw.CenaZaDobe FROM Obiektdowynajecia obw INNER JOIN Miejsce m ON obw.MiejsceID = m.MiejsceID INNER JOIN Oferta ofe ON ofe.ObiektdowynajeciaID=obw.ObiektdowynajeciaID WHERE ofe.ObiektdowynajeciaID = obw.ObiektdowynajeciaID AND ofe.OfertaID =" + OfferID;
            SqlCommand cmd8 = new SqlCommand(sqlsel8, con);
            //Metraz
            String sqlsel10 = "SELECT obw.Metraz FROM Obiektdowynajecia obw INNER JOIN Miejsce m ON obw.MiejsceID = m.MiejsceID INNER JOIN Oferta ofe ON ofe.ObiektdowynajeciaID=obw.ObiektdowynajeciaID WHERE ofe.ObiektdowynajeciaID = obw.ObiektdowynajeciaID AND ofe.OfertaID =" + OfferID;
            SqlCommand cmd10 = new SqlCommand(sqlsel10, con);
            //MaxIlosc
            String sqlsel12 = "SELECT obw.IloscMiejsc FROM Obiektdowynajecia obw INNER JOIN Miejsce m ON obw.MiejsceID = m.MiejsceID INNER JOIN Oferta ofe ON ofe.ObiektdowynajeciaID=obw.ObiektdowynajeciaID WHERE ofe.ObiektdowynajeciaID = obw.ObiektdowynajeciaID AND ofe.OfertaID =" + OfferID;
            SqlCommand cmd12 = new SqlCommand(sqlsel12, con);
            //Udogodnienia
            String sqlsel14 = "SELECT (select u2.nazwa  + ', ' from Udogodnienia_2 u2 INNER JOIN Udogodnienia u ON u.Udogodnienia_2ID=u2.Udogodnienia_2ID, Obiektdowynajecia obw INNER JOIN Oferta ofe ON ofe.ObiektdowynajeciaID=obw.ObiektdowynajeciaID WHERE u.ObiektID=obw.ObiektdowynajeciaID AND u.Udogodnienia_2ID=u2.Udogodnienia_2ID AND ofe.ObiektdowynajeciaID=" + OfferID + " for xml path('')) as 'Udogodnienia'";
            SqlCommand cmd14 = new SqlCommand(sqlsel14, con);


            //String sqlsel16 = "SELECT DISTINCT NazwaObiektu From Obiektdowynajecia WHERE ObiektdowynajeciaID =" + GridView1.SelectedRow.Cells[0].Text;
            //SqlCommand cmd16 = new SqlCommand(sqlsel16, con);
            //String sqlsel18 = "SELECT DISTINCT NazwaObiektu From Obiektdowynajecia WHERE ObiektdowynajeciaID =" + GridView1.SelectedRow.Cells[0].Text;
            //SqlCommand cmd18 = new SqlCommand(sqlsel8, con);
            //String sqlsel20 = "SELECT DISTINCT NazwaObiektu From Obiektdowynajecia WHERE ObiektdowynajeciaID =" + GridView1.SelectedRow.Cells[0].Text;
            //SqlCommand cmd20 = new SqlCommand(sqlsel20, con);


            con.Open();





            Label2.Text = cmd2.ExecuteScalar().ToString();
            Label4.Text = cmd4.ExecuteScalar().ToString();
            Label6.Text = cmd6.ExecuteScalar().ToString();
            Label8.Text = cmd8.ExecuteScalar().ToString();
            Label10.Text = cmd10.ExecuteScalar().ToString() + "&#13217";
            Label12.Text = cmd12.ExecuteScalar().ToString();
            Label18.Text = cmd14.ExecuteScalar().ToString();





            con.Close();
        }

        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {

            int dni = ((Calendar2.SelectedDate - Calendar1.SelectedDate).Days + 1);
            if (dni > 0)
            {
                float cena = (float.Parse(Label8.Text.ToString()) * (float)dni);

                if (GetUserID() > 0)
                {
                    if (GetKlientID() > 0)
                    {


                        if (DateCheck())
                        {
                            string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
                            SqlConnection con = new SqlConnection(ConString);

                            con.Open();

                            String KS_insert = "Insert into Rezerwacja (KlientID, OfertaID, CenaRezerwacji, Przyjazd, Wyjazd) VALUES (" + GetKlientID() + "," + Int32.Parse(Request.QueryString["Oferta"]) + "," + cena + ", '" + Calendar1.SelectedDate.ToString("yyyy-MM-dd") + "','" + Calendar2.SelectedDate.ToString("yyyy-MM-dd") + "')";
                            SqlCommand cmd = new SqlCommand(KS_insert, con);

                            cmd.ExecuteNonQuery();
                            con.Close();


                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Pomyślnie zarezerwowano');window.location ='MyRent.aspx';", true);
                        }
                        else
                        {
                            CountDays.Text = "Wybrałeś nie prawidłowy termin";
                        }

                    }

                }
            }
            else
            {
                CountDays.Text = "Wybrałeś nie prawidłowy termin";
            }

        }
        protected int GetUserID()
        {
            string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
            SqlConnection con = new SqlConnection(ConString);
            con.Open();



            String KS_sqlpass = "Select UzytkownikID from [dbo].[Uzytkownik] WHERE [E-mail] = '" + User.Identity.Name + "'";
            SqlCommand cmd2 = new SqlCommand(KS_sqlpass, con);

            int userid;
            userid = (Int32)cmd2.ExecuteScalar();
            con.Close();


            return userid;
        }
        protected int GetKlientID()
        {

            string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
            SqlConnection con = new SqlConnection(ConString);

            con.Open();



            String KS_sqlpass = "SELECT Count(*) FROM [dbo].[Klient] WHERE [UzytkownikID]= " + GetUserID();
            SqlCommand cmd2 = new SqlCommand(KS_sqlpass, con);

            String KS_sqlpass2 = "SELECT KlientID FROM [dbo].[Klient] WHERE [UzytkownikID]= " + GetUserID();
            SqlCommand cmd3 = new SqlCommand(KS_sqlpass2, con);

            String KS_insert = "Insert into [dbo].[Klient] (UzytkownikID) VALUES (" + GetUserID() + ")";
            SqlCommand cmd = new SqlCommand(KS_insert, con);

            int n;
            n = (Int32)cmd2.ExecuteScalar();

            int ownerid;
            con.Close();


            if (n > 0)
            {

                con.Open();


                ownerid = (Int32)cmd3.ExecuteScalar();
                con.Close();

                return ownerid;

            }
            else
            {


                con.Open();
                cmd.ExecuteNonQuery();
                ownerid = (Int32)cmd3.ExecuteScalar();
                con.Close();
                return ownerid;

            }


        }
        protected int LiczbaRezerwacji()
        {
            string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
            SqlConnection con = new SqlConnection(ConString);

            con.Open();
            String KS_sqlpass2 = "Select count(przyjazd) from Rezerwacja inner join Oferta on Oferta.OfertaID=Rezerwacja.OfertaID WHERE Oferta.OfertaID=" + Int32.Parse(Request.QueryString["Oferta"]);
            SqlCommand cmd3 = new SqlCommand(KS_sqlpass2, con);
            int n = (Int32)cmd3.ExecuteScalar();
            con.Close();
            return n;

        }
        protected bool DateCheck()
        {
            if (LiczbaRezerwacji() > 0)
            {
                int id = Int32.Parse(Request.QueryString["Oferta"]);

                string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
                SqlConnection con = new SqlConnection(ConString);

                SqlConnection con2 = new SqlConnection(ConString);

                SqlConnection con4 = new SqlConnection(ConString);

                con.Open();
                String KS_sqlpass2 = "Select count(przyjazd) from Rezerwacja inner join Oferta on Oferta.OfertaID=Rezerwacja.OfertaID WHERE Oferta.OfertaID=" + Int32.Parse(Request.QueryString["Oferta"]);

                SqlCommand cmd3 = new SqlCommand(KS_sqlpass2, con);
                con2.Open();
                con4.Open();

                DateTime dzienp = Calendar1.SelectedDate;

                DateTime dzienw = Calendar2.SelectedDate;


                using (SqlDataReader rdr = cmd3.ExecuteReader())
                {
                    while (rdr.Read())
                    {

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
                            return false;
                        }

                        for (int i = 0; i < dni; i++)
                        {
                            if (przyjazd == dzienp || przyjazd == dzienw)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }

                            przyjazd = przyjazd.AddDays(1);
                        }



                    }
                }

                con2.Close();
                con.Close();
                con4.Close();



                return true;


            }
            else
            {
                return true;
            }
        }

    }

}