

public interface ISupplierService
{
    List<Supplier> GetSuppliers();
    Supplier GetSupplier(int id);
    Supplier AddSupplier(Supplier supplier);
    Supplier UpdateSupplier(Supplier supplier);
    Supplier DeleteSupplier(int id);

    List<Supplier> GetSuppliersBySupplierName(string supplierName);
}