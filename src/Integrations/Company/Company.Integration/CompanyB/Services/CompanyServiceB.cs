using Company.Integration.CompanyB.Models;
using Mapster;
using Newtonsoft.Json;

namespace Company.Integration.CompanyB.Services;

public class CompanyServiceB : BaseCompanyService
{
    public CompanyServiceB(HttpClient httpClient) : base(httpClient)
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
                "nl", new HashSet<string>
                {
                    "5555",
                    "6666"
                }
            }
        };

    protected override Domain.Models.Company? GetCompanyFromResponse(string responseString)
    {
        CompanyBResponse? companyResponse = JsonConvert.DeserializeObject<CompanyBResponse>(responseString);
        return companyResponse?.Adapt<Domain.Models.Company>();
    }

    protected override string GetCompanyDataEndpoint(string jurisdictionCode, string companyNumber) =>
        $"v1/company-data?jurisdictionCode={jurisdictionCode}&companyNumber={companyNumber}";
}