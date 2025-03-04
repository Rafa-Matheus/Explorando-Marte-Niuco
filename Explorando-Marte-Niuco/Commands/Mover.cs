using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explorando_Marte_Niuco.Models;

namespace Explorando_Marte_Niuco.Commands
{
    public class Mover : ICommand
    {
        public void Executar(Sonda sonda, Planalto planalto)
        {
            int novoX = sonda.X;
            int novoY = sonda.Y;

            switch (sonda.Direcao)
            {
                case 'N': novoY++;
                    break;
                case 'E': novoX++;
                    break;
                case 'S': novoY--;
                    break;
                case 'W': novoX--;
                    break;
            }

            if (!planalto.DentroDosLimites(novoX, novoY))
                throw new ArgumentException($"Operação cancelada. Movimento para fora dos limites do Planalto: ({planalto.XMax} x {planalto.YMax}). Ajuste o planejamento da operação e tente novamente mais tarde.\n");
            
            sonda.X = novoX;
            sonda.Y = novoY;            
        }
    }
}