# ewave-livraria-plenoII
Este projeto é referente ao processo seletivo da Ewave do Brasil para a vaga de Desenvolvedor Back-End Pleno II

Sobre o projeto desenvolvido.

por: João Paulo de Moraes da Costa

O projeto foi dividido em duas etapas back-end e depois front-end.
No Back-end foi utilizada a linguagem c# com .Net Core 3.1. Apostei na arquitetura, funcionalidade e organização do código, como modelo arquitetural utiizei DDD, com os designs patterns Repository e Dependency Injection, disponibilizando os recursos via web api no estilo REST, Utilizei também XUnit para teste unitário e EntityFramework Core como ORM do Banco.
No Front-end utilizei angular na versão 12 e apliquei Reactive Forms como abordagem.

O que eu pretendia: entregar todos os cruds funcionais no front-end, e realizar os testes unitarios em todas as classes controller do back, no entanto devido ao prazo estou entregando na parte do front o cadastro funcional de Livro e a exibição dos livros cadastrados e no Back os seguintes end-points:

 - Autor
 - EmprestimoLivro
 - Genero
 - InstituicaoEnsino
 - Livro
 - ReservaLivro
 - Usuario
Todos estes com os devidos verbos: GET, POST e PUT.

As regras foram implementadas conforme solicitado no readme do desafio.
