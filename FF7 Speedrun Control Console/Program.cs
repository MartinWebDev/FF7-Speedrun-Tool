using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InquirerCS;
using FF7_Speedrun_Control_Logic;
using FF7_Speedrun_Control_Logic.Repositories;
using System.Diagnostics;

namespace FF7_Speedrun_Control_Console
{
    class Program
    {
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
                            RunGame();
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
            Process fpsFix = new Process();
            
            processRepository.ProcessEnded += ProcessRepository_ProcessEnded;
            processRepository.WatchForClose();
        }

        private static void ProcessRepository_ProcessEnded(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
