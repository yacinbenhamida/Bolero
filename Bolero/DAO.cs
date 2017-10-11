using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero
{
    interface DAO<T>
    {
        public T findById(int id);
        public T add(T element);
        public bool delete(T element);
        public bool add(T element);
        public List<T> getAll(T element);
        public bool update(T element);
        public T findByName(T element);
    }
}
