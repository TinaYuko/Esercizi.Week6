using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_3
{
    class Manager
    {
        static List<FormaGeometrica> formeGeometriche = new List<FormaGeometrica>();
        internal static void AggiungiForma(FormaGeometrica f)
        {
            formeGeometriche.Add(f);
        }

        internal static void StampoFigure()
        {
            foreach (var item in formeGeometriche)
            {
                Console.WriteLine($"{item.ToString()}");
            }
        }

        internal static void StampoPerimetro()
        {
            foreach (var item in formeGeometriche)
            {
                Console.WriteLine($"Forma: {item.Nome} - Perimetro: {item.CalcolaPerimetro()}");
            }
        }
        internal static void StampoArea()
        {
            foreach (var item in formeGeometriche)
            {
                Console.WriteLine($"Forma: {item.Nome} - Area: {item.CalcolaArea()}");
            }
        }
    }
}
