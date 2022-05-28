using Microsoft.AspNetCore.Mvc;

using Shared;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
	public static List<Comic> comics = new()
		{
			new Comic { Id = 1,Name = "Marvel" },
			new Comic { Id = 2, Name = "DC" }
		};

	public static List<SuperHero> heroes = new()
		{
			new SuperHero
			{
				Id = 1,
				FirstName = "Peter",
				LastName = "Parker",
				HeroName = "Spiderman",
				Comic = comics[0],
				ComicId = comics[0].Id
			},
			new SuperHero
			{
				Id = 1,
				FirstName = "Bruce",
				LastName = "Wayne",
				HeroName = "Batman",
				Comic = comics[1],
				ComicId = comics[1].Id
			},
		};

	[HttpGet]
	public async Task<ActionResult<List<SuperHero>>> GetSuperHeroesAsync() => Ok(heroes);

	[HttpGet("{id}")]
	public async Task<ActionResult<SuperHero>> GetSuperHerosAsync(int id)
	{
		var hero = heroes.FirstOrDefault(h => h.Id == id);
		return hero == null ? (ActionResult<SuperHero>)BadRequest("Очипка") : (ActionResult<SuperHero>)Ok(hero);
	}
}
