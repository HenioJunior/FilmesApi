### FilmesApi

Atalhos:

ctor - gera o construtor


- Entity Framework

Em Tools/Nuget...

    EntityFrameworkCore
    EntityFrameworkCore.Tools
    Pomelo //MySQL

Mapeamento App x BD

1. Criação da classe FilomeContext na pasta Data
- Na pasta Data criaremos a classe `FilmeContext: DbContext` que será responsável pelo contexto entre o domínio e o banco de dados;
    A classe vai extender de DbContext;

    - Criação da propriedade de acesso ao banco de dados `DbSet`;

2. Configuração de acesso ao banco de dados;
    
    - Em `appsettings.json`
    ```json
    "ConnectionStrings": {
    "FilmeConnection":
      "server=localhost;database=db_filme;user=root;password=P@ssw0rd"
  }
    ```

3. Criação do builder de conexão ao banco em `Program.cs`;

4. Migration

- No Mac/Linux, instalar dotnet-ef

    `dotnet tool install --global dotnet-ef`

    `dotnet ef migrations add CriantoTabelaDeFilme --project FilmesApi`

    `dotnet ef database update --project FilmesApi`

- No Windows 

    Console de gerenciador de pacotes Nuget
        
        Add-Migration CriandoTabelaDeFilme
        
        Update-Database







