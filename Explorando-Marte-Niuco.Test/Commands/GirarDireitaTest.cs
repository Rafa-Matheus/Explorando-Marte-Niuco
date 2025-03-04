using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explorando_Marte_Niuco.Commands;
using Explorando_Marte_Niuco.Models;
using Xunit;

namespace Explorando_Marte_Niuco.Test.Commands
{
    public class GirarDireitaTest
    {
        [Fact]
        public void GirarDeNorteParaLeste()
        {
            var planalto = new Planalto(5, 5);
            var sonda = new Sonda(2, 2, 'N');
            var comando = new GirarDireita();
            comando.Executar(sonda, planalto);
            Assert.Equal('E', sonda.Direcao);
        }
    }
}