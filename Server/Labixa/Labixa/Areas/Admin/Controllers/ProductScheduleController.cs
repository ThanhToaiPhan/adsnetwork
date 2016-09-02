using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Labixa.Areas.Admin.ViewModel;
using Outsourcing.Service;
using Outsourcing.Data.Models;
using Outsourcing.Core.Common;
using Outsourcing.Core.Extensions;
using Outsourcing.Core.Framework.Controllers;

namespace Labixa.Areas.Admin.Controllers
{
    public partial class ProductScheduleController : Controller
    {
        #region Field

        readonly IProductScheduleService _productScheduleService;
        readonly IProductScheduleAttributeService _productScheduleAttributeService;
        readonly IProductScheduleAttributeMappingService _productScheduleAttributeMappingService;
        readonly IProductService _productService;
        readonly IPictureService _pictureService;
        readonly IProductSchedulePictureMappingService _productSchedulePictureMappingService;

        #endregion

        #region Ctor
        public ProductScheduleController(IProductService productService,
            IProductScheduleService productScheduleService,
            IProductScheduleAttributeService productScheduleAttributeService,
            IProductScheduleAttributeMappingService productScheduleAttributeMappingService,
            IProductSchedulePictureMappingService productSchedulePictureMappingService,
            IPictureService pictureService)
        {
            this._productScheduleService = productScheduleService;
            this._productService = productService;
            this._productScheduleAttributeService = productScheduleAttributeService;
            this._productScheduleAttributeMappingService = productScheduleAttributeMappingService;
            this._productSchedulePictureMappingService = productSchedulePictureMappingService;
            this._pictureService = pictureService;
        }
        #endregion

        public ActionResult Schedule()
        {
            var productschedules = _productScheduleService.GetProductSchedules().Where(p => p.Product.ProductCategory.Name.Contains("Tour")).ToList();
            return View(model: productschedules);
        }

        public ActionResult ScheduleCreate()
        {
            var listProduct = _productService.GetProducts().Where(p => p.ProductCategory.Name.Contains("Tour")).ToSelectListItems(-1);
            var schedule = new ProductScheduleFormModel { ListProduct = listProduct };
            return View(schedule);
        }

