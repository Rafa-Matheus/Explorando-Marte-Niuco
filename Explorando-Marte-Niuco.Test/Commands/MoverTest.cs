using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explorando_Marte_Niuco.Commands;
using Explorando_Marte_Niuco.Models;
using Xunit;

namespace Explorando_Marte_Niuco.Test.Commands
{
    public class MoverTest
    {
        [Fact]
        public void MoverCorretamente()
        {
            var planalto = new Planalto(5, 5);
            var sonda = new Sonda(2, 2, 'N');
            planalto.OcuparPosicao(2, 2);
            var comando = new Mover();
            comando.Executar(sonda, planalto);
            Assert.Equal(2, sonda.X);
            Assert.Equal(3, sonda.Y);
            Assert.Equal('N', sonda.Direcao);
        }

        [Fact]
        public void LancaExcecaoQuandoForaDosLimites()
        {
            var planalto = new Planalto(3, 3);
            var sonda = new Sonda(0, 3, 'N');
            planalto.OcuparPosicao(0, 3);
            var comando = new Mover();
            var excecao = Assert.Throws<ArgumentException>(() => comando.Executar(sonda, planalto));
            Assert.Equal("Operação cancelada! Movimento para fora dos limites do Planalto: (0 x 4). Ajuste o planejamento da operação e tente novamente mais tarde.\n", excecao.Message);
        }

        [Fact]
        public void LancaExcecaoQuandoHaColisao()
        {
            var planalto = new Planalto(5, 5);
            var sonda = new Sonda(2, 2, 'N');
            planalto.OcuparPosicao(2, 2);
            planalto.OcuparPosicao(2, 3);
            var comando = new Mover();
            var excecao = Assert.Throws<ArgumentException>(() => comando.Executar(sonda, planalto));
            Assert.Equal("Operação cancelada! Outra sonda está obstruindo o trajeto pretendido para a operação (2 x 3). Ajuste o planejamento da operação e tente novamente mais tarde.", excecao.Message);
        }
    }
}