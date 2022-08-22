namespace Core.Persistence.Repositories;

public class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Entity()
    {
    }

    public Entity(Guid id) : this()
    {
        Id = id;
    }
}