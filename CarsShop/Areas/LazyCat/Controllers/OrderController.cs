using Microsoft.AspNetCore.Mvc;
using CarsShop.Data;
using CarsShop.Data.Entities;
using AdminLab.Controllers;

namespace AdminLab.Areas.LazyCat.Controllers;
[Area("LazyCat")]
public class OrderController : BaseController<AppDbContext, Order>
{
    public OrderController(AppDbContext context) : base(context)
    {
    }
}