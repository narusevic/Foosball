namespace Foosball.Repositories
{
    public interface IRepository<T>
    {
        void Create(T entity);

        T Read(int id);

        void Update(int id, T entity);

        void Delete(int id);
    }
}