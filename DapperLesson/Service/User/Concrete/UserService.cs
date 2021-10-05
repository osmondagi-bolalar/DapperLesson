using Dapper;
using DapperLesson.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperLesson.Service.User.Concrete
{
    public class UserService : IUserService
    {
        public UserService(IDapper dapper)
        {
            _dapper = dapper;
        }
        private readonly IDapper _dapper;

        public async Task<PersonModel> Create(PersonModel model)
        {
            DynamicParameters pars = new DynamicParameters();
            pars.Add("FullName", model.FullName);
            pars.Add("Login", model.Login);
            pars.Add("Password", model.Password);
            pars.Add("ImageUrl", model.ImageUrl);

            var result = await _dapper.Create<PersonModel>(@$"CreatePerson", pars, CommandType.StoredProcedure);
            return result;
        }

        public async Task<bool> Delete(int Id)
        {
            DynamicParameters pars = new DynamicParameters();
            pars.Add("Id", Id);
            await _dapper.Delete<bool>($"DeletePerson", pars, CommandType.StoredProcedure);
            return true;
        }

        public async Task<PersonModel> Get(int Id)
        {
            DynamicParameters pars = new DynamicParameters();
            pars.Add("Id", Id);
            var result = await _dapper.Get<PersonModel>($"GetPersonById", pars, CommandType.StoredProcedure);
            return result;
        }

        public async Task<IEnumerable<PersonModel>> GetAll()
        {
            var results = await _dapper.GetAll<PersonModel>("[dbo].[GetAllPersons]", null, CommandType.StoredProcedure);
            return results;
        }

        public async Task<PersonModel> Update(int Id, PersonModel model)
        {
            DynamicParameters pars = new DynamicParameters();
            pars.Add("Id", Id);
            pars.Add("FullName", model.FullName);
            pars.Add("Login", model.Login);
            pars.Add("Password", model.Password);
            pars.Add("ImageUrl", model.ImageUrl);

            var result = await _dapper.Update<PersonModel>("[dbo].[UpdatePerson]", pars, CommandType.StoredProcedure);
            return result;
        }
    }
}
