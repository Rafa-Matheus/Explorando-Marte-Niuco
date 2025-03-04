using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Explorando_Marte_Niuco.Models
{
    public class Sonda
    {
        public int X {get;}
        public int Y {get;}
        public char Direcao {get; set;}

        public Sonda(int x, int y, char direcao)
        {
            X = x;
            Y = y;
            Direcao = direcao;
        }
    }
}