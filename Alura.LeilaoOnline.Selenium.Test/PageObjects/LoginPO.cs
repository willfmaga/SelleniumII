using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Test.PageObjects
{
    public class LoginPO
    {

        private IWebDriver driver;
        private By byInputLogin;
        private By byInputPassword;
        private By byBtnLogin;

        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputLogin = By.Id("Login");
            byInputPassword = By.Id("Password");
            byBtnLogin = By.Id("btnLogin");
        }

        public void Visitar() =>
            driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");

        public void PreencherFormulario(string login, string password)
        {
            driver.FindElement(byInputLogin).SendKeys(login);
            driver.FindElement(byInputPassword).SendKeys(password);
        }

        public void SubmeterFormulario() =>
            driver.FindElement(byBtnLogin).Click();
    }

}
