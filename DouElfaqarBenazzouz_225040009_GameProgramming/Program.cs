using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;



namespace DouElfaqarBenazzouz_225040009_GameProgramming
{

    class Program
    {
        static async Task Main(string[] args)
        {
            Player player = new Player("MathWhiz");
            player.CurrentLevel = new AdditionLevel();

            Console.WriteLine("Welcome to the Mathematical Adventure Game!");

            // Start the game loop
            await GameLoop(player);
        }

        static async Task GameLoop(Player player)
        {
            bool isRunning = true;
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Player History.txt");

            // Ensure the log file is created and cleared at the start
            using (StreamWriter writer = new StreamWriter(logFilePath, false))
            {
                await writer.WriteLineAsync("Game Started");
            }

            while (isRunning)
            {
                Console.WriteLine("\nChoose an action: [solve, level, quit]");
                string input = await GetUserInputAsync();

                // Log user input
                await PlayerHistory.LogInputAsync(logFilePath, input);

                switch (input.ToLower())
                {
                    case "solve":
                        await player.SolveProblemAsync();
                        break;
                    case "level":
                        player.ShowCurrentLevel();
                        break;
                    case "quit":
                        isRunning = false;
                        Console.WriteLine("Thanks for playing!");
                        await PlayerHistory.LogInputAsync(logFilePath, "Game Ended");
                        break;
                    default:
                        Console.WriteLine("Invalid action. Try again.");
                        break;
                }
            }
        }

        public static async Task<string> GetUserInputAsync()
        {
            return await Task.Run(() => Console.ReadLine());
        }
    }
}

