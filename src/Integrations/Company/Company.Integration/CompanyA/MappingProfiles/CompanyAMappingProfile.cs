using Company.Integration.CompanyA.Extensions;
using Company.Integration.CompanyA.Models;
using Mapster;

namespace Company.Integration.CompanyA.MappingProfiles;

public class CompanyAMappingProfile
{
    public CompanyAMappingProfile()
    {
        TypeAdapterConfig<FullDate?, string?>
            .NewConfig()
            .MapWith(src => src.ToFormattedDate());
        
        TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);

        TypeAdapterConfig<CompanyAResponse, Domain.Models.Company>
            .NewConfig()
            .Map(dest => dest.CompanyNumber, src => src.CompanyNumber)
            .Map(dest => dest.CompanyName, src => src.CompanyName)
            .Map(dest => dest.JurisdictionCode, src => src.JurisdictionCode)
            .Map(dest => dest.CompanyType, src => src.CompanyType)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.DateFrom, src => src.DateEstablished)
            .Map(dest => dest.DateTo, src => src.DateDissolved)
            .Map(dest => dest.Address, src => src.OfficialAddress.ToFormattedAddress())
            .Map(dest => dest.Officers, src => src.Officers)
            .Map(dest => dest.Owners, src => src.Owners);
    }
}