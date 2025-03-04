using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explorando_Marte_Niuco.Models;

namespace Explorando_Marte_Niuco.Factory
{
    public interface ISondaFactory
    {
        Sonda CriarSonda(int x, int y, char direcao);
    }
}