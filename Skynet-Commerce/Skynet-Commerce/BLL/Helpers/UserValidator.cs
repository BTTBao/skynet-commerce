using Skynet_Commerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.BLL.Helpers
{
    public static class UserValidator
    {
        public static string Validate(string fullName, string phone, string email)
        {
            // FULL NAME
            if (string.IsNullOrWhiteSpace(fullName))
                return "Tên người dùng không được để trống!";

            if (fullName.Length < 2 || fullName.Length > 150)
                return "Tên phải từ 2 đến 150 ký tự!";

            if (!Regex.IsMatch(fullName, @"^[\p{L}\s]+$"))
                return "Tên chỉ được chứa chữ cái và khoảng trắng!";

            // PHONE
            if (string.IsNullOrWhiteSpace(phone))
                return "Số điện thoại không được để trống!";

            if (!Regex.IsMatch(phone, @"^\d{10}$"))
                return "Số điện thoại không hợp lệ! Vui lòng nhập đúng 10 chữ số.";

            // EMAIL
            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    return "Email không hợp lệ!";
            }

            return null; // hợp lệ
        }
    }
}
