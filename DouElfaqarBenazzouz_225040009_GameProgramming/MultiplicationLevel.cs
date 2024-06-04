using System;
using System.Numerics;
using System.Reflection.Emit;
using System.Xml.Linq;

class MultiplicationLevel : Level
{
    public MultiplicationLevel()
    {
        Name = "Multiplication Level";
    }

    public override MathProblem GetProblem()
    {
        Random rand = new Random();
        int a = rand.Next(1, 20);
        int b = rand.Next(1, 20);
        return new MathProblem($"{a} * {b}", a * b);
    }

    public override void AdvanceLevel(Player player)
    {
        player.CurrentLevel = null;
        Console.WriteLine("Congratulations! You've completed all levels!");
    }
}