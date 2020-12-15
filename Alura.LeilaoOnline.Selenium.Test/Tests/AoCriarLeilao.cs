using Alura.LeilaoOnline.Selenium.Test.Fixtures;
using Alura.LeilaoOnline.Selenium.Test.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Test.Tests
{
    [Collection("MinhaCollection")]
    public class AoCriarLeilao
    {
        private IWebDriver driver;

        public AoCriarLeilao(TestFixture testFixture)
        {
            this.driver = testFixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminEInfoValidasDeveCadastrarLeilao()
        {
            //arrange 
            string titulo = "Novo Leilao Moto";
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencherFormulario("admin@example.org", "123");
            loginPO.SubmeterFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(driver);
            novoLeilaoPO.Visitar();
            novoLeilaoPO.PreencherFormulario(titulo,
                                            "Leilao de motos antigas, com motorização acima de 500cc, placa preta",
                                            "Item de Colecionador",
                                            19000D,
                                            @"C:\Users\willi\Pictures\hd-nght rod-2008-gd.jpg",
                                            DateTime.Now.AddDays (20),
                                            DateTime.Now.AddDays(40));

            //act 
            novoLeilaoPO.SubmeterFormulario();

            //assert
            Assert.Contains(titulo, driver.PageSource);
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }
    }
}
