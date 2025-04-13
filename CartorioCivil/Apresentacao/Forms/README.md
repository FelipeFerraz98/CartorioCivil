# CartorioCivil.Apresentacao.Forms

Este diretório contém os **Windows Forms** responsáveis pela interface gráfica da aplicação de registro civil. Ele permite ao usuário acessar e operar os módulos de **nascimento**, **casamento** e **óbito**, com funcionalidades de CRUD.

---

### `FormInicio`

Formulário inicial da aplicação, funcionando como **menu principal de navegação**.

**Funcionalidades:**
- Exibe a tela inicial do sistema.
- Redireciona para os formulários:
  - Nascimento
  - Casamento
  - Óbito
- Ao fechar o `FormInicio`, o sistema é completamente encerrado.

**Componentes principais:**
- `btnNascimento`: Abre o formulário de nascimento.
- `btnCasamento`: Abre o formulário de casamento.
- `btnObito`: Abre o formulário de óbito.

> Todos os formulários retornam para este através de um botão **"Início"** ou ao fechar o formulário.

---

### `FormCasamento`

Formulário para gerenciamento de registros de **casamento**.

**Funcionalidades:**
- Buscar por **CPF** ou **nome dos cônjuges**.
- Listagem automática dos resultados em uma `ListView`.
- Selecione o casamento correto a partir da lista presente na `ListView`.
- **Adicionar**, **atualizar** e **excluir** registros.
- Botão de **retorno para o Início**.

**Principais métodos:**
- `btnBuscar_Click`
- `btnAdicionar_Click_1`
- `btnAtualizar_Click_1`
- `btnExcluir_Click`
- `btnInicio_Click`

---

### `FormNascimento`

Formulário de gerenciamento de registros de **nascimento**.

**Funcionalidades:**
- Buscar registros por nome.
- Listagem automática dos resultados em uma `ListView`.
- Selecione o casamento correto a partir da lista presente na `ListView`.
- **Adicionar**, **editar**, **excluir** registros.
- Botão **"Início"** para retornar ao menu principal.

**Principais métodos:**
- `btnBuscar_Click_1`
- `btnAdicionar_Click_1`
- `btnAtualizar_Click`
- `btnExcluir_Click_1`
- `btnInicio_Click`

---

### `FormObito`

Formulário para gerenciamento de registros de **óbitos**.

**Funcionalidades:**
- Buscar registros pelo **nome do falecido**.
- Listagem automática dos resultados em uma `ListView`.
- Selecione o casamento correto a partir da lista presente na `ListView`.
- **Adicionar**, **atualizar**, **remover** registros.
- Botão para retornar ao **FormInicio**.

**Principais métodos:**
- `btnBuscar_Click`
- `btnAdicionar_Click_1`
- `btnAtualizar_Click_1`
- `btnExcluir_Click_1`
- `btnInicio_Click`

## Serviços Utilizados

Os formulários interagem com a camada de **Negócios (Serviços)** da aplicação:

- `CasamentoServico`
- `NascimentoServico`
- `ObitoServico`

Estes serviços realizam a **validação dos dados** e a **comunicação com o banco de dados** via DAOs.

## Navegação entre telas

- A navegação entre os formulários é realizada a partir do `FormInicio` via `ShowDialog()`.
- Os formulários de Nascimento, Casamento e Óbito possuem um botão **"Início"** que fecha a tela atual e retorna ao `FormInicio`.
- O formulário principal (`FormInicio`) é o **único que mantém a aplicação ativa**, garantindo que ao encerrá-lo, toda a aplicação é finalizada.

---