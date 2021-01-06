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
    public class GetHomeIndexViewModel
    {
        readonly ADO_GoodOnlyRead db_Good;
        readonly ADO_CatalogGoodOnlyRead db_CatalogGood;
        readonly ADO_CatalogOnlyRead db_Catalog;
        

        public GetHomeIndexViewModel([FromServices]IConfiguration configuration)
        {
            db_Good = new ADO_GoodOnlyRead(configuration);
            db_CatalogGood = new ADO_CatalogGoodOnlyRead(configuration);
            db_Catalog = new ADO_CatalogOnlyRead(configuration);
        }

        public CatalogAndGoodViewModel GetByCatalogID(int catalogID)
        {
            var IdGoodByCatalogID= new List<int>();
            var listGoodByCatalogID = new List<Good>();

            var CatalogList = db_Catalog.GetALL();
            var CatalogGood = db_CatalogGood.GetALL();

            foreach (var catalogGood in CatalogGood)
            {
                if (catalogGood.CatalogID == catalogID)
                {
                    IdGoodByCatalogID.Add(catalogGood.GoodID);                    
                }
            }
            for (int i = 0; i < IdGoodByCatalogID.Count(); i++)
            {
                listGoodByCatalogID.Add(db_Good.GetbyID(IdGoodByCatalogID[i]));
            }

            return new CatalogAndGoodViewModel(CatalogList, listGoodByCatalogID); 
        }
    }
}
