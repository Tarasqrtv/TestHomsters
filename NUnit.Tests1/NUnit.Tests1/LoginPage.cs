using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace NUnit.Tests1
{	
	public class LoginPage
	{
		private readonly IWebDriver driver;
		private readonly string url = "https://homsters.kz";

		public LoginPage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.ClassName, Using = "b-complex-header__button--login")]
		public IWebElement Loginbtn { get; set; }

		[FindsBy(How = How.ClassName, Using = "js-user-name")]
		public IWebElement Logintbx { get; set; }

		[FindsBy(How = How.ClassName, Using = "js-user-password")]
		public IWebElement Passwordtbx { get; set; }

		[FindsBy(How = How.ClassName, Using = "b-button")]
		public IWebElement Submitbtn { get; set; }

		public void Navigate()
		{
			this.driver.Navigate().GoToUrl(this.url);
		}

		public void Entry(string email, string password)
		{
			this.Loginbtn.Click();
			this.Logintbx.Clear();					//раптом там що є
			this.Passwordtbx.Clear();	
			this.Logintbx.SendKeys(email);			//передаєм текст у відповідні поля
			this.Passwordtbx.SendKeys(password);
			this.Submitbtn.Click();
		}
	}
}
