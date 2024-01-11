using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class MyRent : System.Web.UI.Page
    {
        public string SearchSQL = "";
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                Errr.Visible = false;
                DbBind();

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
            string KS_conn = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;

            SqlConnection KS_con = new SqlConnection(KS_conn);
            KS_con.Open();


            String sqltab = "SELECT ofe.OfertaID, r.CenaRezerwacji, obw.NazwaObiektu, uz.Imie + ' ' + uz.Nazwisko as 'Wlasciciel', uz.NrTelefonu, m.MiejsceID,TypKrainyGeograficznej + ', ' + NazwaKrainyGeograficznej as 'Region', (select u2.nazwa  + ', ' from Udogodnienia_2 u2 INNER JOIN Udogodnienia u ON u.Udogodnienia_2ID = u2.Udogodnienia_2ID INNER JOIN Oferta ofe ON ofe.ObiektdowynajeciaID = obw.ObiektdowynajeciaID WHERE u.ObiektID = obw.ObiektdowynajeciaID AND u.Udogodnienia_2ID = u2.Udogodnienia_2ID for xml path('')) as 'Udogodnienia', obw.IloscMiejsc, obw.Metraz, obw.ObiektdowynajeciaID as 'ObiektID', obw.CenaZaDobe,  obw.Adres + ' ' + obw.KodPocztowy + ' ' + obw.Kraj as 'AdresO', r.Przyjazd, r.Wyjazd, r.KlientID FROM Obiektdowynajecia obw INNER JOIN Miejsce m ON obw.MiejsceID = m.MiejsceID INNER JOIN Oferta ofe ON ofe.ObiektdowynajeciaID = obw.ObiektdowynajeciaID INNER JOIN Rezerwacja r ON r.OfertaID = ofe.OfertaID INNER JOIN WlascicielObiektu wo ON obw.WlascicielObiektuID = wo.WlascicielObiektuID INNER JOIN Uzytkownik uz ON uz.UzytkownikID=wo.UzytkownikID WHERE wo.UzytkownikID=uz.UzytkownikID AND ofe.ObiektdowynajeciaID = obw.ObiektdowynajeciaID AND r.OfertaID = ofe.OfertaID AND r.KlientID =" + GetKlientID() + " ORDER BY r.Przyjazd DESC";





            SqlCommand cmd = new SqlCommand(sqltab, KS_con);
            SqlDataAdapter cmd1 = new SqlDataAdapter(sqltab, KS_con);
            if (cmd.ExecuteScalar() == null)
            {
                Errr.Visible = true;
                Errr.Text = "NIE POSIADASZ REZERWACJI W SYSTEMIE";

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
        protected void Cancel(int ofid)
        {
            string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            String KS_insert = "Delete Rezerwacja WHERE KlientID =" + GetKlientID() + " AND OfertaID =" + ofid;
            SqlCommand cmd = new SqlCommand(KS_insert, con);
            String KS_insert1 = "Select count(*) from Rezerwacja WHERE KlientID =" + GetKlientID() + " AND OfertaID =" + ofid;
            SqlCommand cmd1 = new SqlCommand(KS_insert1, con);
            int es;
            es = (Int32)cmd1.ExecuteScalar();

            if (es > 0)
            {
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Pomyślnie zrezygnowano z rezerwacji');window.location ='MyRent.aspx';", true);
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Nie masz rezerwacji');", true);
            }

            con.Close();

        }
        public void MyBtnHandler(Object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            switch (btn.CommandName)
            {
                case "ThisBtnClick":
                    Cancel(Convert.ToInt32(btn.CommandArgument.ToString()));
                    break;

            }
        }
    }
}