using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebApplication1
{
    public partial class MyHouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DbBind();
            if (!Page.IsPostBack)
            {
                Szczegoly.Visible = false;
            }
        }

        protected void OnClickLogout(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();

            Response.Redirect(Request.RawUrl);


        }
        protected int GetUserID()
        {
            string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
            SqlConnection con = new SqlConnection(ConString);
            con.Open();



            String KS_sqlpass = "Select UzytkownikID from [dbo].[Uzytkownik] WHERE [E-mail] = '" + User.Identity.Name + "'";
            SqlCommand cmd2 = new SqlCommand(KS_sqlpass, con);

            int ownerid;
            ownerid = (Int32)cmd2.ExecuteScalar();
            con.Close();




            return ownerid;
        }
        protected void DbBind()
        {
            string KS_conn = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;

            SqlConnection KS_con = new SqlConnection(KS_conn);
            KS_con.Open();
            String sqltab = "Select o.ObiektdowynajeciaID as 'Numer Obiektu', o.NazwaObiektu as 'Nazwa Obiektu', o.CenaZaDobe as 'Cena za dobę', o.Adres as 'Adres obiektu' From [dbo].[Obiektdowynajecia] as o INNER JOIN [dbo].[WlascicielObiektu] as w on o.WlascicielObiektuID=w.WlascicielObiektuID WHERE w.UzytkownikID = " + GetUserID(); ;
            SqlDataAdapter cmd1 = new SqlDataAdapter(sqltab, KS_con);
            DataTable dt = new DataTable();
            cmd1.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            KS_con.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LabelTest.Text = GridView1.SelectedRow.Cells[0].Text;
            Szczegoly.Visible = true;
            SqlSelect();
        }


        protected void FPublish()
        {
            string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            String KS_insert = "Insert into [dbo].[Oferta] (ObiektdowynajeciaID, WlascicielObiektuID) VALUES ( " + GridView1.SelectedRow.Cells[0].Text + ", " + GetOwnerID() + ");";
            SqlCommand cmd = new SqlCommand(KS_insert, con);
            cmd.ExecuteNonQuery();

            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(),
"alert",
"alert('Pomyślnie opublikowano obiekt');window.location ='MyHouse.aspx';",
true);
        }
        protected void FDown()
        {
            string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            String KS_insert = "DELETE Oferta WHERE ObiektdowynajeciaID=" + GridView1.SelectedRow.Cells[0].Text;
            SqlCommand cmd = new SqlCommand(KS_insert, con);
            cmd.ExecuteNonQuery();

            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(),
"alert",
"alert('Pomyślnie zdjęto obiekt');window.location ='MyHouse.aspx';",
true);
        }

        protected int GetOwnerID()
        {

            string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
            SqlConnection con = new SqlConnection(ConString);

            con.Open();



            String KS_sqlpass = "SELECT Count(*) FROM [dbo].[WlascicielObiektu] WHERE [UzytkownikID]= " + GetUserID();
            SqlCommand cmd2 = new SqlCommand(KS_sqlpass, con);

            String KS_sqlpass2 = "SELECT WlascicielObiektuID FROM [dbo].[WlascicielObiektu] WHERE [UzytkownikID]= " + GetUserID();
            SqlCommand cmd3 = new SqlCommand(KS_sqlpass2, con);

            String KS_insert = "Insert into [dbo].[WlascicielObiektu] (UzytkownikID) VALUES (" + GetUserID() + ")";
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

        protected void SqlSelect()
        {
            string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
            SqlConnection con = new SqlConnection(ConString);

            String sqlsel2 = "SELECT DISTINCT NazwaObiektu From Obiektdowynajecia WHERE ObiektdowynajeciaID =" + GridView1.SelectedRow.Cells[0].Text;
            SqlCommand cmd2 = new SqlCommand(sqlsel2, con);
            String sqlsel4 = "SELECT DISTINCT Adres From Obiektdowynajecia WHERE ObiektdowynajeciaID =" + GridView1.SelectedRow.Cells[0].Text;
            SqlCommand cmd4 = new SqlCommand(sqlsel4, con);
            String sqlsel6 = "SELECT DISTINCT Kraj From Obiektdowynajecia WHERE ObiektdowynajeciaID =" + GridView1.SelectedRow.Cells[0].Text;
            SqlCommand cmd6 = new SqlCommand(sqlsel6, con);
            String sqlsel8 = "SELECT DISTINCT CenaZaDobe From Obiektdowynajecia WHERE ObiektdowynajeciaID =" + GridView1.SelectedRow.Cells[0].Text;
            SqlCommand cmd8 = new SqlCommand(sqlsel8, con);
            String sqlsel10 = "SELECT DISTINCT Metraz From Obiektdowynajecia WHERE ObiektdowynajeciaID =" + GridView1.SelectedRow.Cells[0].Text;
            SqlCommand cmd10 = new SqlCommand(sqlsel10, con);
            String sqlsel12 = "SELECT DISTINCT IloscMiejsc From Obiektdowynajecia WHERE ObiektdowynajeciaID =" + GridView1.SelectedRow.Cells[0].Text;
            SqlCommand cmd12 = new SqlCommand(sqlsel12, con);
            String sqlsel14 = "SELECT Count (*) FROM Oferta WHERE ObiektdowynajeciaID =" + GridView1.SelectedRow.Cells[0].Text;
            SqlCommand cmd14 = new SqlCommand(sqlsel14, con);
            //String sqlsel16 = "SELECT DISTINCT NazwaObiektu From Obiektdowynajecia WHERE ObiektdowynajeciaID =" + GridView1.SelectedRow.Cells[0].Text;
            //SqlCommand cmd16 = new SqlCommand(sqlsel16, con);
            String sqlsel18 = "SELECT DISTINCT NazwaObiektu From Obiektdowynajecia WHERE ObiektdowynajeciaID =" + GridView1.SelectedRow.Cells[0].Text;
            SqlCommand cmd18 = new SqlCommand(sqlsel8, con);
            //String sqlsel20 = "SELECT DISTINCT NazwaObiektu From Obiektdowynajecia WHERE ObiektdowynajeciaID =" + GridView1.SelectedRow.Cells[0].Text;
            //SqlCommand cmd20 = new SqlCommand(sqlsel20, con);
            String sqlsel21 = "Select count(*) From Obiektdowynajecia as o JOIN Oferta as ofer on ofer.ObiektdowynajeciaID = o.ObiektdowynajeciaID where ofer.ObiektdowynajeciaID = " + GridView1.SelectedRow.Cells[0].Text;
            SqlCommand cmd21 = new SqlCommand(sqlsel21, con);
            //UDOGODNIENIA
            String sqlsel22 = "SELECT (select u2.nazwa  + ', ' from Udogodnienia_2 u2 INNER JOIN Udogodnienia u ON u.Udogodnienia_2ID=u2.Udogodnienia_2ID, Obiektdowynajecia obw INNER JOIN Oferta ofe ON ofe.ObiektdowynajeciaID=obw.ObiektdowynajeciaID WHERE u.ObiektID=obw.ObiektdowynajeciaID AND u.Udogodnienia_2ID=u2.Udogodnienia_2ID AND obw.ObiektdowynajeciaID=" + GridView1.SelectedRow.Cells[0].Text + " for xml path('')) as 'Udogodnienia'";
            SqlCommand cmd22 = new SqlCommand(sqlsel22, con);

            con.Open();





            Label2.Text = cmd2.ExecuteScalar().ToString();
            Label4.Text = cmd4.ExecuteScalar().ToString();
            Label6.Text = cmd6.ExecuteScalar().ToString();
            Label8.Text = cmd8.ExecuteScalar().ToString();
            Label10.Text = cmd10.ExecuteScalar().ToString();
            Label12.Text = cmd12.ExecuteScalar().ToString();



            if ((Int32)cmd21.ExecuteScalar() > 0)
            {
                Publish.Enabled = false;
                Down.Enabled = true;
            } //OPUBLIKOWANE CZY NIE
            else
            {
                Publish.Enabled = true;
                Down.Enabled = false;
            }

            if ((Int32)cmd14.ExecuteScalar() > 0)
            {
                Label16.Text = "Oferta aktywna";

            }
            else
            {
                Label16.Text = "Oferta nieaktywna";
            }


            con.Close();
        }

        protected void Publish_Click(object sender, EventArgs e)
        {
            FPublish();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddHouse.aspx");
        }

        protected void Down_Click(object sender, EventArgs e)
        {
            FDown();
        }
    }






}