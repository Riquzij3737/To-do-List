@echo off

rem verificando a existencia do sdk do .net 

dotnet sdk --version 

if %ERRORLEVEL% NEQ 0 (
    echo "SDK do .NET não encontrado"
    goto install
) else (
    echo "SDK do .NET encontrado"
    goto build
)


:install

winget install --ID Microsoft.Dotnet.SDK.8 -e
goto build

:install_git 

winget install --ID Git.Git -e

goto build

:build 

rem verificando a existencia do git 

git --version

if %ERRORLEVEL% NEQ 0 (
    echo "Git não encontrado"
    goto install_git
) else (
    echo "Git encontrado"    
)

git clone https://github.com/Riquzij3737/To-do-List.git

cd To-do-List

dotnet run