using Microsoft.EntityFrameworkCore;
using MinimalApi.Models;

namespace MinimalApi.Data;

public class AppDbContext : DbContext
{
	public DbSet<ListingRequest> ListingRequests => Set<ListingRequest>();

	public AppDbContext(DbContextOptions options) 
		: base(options)
	{ }
}