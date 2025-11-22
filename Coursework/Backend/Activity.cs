namespace Coursework.Backend;
using Enums;

public class Activity
{
    private int _hours;
    private readonly ILecturerAssignment _assignmentService;
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

    public Activity(int hours, string name, ActivityType type, ILecturerAssignment assignmentService)
    {
        Hours = hours;
        Name = name;
        Type = type;
        _assignmentService = assignmentService;
    }
    
    public void AssignLecturer(Lecturer lecturer)
    {
        if (!_assignmentService.CanTeach(lecturer, this))
            throw new InvalidOperationException($"Преподаватель {lecturer} не может вести дисциплину {Name}");
        _assignedLecturers.Add(lecturer);
    }

    public void RemoveLecturer(Lecturer lecturer)
    {
        _assignedLecturers.Remove(lecturer);
    }
}