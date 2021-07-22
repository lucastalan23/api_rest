# API_REST/OSB

Sistema gerenciador de Super Mercado que tem como funcionalidades, CRUD do usuário, categoria e produto. Utilizaçao de injeçao de dependencia, mapeamento de entidades, direcionamento de rotas do banco de dados, utilizaçao de tokens de autenticaçao e utilizaçao de padroes de projeto como Unit Of Work e Request/Response.


## Sumário

- [Configuração de máquina](#Configuração-de-máquina)
- [Configuração do VS Code](#Configuração-do-VS-Code)
- [Rodando o projeto](#Rodando-o-projeto)
- [Rotas para direcionamento](#Rotas-para-direcionamento)

#### Configuração de máquina

Para executar esse projeto na sua máquina, é necessário ter instalado nela o [.Net 3.1 SDK](https://dotnet.microsoft.com/download/visual-studio-sdks) ou uma versão superioir,  [PostgreSQL](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads) e o [POSTMAN](https://www.postman.com/downloads/) . OBS: Se o Visual Studio estiver instalado na sua máquina, é recomendado atualiza-lo ou desinstala-lo antes da instalação do SDK.

Após a instalação do PostgreSQL, abra o pgAdmin. e importe o arquivo .csv dado no repositório da aplicação.


#### Configuração do VS Code

##### Extensões
  - [AutoMapper.Extensions.Microsoft.DependencyInjection](https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection/6.0.0?_src=template)
  - [EntityFramework](https://www.nuget.org/packages/EntityFramework/6.4.4?_src=template)
  - [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/3.1.0?_src=template)
  - [Microsoft.EntityFrameworkCore](nuget.org/packages/Microsoft.EntityFrameworkCore/5.0.7?_src=template)
  - [Microsoft.EntityFrameworkCore.Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/5.0.7?_src=template)	
  - [Microsoft.EntityFrameworkCore.InMemory](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory/5.0.7?_src=template)
  - [Microsoft.EntityFrameworkCore.Relational](nuget.org/packages/Microsoft.EntityFrameworkCore.Relational/5.0.7?_src=template)
  - [Microsoft.EntityFrameworkCore.Sqlite.Core](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite.Core/5.0.7?_src=template)
  - [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/5.0.7?_src=template)
  - [Npgsql.EntityFrameworkCore.PostgreSQL](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL/5.0.7?_src=template)
  - [Npgsql.EntityFrameworkCore.PostgreSQL.Design](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL.Design/1.1.0?_src=template)
  - [System.IdentityModel.Tokens.Jwt](https://www.nuget.org/packages/System.IdentityModel.Tokens.Jwt/6.11.1?_src=template)
  - [ASP.NET Core Snippets](https://marketplace.visualstudio.com/items?itemName=rahulsahay.Csharp-ASPNETCore)
  - [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
  - [C# Extensions](https://marketplace.visualstudio.com/items?itemName=jchannon.csharpextensions) 
  - [C# XML Documentation](https://marketplace.visualstudio.com/items?itemName=k--kato.docomment)



##### Rodando o projeto
-Abra o PgAdmin 4, no Visual Studio Code, abra o terminal e digite a linha de comando "dotnet ef database update", atualize o seu PgAdmin 4 e logo verá o banco de dados da aplicaçao.
- Execução pelo terminal do Visual Studio Code: Abra o terminal dentro da IDE, entre na pasta da aplicação api_rest, e por fim, digite o comando "dotnet run". A aplicaçao vai lançar um LocalHost e provavelmente abrirá um navegador(Nao feche-o) que vai continuar em execuçao até ser parada com o atalho "Ctrl+C".
- Abra o Postman e importe o arquivo de rotas chamado: api_rest.POSTMAN_COLLECTIONS.json. dentro do POST TOKEN, envie uma requisição com o programa no Visual studio code em execuçao. A requisiçao gerará um token e esse mesmo tem que ser utilizado em todas as requisições que serão feitas nas rotas, vá no campo de Authorization, no value substitua o valor do token, para o valor recebido na sua primeira requisição. e envie um objeto, depois é só verificar na rota GET se o objeto foi cadastrado, atualizado, ou excluído.

##### Rotas para direcionamento
- POST

    -Product
      https://localhost:5001/api/product
      
    -Token
      https://localhost:5001/api/token
      
    -Category
      https://localhost:5001/api/categories
      
    -User
      https://localhost:5001/api/user



- PUT

    -Product
      https://localhost:5001/api/categories/ [ID DO PRODUTO]
      
    -Category
      https://localhost:5001/api/categories/ [ID DA CATEGORIA]
      
    -User
      https://localhost:5001/api/user/ [ID DO USUARIO]
      

- GET

    -Product
      https://localhost:5001/api/categories
      
    -Category
      https://localhost:5001/api/categories
      
    -User
      https://localhost:5001/api/user
      


- DELETE

    -Product
      https://localhost:5001/api/product/ [ID DO PRODUTO]
      
    -Category
      https://localhost:5001/api/categories/ [ID DA CATEGORIA]
      
    -User
      https://localhost:5001/api/user/ [ID DO USUARIO] 
