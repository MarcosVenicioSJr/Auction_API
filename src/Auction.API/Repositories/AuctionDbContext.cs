using Microsoft.EntityFrameworkCore;

namespace Auction.API.Repositories;

public class AuctionDbContext : DbContext
{
    public DbSet<Entities.Auction> Auctions { get; set; }
    public DbSet<Entities.User> Users { get; set; }
    public DbSet<Entities.Offer> Offers { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=C:\Users\USER\Project_Auction.db");
    }
}