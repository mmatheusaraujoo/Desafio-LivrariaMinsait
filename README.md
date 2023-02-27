<h1>Desafio Livraria Minsait-Indra</h1>

<h1 align="center"> API Sistema de Livraria </h1>

<div align="center">
    <img
        src="https://img.shields.io/badge/Microsoft_SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white">
    <img src="https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white">
    <img src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white">
    <img src="https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white">
</div>

<p align="center"><img
        src="http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge">

<p align="center"> Projeto que propõe a criação de um sistema de Livraria utilizando ASP.NET6 e Angular com o
    intuito de demonstrar conhecimento para o treinamento Jovens Profissionais da <b>Indra - Minsait (Formação
        .Net e Angular)</b>.</p>


<h2>Descrição do projeto</h2>
<p align="justify">Esse projeto em especifico apresenta a implementação de um sistema de GLivraria com
    funcionalidades basicas, tendo como metodo de requisição HTTP associado com sistema de gerenciamento de
    banco de dados SQLService. A API "LivrariaAPI" é responsavel pela criação de dados e manipulação dos mesmos,
    já o Angular foi utiliado na criação do Front-End de interação com usuário. A criação e conexão com o banco
    de dados é feita utilizando Entity Framework, como auxilio a visualização da implementação é utilizado o
    Swagger.</p>


<h1>Tecnologias Utilizadas</h1>

<h2>C# / .NET6</h2>
<p>Linguagem das API's e Framework Utilizado<p>

<h2>Angular</h2>
<p>Foi utilizado como Framework Front-End</p>

<h2>Requisitos do projeto</h2>
<p>Para confirguração do projeto é necessário os seguintes itens:</p>
<ul>
    <li>
        <h3>Editor de Codigo</h3>
        <p>Você pode usar qualquer editor de código que preferir, como Visual Studio Code, Sublime Text, Atom,
            etc. Para esse projeto em especifio foi utilizado o Visual Studio para desenvolvimento e manipulação
            dos arquivos em C# e Visual Studio Code para Typescript e outros arquivos Angular.</p>
    </li>
    <li>
        <h3>Banco de dados SQLServer</h3>
        <p>Para persistência de dados nesse projeto é nescessário conexão com um banco de dados SQLServer. De
            forma opcional é reconmedavel utilizar uma imagem Docker SQLServer, já que foi nesse ambiente que
            foi desenvolvido o projeto. Afim de auxiliar a executar esse pré-requisito recomendo esta matéria:
            https://balta.io/blog/sql-server-docker</p>
    </li>
    <li>
        <h3>Sdk do .NET 6</h3>
        <p>Nécessario para inicializar projeto "LivrariaAPI". Disponivel em:
            https://dotnet.microsoft.com/pt-br/download/dotnet/6.0</p>
    </li>
    <li>
        <h3>Node.js</h3>
        <p>
            O Angular é construído com o Node.js, portanto, você precisa ter o Node.js instalado em seu
            computador para executar um projeto Angular. Você pode baixar e instalar o Node.js a partir do site
            oficial: https://nodejs.org .
        </p>
    </li>
    <li>
        <h3>AngularCLI</h3>
        <p>
            NAngular CLI: o Angular CLI é uma ferramenta de linha de comando usada para gerar, construir e
            executar projetos Angular. Você pode instalá-lo globalmente em seu computador usando o seguinte
            comando no terminal
        </p>
    </li>
</ul>

```
    npm install -g @angular/cli
```
<h2>Configurando o projeto</h2>
<ol>
    <li>
        <h3>Configurando API e Banco de Dados</h3>
        <p>Para configuração do projeto abra, em um editor de codigo, a pagina LivrariaApi/livrariaApi onde está
            o arquivo Program.cs . Essa caminho é onde está o localizado o projeto .NET6 da api.</p>
        <p>No arquivo Data/LivrariaDataContext.cs no metodo OnConfiguring realize a seguinte modificação</p>

        ```
            protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost,1433;Database=Livraria;User
            ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;");
        ```

        ```
            protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Sua string de Conexão.");
        ```

        <p>
            Após isso, no diretorio raiz do projeto e utilizando de um terminal de sua escolha, execute os
            seguintescomandos
        </p>
        
        ```
            dotnet build //comando responsavel por carregar compilar a aplicação e carregar as dependências.
            dotnet ef migrations add MigraçãoInicial //comando responsavel por gerar uma migração a ser aplicada no banco.
            dotnet ef database update //Comando responsavel por criar o banco de Dados.
        ```
        
    </li>
    <li>
        <h3>Configurando Front-End Angular</h3>
        <p>Depois de ter instalado os requisitos citados anteriormente, você precisa instalar as dependências do
            projeto Angular. Navegue até o diretório raiz do projeto e execute o seguinte comando no terminal
        </p>
        
            ```
                npm install
            ```
        
        <p>Este comando instalará todas as dependências necessárias definidas no arquivo package.json.</p>
    </li>
</ol>
<h2>Executando o projeto</h2>
<ol>
    <li>
        <h3>API .NET</h3>
        <p>
            abra em um terminal a raiz do projeto da API (O caminho /LivrariaApi/LivrariaApi onde está o arquivo
            Program.cs) e execute o seguinte comando.
        </p>

            ```
                dotnet run
            ```

        <p>Caso tudo esteja de acordo a API ira iniciar com endereço: https://localhost:7154 e
            http://localhost:5011</p>
    </li>
    <li>
        <h3>Front-End Angular</h3>
        <p>Em outro terminal abra a pasta raiz do projeto Angular (o caminho /livrariaMinsaitFront) e execute o
            seguinte comando.</p>
        
            ```
                ng serve
        
            ```

        <p>Este comando compilará o projeto e executará um servidor de desenvolvimento. O servidor estará
            disponível em http://localhost:4200/. Abra o navegador e navegue até essa URL para ver o projeto em
            execução.</p>
    </li>
</ol>


<h2>Desenvolvedores do projeto</h2>
<img src="https://avatars.githubusercontent.com/u/106783873?v=4" width=115>
<h5><b>Matheus Araújo<b></h5>

<h2>Licença</h2>
The <a href="https://github.com/mmatheusaraujoo/Desafio-LivrariaMinsait/blob/main/LICENSE.md">[MIT License]</a>
(MIT)
<br>Copyright :copyright: 2023 - Matheus Araújo dos Santos
