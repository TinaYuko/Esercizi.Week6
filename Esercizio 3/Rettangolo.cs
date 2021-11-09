using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_3
{
    class Rettangolo : FormaGeometrica
    {

        public double Base { get; set; }
        public double Altezza { get; set; }

        public Rettangolo(string nome, double Base, double altezza) : base (nome)
        {
            this.Base = Base;
            Altezza = altezza;
            
        }
        public override double CalcolaArea()
        {
            double area = (Base * Altezza) / 2;
            return area;
        }

        public override double CalcolaPerimetro()
        {
            double p = (Base + Altezza) * 2;
            return p;
        }

        public override string ToString()
        {
            return $"Forma: {Nome} - Base: {Base} - Altezza: {Altezza}";
        }
       

    }
}
