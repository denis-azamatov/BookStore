using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<T>
    {
        public List<T> Storage { get; set; }

        public void Add(T element)
        {
            Storage.Add(element);
        }

        public bool Remove(T element)
        {
            return Storage.Remove(element);
        }
    }
}
