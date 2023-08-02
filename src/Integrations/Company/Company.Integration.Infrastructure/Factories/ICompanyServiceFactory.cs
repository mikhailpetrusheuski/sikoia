using Company.Integration.Infrastructure.Services;

namespace Company.Integration.Infrastructure.Factories;

public interface ICompanyServiceFactory
{
    IEnumerable<ICompanyService> Create(string jurisdictionCode, string companyNumber);
}