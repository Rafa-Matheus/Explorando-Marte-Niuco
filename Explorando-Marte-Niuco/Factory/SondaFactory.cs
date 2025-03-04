using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explorando_Marte_Niuco.Models;

namespace Explorando_Marte_Niuco.Factory
{
    public class SondaFactory : ISondaFactory
    {
        private readonly Planalto _planalto;

        public SondaFactory(Planalto planalto)
        {
            _planalto = planalto;
        }

        public Sonda CriarSondaSimulada(int x, int y, char direcao, Planalto planalto)
        {
           if (!planalto.DentroDosLimites(x, y)) throw new ArgumentException("Operação cancelada: Posição inicial fora dos limites do Planalto. ");
           if (!planalto.PosicaoLivre(x, y)) throw new ArgumentException("Opeação cancelada: Posição inicial já está ocupada por outra sonda.");

           var sonda = new Sonda(x, y, direcao);
           planalto.OcuparPosicao(x, y);
           return sonda;
        }

        public Sonda CriarSonda(int x, int y, char direcao)
        {
            var sonda = new Sonda(x, y, direcao);
            _planalto.OcuparPosicao(x,y);
            return sonda;
        }
    }
}