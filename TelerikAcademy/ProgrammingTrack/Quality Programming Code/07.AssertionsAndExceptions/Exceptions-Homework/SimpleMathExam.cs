using System;
using System.Diagnostics;

public class SimpleMathExam : Exam
{
    // Put the maximum number of problems in a constant for easier maintainability.
    public const int NumberOfProblems = 2;

    public SimpleMathExam(int problemsSolved)
    {
        if ((problemsSolved < 0) || (problemsSolved > NumberOfProblems))
        {
            throw new ArgumentOutOfRangeException("problemsSolved", 
                "The number of problems should be between 0 and the specified maximum.");
        }

        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved { get; private set; }

    public override ExamResult Check()
    {
        // Changing the exception with assertion as there is no way in the current implementation
        // to get a different value than the specified range.
        Debug.Assert(0 <= this.ProblemsSolved && this.ProblemsSolved <= NumberOfProblems, 
            "Incorrectly specified number of solved problems.");

        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: one task done.");
        }
        else
        {
            return new ExamResult(6, 2, 6, "Good result: two tasks done.");
        }
    }
}
