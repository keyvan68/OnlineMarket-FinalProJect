using App.Domain.ApplicationServices;
using App.Domain.Core.Contracts.ApplicationService;
using App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels;
using App.EndPoints.MVC.OnlineMarket.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace App.EndPoints.MVC.OnlineMarket.ViewComponents
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly ICategoryApplicationService _categoryApplicationService;

        public CategoriesMenuViewComponent(IMapper mapper, ICategoryApplicationService categoryApplicationService)
        {
            _mapper = mapper;
            _categoryApplicationService = categoryApplicationService;
        }
        //public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        //{
        //    var categories = _mapper.Map<List<BuyerCategoryVM>>(await _getParentCategories.Execute(cancellationToken));
        //    return View(categories);
        //}
        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var categories = _mapper.Map<List<CategoryViewModel>>(await _categoryApplicationService.GetAllParentForMenu(cancellationToken));
            
            return View(categories);
        }
    }
}
