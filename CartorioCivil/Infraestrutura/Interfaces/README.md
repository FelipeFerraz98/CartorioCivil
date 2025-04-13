# CartorioCivil.Infraestrutura.Interfaces

Este diretório contém as interfaces que define **contratos (interfaces)** para os repositórios de acesso a dados (`DAO` - *Data Access Object*), seguindo os princípios da **programação orientada a interfaces** e **injeção de dependência**.

Essas interfaces permitem desacoplar a lógica de acesso ao banco de dados da lógica de negócios, tornando o sistema mais **modular**, **testável** e **flexível**.

## Interfaces Definidas

### `IRegistroDAO<T>`

Interface **genérica base** para operações CRUD comuns:

```csharp
public interface IRegistroDAO<T>
{
    Task<int> AdicionarAsync(T entidade);
    Task RemoverAsync(int id);
    Task AtualizarAsync(T entidade);
    Task<List<T>> ObterTodosAsync();
    Task<T> ObterPorIdAsync(int id);
    T MapearParametros(NpgsqlDataReader leitor);
}
```

#### Responsabilidades:
- Encapsular operações básicas de persistência
- Fornecer contrato genérico reutilizável
- Implementar mapeamento de dados do banco para entidades

#### Detalhe do método `MapearParametros`:
- Recebe um `NpgsqlDataReader` (leitor de resultados do PostgreSQL)
- Retorna uma instância da entidade `T` mapeada a partir das colunas

---

### `ICasamentoDAO`

Interface específica para a entidade `Casamento`.

```csharp
public interface ICasamentoDAO : IRegistroDAO<Casamento>
{
    Task<Casamento> ObterPorIdConjugeAsync(int idConjuge);
}
```

#### Métodos específicos:
- `ObterPorIdConjugeAsync`: Permite encontrar um casamento baseado no ID de um dos cônjuges.

---

### `IConjugeDAO`

Interface para lidar com os registros de `Conjuge`.

```csharp
public interface IConjugeDAO : IRegistroDAO<Conjuge>
{
    Task<List<Conjuge>> ObterPorNomeAsync(string nome);
    Task<Conjuge> ObterPorCpfAsync(string cpf);
}
```

#### Métodos específicos:
- Buscar cônjuges por nome ou CPF

---

### `INascimentoDAO`

Interface para registros de `Nascimento`.

```csharp
public interface INascimentoDAO : IRegistroDAO<Nascimento>
{
    Task<List<Nascimento>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
    Task<List<Nascimento>> ObterPorNomeAsync(string nome);
}
```

#### Métodos específicos:
- Consulta por intervalo de datas
- Filtro por nome

---

### `IObitoDAO`

Interface para registros de óbito.

```csharp
public interface IObitoDAO : IRegistroDAO<Obito>
{
    Task<List<Obito>> ObterPorNomeAsync(string nome);
}
```

#### Método específico:
- Busca por nome do falecido

## Padrão DAO

As interfaces seguem o **Padrão DAO (Data Access Object)**, que:
- Encapsula o acesso ao banco
- Centraliza lógica de persistência
- Fornece um contrato claro para uso na camada de negócios


## Implementação futura

Cada interface desta pasta deverá ser implementada em classes específicas dentro da camada `Infraestrutura/RegistrosDAO`, como por exemplo:

- `NascimentoDAO : INascimentoDAO`
- `ObitoDAO : IObitoDAO`

Essas implementações irão:
- Usar a classe `ConexaoDB`
- Executar os comandos SQL
- Mapear os resultados para as entidades

---
