# CartorioCivil.Infraestrutura.RegistrosDAO

Este diretório contém a **camada de persistência de dados** da aplicação, responsável pela comunicação com o banco de dados PostgreSQL. Ele segue o padrão de arquitetura DAO com uso de interfaces, garantindo desacoplamento, testabilidade e manutenção simplificada.

##  Implementações DAO

### CasamentoDAO

Implementa `ICasamentoDAO`, responsável pelas operações CRUD com registros de casamento:

| Método | Descrição |
|--------|-----------|
| `AdicionarAsync(Casamento)` | Insere novo casamento |
| `AtualizarAsync(Casamento)` | Atualiza casamento existente |
| `RemoverAsync(int id)` | Exclui casamento por ID |
| `ObterTodosAsync()` | Lista todos os registros |
| `ObterPorIdAsync(int id)` | Busca por ID |
| `ObterPorIdConjugeAsync(int idConjuge)` | Busca casamento com base em cônjuge |

---

### ConjugeDAO

Implementa `IConjugeDAO`, manipulando dados de cônjuges:

| Método | Descrição |
|--------|-----------|
| `AdicionarAsync(Conjuge)` | Adiciona cônjuge |
| `AtualizarAsync(Conjuge)` | Atualiza dados |
| `RemoverAsync(int id)` | Remove pelo ID |
| `ObterTodosAsync()` | Lista todos os cônjuges |
| `ObterPorIdAsync(int id)` | Busca por ID |
| `ObterPorNomeAsync(string nome)` | Busca por nome |
| `ObterPorCpfAsync(string cpf)` | Busca por CPF |

---

### NascimentoDAO

Implementa `INascimentoDAO`, com foco em registros de nascimento:

| Método | Descrição |
|--------|-----------|
| `AdicionarAsync(Nascimento)` | Cadastra nascimento |
| `AtualizarAsync(Nascimento)` | Atualiza registro |
| `RemoverAsync(int id)` | Remove pelo ID |
| `ObterTodosAsync()` | Lista geral |
| `ObterPorIdAsync(int id)` | Busca por ID |
| `ObterPorNomeAsync(string nome)` | Busca por nome |
| `ObterPorPeriodoAsync(DateTime inicio, DateTime fim)` | Filtra por datas |

---

### ObitoDAO

Implementa `IObitoDAO`, responsável por registros de falecimentos:

| Método | Descrição |
|--------|-----------|
| `AdicionarAsync(Obito)` | Insere óbito |
| `AtualizarAsync(Obito)` | Edita registro |
| `RemoverAsync(int id)` | Remove por ID |
| `ObterTodosAsync()` | Lista todos |
| `ObterPorIdAsync(int id)` | Busca por ID |
| `ObterPorNomeAsync(string nome)` | Busca pelo nome do falecido |

## Mapeamento de Parâmetros (DataReader)

Cada DAO implementa um método `MapearParametros` responsável por converter os dados brutos retornados do banco (`NpgsqlDataReader`) em objetos fortemente tipados do domínio da aplicação (como `Nascimento`, `Casamento`, etc.).

### Exemplo:

```csharp
public Casamento MapearParametros(NpgsqlDataReader leitor)
{
    return new Casamento
    {
        Id = leitor.GetInt32(leitor.GetOrdinal("Id")),
        DataRegistro = leitor.GetDateTime(leitor.GetOrdinal("DataRegistro")),
        DataCasamento = leitor.GetDateTime(leitor.GetOrdinal("DataCasamento")),
        IdConjuge1 = leitor.GetInt32(leitor.GetOrdinal("IdConjuge1")),
        IdConjuge2 = leitor.GetInt32(leitor.GetOrdinal("IdConjuge2"))
    };
}
```

Esse método é fundamental para garantir consistência na leitura dos dados, reduzindo riscos de erros de tipagem ou campos nulos.

## Segurança e Prevenção de SQL Injection

Todas as consultas SQL na aplicação utilizam parâmetros tipados (`@param`) com o NpgsqlCommand, em vez de concatenar strings diretamente, garantindo segurança contra **SQL Injection**.

