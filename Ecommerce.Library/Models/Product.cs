namespace Ecommerce.Library.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
    public double Price { get; set; } = 0.0;
    public decimal Quantity { get; set; } = 0;
    public string Image { get; set; }

}

