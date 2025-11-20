namespace Coursework.Backend;

public class Activity
{
    public enum ActivityType
    {
        Lection,
        Laboratory,
        Practice
    }
    
    private int _hours;
    public string Name { get; set; }
    public ActivityType Type { get; set; }
    
    private readonly List<Lecturer> _assignedLecturers = new();
    public IReadOnlyList<Lecturer> AssignedLecturers => _assignedLecturers;
    
    public int Hours
    {
        get => _hours;
        set
        {   
            if (value < 0)
                throw new ArgumentOutOfRangeException("Время, отведенное на дисциплину в семестре, не может быть отрицательным");
            _hours = value;
        }
    }

    public Activity(int hours, string name, ActivityType type)
    {
        Hours = hours;
        Name = name;
        Type = type;
    }
    
    public void AssignLecturer(Lecturer lecturer)
    {
        if (!lecturer.CheckPosition(Type))
            throw new InvalidOperationException($"Преподаватель {lecturer.FullName} не может вести {Type}");
        
        _assignedLecturers.Add(lecturer);
    }

    public void RemoveLecturer(Lecturer lecturer)
    {
        _assignedLecturers.Remove(lecturer);
    }
}