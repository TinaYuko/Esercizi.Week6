using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_3
{
    class Cerchio : FormaGeometrica
    {
        public double Raggio { get; set; }

        public Cerchio(string nome,  double raggio): base(nome)
        {
            Raggio = raggio;
        }
        public override double CalcolaArea()
        {
            double area = Math.Pow(Raggio, 2) * Math.PI;
            return area;
        }

        public override double CalcolaPerimetro()
        {
            double circonferenza = 2 * Raggio * Math.PI;
            return circonferenza;
        }

        public override string ToString()
        {
            return $"Forma: {Nome} - Raggio: {Raggio}";
        }

        
    }
}
