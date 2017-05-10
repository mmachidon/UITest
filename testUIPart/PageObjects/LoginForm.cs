using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testUIPart
{
 public class LoginForm

    {

        public string loginUrl;
        public string username;
        public string password;
        public string loginBtn;
        public LoginForm()
        {
            loginUrl = "https://site06.qaw03.rxweb-dev.com/en/Website-Sign-Up/Login-Form/";
            username = "ctl00_centreContentPlaceHolder_txtUsername";
            password = "ctl00_centreContentPlaceHolder_txtPassword";
            loginBtn = "ctl00_centreContentPlaceHolder_btnLogin";
        }
    }
}
