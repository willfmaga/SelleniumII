using Alura.LeilaoOnline.Selenium.Test.Fixtures;
using Alura.LeilaoOnline.Selenium.Test.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Test.Tests
{
    [Collection("MinhaCollection")]
    public class AoNavegarParaFormNovoLeilao
    {
        private IWebDriver driver;

        public AoNavegarParaFormNovoLeilao(TestFixture testFixture)
        {
            this.driver = testFixture.Driver;
        }

        [Fact]
        public void DadoLoginAdmDeveMostrarTresCategorias()
        {
            //arrange 
            //arrange 
            string titulo = "Novo Leilao Moto";
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencherFormulario("admin@example.org", "123");
            loginPO.SubmeterFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(driver);

            //act
            novoLeilaoPO.Visitar();

            Assert.Equal(3, novoLeilaoPO.Categorias.Count());
        }

    }
}
