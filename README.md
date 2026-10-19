# TaskFlow Console

Aplicação de console em .NET 10 para cadastrar, listar e concluir tarefas mantidas em memória. O projeto inclui testes unitários com xUnit.

## Pré-requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download/dotnet/10.0)

Confirme a instalação com:

```bash
dotnet --version
```

## Compilar

Na pasta raiz do repositório, execute:

```bash
dotnet build TaskFlow.sln
```

## Executar a aplicação

```bash
dotnet run --project TaskFlow.Console/TaskFlow.Console.csproj
```

No menu interativo, escolha uma opção para adicionar, listar ou concluir tarefas. As tarefas ficam disponíveis somente durante a execução atual da aplicação.

## Executar os testes

```bash
dotnet test TaskFlow.sln
```

Os testes validam a inclusão de tarefas, a rejeição de títulos nulos ou vazios e o tratamento de IDs inexistentes.

## Estrutura

```text
TaskFlow.Console/   Aplicação, entidade de domínio e gerenciador de tarefas
TaskFlow.Tests/     Testes unitários xUnit
TaskFlow.sln        Solução .NET
```
