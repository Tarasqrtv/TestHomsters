namespace NUnit.Tests1
{
	interface ILoginPage
	{
		void Clear();

		void Navigate();

		void JobWithLogin(string massage);

		void JobWithPassword(string massage);

		void Entry(string email, string password);
	}
}
