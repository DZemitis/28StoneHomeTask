using HomeAssignmentCountriesApi.Models;
using Refit;

namespace HomeAssignmentCountriesApi.ApiLogic;

public interface IRestCountriesApi
{
    [Get("/v2/regionalbloc/eu")]
    Task<List<Country>> GetCountries();

    [Get("/v2/name/{name}")]
    Task<List<Country>> GetCountryByName(string name);
}