using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_3
{
    class Triangolo : FormaGeometrica
    {
        public double Base { get; set; }
        public double Altezza { get; set; }

        public Triangolo(string nome, double Base, double altezza) : base(nome)
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
            double p = Base + Altezza + CalcolaLato();
            return p;
        }

        private double CalcolaLato()
        {
            double lato3 = Math.Sqrt(Math.Pow(Base, 2) + Math.Pow(Altezza, 2));
            return lato3;
        }

        public override string ToString()
        {
            return $"Forma: {Nome} - Base: {Base} - Altezza: {Altezza}";
        }

    }
}
