using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fuzaite.Londres.Service.Models
{
    public class Rodada
    {
        public int CampeonatoId { get; set; }
        public int MandanteId { get; set; }
        public int VisitanteId { get; set; }
        public int PlacarMandante { get; set; }
        public int PlacarVisitante { get; set; }
    }
}