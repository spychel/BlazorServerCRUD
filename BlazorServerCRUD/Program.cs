global using BlazorServerCRUD.Data;
global using BlazorServerCRUD.Sevices.SuperHeroService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddHttpClient<ISuperHeroService, SuperHeroService>("asd", httpClient =>
{
	var url = Environment.GetEnvironmentVariable("ApiUrl");
	if (url is null)
		throw new NullReferenceException("ApiUrl variable does not exists");

	httpClient.BaseAddress = new Uri(url);
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
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.Run();
