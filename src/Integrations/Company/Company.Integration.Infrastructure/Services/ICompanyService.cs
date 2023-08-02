namespace Company.Integration.Infrastructure.Services;

public interface ICompanyService
{
    Dictionary<string, HashSet<string>> SupportedCompanyNumbersPerJurisdictionCode { get; }

    Task<Domain.Models.Company?> GetCompanyDataAsync(string jurisdictionCode, string companyNumber);
}