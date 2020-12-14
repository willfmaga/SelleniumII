using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Alura.LeilaoOnline.Selenium.Test.Helpers;

namespace Alura.LeilaoOnline.Selenium.Test.Fixtures
{
 
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        //Setup
        public TestFixture()
        {
            Driver = new ChromeDriver(TestHelper.PastaDoExecutavelDoDriver());
        }

        //Tear Down
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}