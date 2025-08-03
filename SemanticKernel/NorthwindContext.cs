using Microsoft.EntityFrameworkCore;
using Microsoft.SemanticKernel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SemanticKernel;

internal class NorthwindContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Supplier> Suppliers { get; set; }
}

internal class Supplier
{
    [Key]
    public int SupplierID { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Country { get; set; }

    public bool Active { get; set; }
}

internal class SupplierPlugin(NorthwindContext context)
{
    [KernelFunction("get_suppliers")]
    [Description("Gets a list of all suppliers and their active status")]
    public async Task<List<Supplier>> GetLightsAsync()
    {
        return await context.Suppliers.ToListAsync();
    }

    [KernelFunction("change_supplier_state")]
    [Description("Changes the active status of the supplier")]
    public async Task<Supplier?> ChangeStateAsync(int id, bool active)
    {
        var supplier = await context.Suppliers.FirstOrDefaultAsync(s => s.SupplierID == id);
        if (supplier == null) { return null; }

        await context.Suppliers
             .Where(s => s.SupplierID == id)
             .ExecuteUpdateAsync(l => l.SetProperty(p => p.Active, active));

        supplier.Active = active;
        return supplier;
    }
}