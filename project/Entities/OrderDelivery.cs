

public class OrderDelivery
{
    public int DeliveryID { get; set; }
    public int OrderID { get; set; }
    public int? EmployeeID { get; set; }
    public string DeliveryAddress { get; set; }
    public string DeliveryStatus { get; set; } = "Pending";
    public DateTime DeliveryDate { get; set; }

}