```csharp
var comando = new NpgsqlCommand("SELECT * FROM Nascimento WHERE NomeRegistrado = @nome", conexao);
comando.Parameters.AddWithValue("@nome", nome);
```
Além disso:

- Todos os métodos de busca por nome, CPF ou ID usam esse padrão seguro.
- Esse padrão está presente em todas as implementações das classes DAO.
- `NpgsqlParameter` também valida o tipo de dado, reduzindo falhas e ataques de injeção.

## Banco de Dados

O banco utilizado é **PostgreSQL**, com tabelas mapeadas diretamente pelas entidades `Nascimento`, `Casamento`, `Obito` e `Conjuge`.

###  Estrutura das tabelas (DDL)

<details>
<summary><strong>Casamento</strong></summary>

```sql
CREATE TABLE Casamento (
    Id SERIAL PRIMARY KEY,
    DataRegistro DATE NOT NULL,
    DataCasamento DATE NOT NULL,
    IdConjuge1 INTEGER REFERENCES Conjuge(Id),
    IdConjuge2 INTEGER REFERENCES Conjuge(Id)
);
```
</details>

<details>
<summary><strong>Conjuge</strong></summary>

```sql
CREATE TABLE Conjuge (
    Id SERIAL PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL,
    CPF VARCHAR(14) NOT NULL,
    NomePai VARCHAR(255),
    NomeMae VARCHAR(255),
    DataNascimentoPai DATE,
    DataNascimentoMae DATE,
    CpfnPai VARCHAR(14),
    CpfnMae VARCHAR(14)
);
```
</details>

<details>
<summary><strong>Nascimento</strong></summary>

```sql
CREATE TABLE Nascimento (
    Id SERIAL PRIMARY KEY,
    DataRegistro DATE NOT NULL,
    DataNascimento DATE NOT NULL,
    NomeRegistrado VARCHAR(255) NOT NULL,
    NomePai VARCHAR(255) NOT NULL,
    NomeMae VARCHAR(255) NOT NULL,
    DataNascimentoPai DATE NOT NULL,
    DataNascimentoMae DATE NOT NULL,
    CpfnPai VARCHAR(14) NOT NULL,
    CpfnMae VARCHAR(14) NOT NULL
);
```
</details>

<details>
<summary><strong>Óbito</strong></summary>

```sql
CREATE TABLE Obito (
    Id SERIAL PRIMARY KEY,
    DataRegistro DATE NOT NULL,
    DataObito DATE NOT NULL,
    NomeFalecido VARCHAR(255) NOT NULL,
    DataNascimento DATE NOT NULL,
    NomePai VARCHAR(255) NOT NULL,
    NomeMae VARCHAR(255) NOT NULL,
    DataNascimentoPai DATE NOT NULL,
    DataNascimentoMae DATE NOT NULL
);
```
</details>


##  Exemplo de uso

### Obter um registro de casamento por ID:

```csharp
var casamentoDAO = new CasamentoDAO();
var casamento = await casamentoDAO.ObterPorIdAsync(1);

Console.WriteLine($"Data do casamento: {casamento.DataCasamento}");
```

### Inserir novo nascimento:

```csharp
var nascimento = new Nascimento
{
    DataNascimento = new DateTime(2020, 5, 12),
    DataRegistro = DateTime.Today,
    NomeRegistrado = "Ana Clara",
    NomePai = "Carlos Eduardo",
    NomeMae = "Maria Fernanda",
    DataNascimentoPai = new DateTime(1980, 1, 1),
    DataNascimentoMae = new DateTime(1982, 3, 15),
    CpfnPai = "111.111.111-11",
    CpfnMae = "222.222.222-22"
};

var nascimentoDAO = new NascimentoDAO();
await nascimentoDAO.AdicionarAsync(nascimento);
```
## Testabilidade

A separação entre **interfaces e implementações concretas** permite que os serviços sejam **facilmente mockados** em testes unitários, como nos arquivos:

- `NascimentoServicoTests.cs`
- `CasamentoServicoTests.cs`
- `ObitoServicoTests.cs`
