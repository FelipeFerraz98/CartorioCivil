using System;

namespace CartorioCivil.Entidades
{
    public class Nascimento
    {
        public int Id { get; set; }
        public string NomeRegistrado { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataRegistro { get; set; }
        public string NomePai { get; set; }
        public string CpfPai { get; set; }
        public DateTime DataNascimentoPai { get; set; }
        public string NomeMae { get; set; }
        public string CpfMae { get; set; }
        public DateTime DataNascimentoMae { get; set; }
    }
}
