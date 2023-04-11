public interface IRepository<T>
{
    void Add(T data);
    void Delete(T data);
}