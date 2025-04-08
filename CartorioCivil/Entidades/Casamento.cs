using System;

namespace CartorioCivil.Entidades
{
    public class Casamento
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataCasamento { get; set; }

        // Relacionamentos com Conjuge
        public int IdConjuge1 { get; set; }
        public Conjuge Conjuge1 { get; set; }

        public int IdConjuge2 { get; set; }
        public Conjuge Conjuge2 { get; set; }
    }
}
