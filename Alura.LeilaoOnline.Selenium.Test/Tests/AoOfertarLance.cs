using Alura.LeilaoOnline.Selenium.Test.Fixtures;
using Alura.LeilaoOnline.Selenium.Test.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Test.Tests
{
    [Collection("MinhaCollection")]
    public class AoOfertarLance
    {
        private IWebDriver driver;

        public AoOfertarLance(TestFixture fixture)
        {
            this.driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInterassadaDeveAtualizarLanceAtual()
        {
            //arrange 
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencherFormulario("fulano@example.org", "123");
            loginPO.SubmeterFormulario();

            var detalhePO = new DetalheLeilaoPO(driver);
            detalhePO.Visitar(1);//em andamento

            //act 
            //var wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            //wait1.Until(drv => detalhePO.ExisteInputValor == true);
            detalhePO.OfertarLance(300);


            //arrange
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8)); //criando um wait explicito

            bool iguais = wait.Until(drv => detalhePO.LanceAtual == 300d);

            Assert.True(iguais);


        }
    }
}
