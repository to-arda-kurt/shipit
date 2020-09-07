using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShipIt.Exceptions;
using ShipIt.Models.ApiModels;
using ShipIt.Repositories;

namespace ShipIt.Controllers
{
    [Route("companies")]
    public class CompanyController : ControllerBase
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet("{gcp}")]
        public CompanyResponse Get([FromRoute] string gcp)
        {
            if (gcp == null)
            {
                throw new MalformedRequestException("Unable to parse gcp from request parameters");
            }

            Log.Info($"Looking up company by name: {gcp}");

            var companyDataModel = _companyRepository.GetCompany(gcp);
            var company = new Company(companyDataModel);

            Log.Info("Found company: " + company);

            return new CompanyResponse(company);
        }

        [HttpPost("")]
        public Response Post([FromBody] AddCompaniesRequest requestModel)
        {
            List<Company> companiesToAdd = requestModel.companies;

            if (companiesToAdd.Count == 0)
            {
                throw new MalformedRequestException("Expected at least one <company> tag");
            }

            Log.Info("Adding companies: " + companiesToAdd);

            _companyRepository.AddCompanies(companiesToAdd);
            
            Log.Debug("Companies added successfully");

            return new Response {Success = true};
        }
    }
}
