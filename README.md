# Projeto E-Commerce Web API :globe_with_meridians:

Este é um projeto ASP.NET Core que utiliza o Entity Framework Core em conjunto com o SQLite para armazenamento persistente, gerenciando um sistema de E-Commerce (Produtos, Vendas, Reembolsos e Devoluções) fundado em uma Web API Rest, com visualização da aplicação da política de Cors e de algumas das funcionalidades da API via Front End. 

https://github.com/armentanoc/ECommerceWebAPI/assets/88147887/5002a2f6-ea53-423b-ba11-cfd1cfa9e6d2

## Estrutura do Projeto :building_construction:

A pasta `/src` contém a solução `ECommerce` e os projetos que compõem a aplicação.

---

### 💻 `ECommerce.WebAPI` 
Projeto principal que contém a API e os controladores.

### 📦 `ECommerce.Domain` 
Projeto que contém as entidades de domínio da aplicação.

### 🗃️ `ECommerce.Infra` 
Projeto responsável pela camada de infraestrutura, incluindo o contexto do banco de dados e repositórios.

### 🚀 `ECommerce.Application` 
Projeto que implementa a lógica de aplicação e serviços.

### 👀 `ECommerce.ViewModels` 
Projeto que contém os modelos de visualização utilizados pelos controladores.

## Política de Cors 🔐

A pasta `/test` (`index.html`, `styles.css`, `scripts.js`) contém o teste da Política de Cors implementada, que só permite o acesso a recursos da API através da rota `localhost:5000`: para visualização, é possível obter todos os produtos, vendas, reembolsos e devoluções, além de realizar o filtro por nome de produto.
Obs.: Garanta que as configurações do servidor que rode o FrontEnd de testes (ex.: Live Server), ignore os arquivos de log gerados para impedir que a página seja recarregada após uma requisição POST com sucesso. 
Por exemplo, no Live Server, os settings.json podem ignorar totalmente a pasta do BackEnd (`/src`) no `settings.json`:

```
{
    (...)
    "liveServer.settings.ignoreFiles": [

        (...)
        "src/**"
    ]
}
```

## Configuração do Banco de Dados 🛢️
O projeto utiliza o SQLite como banco de dados, e as configurações podem ser encontradas no arquivo `appsettings.json` do projeto `ECommerce.WebAPI`. Certifique-se de ajustar as configurações conforme necessário.

```json
{
  "ConnectionStrings": {
    "ECommerceSqlite": "Data Source=ECommerceDB.db"
  },
}
```

## Execução do Projeto ▶️
1. Clone e abra a solução no Visual Studio.
2. Configure o projeto `ECommerce.Infra` como o projeto de inicialização no `Package Manager Console`.
3. Certifique-se de que as migrações do banco de dados foram realizadas pelo Entity Framework. Se não, execute os seguintes comandos:
```
Add-Migration CreateDatabaseInitial
Update-Database
```
4. Execute o projeto.

## Middleware Customizado de Logging 🗞️ e Filtro Customizado de Exceção 🐛
Através do `Middlewares/LoggingMiddleware` é realizado o logging sempre no começo e no final de uma requisição, com detalhes sobre o status e eventuais erros de forma personalizada, que são capturados no Filtro Customizado de Exceção Global (`Filters/ExceptionFilter.cs`).

https://github.com/armentanoc/ECommerceWebAPI/assets/88147887/d9299bec-d467-4b06-adf2-7239131f7c9c

## Endpoints da API 🚀
A API oferece os seguintes endpoints:

### Exchange 🔄
```
GET /api/exchange: Obtém todas as trocas.
POST /api/exchange: Cria uma nova troca.
GET /api/exchange/{id}: Obtém uma troca pelo ID.
```

### Product 👕
```
GET /api/product: Obtém todos os produtos.
POST /api/product: Cria um novo produto.
GET /api/product/{id}: Obtém um produto pelo ID.
DELETE /api/product/{id}: Deleta um produto pelo ID.
GET /api/product/filter: Filtra produtos por nome.
```

### Refund ◀️
```
GET /api/refund: Obtém todos os reembolsos.
POST /api/refund: Cria um novo reembolso.
GET /api/refund/{id}: Obtém um reembolso pelo ID.
```

### Sale 🛍️
```
GET /api/sale: Obtém todas as vendas.
POST /api/sale: Cria uma nova venda.
GET /api/sale/{id}: Obtém uma venda pelo ID.
```

## Documentação da API 📚
A API está documentada usando Swagger. Após a execução do projeto, acesse a documentação em:

```
http://localhost:5500/swagger/v1/swagger.json
```

## Contribuições 🛠️

Aceitamos contribuições! Se encontrar um bug ou tiver uma solicitação de recurso, por favor, abra uma issue. 
