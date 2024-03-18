using Microsoft.AspNetCore.Mvc;

namespace CarsShopMVC.Areas.Admin.Controllers;

public class TestController : Controller
{
    public IActionResult Get()
    {
        string view = """
        @model PaginationModel

        @if (Model.TotalPages > 1)
        {
            <input type="hidden" value="@Model.PageNumber" id="pageNumber" />

            <div class="d-flex justify-content-center">
                @if (Model.TotalPages < 6)
                {
                    <nav aria-label="Page navigation example">
                        <ul class="pagination">
                            @for (int i = 1; i <= Model.TotalPages; i++)
                            {
                                if (Model.PageNumber == i)
                                {
                                    <li class="page-item active">
                                        <a class="page-link"
                                           asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="@i">@i</a>
                                    </li>
                                }
                                else
                                {
                                    <li class="page-item">
                                        <a class="page-link"
                                           asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="@i">@i</a>
                                    </li>
                                }
                            }
                        </ul>
                    </nav>
                }
                else if (Model.PageNumber < 3)
                {
                    <nav aria-label="Page navigation example">
                        <ul class="pagination">
                            @if (Model.PageNumber == 1)
                            {
                                <li class="page-item disabled">
                                    <a class="page-link" aria-label="Previous">
                                        <span aria-hidden="true">&laquo;</span>
                                    </a>
                                </li>
                            }
                            else
                            {
                                <li class="page-item">
                                    <a class="page-link" aria-label="Previous"
                                       asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="@(Model.PageNumber-1)">
                                        <span aria-hidden="true">&laquo;</span>
                                    </a>
                                </li>
                            }
                            <li class="page-item">
                                <a class="page-link"
                                   asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="1">1</a>
                            </li>
                            <li class="page-item">
                                <a class="page-link"
                                   asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="2">2</a>
                            </li>
                            <li class="page-item">
                                <a class="page-link"
                                   asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="3">3</a>
                            </li>
                            <li class="page-item disabled"><a class="page-link" href="#">...</a></li>
                            <li class="page-item">
                                <a class="page-link"
                                   asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="@Model.TotalPages">
                                    @Model.TotalPages
                                </a>
                            </li>
                            <li class="page-item">
                                <a class="page-link" aria-label="Previous"
                                   asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="@(Model.PageNumber+1)">
                                    <span aria-hidden="true">&raquo;</span>
                                </a>
                            </li>
                        </ul>
                    </nav>
                }
                else if (Model.TotalPages - 2 >= Model.PageNumber)
                {
                    <nav aria-label="Page navigation example">
                        <ul class="pagination">
                            <li class="page-item">
                                <a class="page-link" aria-label="Previous"
                                   asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="@(Model.PageNumber-1)">
                                    <span aria-hidden="true">&laquo;</span>
                                </a>
                            </li>
                            <li class="page-item">
                                <a class="page-link"
                                   asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="1">1</a>
                            </li>
                            <li class="page-item disabled"><a class="page-link">...</a></li>
                            <li class="page-item">
                                <a class="page-link"
                                   asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="@(Model.PageNumber - 1)">
                                    @(Model.PageNumber - 1)
                                </a>
                            </li>
                            <li class="page-item">
                                <a class="page-link"
                                   asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="@(Model.PageNumber)">
                                    @Model.PageNumber
                                </a>
                            </li>
                            <li class="page-item">
                                <a class="page-link"
                                   asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="@(Model.PageNumber + 1)">
                                    @(Model.PageNumber + 1)
                                </a>
                            </li>
                            <li class="page-item disabled"><a class="page-link">...</a></li>
                            <li class="page-item">
                                <a class="page-link"
                                   asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="@(Model.TotalPages)">
                                    @Model.TotalPages
                                </a>
                            </li>
                            <li class="page-item">
                                <a class="page-link" aria-label="Previous"
                                   asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="@(Model.PageNumber+1)">
                                    <span aria-hidden="true">&raquo;</span>
                                </a>
                            </li>
                        </ul>
                    </nav>
                }
                else
                {
                    <nav aria-label="Page navigation example">
                        <ul class="pagination">
                            <li class="page-item">
                                <a class="page-link" aria-label="Previous"
                                   asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="@(Model.PageNumber-1)">
                                    <span aria-hidden="true">&laquo;</span>
                                </a>
                            </li>
                            <li class="page-item">
                                <a class="page-link"
                                   asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="1">1</a>
                            </li>
                            <li class="page-item disabled"><a class="page-link" href="#">...</a></li>
                            <li class="page-item">
                                <a class="page-link" asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="@(Model.TotalPages - 2)">
                                    @(Model.TotalPages - 2)
                                </a>
                            </li>
                            <li class="page-item">
                                <a class="page-link" asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="@(Model.TotalPages - 1)">
                                    @(Model.TotalPages - 1)
                                </a>
                            </li>
                            <li class="page-item">
                                <a class="page-link" asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="@(Model.TotalPages)">
                                    @Model.TotalPages
                                </a>
                            </li>
                            @if (Model.PageNumber == Model.TotalPages)
                            {
                                <li class="page-item disabled">
                                    <a class="page-link" aria-label="Next">
                                        <span aria-hidden="true">&raquo;</span>
                                    </a>
                                </li>
                            }
                            else
                            {
                                <li class="page-item">
                                    <a class="page-link" aria-label="Next"
                                       asp-controller="@Model.ControllerName" asp-action="@Model.ActionName" asp-route-pageNumber="@(Model.PageNumber+1)">
                                        <span aria-hidden="true">&raquo;</span>
                                    </a>
                                </li>
                            }
                        </ul>
                    </nav>
                }
            </div>
        }
        """;

        return View(view, "text/html");
    }
}