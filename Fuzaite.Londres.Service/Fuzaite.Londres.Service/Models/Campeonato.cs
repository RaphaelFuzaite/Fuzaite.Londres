using System;

namespace Fuzaite.Londres.Service.Models
{
    public class Campeonato
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public int QuantidadeDeJogadores { get; set; }
        public int TipoDeCampeonato { get; set; }
        public int Turnos { get; set; }
        public int ModoDeDisputa { get; set; }
    }
}