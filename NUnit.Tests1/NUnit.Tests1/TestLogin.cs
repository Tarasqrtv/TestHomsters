using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;

namespace NUnit.Tests1
{
	[TestFixture]
	public class TestLogin
	{
		private IWebDriver Driver { get; set; }
									//ці значення можна отримувати 
		private const string _email = "yirokamis@nyrmusic.com",	//безпосередньо після введення користувачем,
			_password = "yirokamis@nyrmusic.com";           //необхідно для тесту на валідність!      

		[SetUp]
		public void SetupTest()
		{
			this.Driver = new ChromeDriver();			
		}

		[TearDown]
		public void TeardownTest()
		{
			this.Driver.Quit();
		}

		[Test]		//якщо я правильно зрозумів то це позитивний тест
		public void Entry()
		{
			LoginPage loginPage = new LoginPage(this.Driver);
			loginPage.Navigate();
			loginPage.Entry(_email, _password);
		}

		const string _patternFORemail = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
				@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

		[Test]		//якщо я правильно зрозумів то це negative тест
		public void ValidEmail()
		{		//успішно якщо нічого не чіпати, впаде якщо заберем наприклад собачку		
			Assert.IsTrue(Regex.IsMatch(_email, _patternFORemail, RegexOptions.IgnoreCase));
		}

		const string _patternFORPassword = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";

		[Test]
		public void ValidPassword()
		{   	//Впаде якщо нічого не чіпати, тут вже залежно яке правило в регулярний вираз засуниш
			//якщо те, що для мейлу, то все буде ок (можна варіювати від вимоги тут же і помилки відловлювати)
			Assert.IsTrue(Regex.IsMatch(_password, _patternFORPassword, RegexOptions.IgnoreCase));
		}
		/*	З приводу логування, я не зовсім зрозумів. Виходить можна просто
		    	в консоль все виводити і це теж буде логування, це якщо робити просто.
			Я думаю це нікуди не годиться і потрібно створювати файл з логами за рахунок
			сторонньої бібліотеки, але чітких інструкцій по такому підходу я не нажаль не знайшов, 
			а те що знайшов, здалось складним як для новачка в даній темі.		 
		 */
	}
}
