namespace Coursework.Backend;
using Enums;

public sealed class Lecturer : Person
{
    public string Department { get; set; }
    public AcademicTitle Title { get; set; }
    public WorkingPosition Position { get; set; }
    
    public Lecturer(string fullName, string faculty, 
        string department, AcademicTitle title, WorkingPosition position, ILecturerValidator validator)
     : base(fullName, faculty)
    {
        validator.Validate(position, title);
        Title = title;
        Position = position;
        Department = department;
    }
}