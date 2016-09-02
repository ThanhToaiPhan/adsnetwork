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

    public class HomeController : BaseHomeController
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

        public HomeController(IProductService productService, IBlogService blogService,
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

        public void SetDefaultAttribute()
        {
            ViewBag.iconURL = _websiteAttributeService.GetWebsiteAttributeByType("icon").FirstOrDefault().Value;
            ViewBag.logoURL = _websiteAttributeService.GetWebsiteAttributeByType("logo").FirstOrDefault().Value;
            ViewBag.hotline = _websiteAttributeService.GetWebsiteAttributeByType("hotline").FirstOrDefault().Value;
            ViewBag.partner = _websiteAttributeService.GetWebsiteAttributeByType("partner").ToList();
            ViewBag.about = _websiteAttributeService.GetWebsiteAttributeByType("about").FirstOrDefault().Value;
            ViewBag.eventt = _websiteAttributeService.GetWebsiteAttributeByType("event").FirstOrDefault().Value;
            ViewBag.mail = _websiteAttributeService.GetWebsiteAttributeByType("mail").FirstOrDefault().Value;
            ViewBag.skype = _websiteAttributeService.GetWebsiteAttributeByType("skype").ToList();
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

        public ActionResult TrangChu()
        {
            SetDefaultAttribute();
            var model = new TrangChuModel();
            model.listTourInHotHomePage = _productService.GetTourInHotHomePage().ToList();
            model.listTourInNewHomePage = _productService.GetTourInNewHomePage().ToList();
            model.listTourOutHotHomePage = _productService.GetTourOutHotHomePage().ToList();
            model.listTourOutNewHomePage = _productService.GetTourOutNewHomePage().ToList();
            model.listTourPromoHomePage = _productService.GetTourPromoHomePage().ToList();
            model.listNewBlog = _blogService.GetBlogs().OrderByDescending(b => b.DateCreated).Take(4).ToList();
            return View(model);
        }

        public ActionResult TimKiemTour(String term, String tour)
        {
            SetDefaultAttribute();
            if (tour == "Tour trong nước")
            {
                ViewBag.tour = "TRONG NƯỚC";
                if (term == "" || term == null)
                {
                    return RedirectToAction("TourTrongNuoc", "Home");
                }
                var model = new TourTrongNuocModel();
                term = term.ToLower();
                var slug = StringConvert.ConvertShortName(term);
                model.tourType = "in";
                model.viewType = "list";
                model.listTourInHot = _productService.GetTourInHot().ToList();
                model.listTourInNew = _productService.GetTourInNew().ToList();
                model.totalPage = 1;
                model.listTourIn = _productService.GetAllProducts().Where(p => (p.Name.ToLower().Contains(term) || p.Slug.Contains(slug)) && p.ProductCategory.Name == tour).ToList();
                return View("TourTrongNuoc", model);
            }
            else
            {
                ViewBag.tour = "NƯỚC NGOÀI";
                if (term == "" || term == null)
                {
                    return RedirectToAction("TourNuocNgoai", "Home");
                }
                var model = new TourTrongNuocModel();
                term = term.ToLower();
                var slug = StringConvert.ConvertShortName(term);
                model.tourType = "out";
                model.viewType = "list";
                model.listTourInHot = _productService.GetHotelPopulaire().ToList();
                model.totalPage = 1;
                model.listTourIn = _productService.GetAllProducts().Where(p => (p.Name.ToLower().Contains(term) || p.Slug.Contains(slug)) && p.ProductCategory.Name == tour).ToList();
                return View("TourTrongNuoc", model);
            }
            
        }

        public ActionResult TimKiemKhachSan(String term)
        {
            SetDefaultAttribute();
            ViewBag.tour = "DEAL KHÁCH SẠN";
            if (term == "" || term == null)
            {
                return RedirectToAction("KhachSan", "Home");
            }
            var model = new TourTrongNuocModel();
            term = term.ToLower();
            var slug = StringConvert.ConvertShortName(term);
            model.tourType = "in";
            model.viewType = "list";
            model.listTourInHot = _productService.GetTourInHot().ToList();
            model.totalPage = 1;
            model.listTourIn = _productService.GetAllProducts().Where(p => (p.Name.ToLower().Contains(term) || p.Slug.Contains(slug)) && p.ProductCategory.Name == "Khách sạn").ToList();
            return View("KhachSan", model);
        }

        public ActionResult TourTrongNuoc(String slug, int page = 0, int totalPage = 0, String viewType = "list")
        {
            SetDefaultAttribute();
            ViewBag.tour = "TRONG NƯỚC";
            if (slug == "" || slug == null || slug == "mien-bac" || slug == "mien-trung" || slug == "mien-nam")
            {
                var model = new TourTrongNuocModel();
                model.tourType = "in";
                model.viewType = viewType; 
                model.listTourInHot = _productService.GetTourInHot().ToList();
                model.listTourInNew = _productService.GetTourInNew().ToList();
                switch (slug)
                {
                    case "mien-bac":
                        if (totalPage == 0)
                        {
                            totalPage = _productService.GetTourInMienBac().ToList().Count;
                            if (totalPage % item_per_page == 0)
                            {
                                model.totalPage = totalPage / item_per_page;
                            }
                            else
                            {
                                model.totalPage = totalPage / item_per_page + 1;
                            }
                        }
                        else
                        {
                            model.totalPage = totalPage;
                        }
                        if (page > 0)
                        {
                            model.listTourIn = _productService.GetTourInMienBac().Skip((page - 1) * item_per_page).Take(item_per_page).ToList();
                            return PartialView("TourTrongNuocPartial", model);
                        }
                        else
                        {
                            model.listTourIn = _productService.GetTourInMienBac().Take(item_per_page).ToList();
                            return View("TourTrongNuoc", model);
                        }
                    case "mien-trung":
                        if (totalPage == 0)
                        {
                            totalPage = _productService.GetTourInMienTrung().ToList().Count;
                            if (totalPage % item_per_page == 0)
                            {
                                model.totalPage = totalPage / item_per_page;
                            }
                            else
                            {
                                model.totalPage = totalPage / item_per_page + 1;
                            }
                        }
                        else
                        {
                            model.totalPage = totalPage;
                        }
                        if (page > 0)
                        {
                            model.listTourIn = _productService.GetTourInMienTrung().Skip((page - 1) * item_per_page).Take(item_per_page).ToList();
                            return PartialView("TourTrongNuocPartial", model);
                        }
                        else
                        {
                            model.listTourIn = _productService.GetTourInMienTrung().Take(item_per_page).ToList();
                            return View("TourTrongNuoc", model);
                        }
                    case "mien-nam":
                        if (totalPage == 0)
                        {
                            totalPage = _productService.GetTourInMienNam().ToList().Count;
                            if (totalPage % item_per_page == 0)
                            {
                                model.totalPage = totalPage / item_per_page;
                            }
                            else
                            {
                                model.totalPage = totalPage / item_per_page + 1;
                            }
                        }
                        else
                        {
                            model.totalPage = totalPage;
                        }
                        if (page > 0)
                        {
                            model.listTourIn = _productService.GetTourInMienNam().Skip((page - 1) * item_per_page).Take(item_per_page).ToList();
                            return PartialView("TourTrongNuocPartial", model);
                        }
                        else
                        {
                            model.listTourIn = _productService.GetTourInMienNam().Take(item_per_page).ToList();
                            return View("TourTrongNuoc", model);
                        }
                    default:
                        if (totalPage == 0)
                        {
                            totalPage = _productService.GetTourIn().ToList().Count;
                            if (totalPage % item_per_page == 0)
                            {
                                model.totalPage = totalPage / item_per_page;
                            }
                            else
                            {
                                model.totalPage = totalPage / item_per_page + 1;
                            }
                        }
                        else
                        {
                            model.totalPage = totalPage;
                        }
                        if (page > 0)
                        {
                            model.listTourIn = _productService.GetTourIn().Skip((page - 1) * item_per_page).Take(item_per_page).ToList();
                            return PartialView("TourTrongNuocPartial", model);
                        }
                        else
                        {
                            model.listTourIn = _productService.GetTourIn().Take(item_per_page).ToList();
                            return View("TourTrongNuoc", model);
                        }
                }
            }
            else
            {
                var model = new List<Product>();
                var current_product = _productService.GetProductBySlug(slug);
                if (current_product != null && !current_product.IsDeleted)
                {
                    var list_product_similar = _productService.GetSimilarProduct(current_product).ToList();
                    model.Add(current_product);
                    if (list_product_similar != null)
                    {
                        foreach (var item in list_product_similar)
                        {
                            if (item.Id != current_product.Id)
                            {
                                model.Add(item);
                            }
                        }
                    }
                    return View("TourTrongNuocChiTiet", model);
                }
                else
                {
                    return View("Error");
                }
            }
        }

        public ActionResult TourNuocNgoai(String slug, int page = 0, int totalPage = 0, String viewType = "list")
        {
            SetDefaultAttribute();
            ViewBag.tour = "NƯỚC NGOÀI";
            if (slug == "" || slug == null || slug == "/")
            {
                var model = new TourTrongNuocModel();
                model.tourType = "out";
                model.viewType = viewType;
                if (totalPage == 0)
                {
                    totalPage = _productService.GetTourOut().ToList().Count;
                    if (totalPage % item_per_page == 0)
                    {
                        model.totalPage = totalPage / item_per_page;
                    }
                    else
                    {
                        model.totalPage = totalPage / item_per_page + 1;
                    }
                }
                else
                {
                    model.totalPage = totalPage;
                }
                model.listTourInHot = _productService.GetTourOutHot().ToList();
                model.listTourInNew = _productService.GetTourOutNew().ToList();
                if (page > 0)
                {
                    model.listTourIn = _productService.GetTourOut().Skip((page - 1) * item_per_page).Take(item_per_page).ToList();
                    return PartialView("TourTrongNuocPartial", model);
                }
                else
                {
                    model.listTourIn = _productService.GetTourOut().Take(item_per_page).ToList();
                    return View("TourTrongNuoc", model);
                }
            }
            else
            {
                var model = new List<Product>();
                var current_product = _productService.GetProductBySlug(slug);
                if (current_product != null && !current_product.IsDeleted)
                {
                    var list_product_similar = _productService.GetSimilarProduct(current_product).ToList();
                    model.Add(current_product);
                    if (list_product_similar != null)
                    {
                        foreach (var item in list_product_similar)
                        {
                            if (item.Id != current_product.Id)
                            {
                                model.Add(item);
                            }
                        }
                    }
                    return View("TourTrongNuocChiTiet", model);
                }
                else
                {
                    return View("Error");
                }
            }
        }

        public ActionResult KhachSan(String slug, String id, int page = 0, int totalPage = 0, String viewType = "list")
        {
            SetDefaultAttribute();
            ViewBag.tour = "DEAL KHÁCH SẠN";
            if (slug == "" || slug == null || slug == "/")
            {
                var model = new TourTrongNuocModel();
                model.tourType = "";
                model.viewType = viewType;
                if (totalPage == 0)
                {
                    totalPage = _productService.GetHotel().ToList().Count;
                    if (totalPage % item_per_page == 0)
                    {
                        model.totalPage = totalPage / item_per_page;
                    }
                    else
                    {
                        model.totalPage = totalPage / item_per_page + 1;
                    }
                }
                else
                {
                    model.totalPage = totalPage;
                }
                model.listTourInHot = _productService.GetHotelPopulaire().ToList();
                if (page > 0)
                {
                    model.listTourIn = _productService.GetHotel().Skip((page - 1) * item_per_page).Take(item_per_page).ToList();
                    return PartialView("KhachSanPartial", model);
                }
                else
                {
                    model.listTourIn = _productService.GetHotel().Take(item_per_page).ToList();
                    return View("KhachSan", model);
                }
            }
            else
            {
                if (id == "" || id == null || id == "/")
                {
                    var model = new List<Product>();
                    var current_product = _productService.GetProductBySlug(slug);
                    if (current_product != null && !current_product.IsDeleted)
                    {
                        var list_product_similar = _productService.GetSimilarProduct(current_product).ToList();
                        model.Add(current_product);
                        if (list_product_similar != null)
                        {
                            foreach (var item in list_product_similar)
                            {
                                if (item.Id != current_product.Id)
                                {
                                    model.Add(item);
                                }
                            }
                        }
                        return View("KhachSanChiTiet", model);
                    }
                }
                else
                {
                    var model = new List<ProductSchedule>();
                    var current_product_schedule = _productScheduleService.GetProductScheduleById(Int32.Parse(id));
                    if (current_product_schedule != null && current_product_schedule.IsAvailable && !current_product_schedule.IsDeleted)
                    {
                        var list_product_schedule_similar = _productScheduleService.GetSimilarProductSchedule(current_product_schedule).ToList();
                        model.Add(current_product_schedule);
                        if (list_product_schedule_similar != null)
                        {
                            foreach (var item in list_product_schedule_similar)
                            {
                                if (item.Id != current_product_schedule.Id)
                                {
                                    model.Add(item);
                                }
                            }
                        }
                        return View("PhongChiTiet", model);
                    }
                }
                return View("Error");
            }
        }

        public ActionResult DatTourTrongNuoc(String slug, int id)
        {
            SetDefaultAttribute();
            ViewBag.tour = "TRONG NƯỚC";
            var model = new DatTourTrongNuocModel();
            model.productSchedule = _productScheduleService.GetProductScheduleById(id);
            if (model.productSchedule.IsDeleted || !model.productSchedule.IsAvailable)
            {
                return View("Error");
            }
            else
            {
                return View("DatTourTrongNuoc", model);
            }
        }

        [HttpPost]
        public ActionResult XemLaiThongTinDatTourTrongNuoc(DatTourTrongNuocModel datTourTrongNuocModel)
        {
            SetDefaultAttribute();
            ViewBag.tour = "TRONG NƯỚC";
            datTourTrongNuocModel.productSchedule = _productScheduleService.GetProductScheduleById(datTourTrongNuocModel.productSchedule.Id);
            if (datTourTrongNuocModel.productSchedule.IsDeleted || !datTourTrongNuocModel.productSchedule.IsAvailable)
            {
                return View("Error");
            }
            else
            {
                return View("XemLaiThongTinDatTourTrongNuoc", datTourTrongNuocModel);
            }
        }

        [HttpPost]
        public ActionResult XacNhanDatTour(DatTourTrongNuocModel datTourTrongNuocModel)
        {
            datTourTrongNuocModel.productSchedule = _productScheduleService.GetProductScheduleById(datTourTrongNuocModel.productSchedule.Id);
            if (datTourTrongNuocModel.productSchedule.IsDeleted || !datTourTrongNuocModel.productSchedule.IsAvailable)
            {
                return View("Error");
            }
            else
            {
                // tao order moi
                var order = new Order();
                order.CustomerAddress = datTourTrongNuocModel.customerAddress;
                order.CustomerEmail = datTourTrongNuocModel.customerEmail;
                order.CustomerName = datTourTrongNuocModel.customerName;
                order.CustomerPhone = datTourTrongNuocModel.customerPhone;
                order.ProductScheduleId = datTourTrongNuocModel.productSchedule.Id;
                order.Note = datTourTrongNuocModel.note;
                order.IsDeleted = false;
                order.Type = "Lịch trình";
                order.OrderTotal = datTourTrongNuocModel.productSchedule.Price;

                // luu order moi vao database
                _orderService.CreateOrder(order);

                // lay cac attribute order
                var listOrderAttribute = _orderAttributeService.GetOrderAttributes().Where(oa => oa.Type == "Lịch trình").ToList();

                // mapping order
                order.OrderAttributeMappings = new List<OrderAttributeMapping>();
                foreach (var item in listOrderAttribute)
                {
                    var temp = "";
                    switch (item.Name)
                    {
                        case "Số lượng người lớn":
                            temp = datTourTrongNuocModel.quantityAdult.ToString();
                            break;
                        case "Số lượng trẻ em":
                            temp = datTourTrongNuocModel.quantityChild.ToString();
                            break;
                        case "Số lượng em bé":
                            temp = datTourTrongNuocModel.quantityBaby.ToString();
                            break;
                    }
                    order.OrderAttributeMappings.Add(new OrderAttributeMapping
                    {
                        OrderId = order.Id,
                        OrderAttributeId = item.Id,
                        Value = temp
                    });
                }
                _orderService.EditOrder(order);
                if (datTourTrongNuocModel.productSchedule.Product.ProductCategory.Name == "Tour trong nước")
                {
                    ViewBag.tour = "TRONG NƯỚC";
                }
                else
                {
                    ViewBag.tour = "NƯỚC NGOÀI";
                }
                SetDefaultAttribute();
                return View("CamOn");
            }
        }

        public ActionResult DatTourNuocNgoai(String slug, int id)
        {
            SetDefaultAttribute();
            ViewBag.tour = "NƯỚC NGOÀI";
            var model = new DatTourTrongNuocModel();
            model.productSchedule = _productScheduleService.GetProductScheduleById(id);
            if (model.productSchedule.IsDeleted || !model.productSchedule.IsAvailable)
            {
                return View("Error");
            }
            else
            {
                return View("DatTourTrongNuoc", model);
            }
        }

        [HttpPost]
        public ActionResult XemLaiThongTinDatTourNuocNgoai(DatTourTrongNuocModel datTourTrongNuocModel)
        {
            SetDefaultAttribute();
            ViewBag.tour = "NƯỚC NGOÀI";
            datTourTrongNuocModel.productSchedule = _productScheduleService.GetProductScheduleById(datTourTrongNuocModel.productSchedule.Id);
            if (datTourTrongNuocModel.productSchedule.IsDeleted || !datTourTrongNuocModel.productSchedule.IsAvailable)
            {
                return View("Error");
            }
            else
            {
                return View("XemLaiThongTinDatTourTrongNuoc", datTourTrongNuocModel);
            }
        }

        public ActionResult DatPhong(String slug, int id)
        {
            SetDefaultAttribute();
            ViewBag.tour = "DEAL KHÁCH SẠN";
            var model = new DatPhongModel();
            model.productSchedule = _productScheduleService.GetProductScheduleById(id);
            if (model.productSchedule.IsDeleted || !model.productSchedule.IsAvailable)
            {
                return View("Error");
            }
            else
            {

                return View("DatPhong", model);
            }
        }

        [HttpPost]
        public ActionResult XemLaiThongTinDatPhong(DatPhongModel datPhongModel)
        {
            SetDefaultAttribute();
            ViewBag.tour = "DEAL KHÁCH SẠN";
            datPhongModel.productSchedule = _productScheduleService.GetProductScheduleById(datPhongModel.productSchedule.Id);
            if (datPhongModel.productSchedule.IsDeleted || !datPhongModel.productSchedule.IsAvailable)
            {
                return View("Error");
            }
            else
            {
                datPhongModel.numberNight = Int32.Parse(((DateTime.ParseExact(datPhongModel.checkOut, "MM/dd/yyyy", CultureInfo.InvariantCulture)).Date - (DateTime.ParseExact(datPhongModel.checkIn, "MM/dd/yyyy", CultureInfo.InvariantCulture)).Date).TotalDays.ToString());
                return View("XemLaiThongTinDatPhong", datPhongModel);
            }
        }

        [HttpPost]
        public ActionResult XacNhanDatPhong(DatPhongModel datPhongModel)
        {
            datPhongModel.productSchedule = _productScheduleService.GetProductScheduleById(datPhongModel.productSchedule.Id);
            if (datPhongModel.productSchedule.IsDeleted || !datPhongModel.productSchedule.IsAvailable)
            {
                return View("Error");
            }
            else
            {
                datPhongModel.numberNight = Int32.Parse(((DateTime.ParseExact(datPhongModel.checkOut, "MM/dd/yyyy", CultureInfo.InvariantCulture)).Date - (DateTime.ParseExact(datPhongModel.checkIn, "MM/dd/yyyy", CultureInfo.InvariantCulture)).Date).TotalDays.ToString());
                // tao order moi
                var order = new Order();
                order.CustomerAddress = datPhongModel.customerAddress;
                order.CustomerEmail = datPhongModel.customerEmail;
                order.CustomerName = datPhongModel.customerName;
                order.CustomerPhone = datPhongModel.customerPhone;
                order.ProductScheduleId = datPhongModel.productSchedule.Id;
                order.Note = datPhongModel.note;
                order.IsDeleted = false;
                order.Type = "Phòng";
                order.OrderTotal = datPhongModel.productSchedule.Price;

                // luu order moi vao database
                _orderService.CreateOrder(order);

                // lay cac attribute order
                var listOrderAttribute = _orderAttributeService.GetOrderAttributes().Where(oa => oa.Type == "Phòng").ToList();

                // mapping order
                order.OrderAttributeMappings = new List<OrderAttributeMapping>();
                foreach (var item in listOrderAttribute)
                {
                    var temp = "";
                    switch (item.Name)
                    {
                        case "Số lượng":
                            temp = datPhongModel.numberPerson.ToString();
                            break;
                        case "Số phòng":
                            temp = datPhongModel.numberRoom.ToString();
                            break;
                        case "Số đêm":
                            temp = datPhongModel.numberNight.ToString();
                            break;
                        case "Ngày nhận phòng":
                            temp = datPhongModel.checkIn;
                            break;
                        case "Ngày trả phòng":
                            temp = datPhongModel.checkOut;
                            break;
                    }
                    order.OrderAttributeMappings.Add(new OrderAttributeMapping
                    {
                        OrderId = order.Id,
                        OrderAttributeId = item.Id,
                        Value = temp
                    });
                }
                _orderService.EditOrder(order);
                ViewBag.tour = "DEAL KHÁCH SẠN";
                SetDefaultAttribute();
                return View("CamOn");
            }
        }

        public ActionResult DichVuVisa(String slug)
        {
            SetDefaultAttribute();
            ViewBag.tour = "VISA";
            var model = new DichVuVisaModel();
            model.listBlog = _blogService.GetBlogs().ToList();
            var currentBlog = _blogService.GetBlogByUrlName(slug);
            if (currentBlog != null)
            {
                model.currentBlog = currentBlog;
            }
            else
            {
                model.currentBlog = model.listBlog[0];
            }
            return View("DichVuVisa", model);
        }

        public ActionResult DatVeMayBay()
        {
            SetDefaultAttribute();
            ViewBag.tour = "BAY";
            var model = new DatTourTrongNuocModel();
            return View("DatVeMayBay", model);
        }

        [HttpPost]
        public ActionResult XemLaiThongTinDatVeMayBay(DatTourTrongNuocModel datTourTrongNuocModel)
        {
            SetDefaultAttribute();
            ViewBag.tour = "BAY";
            return View("XemLaiThongTinDatVeMayBay", datTourTrongNuocModel);
        }

        [HttpPost]
        public ActionResult XacNhanDatVeMayBay(DatTourTrongNuocModel datTourTrongNuocModel)
        {
            // tao order moi
            var order = new Order();
            order.CustomerAddress = datTourTrongNuocModel.customerAddress;
            order.CustomerEmail = datTourTrongNuocModel.customerEmail;
            order.CustomerName = datTourTrongNuocModel.customerName;
            order.CustomerPhone = datTourTrongNuocModel.customerPhone;
            order.Note = datTourTrongNuocModel.note;
            order.ProductScheduleId = 3;
            order.IsDeleted = false;
            order.Type = "Máy bay";
            order.OrderTotal = 0;

            // luu order moi vao database
            _orderService.CreateOrder(order);

            // lay cac attribute order
            var listOrderAttribute = _orderAttributeService.GetOrderAttributes().Where(oa => oa.Type == "Lịch trình").ToList();

            // mapping order
            order.OrderAttributeMappings = new List<OrderAttributeMapping>();
            foreach (var item in listOrderAttribute)
            {
                var temp = "";
                switch (item.Name)
                {
                    case "Số lượng người lớn":
                        temp = datTourTrongNuocModel.quantityAdult.ToString();
                        break;
                    case "Số lượng trẻ em":
                        temp = datTourTrongNuocModel.quantityChild.ToString();
                        break;
                    case "Số lượng em bé":
                        temp = datTourTrongNuocModel.quantityBaby.ToString();
                        break;
                }
                order.OrderAttributeMappings.Add(new OrderAttributeMapping
                {
                    OrderId = order.Id,
                    OrderAttributeId = item.Id,
                    Value = temp
                });
            }
            _orderService.EditOrder(order);
            ViewBag.tour = "BAY";
            SetDefaultAttribute();
            return View("CamOn");
        }

        public ActionResult ThueXe()
        {
            SetDefaultAttribute();
            ViewBag.tour = "XE";
            var model = new DatTourTrongNuocModel();
            return View("ThueXe", model);
        }

        [HttpPost]
        public ActionResult XemLaiThongTinThueXe(DatTourTrongNuocModel datTourTrongNuocModel)
        {
            SetDefaultAttribute();
            ViewBag.tour = "XE";
            return View("XemLaiThongTinThueXe", datTourTrongNuocModel);
        }

        [HttpPost]
        public ActionResult XacNhanThueXe(DatTourTrongNuocModel datTourTrongNuocModel)
        {
            // tao order moi
            var order = new Order();
            order.CustomerAddress = datTourTrongNuocModel.customerAddress;
            order.CustomerEmail = datTourTrongNuocModel.customerEmail;
            order.CustomerName = datTourTrongNuocModel.customerName;
            order.CustomerPhone = datTourTrongNuocModel.customerPhone;
            order.Note = datTourTrongNuocModel.note;
            order.ProductScheduleId = 3;
            order.IsDeleted = false;
            order.Type = "Xe";
            order.OrderTotal = 0;

            // luu order moi vao database
            _orderService.CreateOrder(order);

            // lay cac attribute order
            var listOrderAttribute = _orderAttributeService.GetOrderAttributes().Where(oa => oa.Type == "Lịch trình").ToList();

            // mapping order
            order.OrderAttributeMappings = new List<OrderAttributeMapping>();
            foreach (var item in listOrderAttribute)
            {
                var temp = "";
                switch (item.Name)
                {
                    case "Số lượng người lớn":
                        temp = datTourTrongNuocModel.quantityAdult.ToString();
                        break;
                    case "Số lượng trẻ em":
                        temp = datTourTrongNuocModel.quantityChild.ToString();
                        break;
                    case "Số lượng em bé":
                        temp = datTourTrongNuocModel.quantityBaby.ToString();
                        break;
                }
                order.OrderAttributeMappings.Add(new OrderAttributeMapping
                {
                    OrderId = order.Id,
                    OrderAttributeId = item.Id,
                    Value = temp
                });
            }
            _orderService.EditOrder(order);
            ViewBag.tour = "XE";
            SetDefaultAttribute();
            return View("CamOn");
        }

        public ActionResult CamOn()
        {
            SetDefaultAttribute();
            ViewBag.tour = "TRONG NƯỚC";
            return View("CamOn");
        }

        public static Random rand = new Random();

        [HttpPost]
        public ActionResult CheckDomain(string domain = "http://localhost:55283/", string code = "1257d6da-f300-4b18-aa76-fedcaa9655b1")
        {
            var serverIP = "http://172.16.10.115:9006";
            var titleLength = 40;
            var contentLength = 90;
            if (domain != "" && code != "")
            {
                var queryResult = _codeService.GetCodes().Where(c => domain.Contains(c.Domain.Name) && c.Value == code);
                if (queryResult != null)
                {
                    var codeResult = queryResult.FirstOrDefault();
                    var listMaterial = new List<Material>();
                    foreach (var item in _adMaterialMappingService.GetAdMaterialMappings().Where(amm => amm.AdId == codeResult.AdId).ToList())
                    {
                        listMaterial.Add(item.Material);
                    }
                    var firstAd = 0;
                    var secondAd = 0;
                    var thirdAd = 0;
                    var fourthAd = 0;
                    switch (codeResult.Ad.Name)
                    {
                        case "Banner_Bottom_Right":
                        case "Banner_Bottom_Left":
                        case "Banner_Column_Right":
                            secondAd = firstAd = rand.Next(0, listMaterial.Count());
                            while (secondAd == firstAd)
                            {
                                secondAd = rand.Next(0, listMaterial.Count());
                            }
                            return Json(new
                            {
                                message = "success",
                                link_1 = listMaterial[firstAd].Link,
                                image_1 = listMaterial[firstAd].Image,
                                title_1 = slitString.TruncateAtWord(listMaterial[firstAd].Title, titleLength),
                                url_1 = listMaterial[firstAd].Url,
                                content_1 = slitString.TruncateAtWord(listMaterial[firstAd].Content, contentLength),
                                price_1 = listMaterial[firstAd].Price.ToString("N0"),
                                price_type_1 = listMaterial[firstAd].PriceType,
                                link_2 = listMaterial[secondAd].Link,
                                image_2 = listMaterial[secondAd].Image,
                                title_2 = slitString.TruncateAtWord(listMaterial[secondAd].Title, titleLength),
                                url_2 = listMaterial[secondAd].Url,
                                content_2 = slitString.TruncateAtWord(listMaterial[secondAd].Content, contentLength),
                                price_2 = listMaterial[secondAd].Price.ToString("N0"),
                                price_type_2 = listMaterial[secondAd].PriceType,
                                code = code,
                                script = codeResult.Ad.Script,
                                func = codeResult.Ad.Func
                            });
                        case "Banner_Top_Left":
                        case "Banner_Top_Right":
                        case "Banner_Bottom_Center":
                        case "Banner_Column_Right_Big":
                            thirdAd = secondAd = firstAd = rand.Next(0, listMaterial.Count());
                            while (secondAd == firstAd)
                            {
                                secondAd = rand.Next(0, listMaterial.Count());
                            }
                            while (thirdAd == secondAd || thirdAd == firstAd)
                            {
                                thirdAd = rand.Next(0, listMaterial.Count());
                            }
                            return Json(new
                            {
                                message = "success",
                                link_1 = listMaterial[firstAd].Link,
                                image_1 = listMaterial[firstAd].Image,
                                title_1 = slitString.TruncateAtWord(listMaterial[firstAd].Title, titleLength),
                                url_1 = listMaterial[firstAd].Url,
                                content_1 = slitString.TruncateAtWord(listMaterial[firstAd].Content, contentLength),
                                price_1 = listMaterial[firstAd].Price.ToString("N0"),
                                price_type_1 = listMaterial[firstAd].PriceType,
                                link_2 = listMaterial[secondAd].Link,
                                image_2 = listMaterial[secondAd].Image,
                                title_2 = slitString.TruncateAtWord(listMaterial[secondAd].Title, titleLength),
                                url_2 = listMaterial[secondAd].Url,
                                content_2 = slitString.TruncateAtWord(listMaterial[secondAd].Content, contentLength),
                                price_2 = listMaterial[secondAd].Price.ToString("N0"),
                                price_type_2 = listMaterial[secondAd].PriceType,
                                link_3 = listMaterial[thirdAd].Link,
                                image_3 = listMaterial[thirdAd].Image,
                                title_3 = slitString.TruncateAtWord(listMaterial[thirdAd].Title, titleLength),
                                url_3 = listMaterial[thirdAd].Url,
                                content_3 = slitString.TruncateAtWord(listMaterial[thirdAd].Content, contentLength),
                                price_3 = listMaterial[thirdAd].Price.ToString("N0"),
                                price_type_3 = listMaterial[thirdAd].PriceType,
                                code = code,
                                script = codeResult.Ad.Script,
                                func = codeResult.Ad.Func
                            });
                        case "Banner_Inside":
                            fourthAd = thirdAd = secondAd = firstAd = rand.Next(0, listMaterial.Count());
                            while (secondAd == firstAd)
                            {
                                secondAd = rand.Next(0, listMaterial.Count());
                            }
                            while (thirdAd == secondAd || thirdAd == firstAd)
                            {
                                thirdAd = rand.Next(0, listMaterial.Count());
                            }
                            while (fourthAd == secondAd || fourthAd == firstAd || fourthAd == thirdAd)
                            {
                                fourthAd = rand.Next(0, listMaterial.Count());
                            }
                            return Json(new
                            {
                                message = "success",
                                link_1 = listMaterial[firstAd].Link,
                                image_1 = listMaterial[firstAd].Image,
                                title_1 = slitString.TruncateAtWord(listMaterial[firstAd].Title, titleLength),
                                url_1 = listMaterial[firstAd].Url,
                                content_1 = slitString.TruncateAtWord(listMaterial[firstAd].Content, contentLength),
                                price_1 = listMaterial[firstAd].Price.ToString("N0"),
                                price_type_1 = listMaterial[firstAd].PriceType,
                                link_2 = listMaterial[secondAd].Link,
                                image_2 = listMaterial[secondAd].Image,
                                title_2 = slitString.TruncateAtWord(listMaterial[secondAd].Title, titleLength),
                                url_2 = listMaterial[secondAd].Url,
                                content_2 = slitString.TruncateAtWord(listMaterial[secondAd].Content, contentLength),
                                price_2 = listMaterial[secondAd].Price.ToString("N0"),
                                price_type_2 = listMaterial[secondAd].PriceType,
                                link_3 = listMaterial[thirdAd].Link,
                                image_3 = listMaterial[thirdAd].Image,
                                title_3 = slitString.TruncateAtWord(listMaterial[thirdAd].Title, titleLength),
                                url_3 = listMaterial[thirdAd].Url,
                                content_3 = slitString.TruncateAtWord(listMaterial[thirdAd].Content, contentLength),
                                price_3 = listMaterial[thirdAd].Price.ToString("N0"),
                                price_type_3 = listMaterial[thirdAd].PriceType,
                                link_4 = listMaterial[fourthAd].Link,
                                image_4 = listMaterial[fourthAd].Image,
                                title_4 = slitString.TruncateAtWord(listMaterial[fourthAd].Title, titleLength),
                                url_4 = listMaterial[fourthAd].Url,
                                content_4 = slitString.TruncateAtWord(listMaterial[fourthAd].Content, contentLength),
                                price_4 = listMaterial[fourthAd].Price.ToString("N0"),
                                price_type_4 = listMaterial[fourthAd].PriceType,
                                code = code,
                                script = codeResult.Ad.Script,
                                func = codeResult.Ad.Func
                            });
                        case "Video_Column_Right":
                        case "Video_Bottom_Right":
                        case "Video_Bottom_Left":
                        case "Video_Top_Right":
                        case "Video_Top_Left":
                        case "Video_Middle_Right":
                        case "Video_Middle_Left":
                        case "Video_Inside":
                            firstAd = rand.Next(0, listMaterial.Count());
                            return Json(new
                            {
                                message = "success",
                                link_1 = listMaterial[firstAd].Link,
                                image_1 = listMaterial[firstAd].Image,
                                video_1 = serverIP + listMaterial[firstAd].Video,
                                code = code,
                                script = codeResult.Ad.Script,
                                func = codeResult.Ad.Func
                            });
                        case "Gif_Top_Left":
                        case "Gif_Top_Right":
                        case "Gif_Column_Right":
                        case "Gif_Top_Center":
                        case "Gif_Inside":
                        case "Gif_Bottom_Center":
                        case "Gif_Bottom_Left":
                        case "Gif_Bottom_Right":
                        case "Gif_Column_Right_Square":
                            firstAd = rand.Next(0, listMaterial.Count());
                            return Json(new
                            {
                                message = "success",
                                link_1 = listMaterial[firstAd].Link,
                                image_1 = serverIP + listMaterial[firstAd].Image,
                                code = code,
                                script = codeResult.Ad.Script,
                                func = codeResult.Ad.Func
                            });
                    }
                }
            }
            return Json(new { message = "error" });
        }
    }
}