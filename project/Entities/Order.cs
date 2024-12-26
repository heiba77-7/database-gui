public class Order
{
    public int OrderID { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;

}