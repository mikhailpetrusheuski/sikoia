using Company.Integration.Infrastructure.Factories;
using Company.Integration.Infrastructure.Services;

namespace Company.Integration.Factories;

public class CompanyServiceFactory : ICompanyServiceFactory
{
    private readonly IEnumerable<ICompanyService> _companyServices;

    public CompanyServiceFactory(IEnumerable<ICompanyService> companyServices)
    {
        _companyServices = companyServices;
    }

    public IEnumerable<ICompanyService> Create(string jurisdictionCode, string companyNumber)
    {
        IEnumerable<ICompanyService> companyServices = _companyServices.Where(service =>
            service.SupportedCompanyNumbersPerJurisdictionCode.ContainsKey(jurisdictionCode) &&
            service.SupportedCompanyNumbersPerJurisdictionCode[jurisdictionCode].Contains(companyNumber))
            .ToList();

        if (!companyServices.Any())
        {
            throw new Exception(
                $"No service(s) found that supports jurisdiction code '{jurisdictionCode}' and company number '{companyNumber}'");
        }

        return companyServices;
    }
}