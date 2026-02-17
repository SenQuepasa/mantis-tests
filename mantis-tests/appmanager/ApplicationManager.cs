using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ApplicationManager
    {

        protected IWebDriver driver;
        protected string baseURL;

        public RegistrationHelper Registration { get; }
        public FtpHelper Ftp { get; set; }
        public AdminHelper Admin { get; set; }
        public APIHelper API { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();


        private ApplicationManager()
        {
            this.driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            Admin = new AdminHelper(this, baseURL);
            API = new APIHelper(this);



        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }
        public IWebDriver Driver
        {
            get 
            {
                return driver; 
            }
        }

    }

}
