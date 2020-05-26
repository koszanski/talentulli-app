using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRCOApp
{
    public class Login
    {

        //application-wide class for saving/retaining logged-in credentials

        string loginUser;
        string loginPass;

        public Login(string theLogin, string thePassword)
        {
            loginUser = theLogin;
            loginPass = thePassword;
        }

        public Login()
        {

            loginUser = "";
            loginPass = "";

        }

        public string dispLoggedin()
        {
            return loginUser;
        }



    }

 
}
