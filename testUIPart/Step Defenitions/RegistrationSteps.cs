using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace testUIPart
{
    [Binding]
   public  class RegistrationSteps
    {
        public static string userLoginName;
        public static string userPassword;
        public static string userID;
        public static IWebDriver driver;
        public static LoginForm loginPage;
        public static RegistrationForm registrationPage;
       

        public  RegistrationSteps()
        { }
        public static void setUserName()
        {
            Random rnd = new Random();
            int randomId = rnd.Next(1, 10000);
            userLoginName = "test_user_" + randomId + "@mailinator.com";
            userID = "test_user_" + randomId;
        }
        public static void setPassword()
        {
            userPassword = "Infonet123";

        }
        [Before]
        public static void beforeTest()
        {
            driver = new ChromeDriver();
            loginPage = new LoginForm();
            registrationPage = new RegistrationForm();
        
        }
        [Given(@"I am a User")]
        public static void setUser()
        {
            setUserName();
            setPassword();
        }
        [When(@"I submit a email to Registration Form")]
        public static void sendEmail()
        {
            Console.WriteLine("Registration URL {0}", registrationPage.registrationUrl);
            driver.Url = registrationPage.registrationUrl;
            Console.WriteLine("Is Email box displayed? {0}", driver.FindElement(By.Id(registrationPage.email)).Displayed);
            driver.FindElement(By.Id(registrationPage.email)).Clear();
            driver.FindElement(By.Id(registrationPage.email)).SendKeys(userLoginName);
            driver.FindElement(By.Id(registrationPage.nextButton)).Click();
            Console.WriteLine("Email: {0}", userLoginName);

        }

        [When(@"submit all required fields")]
        public static void sendRequiredFields()
        {
            Console.WriteLine("Sending required fields data");
            Console.WriteLine("Is First Name box displayed? {0}", driver.FindElement(By.Id(registrationPage.firstName)).Displayed);
            driver.FindElement(By.Id(registrationPage.firstName)).Clear();
            driver.FindElement(By.Id(registrationPage.firstName)).SendKeys("First Name");
            Console.WriteLine("Is Second Name field displayed? {0}", driver.FindElement(By.Id(registrationPage.surname)).Displayed);
            driver.FindElement(By.Id(registrationPage.surname)).Clear();
            driver.FindElement(By.Id(registrationPage.surname)).SendKeys("Surname");
            Console.WriteLine("Is Password box displayed? {0}", driver.FindElement(By.Id(registrationPage.password)).Displayed);
            driver.FindElement(By.Id(registrationPage.password)).Clear();
            driver.FindElement(By.Id(registrationPage.password)).SendKeys(userPassword);
            Console.WriteLine("Password {0}", userPassword);
            Console.WriteLine("Is Confirm Password box displayed? {0}", driver.FindElement(By.Id(registrationPage.confirmPassword)).Displayed);
            driver.FindElement(By.Id(registrationPage.confirmPassword)).Clear();
            driver.FindElement(By.Id(registrationPage.confirmPassword)).SendKeys(userPassword);
            Console.WriteLine("Is requred checkbox displayed? {0}", driver.FindElement(By.Id(registrationPage.checkbox)).Displayed);
            driver.FindElement(By.Id(registrationPage.checkbox)).Click();
            Console.WriteLine("Is submit button displayed? {0}", driver.FindElement(By.Id(registrationPage.submitButton)).Displayed);
            driver.FindElement(By.Id(registrationPage.submitButton)).Click();
           
        }
        public static void activateAccount()
        {
          
            var str1 =  "https://www.mailinator.com";
            driver.Url = str1;
            Console.WriteLine("str: {0}", str1);
            driver.FindElement(By.Id("inboxfield")).SendKeys(userID);
            driver.FindElement(By.XPath("//*[contains(text(), 'Go!')]")).Click();
            driver.FindElement(By.XPath("//*[contains(text(), 'Activate Your WhiteLabel Site06 Profile')]")).Click();
            var iframeSwitch = driver.FindElement(By.Id("publicshowmaildivcontent"));
            driver.SwitchTo().Frame(iframeSwitch);
            System.Threading.Thread.Sleep(2000);
            var str = driver.PageSource.ToString();
            string[] split = str.Split('>','<');
            Console.WriteLine("Activation Link: {0}", split[16]);
            driver.Url = split[16];

        }
        public static void testLogin()
        {
            Console.WriteLine("Loggin validation");
            Console.WriteLine("Registration URL {0}", registrationPage.registrationUrl);
            Console.WriteLine("Email: {0}", userLoginName);
            Console.WriteLine("Password {0}", userPassword);
            driver.Url = loginPage.loginUrl;
            Console.WriteLine("Is username box displayed? {0}", driver.FindElement(By.Id(loginPage.username)).Displayed);
            driver.FindElement(By.Id(loginPage.username)).Clear();
            driver.FindElement(By.Id(loginPage.username)).SendKeys(userLoginName);
            Console.WriteLine("Is Password box displayed? {0}", driver.FindElement(By.Id(loginPage.password)).Displayed);
            driver.FindElement(By.Id(loginPage.password)).Clear();
            driver.FindElement(By.Id(loginPage.password)).SendKeys(userPassword);
            Console.WriteLine("Is Login btn displayed? {0}", driver.FindElement(By.Id(loginPage.loginBtn)).Displayed);
            driver.FindElement(By.Id(loginPage.loginBtn)).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(), 'Surname First Name')]")).Displayed, "Account is not created");

        }
        [After]
        public static void afterTest()
        {
            Console.WriteLine("Closing browser");
            driver.Close();

        }

    }
}
