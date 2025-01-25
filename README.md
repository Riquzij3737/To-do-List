# To-do-List-List

Este programa consiste em uma lista de tarefas, onde você pode adicionar, remover e marcar como concluídas as tarefas que desejar. Sua integração com um banco de dados do tipo SQLite permite que você salve suas tarefas e as acesse posteriormente. Ou seja, sempre que você adicionar uma tarefa, sair e depois voltar, ela estará esperando para ser concluída.

# Como usar

A utilização é bem simples:

- Passo 1: Clone o repositório

Primeiro, você deve instalar o git em sua máquina, caso não tenha instalado. Para isso, acesse o site oficial do git e siga as instruções de instalação. Depois, no terminal, digite:

```Powershell
git clone https://github.com/Riquzij3737/To-do-List.git 
```

Após isso, um diretório chamado "To-do-List" será criado em sua máquina.

- Passo 2: Instale as dependências

Após isso, você deve instalar as dependências do projeto, que são:

- SDK do .NET 8.0
- Runtime do .NET 9.0 ou 8.0
- Visual Studio ou Rider

Para isso, acesse o diretório do projeto e digite o seguinte comando no terminal:

* No Windows *

```Powershell
winget install Microsoft.Dotnet.SDK.8
```

* No Linux *
```bash
sudo apt install dotnet-sdk-8
```

Após isso, o runtime e o SDK do .NET serão instalados em sua máquina.

Nota: O Visual Studio ou Rider são opcionais, mas recomendados para uma melhor experiência de desenvolvimento.

- Passo 3: Execute o projeto

Após a instalação das dependências, você deve executar o projeto. Para isso, acesse o diretório do projeto e digite o seguinte comando no terminal:

```Powershell
dotnet run
```

E por fim, o projeto será executado e você poderá utilizar a lista de tarefas.

# Tecnologias utilizadas

As tecnologias utilizadas foram:

- C#, Versão mais recente, a 12
  Para todo o código em geral, incluindo a interface gráfica, configuração de banco de dados, e tudo mais.

- .NET, Versão 8.0
  Para a execução do código, criação e execução do projeto.

- Windows Forms
  Para a criação da interface gráfica.

- SQLite
  Para salvar os dados e reutilizá-los depois.

- Git
  Para o controle de versão do projeto e para o compartilhamento do mesmo.

# Notas finais

Espero que gostem do projeto e que ele seja útil para vocês.

Irei adicionar dois arquivos a mais no código, um é o build.ps1, que é um script que irá compilar o projeto e executá-lo, e o outro é o build.sh, que é o mesmo que o build.ps1, mas para Linux.

Obrigado por instalar meu projeto. Caso encontre algum erro, e queira reportar, por favor, me avise.

