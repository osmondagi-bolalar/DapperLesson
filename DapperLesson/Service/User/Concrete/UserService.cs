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
            var result = await _dapper.Create<PersonModel>(@$"insert into person(fullname, login, password, image_url) 
                         values('{model.FullName}', '{model.Login}', '{model.Password}', '{model.ImageUrl}')", null, CommandType.Text);
            return result;
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonModel> Get(int Id)
        {
            var result = await _dapper.Get<PersonModel>($"select * from person where user_id = {Id}", null, CommandType.Text);
            return result;
        }

        public async Task<IEnumerable<PersonModel>> GetAll()
        {
            var results = await _dapper.GetAll<PersonModel>("select * from person", null, CommandType.Text);
            return results;
        }

        public Task<PersonModel> Update(int Id, PersonModel model)
        {
            throw new NotImplementedException();
        }
    }
}
