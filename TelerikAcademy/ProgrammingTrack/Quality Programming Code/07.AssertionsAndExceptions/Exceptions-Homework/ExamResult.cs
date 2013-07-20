using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentException("Grade cannot be negative", "grade");
        }

        if (minGrade < 0)
        {
            throw new ArgumentException("MinGrade cannot be negative", "minGrade");
        }

        if (maxGrade < 0)
        {
            throw new ArgumentException("MaxGrade cannot be negative", "maxGrade");
        }

        if (minGrade > maxGrade)
        {
            throw new ArgumentException("MinGrade must be less than or equal to maxGrade.");
        }

        if ((grade < minGrade) || (grade > maxGrade))
        {
            throw new ArgumentOutOfRangeException("grade", "Grade must be in the specified interval.");
        }

        if (string.IsNullOrWhiteSpace(comments))
        {
            throw new ArgumentException("Comments cannot be null, empty or containing only white spaces.", "comments");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
