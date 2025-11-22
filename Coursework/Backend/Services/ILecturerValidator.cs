namespace Coursework.Backend;
using Enums;

public interface ILecturerValidator
{
    void Validate(WorkingPosition position, AcademicTitle title);
}