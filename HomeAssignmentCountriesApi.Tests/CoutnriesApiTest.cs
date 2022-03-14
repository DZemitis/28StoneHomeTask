using System.Collections.Generic;
using System.Linq;
using HomeAssignmentCountriesApi.Data;
using HomeAssignmentCountriesApi.Models;
using Newtonsoft.Json;
using Xunit;

namespace HomeAssignmentCountriesApi.Tests;

public class UnitTest1
{
    private readonly List<Country> _europeanCountriesTestList = new()
    {
        new Country
        {
            Name = "Latvia",
            Area = 2,
            Population = 10,
            TopLevelDomain = new List<string> {".lv"},
            NativeName = "Latvija",
            Independent = true
        },
        new Country
        {
            Name = "Germany",
            Area = 3,
            Population = 20,
            TopLevelDomain = new List<string> {".gr"},
            NativeName = "Deutschland",
            Independent = true
        },
        new Country
        {
            Name = "France",
            Area = 4,
            Population = 30,
            TopLevelDomain = new List<string> {".fr"},
            NativeName = "France",
            Independent = true
        }
    };

    [Fact]
    public void SortByPopulation_ReturnSortedCountryListByPopulationDescending_ShouldBeEqual()
    {
        //Arrange
        var expectedCountryList = new List<Country>
        {
            new Country
            {
                Name = "France",
                Area = 4,
                Population = 30,
                TopLevelDomain = new List<string> {".fr"},
                NativeName = "France",
                Independent = true
            },
            new Country
            {
                Name = "Germany",
                Area = 3,
                Population = 20,
                TopLevelDomain = new List<string> {".gr"},
                NativeName = "Deutschland",
                Independent = true
            },
            new Country
            {
                Name = "Latvia",
                Area = 2,
                Population = 10,
                TopLevelDomain = new List<string> {".lv"},
                NativeName = "Latvija",
                Independent = true
            },
        };

        //Act
        var result = DataLogic.SortByPopulation(_europeanCountriesTestList);

        //Assert
        Assert.Equal(JsonConvert.SerializeObject(expectedCountryList), JsonConvert.SerializeObject(result));
    }

    [Fact]
    public void SortByDensity_ReturnSortedCountryListByDensity_ShouldBeEqual()
    {
        //Arrange
        var expectedCountryList = new List<Country>
        {
            new Country
            {
                Name = "France",
                Area = 4,
                Population = 30,
                TopLevelDomain = new List<string> {".fr"},
                NativeName = "France",
                Independent = true
            },
            new Country
            {
                Name = "Germany",
                Area = 3,
                Population = 20,
                TopLevelDomain = new List<string> {".gr"},
                NativeName = "Deutschland",
                Independent = true
            },
            new Country
            {
                Name = "Latvia",
                Area = 2,
                Population = 10,
                TopLevelDomain = new List<string> {".lv"},
                NativeName = "Latvija",
                Independent = true
            },
        };

        //Act
        var result = DataLogic.SortByDensity(_europeanCountriesTestList);

        //Assert
        Assert.Equal(JsonConvert.SerializeObject(expectedCountryList), JsonConvert.SerializeObject(result));
    }

    [Fact]
    public void GetCountryByName_ShouldNotContainNameButContainSelectedProperties_ShouldPass()
    {
        //Arange
        var givenCountry = new List<Country>
        {
            new Country
            {
                Name = "Latvia",
                Area = 4,
                Population = 30,
                TopLevelDomain = new List<string> {".lv"},
                NativeName = "Latvija",
                Independent = true
            }
        };

        var expectedParamaters = givenCountry.Select(c => new
        {
            c.Area,
            c.NativeName,
            c.Population,
            c.TopLevelDomain
        });

        //Act
        var result = DataLogic.GetCountryWithSelectedProperties(givenCountry);

        //Assert
        Assert.DoesNotContain(result.ToString(), "Latvia");
        Assert.Equal(JsonConvert.SerializeObject(expectedParamaters), JsonConvert.SerializeObject(result));
    }

    [Fact]
    public void CheckIfCountryIsInEU_USA_ShouldReturnFalse()
    {
        //Arrange
        var givenCountry = new Country
        {
            Name = "USA",
            Area = 4,
            Population = 30,
            TopLevelDomain = new List<string> {".org"},
            NativeName = "America",
            Independent = true
        };

        //Act
        var result = DataLogic.IsValidEuCountry(_europeanCountriesTestList, givenCountry);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void CheckIfCountryIsInEU_Latvia_ShouldReturnTrue()
    {
        //Arrange
        var givenCountry = new Country
        {
            Name = "Latvia",
            Area = 2,
            Population = 10,
            TopLevelDomain = new List<string> {".lv"},
            NativeName = "Latvija",
            Independent = true
        };

        //Act
        var result = DataLogic.IsValidEuCountry(_europeanCountriesTestList, givenCountry);

        //Assert
        Assert.True(result);
    }
}