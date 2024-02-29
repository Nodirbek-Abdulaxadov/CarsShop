using Microsoft.AspNetCore.Mvc;
using CarsShop.Data;
using CarsShop.Data.Entities;
using AdminLab.Controllers;

namespace AdminLab.Areas.LazyCat.Controllers;
[Area("LazyCat")]
public class ColorController : BaseController<AppDbContext, Color>
{
    public ColorController(AppDbContext context) : base(context)
    {
    }
}
