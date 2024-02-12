using Suppliers.Infrastructure.Models;

namespace Suppliers.Infrastructure;

public interface ISupplierInfrastructure
{
    public Task<Supplier> GetSupplierById(int id);
    public Task<IEnumerable<Supplier>> GetSuppliers();
    public Task<Supplier> AddSupplier(Supplier supplier);
    public Task<Supplier> UpdateSupplier(Supplier supplier);
    public Task<Supplier> DeleteSupplier(int id);
}