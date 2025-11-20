namespace Coursework.Backend;

public class Discipline
{
    public enum ControlForm
    {
        Credit, DifferentialCredit, Exam
    }
    
    private string _name;
    private int _semester;
    private readonly List<Activity> _activities = new(3);
    
    public IReadOnlyList<Activity> Activities => _activities;
    public ControlForm FormControl { get; set; }
    
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Название дисциплины не может быть пустым");
            _name = value;
        }
    }
    
    public int Semester
    {
        get => _semester;
        set
        {
            if (value < 1 || value > 10)
                throw new ArgumentException("Семестр не может быть < 1 и > 10");
            _semester = value;
        }
    }

    public Discipline(string name, int semester, ControlForm controlForm)
    {
        Name = name;
        Semester = semester;
        FormControl = controlForm;
    }

    public void AddActivity(Activity activity)
    {
        if (_activities.Any(x => x.Type == activity.Type))
            throw new InvalidOperationException($"Активность типа {activity.Type}" +
                                                $" уже существует в дисциплине {Name}");
        _activities.Add(activity);
    }

    public void RemoveActivity(Activity activity)
    {
        _activities.Remove(activity);
    }
    
    public int FullHours =>  _activities.Sum(x => x.Hours);
}