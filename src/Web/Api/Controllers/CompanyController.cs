using Company.Integration.Infrastructure.Factories;
using Company.Integration.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers;

public class CompanyController : ControllerBase
{
    private readonly ICompanyServiceFactory _companyServiceFactory;

    public CompanyController(ICompanyServiceFactory companyServiceFactory)
    {
        _companyServiceFactory = companyServiceFactory;
    }

    [HttpGet("v1/company/{jurisdiction_code}/{company_number}")]
    public async Task<ActionResult<Domain.Models.Company>> Get(string jurisdiction_code, string company_number)
    {
        try
        {
            var jurisdictionCode = jurisdiction_code.ToLower();
            var companyNumber = company_number.ToLower();
            var services = _companyServiceFactory.Create(jurisdictionCode, companyNumber.ToLower());
            var companyData = new List<Domain.Models.Company>();
            foreach (ICompanyService service in services)
            {
                Domain.Models.Company? data = await service.GetCompanyDataAsync(jurisdictionCode, companyNumber);
                if (data != null)
                {
                    companyData.Add(data);
                }
            }
            
            return Ok(CompanyHelper.MergeCompanyData(companyData));
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}