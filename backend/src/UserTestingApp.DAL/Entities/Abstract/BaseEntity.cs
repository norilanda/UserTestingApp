namespace UserTestingApp.DAL.Entities.Abstract;

public abstract class BaseEntity<T>
{
    public T Id { get; set; } = default!;
}
