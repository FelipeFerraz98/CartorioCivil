# CartorioCivil.Negocios.Validadores

Este diretório contém classes responsáveis por validar dados de entrada no sistema, garantindo a integridade dos dados antes de serem processados ou armazenados no banco de dados. Ele inclui validações de CPF e a validação geral de entidades.

## **Estrutura dos Validadores**

### 1. **ValidarCPF**

A classe `ValidarCPF` fornece um método estático para validar um número de CPF, verificando sua formatação e os dígitos verificadores de acordo com a regra oficial.

#### **Métodos**

- **Validar(string cpf)**: Este método valida o CPF fornecido. Ele remove pontos e hífens, e então valida os dois dígitos verificadores do CPF.

  - **Parâmetros**: 
    - `cpf` (string): O CPF a ser validado.
  - **Retorno**: Retorna um `bool` indicando se o CPF é válido ou não.

  #### **Exemplo de Uso**:

  ```csharp
  string cpf = "123.456.789-00";
  bool isValido = ValidarCPF.Validar(cpf);

  if (isValido)
  {
      Console.WriteLine("O CPF é válido.");
  }
  else
  {
      Console.WriteLine("O CPF é inválido.");
  }
  ```

### 2. **ValidarEntidade**

A classe `ValidarEntidade` é responsável por garantir que todos os campos obrigatórios de uma entidade (objeto) não estejam nulos ou vazios. Ela pode ser usada para validar qualquer entidade do sistema.

#### **Métodos**

- **Validar<T>(T entidade)**: Este método valida todos os campos de uma entidade, exceto o campo `Id`. Ele verifica se o valor de cada propriedade é nulo ou vazio e lança uma exceção caso algum campo seja inválido.

  - **Parâmetros**: 
    - `entidade` (T): A entidade que será validada.
  - **Retorno**: Não retorna valor. Se uma propriedade obrigatória for nula ou vazia, lança uma `ArgumentException`.

  #### **Exemplo de Uso**:

  ```csharp
  var pessoa = new Pessoa { Nome = "João", CPF = "12345678900" };

  try
  {
      ValidarEntidade.Validar(pessoa);
      Console.WriteLine("Entidade válida.");
  }
  catch (ArgumentException ex)
  {
      Console.WriteLine($"Erro: {ex.Message}");
  }
  ```