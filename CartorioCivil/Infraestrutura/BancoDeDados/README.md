#  CartorioCivil.Infraestrutura.BancoDeDados

Esta pasta contém a camada de infraestrutura responsável pela comunicação entre a aplicação e o banco de dados PostgreSQL, centralizada na classe `ConexaoDB`.

## ConexaoDB.cs

A classe `ConexaoDB` abstrai o gerenciamento de conexões com o banco PostgreSQL e provê métodos assíncronos para:

- Executar comandos (inserções, atualizações, exclusões)
- Executar consultas com retorno genérico
- Realizar mapeamentos de dados
- Gerenciar parâmetros com segurança

## Configuração da Conexão

A string de conexão utilizada pela classe `ConexaoDB` é lida do arquivo `App.config` da aplicação, altere conforme a sua necessidade através da chave:

```xml
<connectionStrings>
	<add name="PostgreSQLConexao"
		 connectionString="Host=localhost;Username=postgres;Password=root;Database=cartoriocivil"
		 providerName="Npgsql" />
</connectionStrings>
```

> A ausência da string de conexão correta gera uma exceção crítica ao instanciar a classe.

##  Funcionalidades

### Abrir e Fechar Conexão

```csharp
await AbrirConexaoAsync();
FecharConexao();
```

Abertura e fechamento explícito da conexão, respeitando o estado atual (`ConnectionState`), evitando múltiplas conexões desnecessárias.

---

### Executar Comandos SQL (INSERT, UPDATE, DELETE)

```csharp
await ExecutarComandoAsync("INSERT INTO ...", parametros);
```

- Utiliza `NpgsqlCommand` com suporte a **parâmetros nomeados**
- Seguro contra SQL Injection
- Descartável via `using`

---

### Executar Consultas com Mapeamento

```csharp
List<T> resultado = await ExecutarConsultaAsync<T>(
    "SELECT * FROM tabela WHERE campo = @valor",
    leitor => new MinhaEntidade
    {
        Propriedade = leitor["coluna"].ToString()
    },
    new Dictionary<string, object> { { "@valor", 123 } }
);
```

Permite:
- Passar uma função de mapeamento para transformar cada linha (`NpgsqlDataReader`) em objetos do tipo `T`
- Trabalhar com listas genéricas fortemente tipadas
- Consultas complexas com ou sem parâmetros

---

### Executar Comando com Retorno Escalar

```csharp
int novoId = await ExecutarComandoComRetornoAsync<int>(
    "INSERT INTO tabela(coluna) VALUES(@valor) RETURNING id",
    new Dictionary<string, object> { { "@valor", "abc" } }
);
```

- Ideal para obter valores únicos do banco (como `COUNT(*)`, `MAX(id)` ou `RETURNING`)
- Conversão automática para o tipo genérico `T`

---

### Adicionar Parâmetros de Forma Segura

```csharp
AdicionarParametros(comando, parametros);
```

- Trata `null` como `DBNull.Value`
- Previne SQL Injection
- Facilita manutenção e legibilidade

---

### Dispose Automático

```csharp
using (var conexao = new ConexaoDB())
{
    await conexao.ExecutarComandoAsync(...);
}
```

A classe implementa `IDisposable`, garantindo que a conexão seja sempre fechada e os recursos liberados, mesmo em caso de exceções.

## Boas Práticas Aplicadas

- **Programação assíncrona** com `async/await` para não bloquear a UI ou a thread principal
- **Separação de responsabilidades**: essa classe não conhece regras de negócio, apenas executa instruções no banco
- **Uso de parâmetros tipados** para segurança
- **Uso do padrão Repository indireto**: as demais camadas chamam essa classe para persistência de dados

## Exemplo de Uso

```csharp
using (var conexao = new ConexaoDB())
{
    var sql = "UPDATE nascimento SET nome_registrado = @nome WHERE id = @id";
    var parametros = new Dictionary<string, object>
    {
        { "@nome", "João Silva" },
        { "@id", 10 }
    };

    await conexao.ExecutarComandoAsync(sql, parametros);
}
```

## Dependências

- [`Npgsql`](https://www.npgsql.org/) – Driver ADO.NET para PostgreSQL
- `System.Configuration` – Para leitura de configuração
- `System.Data` – Para integração com comandos ADO.NET

##  Papel na Arquitetura

Esta classe é usada pelos repositórios ou serviços na camada de negócios (como `NascimentoDAO`, `NascimentoServico`, etc). Ela é a responsável por:

- Executar consultas no banco
- Mapear resultados para entidades do domínio
- Gerenciar transações de forma implícita

---
