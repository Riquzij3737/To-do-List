#!/bin/bash

# Verificando a existência do SDK do .NET
dotnet --version

if [ $? -ne 0 ]; then
    echo "SDK do .NET não encontrado, instalando..."
    sudo apt install -y dotnet-sdk-8.0
    if [ $? -ne 0 ]; then
        echo "Falha ao instalar o SDK do .NET."
        exit 1
    fi
else
    echo "SDK do .NET encontrado."
fi

# Verificando a existência do Git
git --version

if [ $? -ne 0 ]; then
    echo "Git não encontrado, instalando..."
    sudo apt install -y git
    if [ $? -ne 0 ]; then
        echo "Falha ao instalar o Git."
        exit 1
    fi
else
    echo "Git encontrado."
fi

# Clonando o repositório
git clone https://github.com/Riquzij3737/To-do-List.git

if [ $? -ne 0 ]; then
    echo "Falha ao clonar o repositório."
    exit 1
fi

# Entrando no diretório do projeto
cd To-do-List || exit 1

# Executando o projeto
dotnet run
