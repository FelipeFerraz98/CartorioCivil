# CartorioCivil.Negocios.Relatorios

Este diretório contém a classe **`RelNascimento`**, que é responsável por gerar um relatório de registros de **nascimento** a partir de um período de datas específico. O relatório é retornado como um **`DataTable`**, contendo as informações dos nascimentos filtrados pelas datas de início e fim fornecidas.

## Estrutura do Código

A classe `RelNascimento` possui uma dependência do serviço **`NascimentoServico`**, que é responsável por buscar os registros de nascimento no banco de dados.

### Métodos:

#### `GerarRelatorio(DateTime dataInicio, DateTime dataFinal)`

Este método assíncrono é o responsável por gerar o relatório. Ele recebe duas datas (início e fim) e retorna um **`DataTable`** com os dados dos registros de nascimento dentro desse intervalo de tempo.

**Funcionamento:**
- O método chama o serviço `NascimentoServico.ObterPorPeriodoAsync` para buscar os nascimentos no período especificado.
- Em seguida, um **`DataTable`** é criado com as colunas necessárias para armazenar os dados do nascimento.
- Cada registro de nascimento é adicionado como uma linha no `DataTable`, e as datas são formatadas para o padrão `dd/MM/yyyy`.
- O método retorna o `DataTable` pronto para ser usado por um report viewer.

**Parâmetros:**
- `dataInicio` (DateTime): A data inicial para filtrar os nascimentos.
- `dataFinal` (DateTime): A data final para filtrar os nascimentos.

**Retorno:**
- `DataTable`: Um **DataTable** contendo os dados dos nascimentos no período especificado, com as colunas:
  - `NomeRegistrado` (string)
  - `DataNascimento` (string, no formato `dd/MM/yyyy`)
  - `DataRegistro` (string, no formato `dd/MM/yyyy`)
  - `NomePai` (string)
  - `CPFPai` (string)
  - `DataNascimentoPai` (string, no formato `dd/MM/yyyy`)
  - `NomeMae` (string)
  - `CPFMae` (string)
  - `DataNascimentoMae` (string, no formato `dd/MM/yyyy`)

## Notas

- As datas são formatadas no formato `dd/MM/yyyy` para exibição no relatório.
- O método **`GerarRelatorio`** é assíncrono e deve ser aguardado com `await` ao ser chamado.