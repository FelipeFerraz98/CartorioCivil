using System;

namespace CartorioCivil.Entidades
{
    public class Conjuge
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public DateTime DataNascimentoPai { get; set; }
        public DateTime DataNascimentoMae { get; set; }
        public string CpfPai { get; set; }
        public string CpfMae { get; set; }
    }
}
