namespace Coursework.Backend;

public class StudentGroup : Entity
{
    private const int AverageGroupSize = 40;
    
    private string _name;
    private readonly List<Student> _students = new(AverageGroupSize);

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
        Name = name;
    }

    public void AddStudent(Student student)
    {
        _students.AddUnique(student, 
            $"Студент {student.FullName}", $"группе {Name}");
    }

    public void RemoveStudent(Student student)
    {
        _students.Remove(student);
    }
}