namespace EmailSender.Services
{
    public interface IRepositoryBase <T>
    {
        //IQueryable<T> FindAll(bool trackChanges);
        Task Create(T entity);

        //void Update(T entity);
    }
}
