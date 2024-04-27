namespace Invoice.Core.Dtos;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}