using Microsoft.AspNetCore.Mvc;
using CarsShop.Data;
using CarsShop.Data.Entities;
using AdminLab.Controllers;

namespace AdminLab.Areas.LazyCat.Controllers;
[Area("LazyCat")]
public class UserController : BaseController<AppDbContext, User>
{
    public UserController(AppDbContext context) : base(context)
    {
    }
}
