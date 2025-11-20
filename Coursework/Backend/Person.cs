namespace Coursework.Backend;

public abstract class Person
{
    public string FullName { get; set; }
    public string Faculty { get; set; }
    
    public Person(string fullName, string faculty)
    {
        FullName = fullName;
        Faculty = faculty;
    }
}