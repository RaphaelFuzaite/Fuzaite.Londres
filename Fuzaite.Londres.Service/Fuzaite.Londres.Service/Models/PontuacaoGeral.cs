using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fuzaite.Londres.Service.Models
{
    public class PontuacaoGeral
    {
        public int CampeonatoId { get; set; }
        public int JogadorId { get; set; }
        public int Pontos { get; set; }
        public int Jogos { get; set; }
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int GolsAFavor { get; set; }
        public int GolsContra { get; set; }
        public int SaldoDeGols { get; set; }
        public decimal Aproveitamento { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
    }
}