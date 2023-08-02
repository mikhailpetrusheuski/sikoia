using Company.Integration.CompanyA.Models;
using Mapster;
using Newtonsoft.Json;

namespace Company.Integration.CompanyA.Services;

public class CompanyServiceA : BaseCompanyService
{
    public CompanyServiceA(HttpClient httpClient) : base(httpClient)
    {
    }

    public override Dictionary<string, HashSet<string>> SupportedCompanyNumbersPerJurisdictionCode =>
        new()
        {
            {
                "de", new HashSet<string>
                {
                    "3333",
                    "4444"
                }
            },
            {
                "uk", new HashSet<string>
                {
                    "1111",
                    "2222"
                }
            }
        };

    protected override Domain.Models.Company? GetCompanyFromResponse(string responseString)
    {
        CompanyAResponse? companyResponse = JsonConvert.DeserializeObject<CompanyAResponse>(responseString);
        return companyResponse?.Adapt<Domain.Models.Company>();
    }

    protected override string GetCompanyDataEndpoint(string jurisdictionCode, string companyNumber) =>
        $"v1/company/{jurisdictionCode}/{companyNumber}";
}