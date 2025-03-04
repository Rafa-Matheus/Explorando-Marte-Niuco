using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explorando_Marte_Niuco.Factory;
using Explorando_Marte_Niuco.Models;
using Explorando_Marte_Niuco.Services;
using NuGet.Frameworks;
using Xunit;

namespace Explorando_Marte_Niuco.Test.Services
{
    public class SondaServiceTest
    {
        [Fact]
        public void ExecutarComandos_RotaCompletaComSucesso()
        {
            var planalto = new Planalto(5, 5);
            var sondaFactory = new SondaFactory(planalto);
            var sonda = new Sonda(2, 2, 'N');
            var service = new SondaService(planalto);
            service.ExecutarComandos(sonda, "MMR");
            Assert.Equal(2, sonda.X);
            Assert.Equal(4, sonda.Y);
            Assert.Equal('E', sonda.Direcao); 
        }

        public void ChecarSegurancaDaRota_DetectaColisao()
        {
            var planalto = new Planalto(5, 5);
            var sondaFactory = new SondaFactory(planalto);
            sondaFactory.CriarSonda(1, 3, 'N');
            var sondaService = new SondaService(planalto);
            var excecao = Assert.Throws<ArgumentException>(() => sondaService.ChecarSegurancaDoPercursoProgramado(2, 3, 'W', "MRM"));
            Assert.Equal("Operação cancelada! Uma sonda está obstruindo o percurso progrmado (1 x 3). Ajuste o planejamento da operação e tente novamente mais tarde.\n", excecao.Message);
        }

        [Fact]
        public void ChecarSegurancaDaRota_DetectaForaDosLimites()
        {
            var planalto = new Planalto(3, 3);
            var sondaService = new SondaService(planalto);
            var excecao = Assert.Throws<ArgumentException>(() => sondaService.ChecarSegurancaDoPercursoProgramado(0, 3, 'N', "M"));
            Assert.Equal("Operação cancelada! Movimento para fora dos limites do Planalto: (0 x 4). Ajuste o planejamento da operação e tente novamente mais tarde.\n", excecao.Message);
        }
    }
}