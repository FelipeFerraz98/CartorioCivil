# CartorioCivil.Testes

Este diretório contém os testes automatizados para os serviços da aplicação **Cartório Civil**, que lida com registros de Casamentos, Nascimentos e Óbitos. Os testes são escritos usando o framework de testes **NUnit** e **Moq** para mocks de dependências.

## Serviços Testados

1. **CasamentoServico**
2. **NascimentoServico**
3. **ObitoServico**

## Estrutura do Projeto

O projeto de testes é composto por diferentes classes de testes para cada serviço, incluindo o uso de mocks para testar a lógica sem depender de bancos de dados ou outras fontes externas. Cada serviço possui um conjunto de testes unitários que verificam os comportamentos esperados para as operações CRUD (criar, ler, atualizar e excluir).

## CasamentoServicoTests

Testa as operações de adicionar e consultar casamentos, incluindo a validação de dados:

- **AdicionarAsync_CasamentoValido_DeveAdicionarComSucesso**: Verifica se o casamento é adicionado com sucesso.
- **AdicionarAsync_CasamentoComErro_DeveLancarExcecao**: Verifica se uma exceção é lançada ao tentar adicionar um casamento com dados inválidos (exemplo: data no futuro).
- **ObterConjugePorCpfAsync_CpfValido_DeveRetornarConjuge**: Verifica se é possível buscar o cônjuge por CPF.
- **ObterConjugePorCpfAsync_CpfInvalido_DeveLancarExcecao**: Verifica se uma exceção é lançada quando o CPF é inválido.
- **ObterConjugePorNomeAsync_ConjugeExistente_DeveRetornarConjuge**: Testa a busca por nome de cônjuge.
- **ObterConjugePorNomeAsync_ConjugeNaoEncontrado_DeveLancarExcecao**: Verifica se uma exceção é lançada caso o cônjuge não seja encontrado.

## NascimentoServicoTests

Testa as operações de adicionar e consultar nascimentos, além de validar CPF e datas:

- **AdicionarAsync_NascimentoValido_DeveAdicionarComSucesso**: Verifica se o nascimento é adicionado com sucesso.
- **AdicionarAsync_DataNascimentoFutura_DeveLancarExcecao**: Verifica se uma exceção é lançada ao tentar adicionar um nascimento com data futura.
- **AdicionarAsync_CPFInvalidoPai_DeveLancarExcecao**: Verifica se uma exceção é lançada quando o CPF do pai é inválido.
- **ObterPorNomeAsync_NomeValido_DeveRetornarLista**: Verifica se é possível buscar um nascimento pelo nome registrado.
- **ObterPorNomeAsync_NomeVazio_DeveLancarExcecao**: Verifica se uma exceção é lançada quando o nome do registrado é vazio.
- **ObterPorPeriodoAsync_PeriodoValido_DeveRetornarLista**: Verifica se é possível consultar nascimentos dentro de um período.
- **ObterPorPeriodoAsync_DataInicioMaiorQueFim_DeveLancarExcecao**: Verifica se uma exceção é lançada quando a data de início do período é maior que a data de fim.

## ObitoServicoTests

Testa as operações de adicionar e consultar óbitos:

- **AdicionarAsync_ObitoValido_DeveAdicionarComSucesso**: Verifica se o óbito é adicionado com sucesso.
- **AdicionarAsync_ObitoComErro_DeveLancarExcecao**: Verifica se uma exceção é lançada ao tentar adicionar um óbito com dados inválidos.
- **ObterPorIdAsync_ObitoExistente_DeveRetornarObito**: Verifica se um óbito é retornado com sucesso por ID.
- **ObterPorNomeAsync_ObitoExistente_DeveRetornarObito**: Verifica se é possível buscar um óbito pelo nome.

## Dependências

Este projeto usa as seguintes dependências para os testes:

- **NUnit**: Framework para testes unitários.
- **Moq**: Biblioteca para mocks de dependências.

