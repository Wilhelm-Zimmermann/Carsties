using System.ComponentModel.DataAnnotations;

namespace AuctionService.DTOs;

public class UpdateAuctionDto
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int? Year { get; set; }
    public string Color { get; set; }
    public int? Mileage { get; set; }
    public string ImageUrl { get; set; }
    public int ReservedPrice { get; set; }
    public DateTime AuctionEnd { get; set; }
}
