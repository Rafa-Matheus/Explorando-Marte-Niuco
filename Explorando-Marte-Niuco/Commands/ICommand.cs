using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explorando_Marte_Niuco.Models;

namespace Explorando_Marte_Niuco.Commands
{
    public interface ICommand
    {
        void Executar(Sonda sonda, Planalto planalto);
    }
}