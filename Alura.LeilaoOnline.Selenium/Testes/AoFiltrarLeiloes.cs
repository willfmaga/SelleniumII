using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoFiltrarLeiloes
    {
        private IWebDriver driver;

        public AoFiltrarLeiloes(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveMostrarPainelResultado()
        {
            //arrange
            new LoginPO(driver).
                EfetuarLoginComCredenciais("fulano@example.org", "123");
  

            var dashboardInteressadaPO = new DashboardInteressadaPO(driver);

            //act
            dashboardInteressadaPO.Filtro.PesquisarLeiloes(
                new List<string> { "Arte", "Coleções" },
                //new List<string> { "Arte"},
                "",
                true);

            //assert
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(drv => drv.PageSource.Contains("Resultado da pesquisa"));

            Assert.Contains("Resultado da pesquisa", driver.PageSource);

        }
    }
}
