using Shared;

namespace BlazorServerCRUD.Sevices.SuperHeroService;

public class SuperHeroService : HttpClient, ISuperHeroService
{
	private readonly HttpClient _http;

	public SuperHeroService(HttpClient http)
	{
		_http = http;
	}

	public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();
	public List<Comic> Comics { get; set; } = new List<Comic>();

	public Task CreateHero(SuperHero hero) => throw new NotImplementedException();

	public Task DeleteHero(int id) => throw new NotImplementedException();

	public Task GetComics() => throw new NotImplementedException();

	public Task<SuperHero> GetSingleHero(int id) => throw new NotImplementedException();

	public async Task GetSuperHeroes()
	{
		var result = await _http.GetFromJsonAsync<List<SuperHero>>("api/SuperHero");
		if (result != null)
			Heroes = result;
	}

	public Task UpdateHero(SuperHero hero) => throw new NotImplementedException();
}
