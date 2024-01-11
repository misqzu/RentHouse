using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AddHouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            Span1.Text = "";
        }
        protected void OnClickLogout(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();

            Response.Redirect(Request.RawUrl);


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






        protected void Button3_Click(object sender, EventArgs e)
        {
            string filepath = Server.MapPath("~/Upload/Images");
            HttpFileCollection uploadedFiles = Request.Files;
            string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
            SqlConnection con = new SqlConnection(ConString);
            con.Open();



            int ownerid = GetOwnerID();

            //VALIDAte

            if (User.Identity.IsAuthenticated)
            {

                if (uploadedFiles.Count > 5)
                {
                    Span1.Text = "Maksymalnie 5 plików! Każdy maksymalnie 4MB!";
                }
                if (uploadedFiles.Count < 1)
                {
                    Span1.Text += "Brak plików";
                }
                if (uploadedFiles.Count > 0 && uploadedFiles.Count < 6)
                {
                    Span1.Text += "1";
                    for (int i = 0; i < uploadedFiles.Count; i++)
                    {
                        HttpPostedFile userPostedFile = uploadedFiles[i];
                        Span1.Text += "2";
                        try
                        {
                            if (userPostedFile.ContentLength > 0 && userPostedFile.ContentLength < 4194304)
                            {
                                Span1.Text += "3";
                                String KS_insert2 = "Insert into [dbo].[Obiektdowynajecia] ( NazwaObiektu, CenaZaDobe, MiejsceID, WlascicielObiektuID, Metraz, IloscMiejsc, Adres, KodPocztowy, Kraj) " +
                                                           "VALUES ( '" + Nazwa.Text + "', " + Cena.Text + ", " + ListBox2.SelectedValue + ", " + ownerid + ", " + Metraz.Text + ", " + Miejsca.Text + ", '" + Adres.Text + "', '" + Kod.Text + "', '" + Kraj.Text + "'); SELECT CAST(SCOPE_IDENTITY() AS int);";

                                SqlCommand cmd2 = new SqlCommand(KS_insert2, con);

                                int obiektid = (Int32)cmd2.ExecuteScalar();
                                Span1.Text += "File Name: " + userPostedFile.FileName + "<br>";
                                Span1.Text += "Został Dodany! ";
                                userPostedFile.SaveAs(filepath + "\\obiekt_" + obiektid + "-" + i + ".jpg");
                                //Span1.Text += "Location where saved: " + filepath + "/" + Path.GetFileName(userPostedFile.FileName) + "<p>";
                                Span1.Text += "4";


                                foreach (ListItem item in CheckBoxList1.Items)
                                {
                                    if (item.Selected)
                                    {
                                        Span1.Text += "5";
                                        String KS_insert = "Insert into [dbo].[Udogodnienia] (ObiektID, Udogodnienia_2ID) " +
                                                           "VALUES (" + obiektid + "," + item.Value + ")";

                                        SqlCommand cmd = new SqlCommand(KS_insert, con);

                                        cmd.ExecuteNonQuery();
                                        Span1.Text += "6";
                                    }

                                }


                                con.Close();

                                Span1.Text += "7";

                                ScriptManager.RegisterStartupScript(this, this.GetType(),
"alert",
"alert('Dodano obiekt do systemu, w celu udostępnienia kliknij Publikuj w swoich obiektach');window.location ='MyHouse.aspx';",
true);




                            }
                            else
                            {
                                Span1.Text = "Rozmiar pliku przekracza 4MB";
                            }
                        }
                        catch (Exception Ex)
                        {
                            Span1.Text += "Error: <br>" + Ex.Message;
                        }
                    }

                }






            }





        }
    }
}