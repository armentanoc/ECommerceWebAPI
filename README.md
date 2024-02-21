# Projeto E-Commerce Web API :globe_with_meridians:

Este é um projeto ASP.NET Core que utiliza o Entity Framework Core em conjunto com o SQLite para armazenamento persistente, gerenciando um sistema de E-Commerce (Produtos, Vendas, Reembolsos e Devoluções). 

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

## Teste da Política de Cors 🔐

A pasta `/test` (`index.html`, `styles.css`, `scripts.js`) contém o teste da Política de Cors implementada, que só permite o acesso a recursos da API através da rota `localhost:5000`: para visualização, é possível obter todos os produtos, vendas, reembolsos e devoluções, além de realizar o filtro por nome de produto.

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

## Documentação da API 📚
A API está documentada usando Swagger. Após a execução do projeto, acesse a documentação em:

```
http://localhost:5500/swagger/v1/swagger.json
```

## Contribuições 🛠️

Aceitamos contribuições! Se encontrar um bug ou tiver uma solicitação de recurso, por favor, abra uma issue. 
