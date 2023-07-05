using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.utility;
using App.Infrastructures.Data.Repositories.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;

namespace App.EndPoints.MVC.OnlineMarket.Controllers
{
    public class MenuController : Controller
    {
        private readonly ICategoryApplicationService _categoryApplicationService;
        private readonly IMapper _mapper;

        public MenuController(ICategoryApplicationService categoryApplicationService, IMapper mapper)
        {
            _categoryApplicationService = categoryApplicationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            //var categoriesDTO = await _categoryApplicationService.GetAll(cancellationToken);
            //var categories = CategoryMapper.MapCategories(categoriesDTO);
            //var menuHtml = MenuBuilder.BuildMenu(categories);
            //ViewBag.MenuHtml = menuHtml;
            return View();
        }
    }
}
