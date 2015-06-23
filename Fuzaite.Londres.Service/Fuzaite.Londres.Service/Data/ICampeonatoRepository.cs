using Fuzaite.Londres.Service.Models;
using System.Collections.Generic;

namespace Fuzaite.Londres.Service.Data
{
    public interface ICampeonatoRepository
    {
        Campeonato Store(Campeonato campeonato);
        IList<Campeonato> GetAll();
    }
}
