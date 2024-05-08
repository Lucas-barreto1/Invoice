namespace Invoice.Core.Dtos;

public class ProductsByCustomerResponseDto
{
    public string CustomerName { get; set; }
    public List<string> ProductsNames { get; set; }
}