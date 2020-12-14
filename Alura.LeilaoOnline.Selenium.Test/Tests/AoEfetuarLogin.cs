using Alura.LeilaoOnline.Selenium.Test.Fixtures;
using Alura.LeilaoOnline.Selenium.Test.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Test.Tests
{
    [Collection("MinhaCollection")]
    public class AoEfetuarLogin
    {
        private IWebDriver driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            this.driver = fixture.Driver;
        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaDashboard()
        {
            //arrange 
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencherFormulario("fulano@example.org","123");

            //act 
            loginPO.SubmeterFormulario();

            //assert 
            Assert.Contains("Dashboard", driver.Title);

        }

        [Fact]
        public void DadoCredenciasiInvalidasDeveContinuarNaHome()
        {
            //arrange 
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencherFormulario("fulano@example.org", string.Empty);

            //act 
            loginPO.SubmeterFormulario();

            //assert 
            Assert.Contains("Login", driver.PageSource);
        }
    }

}
