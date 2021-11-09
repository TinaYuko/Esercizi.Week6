using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_3
{
    abstract class FormaGeometrica
    {
        public string Nome { get; set; }

        public FormaGeometrica(string nome)
        {
            Nome = nome;
        }

        public abstract double CalcolaPerimetro();
        public abstract double CalcolaArea();
    }
}
