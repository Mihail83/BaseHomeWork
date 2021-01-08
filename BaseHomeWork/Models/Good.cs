using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace BaseHomeWork.Models
{
    [Table(Name = "Good")]
    public class Good
    {
        [Column]
        public int ID { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public decimal Price { get; set; }
    }
}
