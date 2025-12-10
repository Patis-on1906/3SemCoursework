namespace Coursework.Backend;

public abstract class Person : Entity
{
    private string _fullName;
    public string Faculty { get; set; }

    public string FullName
    {
        get => _fullName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("ФИО не может быть пустым");
            _fullName = value;
        }
    }
    
    public Person(string fullName, string faculty)
    {
        FullName = fullName;
        Faculty = faculty;
    }
}