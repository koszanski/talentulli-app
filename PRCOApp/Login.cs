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

        int loginID;
        string loginUser;
        string loginPass;

        public Login(int theID, string theLogin, string thePassword)
        {
            loginID = theID;
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

        public int getID()
        {
            return loginID;
        }



    }

 
}
