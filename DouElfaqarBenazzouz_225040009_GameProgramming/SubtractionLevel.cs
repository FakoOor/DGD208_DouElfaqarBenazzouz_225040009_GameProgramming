using System;
using System.Numerics;
using System.Reflection.Emit;
using System.Xml.Linq;

class SubtractionLevel : Level
{
    public SubtractionLevel()
    {
        Name = "Subtraction Level";
    }

    public override MathProblem GetProblem()
    {
        Random rand = new Random();
        int a = rand.Next(50, 100);
        int b = rand.Next(1, 50);
        return new MathProblem($"{a} - {b}", a - b);
    }

    public override void AdvanceLevel(Player player)
    {
        player.CurrentLevel = new MultiplicationLevel();
        Console.WriteLine("Congratulations! You've advanced to the Multiplication Level.");
    }
}