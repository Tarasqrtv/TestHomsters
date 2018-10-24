using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace NUnit.Tests1
{
	[TestFixture]
	public class TestLogin
	{
		private string _TextLog;

		private IWebDriver Driver { get; set; }
																
		private const string _email = "yirokamis@nyrmusic.com",	
			_password = "yirokamis@nyrmusic.com";                 

		[SetUp]
		public void SetupTest()
		{
			_TextLog += "Start setup test. Open browser" + Environment.NewLine;
			this.Driver = new ChromeDriver();			
		}

		[TearDown]
		public void TeardownTest()
		{
			_TextLog += "Start TeardownTest. Close browser" + Environment.NewLine;
			Thread.Sleep(20000);
			this.Driver.Quit();		
		}

		[OneTimeTearDown]
		public void AfterTesting()
		{		
			Logger.CreateFileLog(_TextLog);
		}

		[TestCase(_email, _password)]
		public void Entry(string _email, string _password)
		{
			_TextLog += "Start Entry. Validation for data entry" + Environment.NewLine;
			LoginPage loginPage = new LoginPage(this.Driver);
			loginPage.Navigate();
			loginPage.Entry(_email, _password);			
		}

		[TestCase("yirokamis@nyrmusic.com", "yirokamis@nyrmusic.com")]//or something
		public void VerifyValidLogin(string _email, string _password)
		{
			_TextLog += "Start VerifyValidLogin. Validation for data entry. You entry" + Environment.NewLine;
			Entry(_email, _password);
			Thread.Sleep(20000);
			var _succesText = Driver.FindElement(By.ClassName("fsz16")).Text;
			Assert.AreEqual(_succesText, $"{_email}, с возвращением. Последний раз вы искали:");
		}

		[TestCase("0000000000", "yirokamis@nyrmusic.com")]
		[TestCase("yirokamis@nyrmusic.com", "yirokamis@nyrmusic")]//or something
		public void VerifyInValidLogin(string _email, string _password)
		{
			_TextLog += "Start VerifyInValidLogin. Validation for data entry. You not entry" + Environment.NewLine;
			Entry(_email, _password);
			Thread.Sleep(20000);
			var _errorText = Driver.FindElement(By.ClassName("b-form__error")).Text;			
			Assert.AreEqual(_errorText, "Неверное имя пользователя или пароль");
		}
	}
}
