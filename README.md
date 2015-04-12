# LearnAngularDDD

Este é um projeto desenvolvido a fim de estudar as tecnologias nele presentes.

É uma agenda, bem simples, com categorias e contatos.
Contatos tem nome, categoria, e um telefone residencial e/ou celular.
É uma SPA (single page application) em angularjs.

O back-end é uma web api com owin e bearer authentication.
Está arquitetado de acordo com o DDD (domain driven design).
Utiliza Ninject para injeção de dependências.
Utiliza EntityFramework Code-First para o db e Migrations para atualizar.
Utiliza uma UnitOfWork criada por mim para gerenciar as transactions com o banco.
