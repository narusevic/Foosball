namespace Foosball.Repositories
{
    public interface IRepository<T>
    {
        T Get(int id);

        void Post(T entity);

        void Update(int id, T entity);

        void Remove(int id);
    }
}