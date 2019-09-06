using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Test
{
    class ConsoleTestRunner
    {
        private TextWriter normalOutput;
        private StringWriter consoleTest;
        private StringBuilder output;
        private string ConsoleApp;
        private readonly string Arguments;
        private Process process;

        public ConsoleTestRunner(string consoleApp, string arguments = "")
        {
            ConsoleApp = consoleApp;
            Arguments = arguments;
            process = new Process();
        }


        public StringBuilder WriteOutput()
        {
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.Write(process.StandardError.ReadToEnd());

            return output;
        }

        public void StartConsole()
        {
            process.StartInfo.FileName = ConsoleApp;

            if (string.IsNullOrEmpty(Arguments))
                process.StartInfo.Arguments = Arguments;

            process.StartInfo.UseShellExecute = false;

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;

            process.Start();
            process.WaitForExit(100);
        }
                
        public void InitialSetUp()
        {
            string directory = GetDirectory();

            Environment.CurrentDirectory = directory;

            output = new StringBuilder();
            consoleTest = new StringWriter(output);

            SwitchConsoleOutPut();
        }

        public void resetTestOutput()
        {
            output.Remove(0, output.Length);
        }

        public void writeOutputToConsole()
        {
            normalOutput.Write(output);
        }

        public void resetConolseOutput()
        {
            Console.SetOut(normalOutput);
        }


        private static string GetDirectory()
        {
            string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            string directory = Path.GetDirectoryName(codeBase);
            if (directory.StartsWith("file:\\"))
                directory = directory.Substring(6);
            return directory;
        }

        private void SwitchConsoleOutPut()
        {
            normalOutput = Console.Out;
            Console.SetOut(consoleTest);
        }
    }
}
