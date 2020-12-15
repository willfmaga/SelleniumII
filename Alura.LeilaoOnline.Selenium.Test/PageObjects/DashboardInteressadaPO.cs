using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Test.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            this.byLogoutLink = By.Id("logout");
            this.byMeuPerfilLink = By.Id("meu-perfil");
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
    }
}
