namespace Coursework.Backend;

public abstract class Entity
{
    public Guid Id { get; } = Guid.NewGuid();

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other)
            return false;
        
        return Id == other.Id;
    }

    public override int GetHashCode() => Id.GetHashCode();
}