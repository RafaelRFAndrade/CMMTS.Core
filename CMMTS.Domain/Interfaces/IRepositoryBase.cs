namespace CMMTS.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetByCode(Guid code);
    }
}
