using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero
{
    interface DAO<T>
    {
         bool add(T element);
         bool delete(T element);
         List<T> getAll();
         T findById(int id);
         T findByName(string name);
         bool update(T element);

    }
}
