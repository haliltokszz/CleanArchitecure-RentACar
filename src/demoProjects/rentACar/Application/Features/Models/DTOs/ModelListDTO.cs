namespace Application.Features.Models.DTOs;

public class ModelListDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string BrandName { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }
}