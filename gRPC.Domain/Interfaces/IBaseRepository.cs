namespace gRPC.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task Create(T entity, CancellationToken cancellationToken);

        IQueryable<T> Select();

        Task Delete(T entity, CancellationToken cancellationToken);

        Task Update(T entity, CancellationToken cancellationToken);
    }
}
