using System;

namespace Skynet_Ecommerce.BLL.Services
{
    public interface ISellerDashboardService
    {
        SellerDashboardData GetDashboardData(int shopId);
        void Dispose();
    }
}