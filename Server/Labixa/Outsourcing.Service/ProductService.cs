using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outsourcing.Core.Common;
using Outsourcing.Data.Models;
using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Repository;
using Outsourcing.Service.Properties;

namespace Outsourcing.Service
{
    public interface IProductService
    {

        IEnumerable<Product> GetProducts();

        //IEnumerable<Product> GetHomePageProducts(bool showOnHomePage);
        //IEnumerable<Product> GetDailyTour();
        //IEnumerable<Product> GetLongTour();
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int productId);
        //trang chu
        IEnumerable<Product> GetProductByProductAttributeName(String productAttributeName);
        IEnumerable<Product> GetTourInHotHomePage();
        IEnumerable<Product> GetTourInNewHomePage();
        IEnumerable<Product> GetTourOutHotHomePage();
        IEnumerable<Product> GetTourOutNewHomePage();
        IEnumerable<Product> GetTourPromoHomePage();
        //trang tour trong nuoc
        IEnumerable<Product> GetTourInNew();
        IEnumerable<Product> GetTourInHot();
        IEnumerable<Product> GetTourIn();
        IEnumerable<Product> GetTourInMienBac();
        IEnumerable<Product> GetTourInMienTrung();
        IEnumerable<Product> GetTourInMienNam();
        //trang tour nuoc ngoai
        IEnumerable<Product> GetTourOutNew();
        IEnumerable<Product> GetTourOutHot();
        IEnumerable<Product> GetTourOut();
        //trang khach san
        IEnumerable<Product> GetHotel();
        IEnumerable<Product> GetHotelPopulaire();
        //lay nhung san pham co lien quan
        IEnumerable<Product> GetSimilarProduct(Product product);

        Product GetProductBySlug(string slug);

        void CreateProduct(Product product);
        void EditProduct(Product productToEdit);
        void DeleteProduct(int productId);
        void SaveProduct();
        IEnumerable<ValidationResult> CanAddProduct(Product product);

