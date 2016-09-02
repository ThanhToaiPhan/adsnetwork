using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Outsourcing.Data.Models;


namespace Outsourcing.Data
{
    public class OutsourcingSampleData : DropCreateDatabaseIfModelChanges<OutsourcingEntities>
    {
        private UserManager<User> UserManager;
        private RoleManager<IdentityRole> RoleManager;

        protected override void Seed(OutsourcingEntities context)
        {
            UserManager = new UserManager<User>(new UserStore<User>(context));
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //Create User

            var users = new List<User>() {
                  new User(){
                      UserName = "admin",
                      FirstName = "Admin",
                      LastName = "Admin",
                      RoleId = SystemRoles.Role01
                  },
                  new User(){
                      UserName = "pub1",
                      FirstName = "Publisher",
                      LastName = "01",
                      RoleId = SystemRoles.Role02
                  },
                  new User(){
                      UserName = "pub2",
                      FirstName = "Publisher",
                      LastName = "02",
                      RoleId = SystemRoles.Role02
                  },
                  new User(){
                      UserName = "ad1",
                      FirstName = "Advertiser",
                      LastName = "01",
                      RoleId = SystemRoles.Role03
                  },
                  new User(){
                      UserName = "ad2",
                      FirstName = "Advertiser",
                      LastName = "02",
                      RoleId = SystemRoles.Role03
                  }
            };
            foreach (var user in users)
            {
                if (UserManager.FindByName(user.UserName) == null)
                {
                    UserManager.Create(user, "123456");
                }
            }


            //Create Roles
            var listRoles = new List<string>(new string[] { "Admin", "Publisher", "Advertiser" });
            foreach (var role in listRoles)
            {
                if (!RoleManager.RoleExists(role))
                {
                    RoleManager.Create(new IdentityRole(role));
                }
            }

            //context.BlogCategories.Add(new BlogCategory() { Name = "Dịch vụ Visa", Slug = "visa", Status = true, IsStaticPage = true });

            //// khach san va tour
            //context.ProductCategories.Add(new ProductCategory() { Name = "Tour trong nước", Slug = "tour-trong-nuoc", IsDeleted = false });
            //context.ProductCategories.Add(new ProductCategory() { Name = "Tour nước ngoài", Slug = "tour-nuoc-ngoai", IsDeleted = false });
            //context.ProductCategories.Add(new ProductCategory() { Name = "Khách sạn", Slug = "khach-san", IsDeleted = false });

            //// cac thanh phan trong website
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Logo", ControlType = "Image", Type = "logo", Value = "/images/uploaded/Oceanlink/logo.png", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Hotline", ControlType = "Text", Type = "hotline", Value = "0902.333.333 - 0912.333.333", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Icon", ControlType = "Image", Type = "icon", Value = "/images/uploaded/Oceanlink/icon.png", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Slogan", ControlType = "Text", Type = "logo", Value = "Natural wonders and majestic structures. Bustling cities and mythical ruins. Mount-watering gastronomic experiences and exotic cultures.", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Partner 1", ControlType = "Image", Type = "partner", Value = "/images/uploaded/Oceanlink/client1.png", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Partner 2", ControlType = "Image", Type = "partner", Value = "/images/uploaded/Oceanlink/client2.png", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Partner 3", ControlType = "Image", Type = "partner", Value = "/images/uploaded/Oceanlink/client3.png", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Partner 4", ControlType = "Image", Type = "partner", Value = "/images/uploaded/Oceanlink/client4.png", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Partner 5", ControlType = "Image", Type = "partner", Value = "/images/uploaded/Oceanlink/client5.png", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Partner 6", ControlType = "Image", Type = "partner", Value = "/images/uploaded/Oceanlink/client1.png", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Partner 7", ControlType = "Image", Type = "partner", Value = "/images/uploaded/Oceanlink/client2.png", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Partner 8", ControlType = "Image", Type = "partner", Value = "/images/uploaded/Oceanlink/client3.png", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "About", ControlType = "Textarea", Type = "about", Value = "<p>Lời đầu ti&ecirc;n, c&ocirc;ng ty du lịch Fiditour xin gửi lời chào th&acirc;n ái đến Qu&yacute; kh&aacute;ch h&agrave;ng v&agrave; đ&ocirc;́i tác. K&iacute;nh ch&uacute;c Qu&yacute; khách hàng v&agrave; đ&ocirc;́i tác lu&ocirc;n dồi d&agrave;o sức khỏe và thành đạt.<br/><br/>Được th&agrave;nh lập 25/03/1989 với hoạt động kinh doanh ban đầu l&agrave; tổ chức c&aacute;c chương tr&igrave;nh du lịch cho du kh&aacute;ch nước ngo&agrave;i v&agrave;o tham quan Việt Nam, đ&ecirc;́n nay trải qua 26 năm x&acirc;y dựng và phát tri&ecirc;̉n (1989&ndash;2015), Fiditour kh&ocirc;ng ngừng lớn mạnh trở thành m&ocirc;̣t trong 10 hãng lữ hành hàng đ&acirc;̀u của ngành du lịch Vi&ecirc;̣t Nam. Lĩnh vực kinh doanh ngày càng được mở r&ocirc;̣ng: kinh doanh du lịch trong v&agrave; ngo&agrave;i nước, cung cấp v&eacute; m&aacute;y bay, quản l&yacute; kh&aacute;ch sạn, nh&agrave; h&agrave;ng, văn ph&ograve;ng cho thu&ecirc;, tổ chức sự kiện (MICE), Du học, Đ&agrave;o tạo.v.v&hellip;</p>", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Event", ControlType = "Text", Type = "event", Value = "...", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Mail", ControlType = "Text", Type = "mail", Value = "toai.phan@indolink.vn", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Nhân viên tư vấn 1", ControlType = "Text", Type = "skype", Value = "papyrusaya", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Nhân viên tư vấn 2", ControlType = "Text", Type = "skype", Value = "phan.thanh.toai", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Nhân viên tư vấn 3", ControlType = "Text", Type = "skype", Value = "skype", IsPublic = true, IsDeleted = false });
            //context.WebsiteAttributes.Add(new WebsiteAttribute() { Name = "Nhân viên tư vấn 4", ControlType = "Text", Type = "skype", Value = "skype", IsPublic = true, IsDeleted = false });

            //// cac thuoc tinh cua tour
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Ngày đi", Description = "Ngày đi", Type = "Tour", ControlType = "DateTimeString", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Khách sạn", Description = "Khách sạn", Type = "Tour", ControlType = "Text", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Điều khoản", Description = "Điều khoản", Type = "Tour", ControlType = "Textarea", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Thời gian đi", Description = "Thời gian đi", Type = "Tour", ControlType = "Text", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Phương tiện", Description = "Phương tiện", Type = "Tour", ControlType = "Text", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Tour mới", Description = "Tour mới", Type = "Tour", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Tour nổi bật", Description = "Tour nổi bật", Type = "Tour", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Tour khuyến mãi", Description = "Tour khuyến mãi", Type = "Tour", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Khởi hành từ", Description = "Khởi hành từ", Type = "Tour", ControlType = "Text", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Tour miền Bắc", Description = "Tour miền Bắc", Type = "Tour", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Tour miền Trung", Description = "Tour miền Trung", Type = "Tour", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Tour miền Nam", Description = "Tour miền Nam", Type = "Tour", ControlType = "CheckBox", IsDeleted = false });

