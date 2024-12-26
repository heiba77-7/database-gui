public class Payment
{
    public int PaymentID { get; set; }
    public int OrderID { get; set; }
    public string PaymentMethod { get; set; } = "Cash";
    public string PaymentStatus { get; set; } = "Pending";
    public DateTime PaymentDate { get; set; } = DateTime.Now;

}