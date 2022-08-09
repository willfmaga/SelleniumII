using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Alura.LeilaoOnline.Selenium.Test.Helpers;
using OpenQA.Selenium.Firefox;

namespace Alura.LeilaoOnline.Selenium.Test.Fixtures
{
 
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        //Setup
        public TestFixture()
        {
            Driver = new ChromeDriver(TestHelper.PastaDoExecutavelDoGoogleDriver103());
            Driver.Manage().Window.Maximize();
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //implicito para todos os find elements
            //Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(4);
        }

        //Tear Down
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}