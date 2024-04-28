
# Teste - Vehicle Manager

Projeto desenvolvido para Fenox Tecnologia


## Autor

- [@brunohmsato](https://www.github.com/brunohmsato)


## Instalação

1. Clone o repositório: git clone https://github.com/brunohmsato/VehicleManager.git

2. Copie a query disponível no arquivo de texto disponível no projeto: 
`DbCreation.txt `

3. No SQL Server, execute a query copiada anteriormente. Faça uma nova consulta e gere as tabelas necessárias para a aplicação;

4. Uma vez gerada as tabelas, é só rodar a aplicação web. 
## Configuração do contexto

Dentro do projeto é necessário confirmar a string de conexão com o banco de dados. Ela está disponível em: 

`Infra.Data` -> `DbContext` -> `ApplicationDbContext`


## Funcionalidades

- Sistema simples de login de usuários;

- Interface diferenciada para usuários administradores e comuns;

- Campos para cadastro/edição/exclusão de "combustível", "cor" e "veículos", conforme proposta do projeto;
