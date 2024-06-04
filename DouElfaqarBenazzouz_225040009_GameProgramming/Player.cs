using DouElfaqarBenazzouz_225040009_GameProgramming;
using System;


class Player
{
    public string Name { get; private set; }
    public Level CurrentLevel { get; set; }

    public Player(string name)
    {
        Name = name;
    }

    public async Task SolveProblemAsync()
    {
        if (CurrentLevel == null)
        {
            Console.WriteLine("No current level to solve problems in.");
            return;
        }

        Console.WriteLine("Solve the following problem:");
        MathProblem problem = CurrentLevel.GetProblem();
        Console.WriteLine(problem.Question);

        string input = await Program.GetUserInputAsync();

        if (int.TryParse(input, out int answer))
        {
            if (problem.CheckAnswer(answer))
            {
                Console.WriteLine("Correct!");
                await PlayerHistory.LogInputAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "text.txt"), $"Solved: {problem.Question} = {answer} (Correct)");
                CurrentLevel.AdvanceLevel(this);
            }
            else
            {
                Console.WriteLine("Incorrect. Try again.");
                await PlayerHistory.LogInputAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "text.txt"), $"Solved: {problem.Question} = {answer} (Incorrect)");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    public void ShowCurrentLevel()
    {
        if (CurrentLevel == null)
        {
            Console.WriteLine("No current level.");
        }
        else
        {
            Console.WriteLine($"Current Level: {CurrentLevel.Name}");
        }
    }
}