        //
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateInput(false)]
        public ActionResult ScheduleCreate(ProductScheduleFormModel newProductSchedule, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                var listAttributeId = _productScheduleAttributeService.GetProductScheduleAttributes().Where(p => p.Type.Equals("Lịch trình")).Select(p => p.Id);
                //Mapping to domain
                ProductSchedule productSchedule = Mapper.Map<ProductScheduleFormModel, ProductSchedule>(newProductSchedule);

                //Create Product Schedule
                _productScheduleService.CreateProductSchedule(productSchedule);

                //Add ProductScheduleAttribute after product created
                productSchedule.ProductScheduleAttributeMappings = new Collection<ProductScheduleAttributeMapping>();
                //var listAttributeId = _productScheduleAttributeService.GetProductScheduleAttributes().Where(p => p.Type.Equals("Lịch trình")).Select(p => p.Id);
                foreach (var id in listAttributeId)
                {
                    productSchedule.ProductScheduleAttributeMappings.Add(
                        new ProductScheduleAttributeMapping() { ProductScheduleAttributeId = id, ProductScheduleId = productSchedule.Id });

                }
                _productScheduleService.EditProductSchedule(productSchedule);
                return continueEditing ? RedirectToAction("ScheduleEdit", "ProductSchedule", new { productScheduleId = productSchedule.Id })
                                : RedirectToAction("Schedule", "ProductSchedule");
            }
            else
            {
                var listProduct = _productService.GetProducts().Where(p => p.ProductCategory.Name.Contains("Tour")).ToSelectListItems(-1);
                newProductSchedule.ListProduct = listProduct;
                return View("ScheduleCreate", newProductSchedule);
            }
        }

        [HttpGet]
        public ActionResult ScheduleEdit(int productScheduleId)
        {

            var productSchedule = _productScheduleService.GetProductScheduleById(productScheduleId);
            ProductScheduleFormModel productScheduleFormModel = Mapper.Map<ProductSchedule, ProductScheduleFormModel>(productSchedule);
            productScheduleFormModel.Price = productSchedule.Price;
            productScheduleFormModel.MaxQuantity = productSchedule.MaxQuantity;
            productScheduleFormModel.IsAvailable = productSchedule.IsAvailable;
            productScheduleFormModel.ListProduct = _productService.GetProducts().Where(p => p.ProductCategory.Name.Contains("Tour")).ToSelectListItems(-1);
            return View(model: productScheduleFormModel);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateInput(false)]
        public ActionResult ScheduleEdit(ProductScheduleFormModel productScheduleToEdit, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                //Mapping to domain
                ProductSchedule productSchedule = Mapper.Map<ProductScheduleFormModel, ProductSchedule>(productScheduleToEdit);
                //if (String.IsNullOrEmpty(product.Slug))
                //{
                //    product.Slug = StringConvert.ConvertShortName(product.Name);
                //}
                ////this funcion not update all relationship value.
                _productScheduleService.EditProductSchedule(productSchedule);
                //update attribute
                foreach (var mapping in productSchedule.ProductScheduleAttributeMappings)
                {
                    _productScheduleAttributeMappingService.EditProductScheduleAttributeMapping(mapping);
                }
                return continueEditing ? RedirectToAction("ScheduleEdit", "ProductSchedule", new { productScheduleId = productSchedule.Id })
                      : RedirectToAction("Schedule", "ProductSchedule");
            }
            else
            {
                var listProduct = _productService.GetProducts().Where(p => p.ProductCategory.Name.Contains("Tour")).ToSelectListItems(-1);
                productScheduleToEdit.ListProduct = listProduct;
                return View("ScheduleEdit", productScheduleToEdit);
            }
        }

        public ActionResult ScheduleDelete(int productScheduleId)
        {
            _productScheduleService.DeleteProductSchedule(productScheduleId);
            return RedirectToAction("Schedule");
        }

        public ActionResult Room()
        {
            var productschedules = _productScheduleService.GetProductSchedules().Where(p => !p.Product.ProductCategory.Name.Contains("Tour")).ToList();
            return View(model: productschedules);
        }

        public ActionResult RoomCreate()
        {
            var listProduct = _productService.GetProducts().Where(p => !p.ProductCategory.Name.Contains("Tour")).ToSelectListItems(-1);
            var schedule = new ProductScheduleFormModel { ListProduct = listProduct };
            return View(schedule);
        }

        //
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateInput(false)]
        public ActionResult RoomCreate(ProductScheduleFormModel newProductSchedule, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                //Mapping to domain
                ProductSchedule productSchedule = Mapper.Map<ProductScheduleFormModel, ProductSchedule>(newProductSchedule);

                //Create Product Schedule
                _productScheduleService.CreateProductSchedule(productSchedule);

                //Add ProductScheduleAttribute after product created
                productSchedule.ProductScheduleAttributeMappings = new Collection<ProductScheduleAttributeMapping>();
                //Add Picture default for Labixa
                productSchedule.ProductSchedulePictureMappings = new Collection<ProductSchedulePictureMapping>();
                for (int i = 0; i < 11; i++)
                {
                    var newPic = new Picture();
                    bool ismain = i == 0;
                    _pictureService.CreatePicture(newPic);
                    productSchedule.ProductSchedulePictureMappings.Add(
                        new ProductSchedulePictureMapping()
                        {
                            PictureId = newPic.Id,
                            ProductScheduleId = productSchedule.Id,
                            IsMainPicture = ismain,
                            DisplayOrder = 0,
                        });
                }
                var listAttributeId = _productScheduleAttributeService.GetProductScheduleAttributes().Where(p => !p.Type.Equals("Lịch trình")).Select(p => p.Id);
                foreach (var id in listAttributeId)
                {
                    productSchedule.ProductScheduleAttributeMappings.Add(
                        new ProductScheduleAttributeMapping() { ProductScheduleAttributeId = id, ProductScheduleId = productSchedule.Id });

                }
                _productScheduleService.EditProductSchedule(productSchedule);
                return continueEditing ? RedirectToAction("RoomEdit", "ProductSchedule", new { productScheduleId = productSchedule.Id })
                                : RedirectToAction("Room", "ProductSchedule");
            }
            else
            {
                var listProduct = _productService.GetProducts().Where(p => !p.ProductCategory.Name.Contains("Tour")).ToSelectListItems(-1);
                newProductSchedule.ListProduct = listProduct;
                return View("RoomCreate", newProductSchedule);
            }
        }

        [HttpGet]
        public ActionResult RoomEdit(int productScheduleId)
        {

            var productSchedule = _productScheduleService.GetProductScheduleById(productScheduleId);
            ProductScheduleFormModel productScheduleFormModel = Mapper.Map<ProductSchedule, ProductScheduleFormModel>(productSchedule);
            productScheduleFormModel.Price = productSchedule.Price;
            productScheduleFormModel.MaxQuantity = productSchedule.MaxQuantity;
            productScheduleFormModel.IsAvailable = productSchedule.IsAvailable;
            productScheduleFormModel.ListProduct = _productService.GetProducts().Where(p => !p.ProductCategory.Name.Contains("Tour")).ToSelectListItems(-1);
            return View(model: productScheduleFormModel);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateInput(false)]
        public ActionResult RoomEdit(ProductScheduleFormModel productScheduleToEdit, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                //Mapping to domain
                ProductSchedule productSchedule = Mapper.Map<ProductScheduleFormModel, ProductSchedule>(productScheduleToEdit);
                //if (String.IsNullOrEmpty(product.Slug))
                //{
                //    product.Slug = StringConvert.ConvertShortName(product.Name);
                //}
                ////this funcion not update all relationship value.
                _productScheduleService.EditProductSchedule(productSchedule);
                //update attribute
                foreach (var mapping in productSchedule.ProductScheduleAttributeMappings)
                {
                    _productScheduleAttributeMappingService.EditProductScheduleAttributeMapping(mapping);
                }
                //update productpicture URL
                foreach (var picture in productSchedule.ProductSchedulePictureMappings)
                {
                    _productSchedulePictureMappingService.EditProductSchedulePictureMapping(picture);
                    _pictureService.EditPicture(picture.Picture);
                }
                return continueEditing ? RedirectToAction("RoomEdit", "ProductSchedule", new { productScheduleId = productSchedule.Id })
                      : RedirectToAction("Room", "ProductSchedule");
            }
            else
            {
                var listProduct = _productService.GetProducts().Where(p => !p.ProductCategory.Name.Contains("Tour")).ToSelectListItems(-1);
                productScheduleToEdit.ListProduct = listProduct;
                return View("RoomEdit", productScheduleToEdit);
            }
        }

        public ActionResult RoomDelete(int productScheduleId)
        {
            _productScheduleService.DeleteProductSchedule(productScheduleId);
            return RedirectToAction("Room");
        }
    }
}
