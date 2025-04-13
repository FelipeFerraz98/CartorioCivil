# CartorioCivil.Negocios.Servicos

Este diretório contém os serviços responsáveis pela lógica de negócios no gerenciamento de registros civis, Casamento, Nascimento, Óbito. Cada serviço é uma implementação de regras específicas para a manipulação de dados e interações com o banco de dados.

## **Estrutura dos Serviços**

Cada serviço segue um padrão base definido pela classe abstrata `RegistroServicoBase<T>`, que define operações como:

- **AdicionarAsync**: Adiciona um novo registro.
- **AtualizarAsync**: Atualiza um registro existente.
- **ObterPorIdAsync**: Obtém um registro específico através do seu ID.
- **ObterTodosAsync**: Obtém todos os registros da entidade.
- **RemoverAsync**: Remove um registro baseado no seu ID.

### **Exemplo de Estrutura dos Serviços**

#### 1. **CasamentoServico**

Responsável por gerenciar casamentos, incluindo a validação dos cônjuges e a verificação das regras de data e CPF.

- **AdicionarAsync**: Adiciona um novo casamento e seus respectivos cônjuges.
- **AtualizarAsync**: Atualiza as informações de um casamento existente.
- **RemoverAsync**: Remove um casamento e seus cônjuges associados.
- **ObterCasamentoPorConjugeAsync**: Obtém o casamento de um cônjuge específico.
- **ObterTodosAsync**: Obtém todos os casamentos registrados.
- **ObterConjugePorNomeAsync**: Obtém os cônjuges com base no nome.
- **ObterConjugePorCpfAsync**: Obtém o cônjuge com base no CPF.

#### 2. **NascimentoServico**

Gerencia os registros de nascimento, validando as regras relacionadas às datas e CPFs dos pais.

- **AdicionarAsync**: Adiciona um novo registro de nascimento.
- **AtualizarAsync**: Atualiza os dados de um nascimento existente.
- **RemoverAsync**: Remove um registro de nascimento.
- **ObterPorIdAsync**: Obtém um registro de nascimento específico pelo ID.
- **ObterTodosAsync**: Obtém todos os registros de nascimento.
- **ObterPorPeriodoAsync**: Obtém registros de nascimento dentro de um período especificado.
- **ObterPorNomeAsync**: Obtém registros de nascimento baseados no nome.

#### 3. **ObitoServico**

Gerencia os registros de óbito, com validação das datas de falecimento e registro.

- **AdicionarAsync**: Adiciona um novo registro de óbito.
- **AtualizarAsync**: Atualiza um registro de óbito existente.
- **RemoverAsync**: Remove um registro de óbito.
- **ObterPorIdAsync**: Obtém um registro de óbito específico.
- **ObterTodosAsync**: Obtém todos os registros de óbito.
- **ObterPorNomeAsync**: Obtém registros de óbito baseados no nome.

## **Padrões e Validações**

Cada serviço segue um padrão de validação antes de realizar qualquer operação com os registros. Alguns exemplos de validações incluem:

- **Validação de CPF**: Os CPFs dos envolvidos (cônjuges, pais, etc.) são validados para garantir que são válidos.
- **Validação de Datas**: As datas de registro, nascimento, óbito e casamento são verificadas para garantir que não sejam datas futuras ou inválidas.

## **Dependências**

Para o funcionamento correto dos serviços, as seguintes dependências precisam estar configuradas:

- **DAOs**: Implementações de acesso ao banco de dados para cada tipo de registro (CasamentoDAO, NascimentoDAO, ObitoDAO, ConjugeDAO).
- **Validadores**: Funções utilitárias para validação de CPF e entidades.

---