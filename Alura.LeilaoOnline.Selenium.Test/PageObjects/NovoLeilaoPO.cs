using Alura.LeilaoOnline.Selenium.Test.Fixtures;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.Test.PageObjects
{
    public class NovoLeilaoPO
    {

        private readonly IWebDriver driver;
        private By byInputTitulo;
        private By byInputDescricao;
        private By byInputCategoria;
        private By byInputValorInicial;
        private By byInputImagem;
        private By byInputInicioPregao;
        private By byInputTerminoPregao;
        private By byBtnSalvar;

        public NovoLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputTitulo = By.Id("Titulo");
            byInputDescricao = By.Id("Descricao");
            byInputCategoria = By.Id("Categoria");
            byInputValorInicial = By.Id("ValorInicial");
            byInputImagem = By.Id("ArquivoImagem");
            byInputInicioPregao = By.Id("InicioPregao");
            byInputTerminoPregao = By.Id("TerminoPregao");
            byBtnSalvar = By.CssSelector("button[type=submit]");

        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
        }

        public void PreencherFormulario(string titulo,
                                        string descricao,
                                        string categoria,
                                        double valor,
                                        string imagem,
                                        DateTime inicio,
                                        DateTime termino)
        {
            driver.FindElement(byInputTitulo).SendKeys(titulo);
            driver.FindElement(byInputDescricao).SendKeys(descricao);
            driver.FindElement(byInputValorInicial).SendKeys(valor.ToString());
            driver.FindElement(byInputImagem).SendKeys(imagem);
            driver.FindElement(byInputInicioPregao).SendKeys(inicio.ToString("dd/MM/yyyy"));
            driver.FindElement(byInputTerminoPregao).SendKeys(termino.ToString("dd/MM/yyyy"));
            driver.FindElement(byInputCategoria).SendKeys(categoria);
            

        }

        public void SubmeterFormulario()
        {
            driver.FindElement(byBtnSalvar).Click();

        }

        public IEnumerable<string> Categorias
        {
            get
            {
                var elementoCategorias = new SelectElement(driver.FindElement(byInputCategoria));

               return elementoCategorias.Options
                    .Where (o => o.Enabled)
                    .Select(o => o.Text);
            }
        }
    }
}
