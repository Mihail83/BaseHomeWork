using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseHomeWork.Interface.Repository;
using BaseHomeWork.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace BaseHomeWork.DAL
{
    public class ADO_IndexViewModel : IRepo_IndexViewModel
    {
        readonly IRepo_OnlyRead<Good> _dbGood;
        readonly IRepo_OnlyRead<CatalogGood> _dbCatalogGood;
        readonly IRepo_OnlyRead<Catalog> _dbCatalog;
        

        public ADO_IndexViewModel(   [FromServices] IRepo_OnlyRead<Good> dbGood,
                                        [FromServices] IRepo_OnlyRead<CatalogGood> dbCatalogGood,
                                        [FromServices] IRepo_OnlyRead<Catalog> dbCatalog)
        {
            _dbGood = dbGood;
            _dbCatalogGood = dbCatalogGood;
            _dbCatalog = dbCatalog;
        }

        public IndexViewModel GetByCatalogID(int catalogID)
        {
            var IdGoodByCatalogID= new List<int>();
            var listGoodByCatalogID = new List<Good>();

            var CatalogList = _dbCatalog.GetALL();
            var CatalogGood = _dbCatalogGood.GetALL();

            foreach (var catalogGood in CatalogGood)
            {
                if (catalogGood.CatalogID == catalogID)
                {
                    IdGoodByCatalogID.Add(catalogGood.GoodID);                    
                }
            }
            for (int i = 0; i < IdGoodByCatalogID.Count(); i++)
            {
                listGoodByCatalogID.Add(_dbGood.GetbyID(IdGoodByCatalogID[i]));
            }

            return new IndexViewModel(CatalogList, listGoodByCatalogID); 
        }
    }
}
