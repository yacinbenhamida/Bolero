using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.DAL
{
    interface DAO<T>
    {
        int add(T e);
        int delete(int id);
        bool find(T e);
        List<T> getAll();
        T getById(int id);
        int update(T obj);
    }
}
