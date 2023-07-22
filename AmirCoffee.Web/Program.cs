using AmirCoffee.Web.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<AppDbContext>(serviceProvider =>
{
	var conString = builder.Configuration.GetConnectionString("DefaultConnection");

	if (string.IsNullOrWhiteSpace(conString))
	{
		throw new ArgumentException("Connection String Not Found.", $"Default Connection");
	}

	return new AppDbContext(conString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
