using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("The first name of the student cannot be uninitialized or empty.", "firstName");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("The last name of the student cannot be uninitialized or empty.", "lastName");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public IList<Exam> Exams { get; set; }

    public IList<ExamResult> CheckExams()
    {
        if ((this.Exams == null) || (this.Exams.Count == 0))
        {
            throw new ArgumentException("The student has no exams to check.");
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalculateAverageExamResultInPercents()
    {
        if ((this.Exams == null) || (this.Exams.Count == 0))
        {
            throw new ArgumentException("There are no exams so average score cannot be calculated.");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();

        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
