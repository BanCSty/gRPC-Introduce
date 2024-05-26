namespace gRPC.Domain.Interfaces
{
    internal interface IBaseRepository<T> where T : class
    {
        Task Create(T entity, CancellationToken cancellationToken);

        IQueryable<T> Select();

        Task Delete(T entity, CancellationToken cancellationToken);

        Task Update(T entity, CancellationToken cancellationToken);
    }
}
