using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_4
{
    interface ILibreriaManager<T>
    {
        public List<T> GetAll();
        public T GetByIsbn(int isbn);
    }
}
