namespace Delivery.Domain.Entites.Base;

public abstract record EntityBase<T> where T : EntityBase<T>
{
    public int Id { get; init; }

    protected EntityBase(int id)
    {
        Id = id;
    }
    protected EntityBase()
    { }
}
