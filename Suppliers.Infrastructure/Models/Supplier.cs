namespace Suppliers.Infrastructure.Models;

public class Supplier
{
    public int Id { get; set; }
    public string LegalName { get; set; }
    public string TradeName { get; set; }
    public string TaxId { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string Address { get; set; }
    public string Country { get; set; }
    public double AnnualRevenue { get; set; }
    public DateTime LastEdited { get; set; }
    public string HighRisks { get; set; }
}