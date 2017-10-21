using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.DAL
{
    interface DAO<T>
    {
        public int add();
        public int delete();
        public bool find();
        public List<T> getAll();
        public T getById(int id);

    }
}