            //// cac thuoc tinh cua khach san
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Quốc gia", Description = "Quốc gia", Type = "Khách sạn", ControlType = "Text", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Tỉnh", Description = "Tỉnh", Type = "Khách sạn", ControlType = "Text", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Thành phố", Description = "Thành phố", Type = "Khách sạn", ControlType = "Text", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Số phòng", Description = "Số phòng", Type = "Khách sạn", ControlType = "Int32String", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Chất lượng", Description = "Chất lượng", Type = "Khách sạn", ControlType = "Int32String", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Lễ tân 24h", Description = "Lễ tân 24h", Type = "Khách sạn", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Hồ bơi trẻ em", Description = "Hồ bơi trẻ em", Type = "Khách sạn", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Tiệm cà phê", Description = "Tiệm cà phê", Type = "Khách sạn", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Cà phê/trà tại sảnh", Description = "Cà phê/trà tại sảnh", Type = "Khách sạn", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Trạm máy tính", Description = "Trạm máy tính", Type = "Khách sạn", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Dịch vụ concierge/hỗ trợ khách", Description = "Dịch vụ concierge/hỗ trợ khách", Type = "Khách sạn", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Phòng hội nghị", Description = "Phòng hội nghị", Type = "Khách sạn", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Dịch vụ giặt ủi", Description = "Dịch vụ giặt ủi", Type = "Khách sạn", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Wifi (miễn phí)", Description = "Wifi (miễn phí)", Type = "Khách sạn", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Nhật báo tại sảnh", Description = "Nhật báo tại sảnh", Type = "Khách sạn", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Bãi đậu xe có người phục vụ", Description = "Bãi đậu xe có người phục vụ", Type = "Khách sạn", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Vườn hoa", Description = "Vườn hoa", Type = "Khách sạn", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Dịch vụ lưu trữ/bảo quản hành lý", Description = "Dịch vụ lưu trữ/bảo quản hành lý", Type = "Khách sạn", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Sự kiện", Description = "Sự kiện", Type = "Khách sạn", ControlType = "Textarea", IsDeleted = false });
            //context.ProductAttributes.Add(new ProductAttribute() { Name = "Khách sạn phổ biến", Description = "Khách sạn phổ biến", Type = "Khách sạn", ControlType = "CheckBox", IsDeleted = false });

