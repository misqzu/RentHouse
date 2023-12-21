using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace WebApplication1
{
    public partial class Rejestracja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                Page.Title = "Home page for " + User.Identity.Name;
                Login.Visible = false;


            }
            else
            {
                Page.Title = "Home page for guest user.";

            }
            Error.Visible = false;
        }

        protected bool IsMail()
        {
            string email = Box_Email.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,2})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
            {
                Error.Visible = true;
                Error.Text = "Nie prawidłowy format email";
                return false;
            }

        }


        protected bool IsNew()
        {
            string KS_conn = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;

            SqlConnection KS_con = new SqlConnection(KS_conn);
            KS_con.Open();
            String sqllogin = "SELECT COUNT(*) FROM [dbo].[Uzytkownik] WHERE [E-mail]= '" + Box_Email.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sqllogin, KS_con);

            int isnew = (Int32)cmd1.ExecuteScalar();

            KS_con.Close();

            if (isnew > 0)
            {
                return false;
            }
            else return true;
        }


        protected bool IsBoxEmpty()
        {
            if (Box_Imie.Text.ToString().Length < 3)
            {
                Error.Visible = true;
                Error.Text = " Pole imię ma za mało znaków.";
                return true;
            }
            else
            {
                if (Box_Nazwisko.Text.ToString().Length < 3)
                {
                    Error.Visible = true;
                    Error.Text = "Pole Nazwisko jest za krótkie";
                    return true;
                }
                else
                {
                    if (Box_Tel.Text.Length < 9)
                    {
                        Error.Visible = true;
                        Error.Text = "Podany numer telefonu jest za krótki";
                        return true;
                    }
                    else
                    {
                        if (!IsMail())
                        {

                            return true;
                        }
                        else
                        {
                            if (Box_Password.Text.Length < 6)
                            {
                                Error.Visible = true;
                                Error.Text = "Hasło jest za krókie (6 znaków)";
                                return true;

                            }
                        }



                    }
                }

            }
            return false;



        }

        protected void SignUP_Click(object sender, EventArgs e)
        {
            if (IsNew())
            {
                if (!IsBoxEmpty())
                {
                    string ConString = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;
                    SqlConnection con = new SqlConnection(ConString);
                    con.Open();
                    //String KS_insert = "insert into [dbo].[Uzytkownik] (Imie, Nazwisko, NrTelefonu, [E-mail], Haslo) VALUES ('test', 'test', 12345 , ' ttt', 'tttt');";
                    String KS_insert = "insert into [dbo].[Uzytkownik] (Imie, Nazwisko, NrTelefonu, [E-mail], Haslo) VALUES ('" + Box_Imie.Text + "', '" + Box_Nazwisko.Text + "', " + Box_Tel.Text + ", '" + Box_Email.Text + "', '" + Box_Password.Text + "');";
                    SqlCommand cmd = new SqlCommand(KS_insert, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    //Response.Write("<script>alert('login successful');</script>");
                    //Response.Redirect("index.aspx");
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
"alert",
"alert('Rejestracja przebiegła pomyślnie');window.location ='Logowanie.aspx';",
true);
                }

            }
            else
            {

                Error.Visible = true;
                Error.Text = "Użytkownik o podanym adresie już istnieje";
            }

        }
    }
}