        #region [Manage PhotoAlbum]
        IEnumerable<Product> GetPhotos();
        Product GetPhoto();
        void CreatePhoto(Product photo);
        void EditPhoto(Product Photo);
        void DeletePhoto(int PhotoId); 
        #endregion

    }
    public class ProductService : IProductService
    {
        #region Field
        private readonly IProductRepository productRepository;
        private readonly IProductScheduleRepository productScheduleRepository;
        private readonly IProductAttributeMappingRepository productAttributeMappingRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public ProductService(IProductRepository productRepository, IProductScheduleRepository productScheduleRepository, IProductAttributeMappingRepository productAttributeMappingRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.productAttributeMappingRepository = productAttributeMappingRepository;
            this.unitOfWork = unitOfWork;
            this.productScheduleRepository = productScheduleRepository;
        }
        #endregion

        #region BaseMethod
        
        public IEnumerable<Product> GetProducts()
        {
            var products = productRepository.GetMany(p => !p.IsDeleted).OrderBy(p => p.Position) ;
            return products;
        }

        //public IEnumerable<Product> GetHomePageProducts(bool showOnHomePage)
        //{
        //    var products = productRepository.GetMany(p => !p.IsDeleted && p.IsPublic );
        //    if (showOnHomePage)
        //    {
        //        products = products.Where(p => p.IsHomePage).OrderBy(p=>p.Position);
        //    }
        //    return products;
        //}
        
        public Product GetProductById(int productId)
        {
            var product = productRepository.GetById(productId);
            return product;
        }
        public Product GetProductBySlug(string slug)
        {
            var product = productRepository.Get(p => !p.IsDeleted && p.Slug.Equals(slug));
            return product;
        }

        public void CreateProduct(Product product)
        {
            productRepository.Add(product);
            SaveProduct();
        }

        public void EditProduct(Product productToEdit)
        {
            productRepository.Update(productToEdit);
            SaveProduct();
        }

        public void DeleteProduct(int productId)
        {
            //Get product by id.
            var product = productRepository.GetById(productId);
            if (product != null)
            {
                product.IsDeleted = true;
                foreach(var item in product.ProductSchedules)
                {
                    item.IsDeleted = true;
                    productScheduleRepository.Update(item);
                }
                //productRepository.Delete(product);
                productRepository.Update(product);
                SaveProduct();
            }
        }

        public void SaveProduct()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<ValidationResult> CanAddProduct(Product product)
        {
        
            //    yield return new ValidationResult("Product", "ErrorString");
            return null;
        }

        #endregion


        public IEnumerable<Product> GetAllProducts()
        {
            var list = productRepository.GetAll().Where(p => p.IsPublic == true && p.IsDeleted == false);
            return list;
        }


        public IEnumerable<Product> GetDailyTour()
        {
            var listDailyTour = new List<Product>();
            var listProduct = productRepository.GetMany(p => p.IsDeleted == false);
            foreach (var product in listProduct)
            {
                if (productAttributeMappingRepository.GetAll().Where(p => p.ProductId == product.Id && p.ProductAttributeId == 13 && p.Value.Equals("true")).Count() > 0)
                {
                    listDailyTour.Add(product);
                }
            }
            //foreach (var daily in listDaily)
            //{
            //    if (daily.ProductAttributeMappings.FirstOrDefault(p=>p.ProductAttributeId==13).Value.Equals("true"))
            //    {
            //        listDailyTour.Add(daily);
            //    }
            //}
            return listDailyTour.OrderBy(p => p.Position);
        }

        //public IEnumerable<Product> GetLongTour()
        //{
        //    var listLongTour = new List<Product>();
        //    var listProduct = productRepository.GetMany(p => p.IsDeleted == false);
        //    foreach (var product in listProduct)
        //    {
        //        if (productAttributeRepository.GetAll().Where(p => p.ProductId == product.Id && p.ProductAttributeId == 13 && p.Value.Equals("false")).Count()>0)
        //         {
        //            listLongTour.Add(product);
        //        }
        //    }
        //    return listLongTour.OrderBy(p=>p.Position);
        //}

        public IEnumerable<Product> GetProductByProductAttributeName(String productAttributeName)
        {
            List<Product> listProduct = new List<Product>();
            var listProductAttributeMapping = productAttributeMappingRepository.GetMany(pam => pam.ProductAttribute.Name.ToLower().Equals(productAttributeName.ToLower()) && pam.Value.Equals("true") && !pam.Product.IsDeleted);
            foreach (var item in listProductAttributeMapping)
            {
                listProduct.Add(item.Product);
            }
            return listProduct;
        }

        public IEnumerable<Product> GetProductByCategoryName(String productCategoryName)
        {
            return productRepository.GetMany(p => p.ProductCategory.Name.ToLower().Equals(productCategoryName.ToLower()) && !p.IsDeleted);
        }

        public IEnumerable<Product> GetTourInHotHomePage()
        {
            var listTour = GetTourInHot().ToList();
            foreach (var item in listTour.ToList())
            {
                if (!item.IsHomePage)
                {
                    listTour.Remove(item);
                }
            }
            return listTour;
        }

        public IEnumerable<Product> GetTourInNewHomePage()
        {
            var listTour = GetTourInNew().ToList();
            foreach (var item in listTour.ToList())
            {
                if (!item.IsHomePage)
                {
                    listTour.Remove(item);
                }
            }
            return listTour;
        }

        public IEnumerable<Product> GetTourOutHotHomePage()
        {
            var listTour = GetProductByProductAttributeName("Tour nổi bật").ToList();
            foreach (var item in listTour.ToList())
            {
                if (!item.IsHomePage || !item.ProductCategory.Name.Equals("Tour nước ngoài"))
                {
                    listTour.Remove(item);
                }
            }
            return listTour;
        }

        public IEnumerable<Product> GetTourOutNewHomePage()
        {
            var listTour = GetProductByProductAttributeName("Tour mới").ToList();
            foreach (var item in listTour.ToList())
            {
                if (!item.IsHomePage || !item.ProductCategory.Name.Equals("Tour nước ngoài"))
                {
                    listTour.Remove(item);
                }
            }
            return listTour;
        }

        public IEnumerable<Product> GetTourPromoHomePage()
        {
            var listTour = GetProductByProductAttributeName("Tour khuyến mãi").ToList();
            foreach (var item in listTour.ToList())
            {
                if (!item.IsHomePage)
                {
                    listTour.Remove(item);
                }
            }
            return listTour;
        }

        public IEnumerable<Product> GetTourInHot()
        {
            var listTour = GetProductByProductAttributeName("Tour nổi bật").ToList();
            foreach (var item in listTour.ToList())
            {
                if (!item.ProductCategory.Name.Equals("Tour trong nước"))
                {
                    listTour.Remove(item);
                }
            }
            return listTour;
        }

        public IEnumerable<Product> GetTourInNew()
        {
            var listTour = GetProductByProductAttributeName("Tour mới").ToList();
            foreach (var item in listTour.ToList())
            {
                if (!item.ProductCategory.Name.Equals("Tour trong nước"))
                {
                    listTour.Remove(item);
                }
            }
            return listTour;
        }

        public IEnumerable<Product> GetTourIn()
        {
            var listTour = GetProductByCategoryName("Tour trong nước").ToList();
            return listTour;
        }

        public IEnumerable<Product> GetTourInMienBac()
        {
            var listTour = GetProductByCategoryName("Tour trong nước").ToList();
            foreach (var item in listTour.ToList())
            {
                if (item.ProductAttributeMappings.Where(pam => pam.ProductAttribute.Name == "Tour miền Bắc").FirstOrDefault().Value != "true")
                {
                    listTour.Remove(item);
                }
            }
            return listTour;
        }

        public IEnumerable<Product> GetTourInMienTrung()
        {
            var listTour = GetProductByCategoryName("Tour trong nước").ToList();
            foreach (var item in listTour.ToList())
            {
                if (item.ProductAttributeMappings.Where(pam => pam.ProductAttribute.Name == "Tour miền Trung").FirstOrDefault().Value != "true")
                {
                    listTour.Remove(item);
                }
            }
            return listTour;
        }

        public IEnumerable<Product> GetTourInMienNam()
        {
            var listTour = GetProductByCategoryName("Tour trong nước").ToList();
            foreach (var item in listTour.ToList())
            {
                if (item.ProductAttributeMappings.Where(pam => pam.ProductAttribute.Name == "Tour miền Nam").FirstOrDefault().Value != "true")
                {
                    listTour.Remove(item);
                }
            }
            return listTour;
        }

        public IEnumerable<Product> GetTourOutHot()
        {
            var listTour = GetProductByProductAttributeName("Tour nổi bật").ToList();
            foreach (var item in listTour.ToList())
            {
                if (!item.ProductCategory.Name.Equals("Tour nước ngoài"))
                {
                    listTour.Remove(item);
                }
            }
            return listTour;
        }

        public IEnumerable<Product> GetTourOutNew()
        {
            var listTour = GetProductByProductAttributeName("Tour mới").ToList();
            foreach (var item in listTour.ToList())
            {
                if (!item.ProductCategory.Name.Equals("Tour nước ngoài"))
                {
                    listTour.Remove(item);
                }
            }
            return listTour;
        }

        public IEnumerable<Product> GetTourOut()
        {
            var listTour = GetProductByCategoryName("Tour nước ngoài").ToList();
            return listTour;
        }

        public IEnumerable<Product> GetSimilarProduct(Product product)
        {
            var listProduct = GetProductByCategoryName(product.ProductCategory.Name);
            return listProduct;
        }

        public IEnumerable<Product> GetHotel()
        {
            var listHotel = GetProductByCategoryName("Khách sạn").ToList();
            return listHotel;
        }

        public IEnumerable<Product> GetHotelPopulaire()
        {
            List<Product> listHotel = new List<Product>();
            var listProductAttributeMapping = productAttributeMappingRepository.GetMany(pam => pam.ProductAttribute.Name.Equals("Khách sạn phổ biến") && pam.Value.Equals("true") && !pam.Product.IsDeleted);
            foreach (var item in listProductAttributeMapping)
            {
                listHotel.Add(item.Product);
            }
            return listHotel;
        }

        #region [Manage Photo]
        public IEnumerable<Product> GetPhotos()
        {
            var ListPhoto = productRepository.GetMany(p => p.ProductCategoryId == 7);
            return ListPhoto;
        }

        public Product GetPhoto()
        {
            return productRepository.Get(p => p.Id == 50);
        }

        public void CreatePhoto(Product photo)
        {
            photo.IsHomePage = false;
            photo.IsPublic = true;
            photo.LastEditedTime = DateTime.Now;
            photo.DateCreated = DateTime.Now;
            photo.OldPrice = 0;
            photo.Position = 999;
            photo.Price = 0;
            photo.ProductCategoryId = 7;
            photo.Slug = StringConvert.ConvertShortName(photo.Name);
            photo.IsDeleted = false;
            productRepository.Add(photo);
            SaveProduct();
        }

        public void EditPhoto(Product Photo)
        {
            Photo.LastEditedTime = DateTime.Now;
            productRepository.Update(Photo);
            SaveProduct();
        }

        public void DeletePhoto(int PhotoId)
        {
            var photo = productRepository.GetById(PhotoId);
            photo.IsDeleted = true;
            EditPhoto(photo);
        }
        #endregion
    }
}
