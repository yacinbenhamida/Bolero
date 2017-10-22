using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.DAL
{
    interface DAO<T>
    {
        public int add(T e);
        public int delete(int id);
        public bool find(T e);
        public List<T> getAll();
        public T getById(int id);

    }
}
