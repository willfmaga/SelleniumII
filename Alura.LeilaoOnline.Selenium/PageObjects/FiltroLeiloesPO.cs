using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class FiltroLeiloesPO
    {
        private IWebDriver driver;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;

        public FiltroLeiloesPO(IWebDriver driver)
        {
            this.driver = driver;
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            //byInputAndamento = By.ClassName("switch");
            byInputAndamento = By.XPath("//div[contains(@class,'switch')]");
            byBotaoPesquisar = By.CssSelector("form>button.btn");

        }

        public void PesquisarLeiloes(
           List<string> categorias,
           string termo,
           bool emAndamento)
        {
            var select = new SelectMaterialize(driver, bySelectCategorias);
           
            
            select.DeselectAll();

            //seleciona as categorias
            //categorias.ForEach(categ =>
            //{
            //    select.SelectByText(categ);
            //});
            select.SelectByText(categorias);


            //usa um termo para o filtro
            driver.FindElement(byInputTermo).SendKeys(termo);

            //altera para somente em andamento
            if (emAndamento)
            {
                driver.FindElement(byInputAndamento).Click();
            }

            driver.FindElement(byBotaoPesquisar).Click();
        }

    }
}
