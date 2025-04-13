# CartorioCivil.Entidades

Este diretório contém as entidades principais utilizadas no domínio da aplicação **Cartório Civil**. Cada classe representa um modelo de dados relacionado aos registros civis de nascimento, casamento e óbito. Essas entidades são utilizadas por outras camadas da aplicação, como serviços, repositórios (DAOs) e a camada de apresentação (Forms).

## Entidades

### Casamento

Representa o registro de um casamento.

**Propriedades:**
- `int Id` – Identificador único do registro.
- `DateTime DataRegistro` – Data do registro do casamento no cartório.
- `DateTime DataCasamento` – Data da cerimônia do casamento.
- `int IdConjuge1` – Chave estrangeira para o primeiro cônjuge.
- `int IdConjuge2` – Chave estrangeira para o segundo cônjuge.
- `Conjuge Conjuge1` – Objeto do primeiro cônjuge.
- `Conjuge Conjuge2` – Objeto do segundo cônjuge.

---

### Conjuge

Representa um indivíduo que faz parte de um casamento.

**Propriedades:**
- `int Id` – Identificador do cônjuge.
- `string Nome` – Nome completo.
- `string CPF` – CPF do cônjuge.
- `string NomePai` – Nome do pai.
- `string NomeMae` – Nome da mãe.
- `string CpfnPai` – CPF do pai.
- `string CpfnMae` – CPF da mãe.
- `DateTime DataNascimentoPai` – Data de nascimento do pai.
- `DateTime DataNascimentoMae` – Data de nascimento da mãe.

---

### Nascimento

Representa um registro de nascimento.

**Propriedades:**
- `int Id` – Identificador do registro.
- `DateTime DataRegistro` – Data de registro no cartório.
- `DateTime DataNascimento` – Data de nascimento da criança.
- `string NomeRegistrado` – Nome dado à criança no registro.
- `string NomePai` – Nome do pai.
- `string NomeMae` – Nome da mãe.
- `string CpfnPai` – CPF do pai.
- `string CpfnMae` – CPF da mãe.
- `DateTime DataNascimentoPai` – Data de nascimento do pai.
- `DateTime DataNascimentoMae` – Data de nascimento da mãe.

---

### Obito

Representa um registro de óbito.

**Propriedades:**
- `int Id` – Identificador do registro.
- `DateTime DataRegistro` – Data do registro do óbito.
- `DateTime DataObito` – Data do falecimento.
- `string NomeFalecido` – Nome completo da pessoa falecida.
- `DateTime DataNascimento` – Data de nascimento da pessoa falecida.
- `string NomePai` – Nome do pai.
- `string NomeMae` – Nome da mãe.
- `DateTime DataNascimentoPai` – Data de nascimento do pai.
- `DateTime DataNascimentoMae` – Data de nascimento da mãe.

---

