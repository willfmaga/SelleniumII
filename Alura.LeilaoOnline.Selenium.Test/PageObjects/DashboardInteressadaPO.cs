using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.Test.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBtnPesquisar;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            this.byLogoutLink = By.Id("logout");
            this.byMeuPerfilLink = By.Id("meu-perfil");
            this.bySelectCategorias = By.ClassName("select-wrapper");
        }

        public void EfetuarLogout()
        {
            var linkMenuPerfil = driver.FindElement(byMeuPerfilLink);
            var linkLogout = driver.FindElement(byLogoutLink);

            var actions = new Actions(driver)
                .MoveToElement(linkMenuPerfil)
                .MoveToElement(linkLogout)
                .Click()
                .Build();

            actions.Perform();

        }

        public void PesquisarLeiloes(
            List<string> Categorias
            )
        {
            Thread.Sleep(2000);
            var selectWrapper = driver.FindElement(bySelectCategorias);
            selectWrapper.Click();

            var opcoes = selectWrapper.FindElements(By.CssSelector("li>span"))
                .ToList();

            opcoes.ForEach(o =>
            {
                o.Click();
            });
            Thread.Sleep(2000);

            Categorias.ForEach(c =>
               {
                   opcoes.Where(o => o.Text.Contains(c))
                         .ToList()
                         .ForEach(o =>
                            {
                                o.Click();
                            });
               });

            Thread.Sleep(2000);

            selectWrapper.FindElement(By.TagName("li")).SendKeys(Keys.Tab);
            Thread.Sleep(2000);

        }
    }
}
