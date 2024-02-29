using Microsoft.AspNetCore.Mvc;
using CarsShop.Data;
using CarsShop.Data.Entities;
using AdminLab.Controllers;

namespace AdminLab.Areas.LazyCat.Controllers;
[Area("LazyCat")]
public class ImageController : BaseController<AppDbContext, Image>
{
    public ImageController(AppDbContext context) : base(context)
    {
    }
}
