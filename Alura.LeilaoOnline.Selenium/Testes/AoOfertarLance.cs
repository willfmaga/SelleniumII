using System;
using OpenQA.Selenium;
using Xunit;
using Alura.LeilaoOnline.Selenium.PageObjects;
using Alura.LeilaoOnline.Selenium.Fixtures;
using System.Threading;
using System.Linq;
using OpenQA.Selenium.Support.UI;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoOfertarLance
    {
        private IWebDriver driver;

        public AoOfertarLance(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveAtualizarLanceAtual()
        {
            //arrange 
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            loginPO.SubmeteFormulario();

            var detalhePO = new DetalheLeilaoPO(driver);
            detalhePO.Visitar(1); //em andamento

            //act 
            detalhePO.OfertarLance(300);

            //assert 
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            var iguais = wait.Until(drv => 300 == detalhePO.LanceAtual);

            Assert.True(iguais);

        }

    }
}
