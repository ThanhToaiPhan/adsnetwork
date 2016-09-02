using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Outsourcing.Service;
using Outsourcing.Data.Models;
using PagedList;
using Labixa.ViewModels;
using System.Globalization;
using Outsourcing.Core.Common;

namespace Labixa.Controllers
{

    public class PublisherController : BaseHomeController
    {
        private readonly IProductService _productService;
        private readonly IProductScheduleService _productScheduleService;
        private readonly IBlogService _blogService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly IWebsiteAttributeService _websiteAttributeService;
        private readonly IStaffService _staffService;
        private readonly IProductAttributeMappingService _productAttributeMappingService;
        private readonly IProductRelationshipService _productRelationshipService;
        private readonly IOrderService _orderService;
        private readonly IOrderAttributeService _orderAttributeService;
        private readonly IOrderAttributeMappingService _orderAttributeMappingService;

        private readonly IAdService _adService;
        private readonly IAdMaterialMappingService _adMaterialMappingService;
        private readonly IMaterialService _materialService;
        private readonly IDomainService _domainService;
        private readonly ICodeService _codeService;

        int item_per_page = 12;

        public PublisherController(IProductService productService, IBlogService blogService,
            IWebsiteAttributeService websiteAttributeService, IBlogCategoryService blogCategoryService,
            IStaffService staffService, IProductAttributeMappingService productAttributeMappingService,
            IProductRelationshipService productRelationshipService, IProductScheduleService productScheduleService,
            IOrderService orderService, IOrderItemService orderItemService,
            IOrderAttributeService orderAttributeService, IOrderAttributeMappingService orderAttributeMappingService,
            IAdService adService, IAdMaterialMappingService adMaterialService, IMaterialService materialService, IDomainService domainService, ICodeService codeService)
        {
            this._productService = productService;
            this._blogService = blogService;
            this._websiteAttributeService = websiteAttributeService;
            this._blogCategoryService = blogCategoryService;
            this._staffService = staffService;
            this._productAttributeMappingService = productAttributeMappingService;
            this._productRelationshipService = productRelationshipService;
            this._productScheduleService = productScheduleService;
            this._orderService = orderService;
            this._orderAttributeService = orderAttributeService;
            this._orderAttributeMappingService = orderAttributeMappingService;
            this._adService = adService;
            this._adMaterialMappingService = adMaterialService;
            this._materialService = materialService;
            this._domainService = domainService;
            this._codeService = codeService;
        }

        public List<Product> Multiple(List<Product> list, int number)
        {
            List<Product> result = new List<Product>();
            while (result.Count < number)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    result.Add(list[i]);
                }
            }
            return result;
        }

        public ActionResult Index()
        {
            var model = new TrangChuModel();
            model.listTourInHotHomePage = _productService.GetTourInHotHomePage().ToList();
            model.listTourInNewHomePage = _productService.GetTourInNewHomePage().ToList();
            model.listTourOutHotHomePage = _productService.GetTourOutHotHomePage().ToList();
            model.listTourOutNewHomePage = _productService.GetTourOutNewHomePage().ToList();
            model.listTourPromoHomePage = _productService.GetTourPromoHomePage().ToList();
            model.listNewBlog = _blogService.GetBlogs().OrderByDescending(b => b.DateCreated).Take(4).ToList();
            return View(model);
        }
    }
}