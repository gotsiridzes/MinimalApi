using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Dtos;
using MinimalApi.Models;

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

app.MapGet("api/v1/productstatus/{requestId}", (AppDbContext context, string requestId) =>
{
	var listingRequest = context.ListingRequests.FirstOrDefault(x => x.RequestId.Equals(requestId));
	
	if (listingRequest is null)
		return Results.NotFound();

	var listingStatus = new ListingStatus
	{
		RequestStatus = listingRequest.RequestStatus,
		ResourceUrl = string.Empty
	};

	if (listingRequest.RequestStatus!.ToUpper() == "COMPLETE")
	{
		listingStatus.ResourceUrl = $"api/v1/products/{Guid.NewGuid()}";
		return Results.Redirect($"http://localhost:5022/{listingStatus.ResourceUrl}");
	}

	listingStatus.EstimatedCompletionTime = "2023-03-13:18:00";
	return Results.Ok(listingStatus);
});


app.MapGet("api/v1/products/{requestId}", (string requestId) => Results.Ok("here would be final result"));

app.Run();