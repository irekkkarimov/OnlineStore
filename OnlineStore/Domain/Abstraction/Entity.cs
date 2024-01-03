namespace Domain.Abstraction;

public abstract class Entity
{
    public int Id { get; protected set; }

    public override bool Equals(object? obj)
    {
        return obj is Entity entity && Id == entity.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}