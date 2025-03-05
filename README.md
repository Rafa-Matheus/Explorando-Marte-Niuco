# Explorando-Marte-Niuco# Explorando Marte Niuco 2025

Esta é uma solução em C# .NET 7.0 para o desafio técnico da Niuco, onde controlo sondas em Marte com comandos como **L** (girar à esquerda), **R** (girar à direita) e **M** (mover), respeitando limites do planalto e evitando colisões, com validação de segurança antes da execução. Utilizo padrões como **Command** e **Factory**, princípios **SOLID**, testes **xUnit** e **CI no GitHub Actions**.

## Estrutura do Projeto

**Repositório Remoto:** [GitHub](https://github.com/Rafa-Matheus/Explorando-Marte-Niuco)

### Pastas:
- **Explorando-Marte-Niuco**: Código principal (console app).
- **Explorando-Marte-Niuco.Test**: Testes unitários com xUnit.
- **.github/workflows/CIpipeline.yml**: Pipeline CI no GitHub Actions.

## Como Executar

Clone o repositório:

```bash
git clone https://github.com/Rafa-Matheus/Explorando-Marte-Niuco.git
cd Explorando-Marte-Niuco
```

Rode o programa:

```bash
dotnet run --project Explorando-Marte-Niuco/Explorando-Marte-Niuco.csproj
```

1. Digite as dimensões do planalto (ex.: `5 5`).
2. Digite a posição inicial e direção da sonda (ex.: `1 1 N`).
3. Digite os comandos (ex.: `MMR`).
4. Veja a posição final ou mensagens de erro (colisão ou fora dos limites).

## Estrutura do Código

### Modelos (`Models/`):
- **Planalto.cs**: Gerencia limites e posições ocupadas com um HashSet.
- **Sonda.cs**: Representa a sonda com posição (X, Y) e direção (N, S, E, W).

### Comandos (`Commands/`):
- **ICommand.cs**, **Mover.cs**, **GirarEsquerda.cs**, **GirarDireita.cs**: Implementam ações da sonda.

### Fábrica (`Factory/`):
- **ISondaFactory.cs**, **SondaFactory.cs**: Criam sondas reais e simuladas.

### Serviço (`Services/`):
- **SondaService.cs**: Executa comandos e simula trajetos.

### Programa (`Program.cs`):
- Interface com o usuário e coordenação da execução.

## Design Patterns

### **Command Pattern**
O **Command Pattern** encapsula ações como objetos, permitindo flexibilidade para extensões ou reversão de comandos. Ele opera por meio de uma interface com um método `Executar`, implementado por classes específicas para cada ação. Neste projeto, utilizo-o para gerenciar os comandos **L, R e M** da sonda, implementados como classes (**Mover, GirarEsquerda, GirarDireita**) que são mapeadas em um dicionário no **SondaService** para execução dinâmica conforme os comandos do usuário.

### **Factory Pattern**
O **Factory Pattern** controla a criação de objetos, abstraindo o processo de instanciação para garantir consistência e flexibilidade. Ele funciona com uma interface que define métodos de criação, delegando a construção a uma classe concreta. Aqui, aplico-o na **SondaFactory**, que usa `CriarSondaSimulada` para simular trajetos em um planalto separado e `CriarSonda` para instanciar sondas reais após validação, assegurando que o estado do planalto só seja alterado se o trajeto for seguro.

## Princípios SOLID

- **SRP (Single Responsibility Principle):** Cada classe tem uma única responsabilidade. O **Planalto** gerencia limites e posições, o **Mover** executa movimentos, e o **SondaService** coordena comandos e simulação.

## Debugging

Configurei o debug no **VS Code** com um breakpoint no método `Executar` do **Mover.cs**.

### Passos:
1. Abra `Mover.cs` e adicione um breakpoint na linha `public void Executar(Sonda sonda, Planalto planalto)`.
2. Eu não precisei durante o desenvolvimento, mas se necessário, configure o `launch.json` em `.vscode/`. Eu costumo usar o "integratedTerminal" como console:

```json
{
    "version": "0.2.0",
    "configurations": [
        {
            "name": "Debug MarsRoverChallenge",
            "type": "coreclr",
            "request": "launch",
            "preLaunchTask": "build",
            "program": "${workspaceFolder}/Explorando-Marte-Niuco/bin/Debug/net7.0/Explorando-Marte-Niuco.dll",
            "args": [],
            "cwd": "${workspaceFolder}/Explorando-Marte-Niuco",
            "console": "integratedTerminal",
            "stopAtEntry": false
        }
    ]
}
```

3. Execute com `F5`, entre no método `Executar` com `F11`, insira `5 5`, `1 1 N`, `M`, e observe as variáveis `novoX` e `novoY` mudarem na coluna de debug à esquerda (ex.: `novoY` de 1 para 2).

**Resultado:** Demonstra a validação do movimento antes de atualizar a posição.

## Testes Unitários

**Localização:** `Explorando-Marte-Niuco.Test/`

**Comando:**

```bash
dotnet test Explorando-Marte-Niuco.Test/Explorando-Marte-Niuco.Test.csproj
```

### Testes:
- **MoverTest**: Verifica movimento correto, exceções para fora dos limites e colisões.
- **GirarEsquerdaTest**: Confirma giro de 'N' para 'W'.
- **GirarDireitaTest**: Confirma giro de 'N' para 'E'.
- **SondaTest**: Confirma criação da sonda com posição e direção corretas
- **SondaServiceTest**: Testa trajetos completos e detecção de erros na simulação.

**Cobertura:** Movimentação básica, mudança de direção, limites, colisões e cenários de erro.

## CI com GitHub Actions

**Arquivo:** `.github/workflows/CIpipeline.yml`

### Conteúdo:

```yaml
name: Pipeline-CI

on:
  push:
    branches: [main]
  pull_request:
    branches: [main]

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
    - name: Baixar código
      uses: actions/checkout@v4
    - name: Configurar .NET
      uses: actions/setup-dotnet@v4
      with:
        dotnet-version: '7.0.x'
    - name: Restaurar as dependências
      run: dotnet restore Explorando-Marte-Niuco.sln
    - name: Compilar
      run: dotnet build Explorando-Marte-Niuco.sln --configuration Release --no-restore
    - name: Executar testes
      run: dotnet test Explorando-Marte-Niuco.Test/Explorando-Marte-Niuco.Test.csproj --configuration Release --no-build --verbosity normal
```

**Funcionamento:** Executa a cada push ou pull request para a branch **main**, baixando o código, configurando **.NET 7.0**, restaurando dependências, compilando e rodando os testes.

## Vídeos no YouTube

Acompanhe o desenvolvimento do sistema nos vídeos abaixo:

- [Desafio Niuco - Pt. 1](https://www.youtube.com/watch?v=cMezdz5UrRw&t=69s)
- [Desafio Niuco - Pt. 2](https://www.youtube.com/watch?v=nFcqDwDOTDM&t=752s)
- [Desafio Niuco - Pt. 3](https://www.youtube.com/watch?v=Te-oG943iQ8&t=4s)

## Agradecimentos

Agradeço à **Niuco** pela oportunidade de participar deste desafio técnico! Foi incrível desenvolver esta solução com boas práticas e automação. 

Gostaria de contribuir com a equipe da Niuco com minha dedicação, conhecimento, curiosidade e compromisso. Tenho plena consciência de que ainda há muito a aprender, mas estou determinado a evoluir rapidamente e entregar resultados que não apenas atendam, mas acima de tudo superem as expectativas. Sou estudioso, resiliente e apaixonado por resolver desafios, e acredito que posso agregar valor ao time enquanto cresço junto com a empresa. Agradeço sinceramente pela oportunidade de participar deste processo.

Rafael Matheus de Oliveira
rafi.matheus.oliveira@gmail.com
(16) 99159-0367
