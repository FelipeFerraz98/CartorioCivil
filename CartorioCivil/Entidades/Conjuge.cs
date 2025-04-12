using System;

namespace CartorioCivil.Entidades
{
    public class Conjugue
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public DateTime DataNascimentoPai { get; set; }
        public DateTime DataNascimentoMae { get; set; }
        public string CpfnPai { get; set; }
        public string CpfnMae { get; set; }
    }
}
