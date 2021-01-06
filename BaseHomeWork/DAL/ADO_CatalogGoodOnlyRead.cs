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
    public class ADO_CatalogGoodOnlyRead : IRepo_OnlyRead<CatalogGood>
    {
        private readonly string _connectionString;
        public ADO_CatalogGoodOnlyRead([FromServices] IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LocalSQLExpress");
        }
        public IEnumerable<CatalogGood> GetALL()
        {
            var goods = new List<CatalogGood>();

            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand($"Select * from [CatalogGood]", connection)
            {
                CommandType = CommandType.Text
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                goods.Add(CreateGoodFromReader(reader));
            }
            return goods;
        }

        public CatalogGood GetbyID(int ID)   //return only first result
        {
            var good = new CatalogGood();

            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand($"Select * from [CatalogGood] where [CatalogGood].[CatalogID]= {ID}", connection);
            command.CommandType = CommandType.Text;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                good = CreateGoodFromReader(reader);
            }
            return good;
        }

        static CatalogGood CreateGoodFromReader(SqlDataReader reader)
        {
            var catalog = new CatalogGood
            {
                GoodID = Convert.ToInt32(reader["GoodID"]),
                CatalogID = Convert.ToInt32(reader["CatalogID"])
            };
            return catalog;
        }
    }
}
