
namespace CarsShop.BusinessLogic.Services;

public class OrderService(IUnitOfWork unitOfWork,
                          IAuthService authService)
    : IOrderService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IAuthService authService = authService;

    public void Add(int carId, int colorId)
    {
        var phoneNumber = authService.GetPhoneNumber(Role.User);
        var color = _unitOfWork.Colors.GetById(colorId);
        var user = _unitOfWork.Users
                              .GetAll()
                              .FirstOrDefault(u => u.TelNomer == phoneNumber);
        var car = _unitOfWork.Cars.GetById(carId);

        Order order = new()
        {
            UserId = user.Id,
            User = null,
            CarId = car.Id,
            Car = null,
            ColorName = color.Name,
            ModelName = car.Name,
            Date = DateTime.Now,
            Price = car.Price
        };

        _unitOfWork.Orders.Add(order);
    }

    public IEnumerable<Order> GetAll()
    {
        throw new NotImplementedException();
    }

    public Order GetById(int id)
    {
        throw new NotImplementedException();
    }
}
