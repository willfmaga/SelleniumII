using Alura.LeilaoOnline.Selenium.Test.Fixtures;
using Alura.LeilaoOnline.Selenium.Test.Helpers;
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
        public void DadoLoginAdminEInfoValidasDeveCadastrarLeilaoMoto()
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
                                            TestHelper.CaminhoCompletoArquivo(@"Imagens\HDDyna.jpg"),
                                            DateTime.Now.AddDays(20),
                                            DateTime.Now.AddDays(40));

            //act 
            novoLeilaoPO.SubmeterFormulario();

            //assert
            Assert.Contains(titulo, driver.PageSource);
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }

        [Fact]
        public void DadoLoginAdminEInfoValidasDeveCadastrarLeilaoMotoMirage()
        {
            //arrange 
            string titulo = "Novo Leilao Moto Mirage 250";
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencherFormulario("admin@example.org", "123");
            loginPO.SubmeterFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(driver);
            novoLeilaoPO.Visitar();
            novoLeilaoPO.PreencherFormulario(titulo,
                                            "Leilao de moto Mirage 250cc",
                                            "Item importante para quem começa nas custom",
                                            100D,
                                            TestHelper.CaminhoCompletoArquivo(@"Imagens\Mirage250.jpg"),
                                            DateTime.Now.AddDays(0),
                                            DateTime.Now.AddDays(40));

            //act 
            novoLeilaoPO.SubmeterFormulario();

            //assert
            Assert.Contains(titulo, driver.PageSource);
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }
    }
}
