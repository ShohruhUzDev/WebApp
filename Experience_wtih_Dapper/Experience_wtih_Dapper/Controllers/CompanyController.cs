using Experience_wtih_Dapper.Contracts;
using Experience_wtih_Dapper.Dto;
using Experience_wtih_Dapper.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Experience_wtih_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task< IActionResult> GetAllCompanies()
        {
            try
            {
                var companies = await _companyRepository.GetCompanies();
                return Ok(companies);

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id }", Name ="CompanyById") ]
        public async Task<IActionResult> GetCompany(int id)
        {
            try
            {
                var company = await _companyRepository.GetCompanyById(id);

                if (company == null)
                    return NotFound();

                return Ok(company);
            }
            catch(Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        [HttpPost]
        public async ValueTask<IActionResult> CraeteCompany(CompanyForCreationDto company)
        {
            try
            {
                var createCompany = await _companyRepository.CreateCompany(company);
                return CreatedAtRoute("CompanyById", new {id= createCompany.Id }, createCompany);
                //return Ok(createCompany);

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
