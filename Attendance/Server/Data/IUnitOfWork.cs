using Microsoft.EntityFrameworkCore;

namespace Attendance.Server.Data
{
    public interface IUnitOfWork : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void MarkAsDeleted<TEntity>(TEntity entity);
    }
}