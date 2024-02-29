using Microsoft.AspNetCore.Mvc;
using CarsShop.Data;
using CarsShop.Data.Entities;
using AdminLab.Controllers;

namespace AdminLab.Areas.LazyCat.Controllers;
[Area("LazyCat")]
public class CategoryController : BaseController<AppDbContext, Category>
{
    public CategoryController(AppDbContext context) : base(context)
    {
    }
}
