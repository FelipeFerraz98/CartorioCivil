using System;

namespace CartorioCivil.Negocios.Validadores
{
    public static class ValidarEntidade
    {
        public static void Validar<T>(T entidade)
        {
            var propriedades = entidade.GetType().GetProperties();

            foreach (var propriedade in propriedades)
            {
                if (string.Equals(propriedade.Name, "Id", StringComparison.OrdinalIgnoreCase))
                    continue;

                var valor = propriedade.GetValue(entidade);
                if (valor == null || (valor is string str && string.IsNullOrWhiteSpace(str)))
                    throw new ArgumentException($"O campo '{propriedade.Name}' não pode ser vazio ou nulo.");

            }
        }
    }
}
