namespace Coursework.Backend;

public class Department
{
    public string Name { get; private set; }
    
    private readonly List<StudentGroup> _studentGroups = new();
    public IReadOnlyList<StudentGroup> StudentGroups => _studentGroups;

    private readonly List<Lecturer> _lecturers = new();
    public IReadOnlyList<Lecturer> Lecturers => _lecturers;

    public Department(string name)
    {
        Name = name;
    }

    public void AddGroup(StudentGroup studentGroup)
    {
        _studentGroups.AddUnique(studentGroup,
            $"Группа {studentGroup.Name}", $"кафедре {Name}");
    }

    public void RemoveGroup(StudentGroup studentGroup)
    {
        _studentGroups.Remove(studentGroup);
    }

    public void AddLecturer(Lecturer lecturer)
    {
       _lecturers.AddUnique(lecturer, 
           $"Преподаватель {lecturer.FullName}", $"кафедре {Name}");
    }

    public void RemoveLecturer(Lecturer lecturer)
    {
        _lecturers.Remove(lecturer);
    }
}