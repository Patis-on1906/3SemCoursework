namespace Coursework.Backend;

public sealed class Student : Person
{
    private int _course;
    private int _yearOfAdmission;
    
    public string Group { get; set; }
    public string Direction { get; set; }
    
    public int Course
    {
        get => _course;
        set
        {
            if (value < 1 || value > 5)
                throw new ArgumentOutOfRangeException(nameof(value), "Курс не может быть от 1 до 5");
            _course = value;
        }
    }

    public int YearOfAdmission
    {
        get => _yearOfAdmission;
        set
        {
            var nowYear = DateTime.Now.Year;
            if (value < 1900 || value > nowYear)
                throw new ArgumentOutOfRangeException(nameof(value), $"Год поступления должен быть между 1900 и {nowYear}");
            _yearOfAdmission = value;
        }
    }

    public Student(string fullName, string group, string faculty, 
        string direction, int course, int yearOfAdmission)
    : base(fullName, faculty)
    {
        Group = group;
        Direction = direction;
        Course = course;
        YearOfAdmission = yearOfAdmission;
    }
}