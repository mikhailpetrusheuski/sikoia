using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace IntegrationTests;

public class ApiIntegrationTests
{
    private readonly HttpClient _client;

    public ApiIntegrationTests()
    {
        _client = new WebApplicationFactory<Program>().WithWebHostBuilder(_ =>
        {
            
        })
            .CreateClient();
    }

    [Theory]
    [InlineData("uk", "1111")]
    [InlineData("uk", "2222")]
    [InlineData("de", "3333")]
    [InlineData("de", "4444")]
    [InlineData("nl", "5555")]
    [InlineData("nl", "6666")]
    public async Task GetCompanyData_Should_Return_Correct_Data(string jurisdictionCode, string companyNumber)
    {
        // Act
        HttpResponseMessage response = await _client.GetAsync($"/v1/company/{jurisdictionCode}/{companyNumber}");

        // Assert
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        Domain.Models.Company? companyData = JsonConvert.DeserializeObject<Domain.Models.Company>(responseString);
        
        companyData?.JurisdictionCode.Should().Be(jurisdictionCode);
        companyData?.CompanyNumber.Should().Be(companyNumber);
    }
}
