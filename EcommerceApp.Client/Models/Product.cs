namespace EcommerceApp.Client.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "string.Empty";
    public string Description { get; set; } = "string.Empty";
    public Category? Category { get; set; }
    public int CategoryId { get; set; } = 0;
    public double Price { get; set; } = 0.0;
    public decimal Quantity { get; set; } = 0;
    public string Image { get; set; }
}

