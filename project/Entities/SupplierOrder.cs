public class SupplierOrder
{
    public int SupplierOrderID { get; set; }
    public int SupplierID { get; set; }
    public int? EmployeeID { get; set; }
    public decimal TotalCost { get; set; }
    public DateTime OrderDate { get; set; }
    public Supplier Supplier { get; set; }
    public Employee Employee { get; set; }
}