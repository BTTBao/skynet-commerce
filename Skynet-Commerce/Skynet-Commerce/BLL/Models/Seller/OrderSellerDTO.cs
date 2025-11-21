public class OrderSellerDTO
{
    public int OrderID { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }

    public string ProductName { get; set; }
    public string Variant { get; set; }  
    public string ImageURL { get; set; }

    public DateTime CreatedAt { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal SubTotal { get; set; }

    public decimal TotalOrderAmount { get; set; }
    public string Status { get; set; }

    public string AddressFull { get; set; }
}
