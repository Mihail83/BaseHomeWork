using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseHomeWork.Interface.Repository;
using BaseHomeWork.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace BaseHomeWork.DAL
{
    public class ADO_GoodOnlyRead : IRepo_OnlyRead<Good>
    {
        private readonly string _connectionString ;
        public ADO_GoodOnlyRead([FromServices]IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LocalSQLExpress");
        }
        public IEnumerable<Good> GetALL()
        {
            var goods = new List<Good>();

            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand($"Select * from [Good]", connection);
            command.CommandType = CommandType.Text;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {                             
                goods.Add(CreateGoodFromReader(reader));
            }
            return goods;
        }

        public Good GetbyID(int ID)
        {
            var good = new Good();

            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand($"Select * from [Good] where [Good].[ID]= {ID}", connection);
            command.CommandType = CommandType.Text;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                good = CreateGoodFromReader(reader);
            }
            return good;
        }

        static Good CreateGoodFromReader(SqlDataReader reader)
        {
            var good = new Good
            {
                ID = Convert.ToInt32(reader["ID"]),
                Name = reader["Name"].ToString(),
                Price = Convert.ToDecimal(reader["Price"])
            };
            return good;
        }
    }
}
