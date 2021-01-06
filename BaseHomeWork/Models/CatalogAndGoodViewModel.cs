using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseHomeWork.Models
{
    public class CatalogAndGoodViewModel
    {
        public CatalogAndGoodViewModel() { }
        public CatalogAndGoodViewModel(IEnumerable<Catalog>catalogs, IEnumerable<Good> goods)
        {
            ListOfCatalog = catalogs;
            ListOfGood = goods;
        }

        public IEnumerable<Catalog> ListOfCatalog { get; set; }
        public IEnumerable<Good> ListOfGood { get; set; }  // by ID Catalog
    }
}
