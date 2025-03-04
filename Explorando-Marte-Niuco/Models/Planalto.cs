using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Explorando_Marte_Niuco.Models
{
    public class Planalto
    {
        public int XMax {get;}
        public int YMax {get;}
        private readonly HashSet<(int, int)> _posicoesOcupadas;

        public Planalto(int xMax, int yMax)
        {
            XMax = xMax;
            YMax = yMax;
            _posicoesOcupadas = new HashSet<(int, int)>();
        }

        public bool DentroDosLimites(int x, int y) => x >= 0 && x <= XMax && y >= 0 && y <= YMax;
    }
}