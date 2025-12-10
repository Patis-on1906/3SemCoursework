using System.Diagnostics;

namespace Coursework.Backend;

public class ExamResult : Entity
{
    public Student Student { get; }
    public Discipline Discipline { get; }
    public DateTime Date { get; }
    public Grade Grade { get; }

    public ExamResult(Student student, Discipline discipline, DateTime date, Grade grade)
    {
        Student = student ?? throw new ArgumentNullException(nameof(student));
        Discipline = discipline ?? throw new ArgumentNullException(nameof(discipline));
        Date = date;
        Grade = grade ?? throw new ArgumentNullException(nameof(grade));
    }
}