using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace BaseHomeWork.Models
{
    [Table]
    public class Catalog
    {
        [Column]
        public int ID { get; set; }
        [Column(Name ="CatalogName")]
        public string Name { get; set; }
    }
}
