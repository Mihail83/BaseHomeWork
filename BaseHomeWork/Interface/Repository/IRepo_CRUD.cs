using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseHomeWork.Models;

namespace BaseHomeWork.Interface.Repository
{
    public interface IRepo_CRUD<T>
    {
        IList<T> GetGoods();   //all
        void CreateGood(T good);
        T GetGood(int id);
        void UpdateGood(T good);
        void DeleteGood(T good);
    }
}
