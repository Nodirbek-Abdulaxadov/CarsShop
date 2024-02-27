namespace CarsShop.Data.Interfaces;

public interface IRepository<TEntity>
{
    List<TEntity> GetAll();
    TEntity GetById(int id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(int id);
}