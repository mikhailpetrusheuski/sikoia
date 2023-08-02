using Company.Integration.CompanyA.MappingProfiles;
using Company.Integration.CompanyB.MappingProfiles;

namespace Api.Extensions;

public static class MappingConfigExtensions
{
    public static void RegisterMappings(this IServiceCollection services)
    {
        new CompanyAMappingProfile();
        new CompanyBMappingProfile();
        
    }
}