using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;

namespace WebApplication1
{
    public partial class Logowanie : System.Web.UI.Page
    {
        public object FomrsAuthentication { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            wrongpass.Visible = false;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public int ks_valid()
        {
            string KS_dbpass = null;
            int isnew = 0;
            try
            {
                string KS_conn = ConfigurationManager.ConnectionStrings["DbRent"].ConnectionString;

                SqlConnection KS_con = new SqlConnection(KS_conn);
                KS_con.Open();
                String sqllogin = "SELECT COUNT(*) FROM [dbo].[Uzytkownik] WHERE [E-mail]= '" + txtlogin.Value + "'";
                SqlCommand cmd1 = new SqlCommand(sqllogin, KS_con);

                String KS_sqlpass = "SELECT [Haslo] FROM [dbo].[Uzytkownik] WHERE [E-mail]= '" + txtlogin.Value + "'";
                SqlCommand cmd2 = new SqlCommand(KS_sqlpass, KS_con);


                isnew = (Int32)cmd1.ExecuteScalar();
                KS_dbpass = (string)cmd2.ExecuteScalar();
                KS_con.Close();

            }

            catch { }
            if (isnew > 0)
            {
                if (KS_dbpass == txtpassword.Value.ToString())
                {
                    return 2; // KONTO ISTNIEJE I HASLO SIE ZGADZA
                }
                else return 3; // KONTO ISTNIEJE ALE ZLE HASLO
            }
            else return 1; // KONTO NIE ISTNIEJE
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                if (ks_valid() == 1)
                {
                    wrongpass.Visible = true;
                    //FormsAuthentication.RedirectFromLoginPage(txtlogin.Value, false); // nie do konca
                }
                if (ks_valid() == 2)
                {
                    FormsAuthentication.RedirectFromLoginPage(txtlogin.Value, false); // Zalogowany wraaca na strone glowna, z autoryzoacja
                }
                if (ks_valid() == 3)
                {
                    wrongpass.Visible = true;
                }
            }

        }

    }
}