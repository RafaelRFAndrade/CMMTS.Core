using Microsoft.EntityFrameworkCore;

namespace CMMTS.Domain.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }

}
