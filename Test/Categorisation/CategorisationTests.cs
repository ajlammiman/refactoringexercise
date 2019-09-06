using NUnit.Framework;
using WindowsInput;
using WindowsInput.Native;

namespace Test
{
    [TestFixture]
    class CategorisationTests
    {
        private ConsoleTestRunner consoleTestRunner;

        [OneTimeSetUp]
        public void intial_setup()
        {
            consoleTestRunner = new ConsoleTestRunner(@"C:\Projects\refactoringexercise\RefactorKata\bin\MineGameConsole.exe");
            consoleTestRunner.InitialSetUp();
        }

        [SetUp]
        public void set_up()
        {
            consoleTestRunner.resetTestOutput();
        }

        [Test]
        public void console_game_start()
        {
            consoleTestRunner.StartConsole();

            //var inputSimulator = new InputSimulator();
            //inputSimulator.Keyboard.KeyPress(VirtualKeyCode.ESCAPE);

            var output = consoleTestRunner.WriteOutput();

            Assert.IsTrue(output.ToString().Contains("Welcome to the Mine Game, try to cross the board without hitting a Mine. W = Up, X = down, A = left and S = right."));
        }

        [TearDown]
        public void tear_down()
        {
            consoleTestRunner.writeOutputToConsole();
        }

        [OneTimeTearDown]
        public void final_tear_down()
        {
            consoleTestRunner.resetConolseOutput();
        }
    }
}
