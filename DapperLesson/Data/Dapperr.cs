﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperLesson.Data
{
    public class Dapperr : IDapper
    {
        public Dapperr(IConfiguration config)
        {
            _config = config;
        }
        private readonly IConfiguration _config;
        private readonly string _connectionString = "DefaultConnection";

        public async Task<T> Create<T>(string query, DynamicParameters pars, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = GetConnection();
            return await db.QueryFirstOrDefaultAsync<T>(query, pars, commandType: commandType);
        }

        public async Task<T> Delete<T>(string query, DynamicParameters pars, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = GetConnection();
            return await db.QueryFirstOrDefaultAsync<T>(query, pars, commandType: commandType);
        }

        public async Task<T> Get<T>(string query, DynamicParameters pars, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = GetConnection();
            return await db.QueryFirstOrDefaultAsync<T>(query, pars, commandType: commandType);
        }

        public async Task<IEnumerable<T>> GetAll<T>(string query, DynamicParameters pars, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = GetConnection();
            return await db.QueryAsync<T>(query, pars, commandType: commandType);
        }

        public DbConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString(_connectionString));
        }

        public async Task<T> Update<T>(string query, DynamicParameters pars, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = GetConnection();
            IEnumerable<T> results = await db.QueryAsync<T>(query, pars, commandType: commandType);
            return results.FirstOrDefault();
        }

        public void Dispose()
        {
            
        }
    }
}
