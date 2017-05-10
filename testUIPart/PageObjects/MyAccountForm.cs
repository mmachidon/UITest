using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testUIPart.PageObjects
{
    public class MyAccountForm
    {
        public string header;
        public MyAccountForm()
        {
            header = "//h2[contains(text(), 'Surname First Name')]";
        }
    }
}
