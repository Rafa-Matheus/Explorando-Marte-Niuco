using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explorando_Marte_Niuco.Commands;
using Explorando_Marte_Niuco.Factory;
using Explorando_Marte_Niuco.Models;

namespace Explorando_Marte_Niuco.Services
{
    public class SondaService
    {
        private readonly Planalto _planalto;
        private readonly Dictionary<char, ICommand> _comandos;
        private readonly SondaFactory _sondaFactory;

        public SondaService(Planalto planalto)
        {
            _planalto = planalto;
            _sondaFactory = new SondaFactory(planalto);
            _comandos = new Dictionary<char, ICommand>
            {
                {'L', new GirarEsquerda()},
                {'R', new GirarDireita()},
                {'M', new Mover()}
            };
        }

        public void ExecutarComandos(Sonda sonda, string sequenciaComandos)
        {
            foreach(var comando in sequenciaComandos)
            {
                if (!_comandos.ContainsKey(comando)) throw new ArgumentException("Comando inválido.");
                _comandos[comando].Executar(sonda, _planalto);
            }
        }

        public void ChecarSegurancaDoPercursoProgramado(int x, int y, char direcao, string sequenciaComandos)
        {
            var planaltoSimulado = new Planalto(_planalto.XMax, _planalto.YMax);
            foreach (var pos in _planalto.PosicoesOcupadas)
                planaltoSimulado.OcuparPosicao(pos.Item1, pos.Item2);

            var sondaSimulada = _sondaFactory.CriarSondaSimulada(x, y, direcao, planaltoSimulado);

            foreach (char comando in sequenciaComandos)
            {
                _comandos[comando].Executar(sondaSimulada, planaltoSimulado);
            }
        }
    }
}