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

    public partial class ProductController : Controller
    {
        #region Field

        readonly IProductService _productService;
        readonly IProductCategoryService _productCategoryService;

        readonly IProductAttributeService _productAttributeService;
        readonly IProductAttributeMappingService _productAttributeMappingService;

        readonly IPictureService _pictureService;
        readonly IProductPictureMappingService _productPictureMappingService;

        readonly IProductScheduleService _productScheduleService;
        readonly IProductRelationshipService _productRelationShipService;

        #endregion

        #region Ctor
        public ProductController(IProductService productService, IProductCategoryService productCategoryService,
            IProductAttributeService productAttributeService, IProductAttributeMappingService productAttributeMappingService,
            IPictureService pictureService, IProductPictureMappingService productPictureMappingService,
            IProductRelationshipService productRelationShipService, IProductScheduleService productScheduleService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
            this._productAttributeService = productAttributeService;
            this._productAttributeMappingService = productAttributeMappingService;
            this._pictureService = pictureService;
            this._productPictureMappingService = productPictureMappingService;
            this._productRelationShipService = productRelationShipService;
            this._productScheduleService = productScheduleService;
        }
        #endregion

        public ActionResult Tour()
        {
            var products = _productService.GetProducts().Where(p => p.ProductCategory.Name.Contains("Tour")).ToList();
            return View(model: products);
        }

        public ActionResult TourCreate()
        {
            //Get the list category
            var listProductCategory = _productCategoryService.GetProductCategories().Where(c => c.Name.Contains("Tour")).ToSelectListItems(-1);
            var product = new ProductFormModel { ListProductCategory = listProductCategory };
            return View(product);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateInput(false)]
        public ActionResult TourCreate(ProductFormModel newProduct, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                //Mapping to domain
                Product product = Mapper.Map<ProductFormModel, Product>(newProduct);
                if (String.IsNullOrEmpty(product.Slug))
                {
                    product.Slug = StringConvert.ConvertShortName(product.Name);
                }

                //Create Product
                _productService.CreateProduct(product);

                //Add ProductAttribute after product created
                product.ProductAttributeMappings = new Collection<ProductAttributeMapping>();
                var listAttributeId = _productAttributeService.GetProductAttributes().Where(p => p.Type.Equals("Tour")).Select(p => p.Id);
                foreach (var id in listAttributeId)
                {
                    product.ProductAttributeMappings.Add(
                        new ProductAttributeMapping() { ProductAttributeId = id, ProductId = product.Id });

                }
                //Add Picture default for Labixa
                product.ProductPictureMappings = new Collection<ProductPictureMapping>();
                for (int i = 0; i < 11; i++)
                {
                    var newPic = new Picture();
                    bool ismain = i == 0;
                    _pictureService.CreatePicture(newPic);
                    product.ProductPictureMappings.Add(
                        new ProductPictureMapping()
                        {
                            PictureId = newPic.Id,
                            ProductId = product.Id,
                            IsMainPicture = ismain,
                            DisplayOrder = 0,
                        });
                }
                _productService.EditProduct(product);
                return continueEditing ? RedirectToAction("TourEdit", "Product", new { productId = product.Id })
                                : RedirectToAction("Tour", "Product");
            }
            else
            {
                var listProductCategory = _productCategoryService.GetProductCategories().Where(c => !c.Name.Contains("Tour")).ToSelectListItems(-1);
                newProduct.ListProductCategory = listProductCategory;
                return View("TourCreate", newProduct);
            }
        }

        [HttpGet]
        public ActionResult TourEdit(int productId)
        {

            var product = _productService.GetProductById(productId);
            ProductFormModel productFormModel = Mapper.Map<Product, ProductFormModel>(product);
            productFormModel.ListProductCategory = _productCategoryService.GetProductCategories().Where(c => c.Name.Contains("Tour")).ToSelectListItems(-1);
            productFormModel.ListProducts = _productService.GetAllProducts().ToSelectListItems(-1);
            return View(model: productFormModel);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateInput(false)]
        public ActionResult TourEdit(ProductFormModel productToEdit, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                //Mapping to domain
                Product product = Mapper.Map<ProductFormModel, Product>(productToEdit);
                if (String.IsNullOrEmpty(product.Slug))
                {
                    product.Slug = StringConvert.ConvertShortName(product.Name);
                }
                //this funcion not update all relationship value.
                _productService.EditProduct(product);
                //update attribute
                foreach (var mapping in product.ProductAttributeMappings)
                {
                    _productAttributeMappingService.EditProductAttributeMapping(mapping);
                }
                //update productpicture URL
                foreach (var picture in product.ProductPictureMappings)
                {
                    _productPictureMappingService.EditProductPictureMapping(picture);
                    _pictureService.EditPicture(picture.Picture);
                }
                return continueEditing ? RedirectToAction("TourEdit", "Product", new { productId = product.Id })
                      : RedirectToAction("Tour", "Product");
            }
            else
            {
                var listProductCategory = _productCategoryService.GetProductCategories().Where(c => c.Name.Contains("Tour")).ToSelectListItems(-1);
                productToEdit.ListProductCategory = listProductCategory;
                return View("TourEdit", productToEdit);
            }
        }


        public ActionResult TourDelete(int productId)
        {
            _productService.DeleteProduct(productId);
            return RedirectToAction("Tour");
        }

        public ActionResult Hotel()
        {
            var products = _productService.GetProducts().Where(p => !p.ProductCategory.Name.Contains("Tour")).ToList();
            return View(model: products);
        }

        public ActionResult HotelCreate()
        {
            //Get the list category
            var listProductCategory = _productCategoryService.GetProductCategories().Where(c => !c.Name.Contains("Tour")).ToSelectListItems(-1);
            var product = new ProductFormModel { ListProductCategory = listProductCategory };
            return View(product);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateInput(false)]
        public ActionResult HotelCreate(ProductFormModel newProduct, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                //Mapping to domain
                Product product = Mapper.Map<ProductFormModel, Product>(newProduct);
                if (String.IsNullOrEmpty(product.Slug))
                {
                    product.Slug = StringConvert.ConvertShortName(product.Name);
                }

                //Create Product
                _productService.CreateProduct(product);

                //Add ProductAttribute after product created
                product.ProductAttributeMappings = new Collection<ProductAttributeMapping>();
                var listAttributeId = _productAttributeService.GetProductAttributes().Where(p => !p.Type.Equals("Tour")).Select(p => p.Id);
                foreach (var id in listAttributeId)
                {
                    product.ProductAttributeMappings.Add(
                        new ProductAttributeMapping() { ProductAttributeId = id, ProductId = product.Id });

                }
                //Add Picture default for Labixa
                product.ProductPictureMappings = new Collection<ProductPictureMapping>();
                for (int i = 0; i < 4; i++)
                {
                    var newPic = new Picture();
                    bool ismain = i == 0;
                    _pictureService.CreatePicture(newPic);
                    product.ProductPictureMappings.Add(
                        new ProductPictureMapping()
                        {
                            PictureId = newPic.Id,
                            ProductId = product.Id,
                            IsMainPicture = ismain,
                            DisplayOrder = 0,
                        });
                }
                _productService.EditProduct(product);
                return continueEditing ? RedirectToAction("HotelEdit", "Product", new { productId = product.Id })
                                : RedirectToAction("Hotel", "Product");
            }
            else
            {
                var listProductCategory = _productCategoryService.GetProductCategories().Where(c => !c.Name.Contains("Tour")).ToSelectListItems(-1);
                newProduct.ListProductCategory = listProductCategory;
                return View("HotelCreate", newProduct);
            }
        }

        [HttpGet]
        public ActionResult HotelEdit(int productId)
        {

            var product = _productService.GetProductById(productId);
            ProductFormModel productFormModel = Mapper.Map<Product, ProductFormModel>(product);
            productFormModel.ListProductCategory = _productCategoryService.GetProductCategories().Where(c => !c.Name.Contains("Tour")).ToSelectListItems(-1);
            productFormModel.ListProducts = _productService.GetAllProducts().ToSelectListItems(-1);
            return View(model: productFormModel);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateInput(false)]
        public ActionResult HotelEdit(ProductFormModel productToEdit, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                //Mapping to domain
                Product product = Mapper.Map<ProductFormModel, Product>(productToEdit);
                if (String.IsNullOrEmpty(product.Slug))
                {
                    product.Slug = StringConvert.ConvertShortName(product.Name);
                }
                //this funcion not update all relationship value.
                _productService.EditProduct(product);
                //update attribute
                foreach (var mapping in product.ProductAttributeMappings)
                {
                    _productAttributeMappingService.EditProductAttributeMapping(mapping);
                }
                //update productpicture URL
                foreach (var picture in product.ProductPictureMappings)
                {
                    _productPictureMappingService.EditProductPictureMapping(picture);
                    _pictureService.EditPicture(picture.Picture);
                }
                return continueEditing ? RedirectToAction("HotelEdit", "Product", new { productId = product.Id })
                      : RedirectToAction("Hotel", "Product");
            }
            else
            {
                var listProductCategory = _productCategoryService.GetProductCategories().Where(c => !c.Name.Contains("Tour")).ToSelectListItems(-1);
                productToEdit.ListProductCategory = listProductCategory;
                return View("HotelEdit", productToEdit);
            }
        }


        public ActionResult HotelDelete(int productId)
        {
            _productService.DeleteProduct(productId);
            return RedirectToAction("Hotel");
        }
    }
}