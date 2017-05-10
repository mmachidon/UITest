using System;

namespace testUIPart
{
  
    class Program
    {     
        static void Main(string[] args)
        {
            RegistrationSteps.beforeTest();
            RegistrationSteps.setUser();
            RegistrationSteps.sendEmail();
            RegistrationSteps.sendRequiredFields();
            
            System.Threading.Thread.Sleep(10000);
            RegistrationSteps.activateAccount();
            RegistrationSteps.testLogin();
            RegistrationSteps.afterTest();
            Console.ReadKey();
        }
    }    
        
   
    
}
