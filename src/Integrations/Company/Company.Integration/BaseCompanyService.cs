using Company.Integration.Infrastructure.Services;

namespace Company.Integration;

public abstract class BaseCompanyService : ICompanyService
{
    private readonly HttpClient _httpClient;

    protected BaseCompanyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public abstract Dictionary<string, HashSet<string>> SupportedCompanyNumbersPerJurisdictionCode { get; }
    
    public async Task<Domain.Models.Company?> GetCompanyDataAsync(string jurisdictionCode, string companyNumber)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(GetCompanyDataEndpoint(jurisdictionCode, companyNumber));
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseString = await response.Content.ReadAsStringAsync();
            return GetCompanyFromResponse(responseString);
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    
    protected abstract Domain.Models.Company? GetCompanyFromResponse(string responseString);
    
    protected abstract string GetCompanyDataEndpoint(string jurisdictionCode, string companyNumber);
}