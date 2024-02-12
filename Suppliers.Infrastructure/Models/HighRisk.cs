namespace Suppliers.Infrastructure.Models;

public class HighRisk
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }
}