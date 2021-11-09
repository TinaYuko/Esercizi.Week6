using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_3
{
    class Quadrato : Rettangolo
    {
        public Quadrato(string nome, double lato) : base(nome, lato, lato)
        {
            
        }

        public override string ToString()
        {
            return $"Forma: {Nome} - Lato: {Base}";
        }

        
    }
}
