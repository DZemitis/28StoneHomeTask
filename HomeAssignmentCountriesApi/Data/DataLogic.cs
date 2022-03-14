using System.Collections;
using HomeAssignmentCountriesApi.Models;

namespace HomeAssignmentCountriesApi.Data;

public static class DataLogic
{
    private static IEnumerable<Country> EuropeUnionCountries(List<Country> country)
    {
        var europeanUnionCountries = country.Where(c => c.Independent);

        return europeanUnionCountries;
    }

    public static IEnumerable<Country> SortByDensity(List<Country> country)
    {
        var europeanUnionCountries = EuropeUnionCountries(country);
        var sortByDensityTop10 = europeanUnionCountries.OrderByDescending(c => c.Population / c.Area);

        return sortByDensityTop10;
    }

    public static IEnumerable<Country> SortByPopulation(List<Country> country)
    {
        var europeanUnionCountries = EuropeUnionCountries(country);
        var sortByPopulationTop10 = europeanUnionCountries.OrderByDescending(c => c.Population);

        return sortByPopulationTop10;
    }

    public static bool IsValidEuCountry(List<Country> europeanUnionCountries, Country name)
    {
        return europeanUnionCountries.Any(c => c.Name == name.Name);
    }

    public static IEnumerable GetCountryWithSelectedProperties(List<Country> country)
    {
        return country.Select(c => new
        {
            c.Area,
            c.NativeName,
            c.Population,
            c.TopLevelDomain
        });
    }
    
    public static IEnumerable GetCountryWithSelectedProperties(Country country)
    {
        var expectedParamaters = new Country()
        {
            Area = country.Area,
            Population = country.Population,
            NativeName = country.NativeName,
            TopLevelDomain = country.TopLevelDomain
        };
        return null;
    }
}