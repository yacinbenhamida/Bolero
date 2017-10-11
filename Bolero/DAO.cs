using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero
{
    interface DAO<T>
    {
        public bool add(T element);
        public bool delete(T element);
        public List<T> getAll();
        public T findById(int id);
        public T findByName(string name);
        public bool update(T element);
    }
}
