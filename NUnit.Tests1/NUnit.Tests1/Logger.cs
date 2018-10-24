using System.IO;

namespace NUnit.Tests1
{
	static class Logger
	{
		public static void CreateFileLog(string log)
		{
			File.AppendAllText("E:\\TestFile.txt", log);			
		}
	}
}
