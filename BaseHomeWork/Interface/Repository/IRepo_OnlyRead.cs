using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseHomeWork.Interface.Repository
{
    public interface IRepo_OnlyRead<T>
    {
        T GetbyID(int ID);
        IEnumerable<T> GetALL();
    }
}
