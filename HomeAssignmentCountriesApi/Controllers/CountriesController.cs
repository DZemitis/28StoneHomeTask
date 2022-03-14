using HomeAssignmentCountriesApi.ApiLogic;
using HomeAssignmentCountriesApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace HomeAssignmentCountriesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : Controller
{
    private readonly IRestCountriesApi _countries;

    public CountriesController(IRestCountriesApi countries)
    {
        _countries = countries;
    }

    [HttpGet]
    [Route("TopTenByPopulation")]
    public async Task<IActionResult> GetTopTenCountriesByPopulation()
    {
        var getAllEuCountries = await _countries.GetCountries();

        return Ok(DataLogic.SortByPopulation(getAllEuCountries).Take(10));
    }

    [HttpGet]
    [Route("TopTenByDensity")]
    public async Task<IActionResult> GetTopTenCountriesByDensity()
    {
        var getAllEuCountries = await _countries.GetCountries();

        return Ok(DataLogic.SortByDensity(getAllEuCountries).Take(10));
    }

    [HttpGet]
    [Route("{name}")]
    public async Task<IActionResult> GetCountryByName(string name)
    {
        var getAllEuCountries = await _countries.GetCountries();
        var countryByName = await _countries.GetCountryByName(name);
        var selectedCountry = countryByName.FirstOrDefault(x => x.Name == name);

        if (selectedCountry == null || !DataLogic.IsValidEuCountry(getAllEuCountries, selectedCountry))
        {
            return BadRequest($"There is no such country as {name} in European Union");
        }

        return Ok(DataLogic.GetCountryWithSelectedProperties(countryByName));
    }
}