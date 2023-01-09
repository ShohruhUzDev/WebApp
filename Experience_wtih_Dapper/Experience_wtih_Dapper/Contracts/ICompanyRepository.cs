using Experience_wtih_Dapper.Dto;
using Experience_wtih_Dapper.Entities;

namespace Experience_wtih_Dapper.Contracts
{
    public interface ICompanyRepository
    {

        public ValueTask<IEnumerable<Company>> GetCompanies();
        public ValueTask<Company> GetCompanyById(int id);
        public ValueTask<Company> CreateCompany(CompanyForCreationDto company);

    }
}
