
using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Models;

namespace TequipWiseServer.Interfaces
{
    public interface Isupplier
    {

        Task<IEnumerable<Supplier>> GetSuppliers();

        Task<IActionResult> AddSuplier(Supplier supplier);

        Task<IActionResult> DeleteSuplier(string id);
        Task<IActionResult> UpdateUser(string suplierId, Supplier supplier);

        Task<int> GetSuppliersCount();

        Task<List<dynamic>> GetSupplierInfoAsync();
    }
}
