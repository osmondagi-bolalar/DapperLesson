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
            var result = await _dapper.Create<PersonModel>(@$"insert into Person(fullname, login, password, image_url) 
                         values('{model.FullName}', '{model.Login}', '{model.Password}', '{model.ImageUrl}')", null, CommandType.Text);
            return result;
        }

        public async Task<bool> Delete(int Id)
        {
            await _dapper.Delete<bool>($"delete from Person where Id = {Id}", null, CommandType.Text);
            return true;
        }

        public async Task<PersonModel> Get(int Id)
        {
            var result = await _dapper.Get<PersonModel>($"select * from Person where Id = {Id}", null, CommandType.Text);
            return result;
        }

        public async Task<IEnumerable<PersonModel>> GetAll()
        {
            var results = await _dapper.GetAll<PersonModel>("select * from Person", null, CommandType.Text);
            return results;
        }

        public async Task<PersonModel> Update(int Id, PersonModel model)
        {
            var result = await _dapper.Update<PersonModel>($@"update Person set FullName = {model.FullName}, Login = {model.Login}, 
                                                Password = {model.Password}, ImageUrl = {model.ImageUrl} where Id = {Id}", null, CommandType.Text);
            return result;
        }
    }
}
