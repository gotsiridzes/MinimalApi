using AsyncApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncApi.Data;

public class AppDbContext : DbContext
{
	public DbSet<ListingRequest> ListingRequests => Set<ListingRequest>();

	public AppDbContext(DbContextOptions options) 
		: base(options)
	{ }
}