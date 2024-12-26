public class Supply
{
    public int SupplyID { get; set; }
    public int SupplierID { get; set; }
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public Supplier Supplier { get; set; }
}
