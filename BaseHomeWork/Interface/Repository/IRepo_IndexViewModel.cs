using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseHomeWork.Models;

namespace BaseHomeWork.Interface.Repository
{
    public interface IRepo_IndexViewModel
    {
        CatalogAndGoodViewModel GetByCatalogID(int catalogID);
    }
}
