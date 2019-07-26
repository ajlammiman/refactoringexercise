using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace Test
{
    [TestFixture]
    class CategorisationTests
    {
        private TextWriter normalOutput;
        private StringWriter consoleTest;
        private StringBuilder output;

        [OneTimeSetUp]
        public void intial_setup()
        {
            string directory = GetDirectory();

            Environment.CurrentDirectory = directory;

            output = new StringBuilder();
            consoleTest = new StringWriter(output);

            SwitchConsoleOutPut();
        }

        [SetUp]
        public void set_up()
        {
            output.Remove(0, output.Length);
        }

        [Test]
        public void console_game_start()
        {
            //Assert.IsTrue(output.ToString().Contains("Welcome to the Mine Game, try to cross the board without hitting a Mine. W = Up, X = down, A = left and S = right."));
        }

        [TearDown]
        public void tear_down()
        {
            normalOutput.Write(output);
        }

        [OneTimeTearDown]
        public void final_tear_down()
        {
            Console.SetOut(normalOutput);
        }

        private void SwitchConsoleOutPut()
        {
            normalOutput = Console.Out;
            Console.SetOut(consoleTest);
        }

        private static string GetDirectory()
        {
            string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            string directory = Path.GetDirectoryName(codeBase);
            if (directory.StartsWith("file:\\"))
                directory = directory.Substring(6);
            return directory;
        }
    }
}
