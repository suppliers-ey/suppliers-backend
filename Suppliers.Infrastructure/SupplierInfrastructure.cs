using Suppliers.Infrastructure.Context;
using Suppliers.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Suppliers.Infrastructure
{
    public class SupplierInfrastructure : ISupplierInfrastructure
    {
        private readonly SupplierContext _supplierContext;
        
        // Constructor
        public SupplierInfrastructure(SupplierContext supplierContext)
        {
            _supplierContext = supplierContext;
        }
        
        public async Task<Supplier> GetSupplierById(int id)
        {
            return await _supplierContext.Suppliers.FindAsync(id);
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await _supplierContext.Suppliers.ToListAsync();
        }

        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            _supplierContext.Suppliers.Add(supplier);
            await _supplierContext.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier> UpdateSupplier(Supplier supplier)
        {
            _supplierContext.Entry(supplier).State = EntityState.Modified;
            await _supplierContext.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier> DeleteSupplier(int id)
        {
            var supplier = await _supplierContext.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return null;
            }

            _supplierContext.Suppliers.Remove(supplier);
            await _supplierContext.SaveChangesAsync();
            return supplier;
        }
    }
}