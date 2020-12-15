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
            Driver = new ChromeDriver(TestHelper.PastaDoExecutavelDoDriver());
            Driver.Manage().Window.Maximize();
        }

        //Tear Down
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}