using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Explorando_Marte_Niuco.Commands;
using Explorando_Marte_Niuco.Models;
using Xunit;

namespace Explorando_Marte_Niuco.Test.Commands
{
    public class GirarEsquerdaTest
    {
        [Fact]
        public void GirarDeNorteParaOeste()
        {
            var planalto = new Planalto(5, 5);
            var sonda = new Sonda(2, 2, 'N');
            var comando = new GirarEsquerda();
            comando.Executar(sonda, planalto);
            Assert.Equal('W', sonda.Direcao);
        }
    }
}