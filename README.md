# CartorioCivil

Sistema de registro civil para gerenciamento de **nascimentos**, **casamentos** e **óbitos**, desenvolvido em **C# com Windows Forms .NET Framework 4.6.2** e banco de dados **PostgreSQL**. O projeto adota arquitetura DAO, promovendo modularidade, testabilidade e manutenibilidade.

Este `README` fornece uma visão geral e aponta para documentações específicas em cada diretório.

## Estrutura do Projeto

```bash
CartorioCivil/
├── Apresentacao/         # Interface gráfica (Windows Forms)
│   └── Forms/            # Formulários principais
├── Entidades/            # Modelos de domínio
├── Infraestrutura/
│   ├── BancoDeDados/     # Classe de conexão com o PostgreSQL
│   ├── Interfaces/       # Contratos dos DAOs
│   └── RegistrosDAO/     # Implementações de acesso a dados
├── Negocios/
│   ├── Servicos/         # Lógica de negócio
│   ├── Validadores/      # Validações (CPF, entidade)
│   └── Relatorios/       # Geração de relatórios em DataTable
├── CartorioCivil.Testes/ # Testes automatizados com NUnit + Moq            
```

---

## Visão Geral dos Módulos

### Interface Gráfica

A interface é baseada em **Windows Forms** com formulários separados por tipo de registro. Inclui botões de navegação para facilitar a usabilidade.

Veja mais em:  
- [`Apresentacao/Forms/README.md`](CartorioCivil/Apresentacao/Forms/README.md)

---

### Entidades

As **entidades** representam os objetos principais do domínio: `Nascimento`, `Casamento`, `Obito` e `Conjuge`.

Veja mais em:  
- [`Entidades/README.md`](CartorioCivil/Entidades)

---

### Infraestrutura e Acesso a Dados

A camada de infraestrutura implementa o **padrão DAO**, dividida entre interfaces e implementações.  
Inclui o uso de `MapearParametros` e acesso seguro com `NpgsqlCommand` parametrizado (contra SQL Injection).

Veja mais em:  
- [`Infraestrutura/BancoDeDados/README.md`](CartorioCivil/Infraestrutura/BancoDeDados)  
- [`Infraestrutura/Interfaces/README.md`](CartorioCivil/Infraestrutura/Interfaces)  
- [`Infraestrutura/RegistrosDAO/README.md`](CartorioCivil/Infraestrutura/RegistrosDAO)

---

### Lógica de Negócio

A lógica de negócio é centralizada na pasta `Servicos`, garantindo a validação e consistência dos dados antes de acessar o banco.

Veja mais em:  
- [`Negocios/Servicos/README.md`](CartorioCivil/Negocios/Servicos)

---

### Testes Automatizados

Os testes utilizam **NUnit** e **Moq** para garantir o correto funcionamento dos serviços de negócio com cobertura de cenários válidos e inválidos.

Veja os testes em:  
- [`CartorioCivil.Testes/README.md`](CartorioCivil.Testes/)

---

## Como Executar o Projeto

1. **Configure o Banco de Dados**:
   - Crie um banco PostgreSQL local
   - Execute os scripts SQL do [README da Infraestrutura](CartorioCivil/Infraestrutura/RegistrosDAO/README.md)

2. **Configure a String de Conexão**:
   - No `App.config`, configure o valor correto na tag `connectionString`

3. **Rode pelo Visual Studio**:
   - Abra o arquivo `CartorioCivil.sln`
   - Pressione `F5` para compilar e executar o sistema


## Bibliotecas Utilizadas

| Biblioteca                     | Uso                                          |
|-------------------------------|----------------------------------------------|
| **Npgsql**                    | Conector PostgreSQL para .NET                |
| **NUnit**                     | Testes automatizados                         |
| **Moq**                       | Mock de interfaces nos testes                |
| **System.Configuration**      | Leitura de `App.config`                      |
