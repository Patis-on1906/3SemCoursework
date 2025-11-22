namespace Coursework.Backend;
using Enums;

public class LecturerPositionValidator : ILecturerValidator
{
    private readonly Dictionary<WorkingPosition, AcademicTitle> _rules = new()
    {
        { WorkingPosition.Docent, AcademicTitle.Docent },
        { WorkingPosition.Professor, AcademicTitle.Professor }
    };

    public void Validate(WorkingPosition position, AcademicTitle title)
    {
        if (_rules.TryGetValue(position, out var requiredTitle) && title != requiredTitle)
            throw new InvalidOperationException($"Должность {position} требует звания {requiredTitle}");
    }
}