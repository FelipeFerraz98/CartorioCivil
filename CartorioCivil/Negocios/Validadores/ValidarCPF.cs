using System;
using System.Linq;

namespace CartorioCivil.Servicos
{
    public class ValidarCPF
    {
        public bool Validar(string cpf)
        {
            cpf = cpf?.Replace(".", "").Replace("-", "");

            if (string.IsNullOrEmpty(cpf) || cpf.Length != 11 || cpf.All(c => c == cpf[0]))
                return false;

            int[] pesosPrimeiroDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] pesosSegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var somaPrimeiroDigito = cpf.Take(9)
                .Select((c, i) => (c - '0') * pesosPrimeiroDigito[i])
                .Sum();
            var primeiroDigitoVerificador = (somaPrimeiroDigito * 10) % 11;
            if (primeiroDigitoVerificador == 10)
                primeiroDigitoVerificador = 0;

            var somaSegundoDigito = cpf.Take(10)
                .Select((c, i) => (c - '0') * pesosSegundoDigito[i])
                .Sum();
            var segundoDigitoVerificador = (somaSegundoDigito * 10) % 11;
            if (segundoDigitoVerificador == 10)
                segundoDigitoVerificador = 0;

            return primeiroDigitoVerificador == (cpf[9] - '0') && segundoDigitoVerificador == (cpf[10] - '0');
        }
    }
}
