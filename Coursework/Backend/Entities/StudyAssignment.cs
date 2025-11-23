namespace Coursework.Backend;

public class StudyAssignment
{
    public Lecturer Lecturer { get; init; }
    public StudentGroup StudentGroup { get; init; }
    public Discipline Discipline { get; init; }
    public Activity Activity { get; init; }
    public int LecturersHours { get; private set; }

    public StudyAssignment(Lecturer lecturer, StudentGroup studentGroup,
        Discipline discipline, Activity activity, int lecturersHours, ILecturerAssignment assignmentService)
    {
        if (lecturer == null)
            throw new ArgumentNullException(nameof(lecturer));
        if (studentGroup == null)
            throw new ArgumentNullException(nameof(studentGroup));
        if (discipline == null)
            throw new ArgumentNullException(nameof(discipline));
        if (activity == null)
            throw new ArgumentNullException(nameof(activity));
        if (assignmentService == null)
            throw new ArgumentNullException(nameof(assignmentService));
        
        if (!discipline.Activities.Contains(activity))
            throw new InvalidOperationException(
                $"Дисциплина {discipline.Name} не содержит занятия типа {activity.Type}");
        
        if (!assignmentService.CanTeach(lecturer, activity))
            throw new InvalidOperationException(
                $"Преподаватель {lecturer.FullName} не может вести занятия типа {activity.Type}");
        
        Lecturer = lecturer;
        StudentGroup = studentGroup;
        Discipline = discipline;
        Activity = activity;
        UpdateLecturersHours(lecturersHours);
    }

    public void UpdateLecturersHours(int newLecturersHours)
    {
        if (newLecturersHours < 0)
            throw new ArgumentOutOfRangeException("Количество часов должно быть положительным");
            
        if (newLecturersHours > Activity.Hours)
            throw new ArgumentOutOfRangeException(
                $"Вы пытаетесь назначить {newLecturersHours} часов," +
                $"но в плане только {Activity.Hours} для {nameof(Activity)}");
            
        LecturersHours = newLecturersHours;
    }
}