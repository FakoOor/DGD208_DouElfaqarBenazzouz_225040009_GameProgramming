using System;

class MathProblem
{
    public string Question { get; private set; }
    public int Answer { get; private set; }

    public MathProblem(string question, int answer)
    {
        Question = question;
        Answer = answer;
    }

    public bool CheckAnswer(int answer)
    {
        return answer == Answer;
    }
}
