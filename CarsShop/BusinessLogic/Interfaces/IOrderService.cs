namespace CarsShop.BusinessLogic.Interfaces;

public interface IOrderService
{
    public IEnumerable<Order> GetAll();
    public Order GetById(int id);
    public void Add(int carId, int colorId);
}