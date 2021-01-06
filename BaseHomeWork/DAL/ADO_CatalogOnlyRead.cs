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
    public class ADO_CatalogOnlyRead : IRepo_OnlyRead<Catalog>
    {
        private readonly string _connectionString;
        public ADO_CatalogOnlyRead([FromServices] IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LocalSQLExpress");
        }
        public IEnumerable<Catalog> GetALL()
        {
            var goods = new List<Catalog>();

            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand($"Select * from [Catalog]", connection);
            command.CommandType = CommandType.Text;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                goods.Add(CreateGoodFromReader(reader));
            }
            return goods;
        }

        public Catalog GetbyID(int ID)
        {
            var good = new Catalog();

            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand($"Select * from [Catalog] where [Catalog].[ID]= {ID}", connection);
            command.CommandType = CommandType.Text;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                good = CreateGoodFromReader(reader);
            }
            return good;
        }

        static Catalog CreateGoodFromReader(SqlDataReader reader)
        {
            var catalog = new Catalog();
            catalog.ID = Convert.ToInt32(reader["ID"]);
            catalog.Name = reader["Name"].ToString();            
            return catalog;
        }
    }
}
