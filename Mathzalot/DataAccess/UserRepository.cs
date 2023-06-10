using System;
using MySql.Data.MySqlClient;

namespace Mathzalot.DataAccess
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}