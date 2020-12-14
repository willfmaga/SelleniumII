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
    public class AoEfetuarLogout
    {
        private IWebDriver driver;

        public AoEfetuarLogout(TestFixture testFixture)
        {
            this.driver = testFixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoDeveIrParaHomeNaoLogada()
        {

            //arrange 
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencherFormulario("fulano@example.org", "123");
            loginPO.SubmeterFormulario();
            var dashboard = new DashboardInteressadaPO(driver);

            //act 
            dashboard.EfetuarLogout();

            //assert 
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}
