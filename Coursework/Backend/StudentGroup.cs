namespace Coursework.Backend;

public class StudentGroup
{
    private string _name;
    private readonly List<Student> _students = new(40);

    public IReadOnlyList<Student> Students => _students;
    
    public string Name
    {
        get => _name;
        set
        {
            if (value.Length > 10)
                throw new ArgumentException("Название группы слишком длинное");
            _name = value;
        }
    }

    public StudentGroup(string name)
    {
        _name = name;
    }

    public void AddStudent(Student student)
    {
        if (_students.Contains(student))
            throw new InvalidOperationException($"Студент {student.FullName} " +
                                                $"уже есть в группе {Name}");
        _students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        _students.Remove(student);
    }
}