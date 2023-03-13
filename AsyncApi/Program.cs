using AsyncApi.Data;
using AsyncApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(ops =>
	ops.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
var app = builder.Build();

app.UseHttpsRedirection();

app.MapPost("api/v1/products", async (AppDbContext context, ListingRequest? request) =>
{
	if (request is null) return Results.BadRequest();

	request.RequestStatus = "ACCEPT";
	request.EstimatedCompletionTime = "2023-03-13:16:38";

	await context.ListingRequests.AddAsync(request);

	await context.SaveChangesAsync();
	return Results.Accepted($"api/v1/productstatus/{request.RequestId}", request);
});

app.Run();