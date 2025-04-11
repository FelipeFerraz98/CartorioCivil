using System;

namespace CartorioCivil.Entidades
{
    public class Casamento
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataCasamento { get; set; }
        public int IdConjugue1 { get; set; }
        public Conjugue Conjugue1 { get; set; }

        public int IdConjugue2 { get; set; }
        public Conjugue Conjugue2 { get; set; }
    }
}
