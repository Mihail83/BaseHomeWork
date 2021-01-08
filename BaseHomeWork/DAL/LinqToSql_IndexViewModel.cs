using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseHomeWork.Interface.Repository;
using BaseHomeWork.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data.Linq;

namespace BaseHomeWork.DAL
{
    public class LinqToSql_IndexViewModel : IRepo_IndexViewModel
    {
        private readonly string _connection;
        public LinqToSql_IndexViewModel([FromServices] IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("LocalSQLExpress");            
        }
        public IndexViewModel GetByCatalogID(int catalogID)
        {
            DataContext db = new DataContext(_connection);
            var allCatalogs = db.GetTable<Catalog>();
            var goods = from gd in db.GetTable<Good>()
                         join catgood in db.GetTable<CatalogGood>() on gd.ID equals catgood.GoodID
                         where catgood.CatalogID == catalogID
                         select gd;
           
            return new IndexViewModel(allCatalogs, goods); 
        }
    }
}
