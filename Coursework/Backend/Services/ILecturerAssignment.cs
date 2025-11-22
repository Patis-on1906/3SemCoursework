namespace Coursework.Backend;

public interface ILecturerAssignment
{
    bool CanTeach(Lecturer lecturer, Activity activity);
}