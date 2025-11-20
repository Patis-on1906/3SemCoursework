namespace Coursework.Backend;

public sealed class Lecturer : Person
{
    public enum AcademicTitle
    {
        None, 
        Candidate, 
        Doctor, 
        Docent, 
        Professor
    }

    public enum WorkingPosition
    {
        Assistant,
        SeniorLecturer, 
        Docent, 
        Professor
    }
    
    public string Department { get; set; }
    public AcademicTitle Title { get; set; }
    public WorkingPosition Position { get; set; }
    
    public Lecturer(string fullName, string faculty, 
        string department, AcademicTitle title, WorkingPosition position)
     : base(fullName, faculty)
    {
        if (position == WorkingPosition.Docent && title != AcademicTitle.Docent)
            throw new Exception("Должность доцента требует звания доцента.");
        
        if (position == WorkingPosition.Professor && title != AcademicTitle.Professor)
            throw new Exception("Должность профессора требует звание профессора.");
        
        Title = title;
        Position = position;
        Department = department;
    }

    public bool CheckPosition(Activity.ActivityType type)
    {
        return (Position, type) switch
        {
            (WorkingPosition.Assistant, Activity.ActivityType.Lection) => false,
            (WorkingPosition.Professor, Activity.ActivityType.Laboratory) => false,
            _ => true
        };
    }
}