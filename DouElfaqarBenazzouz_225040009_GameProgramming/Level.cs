using System;
using System.Numerics;
using System.Reflection.Emit;
using System.Xml.Linq;


abstract class Level
{
    public string Name { get; protected set; }

    public abstract MathProblem GetProblem();

    public abstract void AdvanceLevel(Player player);
}