# Yoga Commerce
Um ecommerce de produtos para yoga.

## Index 
1. [Modelagem de Dados](#modelagem)  
    1. [Modelo Conceitual](#mconceitual)  
    2. [Modelo Lógico](#mlogico)  
    3. [Dicionário de Dados](#mdicionario)  
2. [Uml](#uml) 
    1. [Diagrama de Caso de Uso](#ucasouso)  
    2. [Especificações do Caso de Uso](#uespecificacoes)  
    3. [Diagrama de Classes](#uclasses)  
3. [Guia de Configuração e Execução da Aplicação](#guia)
4. [Contribuidores do projeto](#contribuidores)

<a name="modelagem"/>

## Modelagem de Dados
Programa utilizado: [BrModelo3](http://www.sis4.com/brmodelo/)

<a name="mconceitual"/>

### Modelo Conceitual
O modelo conceitual define a estrutura do nosso ecommerce em termos gerais. Ele é uma representação abstrata da
entidade-relacionamento (ER) da nossa aplicação.

<img src="/Banco%20de%20Dados/Modelagem%20de%20Dados/Modelo%20Conceitual.png">

<a name="mlogico"/>

### Modelo Lógico
O modelo lógico define como as entidades e atributos do nosso ecommerce serão implementados no banco de dados. Ele
utiliza a linguagem SQL para criar tabelas e relacionamentos entre elas.

<img src="/Banco%20de%20Dados/Modelagem%20de%20Dados/Modelo%20L%C3%B3gico.png">

<a name="mdicionario"/>

### Dicionário de Dados
O dicionário de dados é uma coleção de descrições das entidades, atributos e relacionamentos do nosso ecommerce.

PDF: [Dicionário de Dados](https://github.com/henriquecea/YogaCommerce/blob/master/Banco%20de%20Dados/Modelagem%20de%20Dados/Dicion%C3%A1rio%20de%20Dados.pdf)

Excel, XLSX: [Dicionário de Dados](https://github.com/henriquecea/YogaCommerce/blob/master/Banco%20de%20Dados/Modelagem%20de%20Dados/Dicion%C3%A1rio%20de%20Dados.xlsx)

<a name="uml"/>

## Uml - Unified Modeling Language
Programa utilizado: [Drawio](https://app.diagrams.net/)

<a name="ucasouso"/>

### Diagrama de Caso de Uso
Um diagrama de caso de uso representa as funcionalidades do nosso ecommerce em termos dos usos que os usuários
podem fazer da aplicação. Ele é composto por casos de uso, atores e fluxos entre eles.

PDF: [Diagrama de Caso de Uso](https://github.com/henriquecea/YogaCommerce/blob/master/Uml/Diagrama%20Caso%20de%20Uso.pdf)

<a name="uespecificacoes"/>

### Especificações do Caso de Uso
As especificações de cada caso de uso descrevem como ele é implementado no nosso ecommerce. Elas incluem as
funcionalidades necessárias, as restrições e os resultados esperados.

PDF: [Especificações do Caso de Uso](https://github.com/henriquecea/YogaCommerce/blob/master/Uml/Especifica%C3%A7%C3%B5es%20do%20Caso%20de%20Uso.pdf)

<a name="uclasses"/>

### Diagrama de Classes
Um diagrama de classes representa as classes do nosso ecommerce em termos de suas propriedades e métodos. Ele é
composto por classes, atributos e métodos.

PDF: [Diagrama de Classes](https://github.com/henriquecea/YogaCommerce/blob/master/Uml/Diagrama%20de%20Classes.pdf)

<a name="guia"/>

## Guia de Configuração e Execução da Aplicação

Tecnologias Utilizadas:

 - ASP.NET Core: Framework para desenvolvimento de aplicações web e APIs.
 - Angular: Framework para construção da interface do usuário.
 - Node.js: Ambiente de execução para JavaScript no servidor.
 - C#: Linguagem de programação principal para a lógica do servidor.
 - HTML, CSS e TypeScript: Tecnologias para o desenvolvimento do frontend.
 - SQL Server: Sistema de gerenciamento de banco de dados usado pelo Entity Framework para criar tabelas e realizar consultas.

### Passo 1: Baixar e Instalar o Visual Studio 2022 Community

1. Acesse o [site de download do Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/).
2. Selecione a versão "Community" e faça o download.
3. Siga as instruções de instalação.

### Passo 2: Clonar o Repositório

1. Abra o Visual Studio 2022.
2. Clique em **Clonar Repositório**.
3. Insira o link do repositório e siga as instruções para clonar o projeto para o seu ambiente local.
4. Defina dois projetos de inicialização:
   -YogaCommerce.Application
   -YogaCommerce.WebServer

### Passo 3: Baixar e Instalar o Node.js

1. Acesse o [site de download do Node.js](https://nodejs.org/en/download/prebuilt-installer/current).
2. Baixe o instalador para a versão recomendada.
3. Execute o instalador e siga as instruções para completar a instalação.

### Passo 4: Instalar o Angular CLI

1. Abra o **Node.js Command Prompt**.
2. Execute o seguinte comando para instalar o Angular CLI:

   ```bash
   npm install -g @angular/cli@17
   ```

## Passo 5: Banco de Dados

1. Adicione o arquivo .bak no seu banco de dados (SQL SERVER)

<a name="contribuidores"/>

# Contribuidores do projeto:
- Henrique Cea [Linkedin](https://www.linkedin.com/in/henriquecea/)
- Moisés Xavier [Linkedin](www.linkedin.com/in/moises-xavier)
- Gabriel Ramalho [Linkedin](https://www.linkedin.com/in/gabriel-ramalho-6060732b5/)
- Lilian Gouveia [Linkedin](https://www.linkedin.com/in/fromlily/)
- Alexandre Muniz 
- Vitor 
