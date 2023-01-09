using Dapper;
using Experience_wtih_Dapper.Context;
using Experience_wtih_Dapper.Contracts;
using Experience_wtih_Dapper.Dto;
using Experience_wtih_Dapper.Entities;
using System.Data;

namespace Experience_wtih_Dapper.Repositroy
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;

        public CompanyRepository(DapperContext context)
        {
            _context = context;
        }

        public async ValueTask<Company> CreateCompany(CompanyForCreationDto company)
        {
            var query = " INSERT INTO Companies ( Name, Address, Country) Values (@Name, @Address, @Country)  SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", company.Name, DbType.String);
            parameters.Add("Address", company.Address, DbType.String);
            parameters.Add("Country", company.Country, DbType.String);

            using (var connection=_context.CreateConnection())
            {
            var Id=await  connection.QuerySingleAsync<int>(query, parameters);

                // var createCompany =  await GetCompanyById(Id);

                var result = new Company()
                {
                    Id = Id,
                    Name = company.Name,
                    Address = company.Address,
                    Country = company.Country
                };

                return result;

            }

                 
        }

        public async ValueTask<IEnumerable<Company>> GetCompanies()
        {
            var query = "SELECT * FROM Companies";
            using (var connection = _context.CreateConnection())
            {
                var companies=await connection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }

        public async ValueTask<Company> GetCompanyById(int id)
        {
            var query = $"SELECT * FROM Companies WHERE Id=@id";
            

            using(var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Company>(query ,new {id});
                return company;
            }
        }
    }
}
