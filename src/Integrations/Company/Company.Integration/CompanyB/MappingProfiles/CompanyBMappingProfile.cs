using Company.Integration.CompanyB.Models;
using Mapster;

namespace Company.Integration.CompanyB.MappingProfiles;

public class CompanyBMappingProfile
{
    public CompanyBMappingProfile()
    {
        TypeAdapterConfig<CompanyBResponse, Domain.Models.Company>.NewConfig()
            .Map(dest => dest.CompanyNumber, src => src.CompanyNumber).Map(dest => dest.CompanyName, src => src.CompanyName)
            .Map(dest => dest.JurisdictionCode, src => src.Country)
            .Map(dest => dest.DateFrom, src => src.DateFrom)
            .Map(dest => dest.DateTo, src => src.DateTo)
            .Map(dest => dest.Address, src => src.Address)
            .Map(dest => dest.Activities, src => src.Activities)
            .Map(dest => dest.RelatedPersons, src => src.RelatedPersons)
            .Map(dest => dest.RelatedCompanies, src => src.RelatedCompanies);
    }
}