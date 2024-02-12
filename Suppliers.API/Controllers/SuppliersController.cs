using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Suppliers.Domain;
using Suppliers.Infrastructure;
using Suppliers.Infrastructure.Models;

namespace Suppliers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierDomain _supplierDomain;
        private readonly ISupplierInfrastructure _supplierInfrastructure;

        public SuppliersController(ISupplierDomain supplierDomain, ISupplierInfrastructure supplierInfrastructure)
        {
            _supplierDomain = supplierDomain ?? throw new ArgumentNullException(nameof(supplierDomain));
            _supplierInfrastructure = supplierInfrastructure ?? throw new ArgumentNullException(nameof(supplierInfrastructure));
        }

        // GET: api/<SuppliersController>
        [HttpGet]
        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await _supplierDomain.GetSuppliers();
        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplierById(int id)
        {
            var supplier = await _supplierDomain.GetSupplierById(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier;
        }

        // POST api/<SuppliersController>
        [HttpPost]
        public async Task<ActionResult<Supplier>> AddSupplier([FromBody] Supplier supplier)
        {
            var addedSupplier = await _supplierInfrastructure.AddSupplier(supplier);
            return CreatedAtAction(nameof(GetSupplierById), new { id = addedSupplier.Id }, addedSupplier);
        }

        // PUT api/<SuppliersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, [FromBody] Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return BadRequest();
            }

            await _supplierInfrastructure.UpdateSupplier(supplier);

            return NoContent();
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var existingSupplier = await _supplierInfrastructure.GetSupplierById(id);
            if (existingSupplier == null)
            {
                return NotFound();
            }

            await _supplierInfrastructure.DeleteSupplier(id);

            return NoContent();
        }
    }
}