            //// cac thuoc tinh cua lich trinh tour
            //context.ProductScheduleAttributes.Add(new ProductScheduleAttribute() { Name = "Ngày đi", Description = "Ngày đi", Type = "Lịch trình", ControlType = "DateTimeString", IsDeleted = false });
            //context.ProductScheduleAttributes.Add(new ProductScheduleAttribute() { Name = "Ngày về", Description = "Ngày về", Type = "Lịch trình", ControlType = "DateTimeString", IsDeleted = false });

            //// cac thuoc tinh cua phong khach san
            //context.ProductScheduleAttributes.Add(new ProductScheduleAttribute() { Name = "Tên", Description = "Tên", Type = "Phòng", ControlType = "Text", IsDeleted = false });
            //context.ProductScheduleAttributes.Add(new ProductScheduleAttribute() { Name = "Số người", Description = "Số người", Type = "Phòng", ControlType = "Int32String", IsDeleted = false });
            //context.ProductScheduleAttributes.Add(new ProductScheduleAttribute() { Name = "Thêm 1 người", Description = "Thêm 1 người", Type = "Phòng", ControlType = "Int32String", IsDeleted = false });
            //context.ProductScheduleAttributes.Add(new ProductScheduleAttribute() { Name = "Phí khác", Description = "Phí khác", Type = "Phòng", ControlType = "Int32String", IsDeleted = false });
            //context.ProductScheduleAttributes.Add(new ProductScheduleAttribute() { Name = "Bữa sáng miễn phí", Description = "Bữa sáng miễn phí", Type = "Phòng", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductScheduleAttributes.Add(new ProductScheduleAttribute() { Name = "Wifi (miễn phí)", Description = "Wifi (miễn phí)", Type = "Phòng", ControlType = "CheckBox", IsDeleted = false });
            //context.ProductScheduleAttributes.Add(new ProductScheduleAttribute() { Name = "Giới thiệu", Description = "Giới thiệu", Type = "Phòng", ControlType = "Textarea", IsDeleted = false });
            //context.ProductScheduleAttributes.Add(new ProductScheduleAttribute() { Name = "Điều khoản", Description = "Điều khoản", Type = "Phòng", ControlType = "Textarea", IsDeleted = false });
            //context.ProductScheduleAttributes.Add(new ProductScheduleAttribute() { Name = "Thông tin bổ sung", Description = "Thông tin bổ sung", Type = "Phòng", ControlType = "Textarea", IsDeleted = false });

            //// cac thuoc tinh cua hoa don lich trinh
            //context.OrderAttributes.Add(new OrderAttribute() { Name = "Số lượng người lớn", Description = "Số lượng người lớn", Type = "Lịch trình", ControlType = "Int32String", IsDeleted = false });
            //context.OrderAttributes.Add(new OrderAttribute() { Name = "Số lượng trẻ em", Description = "Số lượng trẻ em", Type = "Lịch trình", ControlType = "Int32String", IsDeleted = false });
            //context.OrderAttributes.Add(new OrderAttribute() { Name = "Số lượng em bé", Description = "Số lượng em bé", Type = "Lịch trình", ControlType = "Int32String", IsDeleted = false });

            //// cac thuoc tinh cua hoa don phong
            //context.OrderAttributes.Add(new OrderAttribute() { Name = "Số lượng", Description = "Số lượng", Type = "Phòng", ControlType = "Int32String", IsDeleted = false });
            //context.OrderAttributes.Add(new OrderAttribute() { Name = "Số phòng", Description = "Số phòng", Type = "Phòng", ControlType = "Int32String", IsDeleted = false });
            //context.OrderAttributes.Add(new OrderAttribute() { Name = "Số đêm", Description = "Số đêm", Type = "Phòng", ControlType = "Int32String", IsDeleted = false });
            //context.OrderAttributes.Add(new OrderAttribute() { Name = "Ngày nhận phòng", Description = "Ngày nhận phòng", Type = "Phòng", ControlType = "DateTimeString", IsDeleted = false });
            //context.OrderAttributes.Add(new OrderAttribute() { Name = "Ngày trả phòng", Description = "Ngày trả phòng", Type = "Phòng", ControlType = "DateTimeString", IsDeleted = false });

            context.SaveChanges();
        }

    }
}