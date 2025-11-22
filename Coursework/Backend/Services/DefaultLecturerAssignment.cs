namespace Coursework.Backend;
using Enums;

public class DefaultLecturerAssignment : ILecturerAssignment
{
    public bool CanTeach(Lecturer lecturer, Activity activity)
    {
        return (lecturer.Position, activity.Type) switch
        {
            (WorkingPosition.Assistant, ActivityType.Lection) => false,
            (WorkingPosition.Professor, ActivityType.Laboratory) => false,
            _ => true
        };
    }
}