using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explorando_Marte_Niuco.Models;
using Xunit;

namespace Explorando_Marte_Niuco.Test.Models
{
    public class SondaTest
    {
        [Fact]
        public void Sonda_PosicaoEDirecaoInicial_Corretas()
        {
            var sonda = new Sonda(2, 2, 'N');
            Assert.Equal(2, sonda.X);
            Assert.Equal(2, sonda.Y);
            Assert.Equal('N', sonda.Direcao);
        }
    }
}