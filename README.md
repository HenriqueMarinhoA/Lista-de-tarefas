# Sistema de Gerenciamento de Tarefas

Este projeto é um Sistema de Gerenciamento de Tarefas desenvolvido com **ASP.NET Core**, que permite o gerenciamento de tarefas através de uma **API REST**. O sistema oferece operações CRUD (Criar, Ler, Atualizar e Deletar) e conta com documentação via Swagger para facilitar o uso.

## Tecnologias Utilizadas
- **ASP.NET Core**: Framework para desenvolvimento de aplicações web.
- **Entity Framework Core**: ORM para interação com o banco de dados.
- **SQL Server** (ou outro banco de dados configurado).
- **Swagger**: Documentação da API.

## Funcionalidades
- **Cadastro de Tarefas**: Permite criar, listar, atualizar e deletar tarefas com as seguintes informações:
  - **Título**
  - **Descrição**
  - **Status** (Pendente, Em Progresso ou Concluída)
  - **Prioridade** (Baixa, Média ou Alta)
  - **Datas de Criação e Conclusão**
- **Filtragem de Tarefas**: Buscar tarefas por status.
- **Documentação da API**: Utiliza **Swagger** para visualizar as rotas e seus parâmetros.

## Como Configurar o Projeto

### **Pré-requisitos**
- .NET SDK (versão 6.0 ou superior)
- SQL Server ou MySQL configurado e acessível
- Visual Studio ou Visual Studio Code para desenvolvimento

### **Passos para Configuração**

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
   cd seu-repositorio
   ```

2. **Configure a string de conexão do banco**
   Edite o arquivo `appsettings.json` para apontar para seu banco de dados.
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=SEU_SERVIDOR;Database=ListaTarefas;User Id=SEU_USUARIO;Password=SUA_SENHA;"
   }
   ```

3. **Restaurar pacotes e rodar migrações do banco**
   ```bash
   dotnet restore
   dotnet ef database update
   ```

4. **Rodar a API**
   ```bash
   dotnet run
   ```
   A API rodará por padrão em `http://localhost:5000`.

5. **Testar no Swagger**
   Abra no navegador:  
   [http://localhost:5000/swagger](http://localhost:5000/swagger)

## **Endpoints Principais**

### **Criar uma nova tarefa**
```http
POST /api/tarefas
```
#### Exemplo de JSON esperado:
```json
{
  "titulo": "Minha tarefa",
  "descricao": "Detalhes da tarefa",
  "dataCriacao": "2025-03-24T01:05:57.108Z",
  "dataConclusao": null,
  "status": 0,
  "prioridade": 1
}
```

### **Listar todas as tarefas**
```http
GET /api/tarefas
```

### **Filtrar tarefas por status**
```http
GET /api/tarefas?status=0
```

### **Atualizar uma tarefa**
```http
PUT /api/tarefas/{id}
```

### **Deletar uma tarefa**
```http
DELETE /api/tarefas/{id}
```

## **Contribuição**
Sinta-se à vontade para abrir **issues** ou enviar **pull requests**!

## **Licença**
Este projeto está sob a licença **MIT**. Veja o arquivo LICENSE para mais detalhes.

