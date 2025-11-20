namespace Coursework.Backend;

public class Department
{
    public string Name { get; set; }
    
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
        if (_studentGroups.Contains(studentGroup))
            throw new InvalidOperationException($"Группа {studentGroup.Name} " +
                                                $"уже прикреплена к кафедре.");
        _studentGroups.Add(studentGroup);
    }

    public void RemoveGroup(StudentGroup studentGroup)
    {
        _studentGroups.Remove(studentGroup);
    }

    public void AddLecturer(Lecturer lecturer)
    {
        if (_lecturers.Contains(lecturer))
            throw new InvalidOperationException($"Преподаватель {lecturer.FullName} " +
                                                $"уже работает на этой кафедре");
        _lecturers.Add(lecturer);
    }

    public void RemoveLecturer(Lecturer lecturer)
    {
        _lecturers.Remove(lecturer);
    }
}