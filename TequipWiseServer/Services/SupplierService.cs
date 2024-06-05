using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TequipWiseServer.Data;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;

namespace TequipWiseServer.Services
{
    public class SupplierService : Isupplier
    {
        private readonly AppDbContext _dbContext;

        public SupplierService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> GetSuppliersCount()
        {
            return await _dbContext.Suppliers.CountAsync();
        }
        public async Task<IActionResult> AddSuplier(Supplier supplier)
        {
            _dbContext.Suppliers.Add(supplier);
            await _dbContext.SaveChangesAsync();
            return new OkObjectResult(supplier);
        }

        public async Task<IActionResult> DeleteSuplier(string id)
        {
            var supplier = await _dbContext.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return new NotFoundResult();
            }

            _dbContext.Suppliers.Remove(supplier);
            await _dbContext.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await _dbContext.Suppliers.Include(s => s.Equipements).ToListAsync();
        }


        public async Task<IActionResult> UpdateUser(string suplierId, Supplier supplier)
        {
            var existingSupplier = await _dbContext.Suppliers.FindAsync(suplierId);
            if (existingSupplier == null)
            {
                return new NotFoundResult();
            }

            existingSupplier.suuplier_name = supplier.suuplier_name;
            existingSupplier.address = supplier.address;
            existingSupplier.email = supplier.email;

            _dbContext.Suppliers.Update(existingSupplier);
            await _dbContext.SaveChangesAsync();
            return new OkObjectResult(existingSupplier);
        }
        //is a best practice if you want to get just a small informations using Dynamic
        public async Task<List<dynamic>> GetSupplierInfoAsync()
        {
            return await _dbContext.Suppliers
                .AsNoTracking()
                .Select(s => new
                {
                    SupplierId = s.SuplierId,
                    SupplierName = s.suuplier_name
                })
                .Cast<dynamic>()
                .ToListAsync();
        }
    }
}
