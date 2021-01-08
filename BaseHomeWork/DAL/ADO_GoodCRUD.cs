using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseHomeWork.Interface.Repository;
using BaseHomeWork.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace BaseHomeWork.DAL
{
    public class ADO_GoodCRUD : IRepo_CRUD<Good>
    {
        
        string _connectionString;
        public ADO_GoodCRUD(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateGood(Good good)
        {
            if (good != null)
            {
                using SqlConnection connection = new SqlConnection(_connectionString);                
                var command = new SqlCommand($"insert into Good ([ID], [Name], [Price]) values ({good.ID},'{good.Name}',{good.Price})", connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();                
            }
        }

        public void DeleteGood(Good good)
        {
            if (good != null)
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                var command = new SqlCommand($"Delete Good from Good where Good.ID= {good.ID}", connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();                
            }
        }

        public Good GetGood(int id)
        {
            Good good = new Good();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(   
                    $"Select Good.ID, Good.[Name], Good.Price, [Catalog].[Name] as [Catalog] from Good " +
                    $"inner join CatalogGood on Good.ID = [CatalogGood].[GoodID] " +
                    $"inner join[Catalog] on[Catalog].ID = CatalogGood.CatalogID " +
                    $"where Good.ID = {id}", connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    good.ID = Convert.ToInt32(reader["ID"]);
                    good.Name = reader["Name"].ToString();
                    good.Price = Convert.ToDecimal(reader["Price"]);
                   
                }
            }
            return good;
        }

        public IList<Good> GetGoods()
        {

            List<Good> goods = new List<Good>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(
                    $"Select Good.ID, Good.[Name], Good.Price, [Catalog].[Name] as [Catalog] from Good " +
                    $"inner join CatalogGood on Good.ID = [CatalogGood].[GoodID] " +
                    $"inner join[Catalog] on[Catalog].ID = CatalogGood.CatalogID", connection);

                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var good = new Good();
                    good.ID = Convert.ToInt32(reader["ID"]);
                    good.Name = reader["Name"].ToString();
                    good.Price = Convert.ToDecimal(reader["Price"]);                    
                    goods.Add(good);
                }
            }
            return goods;
        }

        public void UpdateGood(Good good)
        {
            if (good != null)
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                var command = new SqlCommand($"update Good set [Name]='{good.Name}', Price = {good.Price} where ID=  {good.ID}", connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();                
            }
        }
    }
}
