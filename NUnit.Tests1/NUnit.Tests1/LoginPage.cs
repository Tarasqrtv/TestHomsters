using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NUnit.Tests1
{	
	public class LoginPage : ILoginPage
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
		
		[FindsBy(How = How.ClassName, Using = "b-button")]
		public IWebElement Submitbtn { get; set; }

		[FindsBy(How = How.ClassName, Using = "js-user-name")]
		public IWebElement Logintbx { get; set; }

		[FindsBy(How = How.ClassName, Using = "js-user-password")]
		public IWebElement Passwordtbx { get; set; }

		public void Navigate()
		{
			this.driver.Navigate().GoToUrl(this.url);			
		}

		public void Entry(string email, string password)
		{
			this.Loginbtn.Click();

			Clear();
			JobWithLogin(email);
			JobWithPassword(password);

			this.Submitbtn.Click();
		}

		public void JobWithLogin(string massage)
		{
			this.Logintbx.SendKeys(massage);
			//and we can add something else
		}

		public void JobWithPassword(string massage)
		{			
			this.Passwordtbx.SendKeys(massage);
			//and we can add something else
		}

		public void Clear()
		{
			this.Logintbx.Clear();                 
			this.Passwordtbx.Clear();
		}		
	}
}
