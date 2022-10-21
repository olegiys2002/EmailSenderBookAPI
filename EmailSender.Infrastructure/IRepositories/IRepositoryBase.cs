namespace EmailSender.Services
{
    public interface IRepositoryBase <T>
    {
        Task Create(T entity);
        Task<T> FindByIdAsync(string id);
        Task Delete(string id);
        Task<List<T>> FindAllAsync();
    }
}
