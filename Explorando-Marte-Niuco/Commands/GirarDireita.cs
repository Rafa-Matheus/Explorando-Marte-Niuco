using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explorando_Marte_Niuco.Models;

namespace Explorando_Marte_Niuco.Commands
{
    public class GirarDireita : ICommand
    {
        public void Executar(Sonda sonda, Planalto planalto)
        {
            sonda.Direcao = sonda.Direcao switch
            {
                'N' => 'E',
                'E' => 'S',
                'S' => 'W',
                'W' => 'N',
                _=> throw new ArgumentException("Direção inválida")
            };
        }
    }
}