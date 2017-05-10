using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testUIPart
{
  public  class RegistrationForm
    {

        public string registrationUrl;
        public string email;
        public string nextButton;
        public string firstName;
        public string surname;
        public string checkbox;
        public string submitButton;
        public string password;
        public string confirmPassword;
        public string resendEmailBtn;
        public RegistrationForm()
        {
             registrationUrl = "https://site06.qaw03.rxweb-dev.com/en/Website-Sign-Up/";
             email = "ctl00_centreContentPlaceHolder_ctlSignUp_txtEmail";
             nextButton = "ctl00_centreContentPlaceHolder_ctlSignUp_submitButton";
             firstName = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtFirstname";
             surname = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtSurname";
             checkbox = "ctl00_centreContentPlaceHolder_ctlCreateProfile_chkTAndC";
             submitButton = "ctl00_centreContentPlaceHolder_ctlCreateProfile_submitButton";
             password = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtPassword";
             confirmPassword = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtConfirmPassword";
             resendEmailBtn = "ctl00_centreContentPlaceHolder_btnSendEmail";
        }
    }
}
