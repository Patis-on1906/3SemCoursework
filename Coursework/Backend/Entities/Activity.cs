namespace Coursework.Backend;
using Enums;

public class Activity
{
    private int _hours;
   
    public ActivityType Type { get; set; }
    
    public int Hours
    {
        get => _hours;
        set
        {   
            if (value < 0)
                throw new ArgumentOutOfRangeException("Время, отведенное на дисциплину в семестре, не может быть отрицательным");
            _hours = value;
        }
    }

    public Activity(int hours, ActivityType type)
    {
        Hours = hours;
        Type = type;
    }
}