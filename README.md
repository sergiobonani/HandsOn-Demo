#CRUD - HandsOn 

# Backend (.Net core e MYSql, podendo ser usado com SQL Server)

O objetivo é criar toda a estrutura de um CRUD, utilizando padrões de desenvolvimento e testes. Nesse projeto, ao final do desenvolvimento, deverá ser contemplado as estruturas em camadas, validações de campos, persistência de dados (incluindo criação da base) e testes.

O projeto usa .Net Core 3.*.

##### Progresso Backend
- Inserção/edição e remoção básicos, validações de campos e sem testes unitários/funcionais.

# Frontend (Angular)

O objetivo é criar um CRUD utilizando Angular, componetizando e reutilizando códigos. Nesse projeto, ao final do desenvolvimento, deverá ter validações de campos, máscaras, mensagens, conexão com backend (considerando persistência dos dados) e por último controle de acesso (login).

O projeto usa Angular Material 8.*, Angular Material e Bootstrap.

##### Progresso Frontend
- Listagem de clientes, opções adicionar/editar e remover. 
Há conexão com o backend, faltam validações e destaque dos campos, não há implementação de testes, não foi feito tela de login e não há implementação da internacionalização.

# Requisitos mínimos para rodar o projeto
- Visual Studio
- Banco de dados MYSql
- Node


# Como utilizar o Backend?
- Altere a string de conexão do banco no arquivo appsettings.json
- Utilize Visual Studio. Não precisa rodar ef migration, pois está setado para instalar automaticamente, caso a string de conexão esteja certa.

# Como utilizar o Frontend?
- O projeto front se encontra na pasta PortalClient. Apesar de estar na mesma pasta, não há vínculo com o backend/solution.
- Utilize npm install e depois npm start.
- Caso necessário, altere o environment para utilizar a url correta de conexão com o back