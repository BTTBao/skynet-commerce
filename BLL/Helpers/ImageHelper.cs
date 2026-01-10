using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Skynet_Ecommerce.BLL.Helpers
{
    public static class ImageHelper
    {
        // Hàm tải ảnh từ URL (Synchronous)
        public static Image LoadFromUrl(string url)
        {
            try
            {
                // Bỏ qua check SSL nếu cần thiết (cho một số link https)
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var request = WebRequest.Create(url);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    return Image.FromStream(stream);
                }
            }
            catch
            {
                return null; // Trả về null nếu lỗi
            }
        }

        // Hàm đổi màu Icon (Recolor)
        public static Image Recolor(Image originalImage, Color newColor)
        {
            if (originalImage == null) return null;

            Bitmap bmp = new Bitmap(originalImage);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    if (pixelColor.A > 0) // Nếu không trong suốt
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(pixelColor.A, newColor));
                    }
                }
            }
            return bmp;
        }
    }
}
