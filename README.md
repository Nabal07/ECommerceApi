# 🛒 ECommerce API

API REST desenvolvida para gerenciamento de um sistema de e-commerce.

---

## 🚀 Tecnologias Utilizadas

- C#
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger (OpenAPI)

---

## 📁 Estrutura do Projeto

O projeto segue uma arquitetura organizada em camadas:

ECommerce

├── Ecommerce.Domain         → Entidades do sistema  
├── Ecommerce.Infrastructure → Contexto do banco e configurações  
├── Ecommerce.Application    → Regras de negócio  
├── Ecommerce                → Endpoints  

---

## ⚙️ Funcionalidades

- 📦 Criação e gerenciamento de Pedidos
- 📊 Persistência de dados com Entity Framework
- 🧾 Documentação com o Swagger
z
---

## 🗄️ Modelagem do Banco de Dados

### Entidade: Pedido

| Campo       | Tipo        | Descrição                 |
|-------------|-------------|---------------------------|
| Id          | Guid        | Identificador             |
| Status      | Int         | Status do pedido          |
| DataPedido  | DateTime    | Data de criação do pedido |
| CompradorId | Guid        | FK para usuario(comprador)|

---

### Entidade: Produto

| Campo      | Tipo         | Descrição              |
|------------|--------------|------------------------|
| Id         | Guid         | Identificador          |
| Nome       | nvarchar     | Nome do produto        |
| Descricao  | nvarchar     | Descricao do produto   |
| Preco      | decimal      | Valor do produto       |

---

### Entidade: PedidoItem

| Campo       | Tipo | Descrição            |
|-----------|-------|-----------------------|
| Id        | Guid  | Identificador         |
| PedidoId  | Guid  | FK para Pedido        |
| ProdutoId | Guid  | FK para Produto       |

---

### Entidade: Usuario

| Campo  | Tipo   | Descrição               |
|--------|---------|------------------------|
| Id     | Guid    | Identificador          |
| Nome   | nvarchar| Nome do usuario        |


---

## 🔗 Relacionamentos

- Um Pedido pode conter vários Produtos  
- Um Produto pode estar presente em vários Pedidos  

---

## 🧪 Como Rodar o Projeto

### 1. Clonar o repositório

git clone https://github.com/Nabal07/ECommerce.git  
cd ECommerceApi  

---

### 2. Configurar o banco de dados

No arquivo appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ECommerceDB;Trusted_Connection=True;"
}

---

### 3. Executar migrations

dotnet ef migrations add InitialCreate  
dotnet ef database update  

---

### 4. Executar a aplicação

dotnet run  

---

## 📌 Endpoints (Exemplo)

### Pedidos

- GET /api/pedidos  
- POST /api/pedidos  
- PUT /api/pedidos/{id}  
- DELETE /api/pedidos/{id}  

### Produtos

- GET /api/produtos  
- POST /api/produtos  

---

## 📄 Documentação

Após rodar o projeto, acesse:

https://localhost:{porta}/swagger

---

## 📌 Melhorias Futuras

- Adicionar Log  
- Adicionar Autenticação  

---

## 👨‍💻 Autor

Desenvolvido por Nabal Gomes Menezes Filho


