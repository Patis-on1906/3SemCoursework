namespace Coursework.Backend;

public class Faculty
{
    public string Name { get; private set; }
    
    private readonly List<Department> _departments = new();
    public IReadOnlyList<Department> Departments => _departments;

    public Faculty(string name)
    {
        Name = name;
    }

    public void AddDepartment(Department department)
    {
        if (_departments.Contains(department))
            throw new InvalidOperationException($"Кафедра {department.Name} " +
                                                $"уже прикреплена к факультету {Name}");
        _departments.Add(department);
    }

    public void RemoveDepartment(Department department)
    {
        _departments.Remove(department);
    }
}