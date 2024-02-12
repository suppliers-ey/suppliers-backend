using Suppliers.Infrastructure;
using Suppliers.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suppliers.Domain
{
    public class SupplierDomain : ISupplierDomain
    {
        private readonly ISupplierInfrastructure _supplierInfrastructure;

        public SupplierDomain(ISupplierInfrastructure supplierInfrastructure)
        {
            _supplierInfrastructure = supplierInfrastructure;
        }


        public Task<Supplier> GetSupplierById(int id)
        {
            return _supplierInfrastructure.GetSupplierById(id);
        }

        public Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return _supplierInfrastructure.GetSuppliers();
        }

        public Task<Supplier> AddSupplier(Supplier supplier)
        {
            return _supplierInfrastructure.AddSupplier(supplier);
        }

        public Task<Supplier> UpdateSupplier(Supplier supplier)
        {
            return _supplierInfrastructure.UpdateSupplier(supplier);
        }

        public Task<Supplier> DeleteSupplier(int id)
        {
            return _supplierInfrastructure.DeleteSupplier(id);
        }
    }
}