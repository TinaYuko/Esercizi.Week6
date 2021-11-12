using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStazionePolizia
{
    interface IManagerPolizia<T>
    {
        public List<T> GetAll();
        public T GetByArea(string area);
        public T GetByAnni(int anni);

        public void Add(T item);

    }
}
