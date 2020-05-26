using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using InquirerCS;
using FF7_Speedrun_Control_Logic;
using FF7_Speedrun_Control_Logic.Repositories;
using FF7_Speedrun_Control_Logic.Utils;
using System.Threading;

namespace FF7_Speedrun_Control_Console
{
    class Program
    {
        static bool listening = false;

        static void Main(string[] args)
        {
            bool done = false;
            ConfigRepository config = new ConfigRepository();
            HexConverter hex = new HexConverter();
            FPSFixRepository fPSFixRepository = new FPSFixRepository(config, hex);
            ProcessRepository processRepository = new ProcessRepository(config.Get("FF7ProcessName"));

            List<CommandOption> colors = Enum.GetValues(typeof(CommandOption)).Cast<CommandOption>().ToList();
            
            for (;;)
            {
                Inquirer.Prompt(Question.List("Choose favourite color", colors)).Then((command) => {
                    switch (command)
                    {
                        case CommandOption.Exit:
                            done = true;
                            return;
                        case CommandOption.GetFPSFixValueFromFile:
                            Console.Clear();
                            Console.WriteLine("Get FPSFix value");
                            Console.WriteLine(fPSFixRepository.GetFPSFIXValue().ToString());
                            Console.ReadLine();
                            break;
                        case CommandOption.SaveFPSFixValueToFile:
                            Console.Clear();
                            Console.WriteLine("Enter a new value: (integer only!)");
                            int newValue = int.Parse(Console.ReadLine());
                            Console.WriteLine($"New value is: {newValue.ToString()}");
                            fPSFixRepository.SaveFPSFixValue(newValue);
                            Console.ReadLine();
                            break;
                        case CommandOption.AttachToGame:
                            Task.Run(() => RunGame());
                            break;
                        case CommandOption.DetatchFromGame:
                            break;
                    }
                });
                Inquirer.Go();

                if (done) return;
            }
        }
        
        private static void RunGame()
        {
            ConfigRepository config = new ConfigRepository();
            ProcessRepository processRepository = new ProcessRepository(config.Get("FF7ProcessName"));

            // Start the FPSFix tool
            using (Process proc = new Process())
            {
                proc.StartInfo.FileName = config.Get("FPSFixExecutable");
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "runas";
                proc.Start();
                proc.WaitForExit();
            }

            // Look for, and attach to, ff7 process. When found, event handler for exit will relaunch this whole process.
            if (listening)
            {
                processRepository.ProcessEnded -= ProcessRepository_ProcessEnded;
                listening = false;
            }

            processRepository.ProcessEnded += ProcessRepository_ProcessEnded;
            processRepository.WatchForClose();
            listening = true;
        }

        private static void ProcessRepository_ProcessEnded(object sender, EventArgs args)
        {
            Thread.Sleep(200);
            RunGame();
        }
    }
}
