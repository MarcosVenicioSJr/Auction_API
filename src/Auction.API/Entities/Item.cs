using System.ComponentModel.DataAnnotations.Schema;
using Auction.API.Entities.Enums;

namespace Auction.API.Entities;

[Table("Items")]
public class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Brand { get; set; } = String.Empty;
    public Condition Condition { get; set; }
    public decimal BasePrice { get; set; }
    public int AuctionId { get; set; }
}