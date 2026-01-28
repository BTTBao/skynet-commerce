using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.IO;

namespace Skynet_Ecommerce.BLL.Helpers
{
    public static class CloudinaryHelper
    {
        // 1. Cấu hình tài khoản Cloudinary
        // 👇 SỬA DÒNG NÀY: Thêm "CloudinaryDotNet." vào trước chữ Account
        private static readonly CloudinaryDotNet.Account account = new CloudinaryDotNet.Account(
            "dr5f6xxwx",                   // Cloud Name
            "633249932448836",             // API Key
            "6MMYlD7W-oH-oIHkrA2l5nd3J4E"  // API Secret
        );

        private static readonly Cloudinary _cloudinary = new Cloudinary(account);

        // 2. Hàm Upload ảnh
        public static string UploadImage(string localFilePath)
        {
            // Kiểm tra: Nếu file path rỗng hoặc đã là link online thì không upload lại
            if (string.IsNullOrEmpty(localFilePath) || localFilePath.StartsWith("http"))
            {
                return localFilePath;
            }

            if (!File.Exists(localFilePath))
            {
                // Nếu file không tồn tại, trả về null hoặc chuỗi rỗng để không crash app
                return null;
            }

            try
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(localFilePath),
                    Folder = "Skynet_Commerce_Products"
                };

                var uploadResult = _cloudinary.Upload(uploadParams);

                if (uploadResult.Error != null)
                {
                    throw new Exception(uploadResult.Error.Message);
                }

                return uploadResult.SecureUrl.AbsoluteUri;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi upload Cloudinary: {ex.Message}");
            }
        }
    }
}