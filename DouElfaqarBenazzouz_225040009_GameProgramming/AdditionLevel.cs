using System;
using System.Numerics;
using System.Reflection.Emit;
using System.Xml.Linq;

class AdditionLevel : Level
{
    public AdditionLevel()
    {
        Name = "Addition Level";
    }

    public override MathProblem GetProblem()
    {
        Random rand = new Random();
        int a = rand.Next(1, 100);
        int b = rand.Next(1, 100);
        return new MathProblem($"{a} + {b}", a + b);
    }

    public override void AdvanceLevel(Player player)
    {
        player.CurrentLevel = new SubtractionLevel();
        Console.WriteLine("Congratulations! You've advanced to the Subtraction Level.");
    }
}