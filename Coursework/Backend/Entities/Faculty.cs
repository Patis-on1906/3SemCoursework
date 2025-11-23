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
        _departments.AddUnique(department,
            $"Кафедра {department.Name}", $"факультете {Name}");
    }

    public void RemoveDepartment(Department department)
    {
        _departments.Remove(department);
    }
}