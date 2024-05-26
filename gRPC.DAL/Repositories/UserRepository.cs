using gRPC.Domain;
using gRPC.Domain.Interfaces;

namespace gRPC.DAL.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(User entity, CancellationToken cancellationToken)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(User entity, CancellationToken cancellationToken)
        {
            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<User> Select()
        {
            return _dbContext.Users.AsQueryable();
        }

        public async Task Update(User entity, CancellationToken cancellationToken)
        {
            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
