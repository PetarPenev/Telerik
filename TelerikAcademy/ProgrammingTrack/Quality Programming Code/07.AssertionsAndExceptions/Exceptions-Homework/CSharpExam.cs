// Did some additional refactoring and change a bit of the implementation of the code in order to
// comply with the best quality code practices for the whole task.
using System;

public class CSharpExam : Exam
{
    public const int MaxScore = 100;

    public CSharpExam(int score)
    {
        if (score < 0)
        {
            throw new ArgumentOutOfRangeException("score", "The score cannot be less than 0.");
        }

        if (MaxScore <= 0)
        {
            throw new ArgumentException("Incorrectly specified constant for max score.", "MaxScore");
        }

        this.Score = score;
    }

    public int Score { get; private set; }

    public override ExamResult Check()
    {
        if (this.Score < 0 || this.Score > MaxScore)
        {
            throw new ArgumentOutOfRangeException("Score", string.Format("The score must be between 0 and {0}.", MaxScore));
        }
        else
        {
            return new ExamResult(this.Score, 0, MaxScore, "Exam results calculated by score.");
        }
    }
}
