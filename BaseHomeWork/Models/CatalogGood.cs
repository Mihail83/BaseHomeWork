using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace BaseHomeWork.Models
{
    [Table]
    public class CatalogGood
    {
        [Column]
        public int GoodID { get; set; }
        [Column]
        public int CatalogID { get; set; }
    }
}
