using DapperLesson.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperLesson.Service.User
{
    [Table(Schema = "dbo", Name = "person")]
    public class PersonModel
    {
        [Column(DbType = DbType.Int32, Name = "user_id")]
        public int Id { get; set; }

        [Column(DbType = DbType.String, Name = "fullname")]
        public string FullName { get; set; }

        [Column(DbType = DbType.String, Name = "login")]
        public string Login { get; set; }

        [Column(DbType = DbType.String, Name = "password")]
        public string Password { get; set; }

        [Column(DbType = DbType.String, Name = "image_url")]
        public string ImageUrl { get; set; }
    }
}
