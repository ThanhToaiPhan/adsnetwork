using System.ComponentModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Outsourcing.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            DateCreated = DateTime.Now;
        }

        [DisplayName(@"Tên")]
        public string FirstName { get; set; }

        [DisplayName(@"Họ")]
        public string LastName { get; set; }

        [DisplayName(@"Địa chỉ")]
        public string Address { get; set; }

        [DisplayName(@"Ngày tạo")]
        public DateTime DateCreated { get; set; }

        [DisplayName(@"Ngày đăng nhập cuối")]
        public DateTime? LastLoginTime { get; set; }

        [DisplayName(@"Đã kích hoạt")]
        public bool IsActivated { get; set; }

        [DisplayName(@"Giới tính")]
        public Gender Gender { get; set; }

        [DisplayName(@"ID Chức danh")]
        public SystemRoles RoleId { get; set; }

        [DisplayName(@"Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName(@"Đã xóa")]
        public bool IsDeleted { get; set; }

        [DisplayName(@"Tên hiển thị")]
        public string DisplayName
        {
            get { return LastName + " " + FirstName; }
        }

        public virtual ICollection<Domain> Domains { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
    }
    public enum SystemRoles
    {
        [Description("Admin")]
        Role01 = 0,
        [Description("Publisher")]
        Role02 = 1,
        [Description("Server")]
        Role03 = 2
    }
    public enum Gender
    {
        [Description("Nam")]
        Male = 0,
        [Description("Nữ")]
        Female = 1
    }
}
