# DesafioTecnico-Siemens
Repositório destinado ao desafio Técnico proposto


Utilizado net Core 3.1 para o Backend e Angular 12 para FrontEnd, e visando a possibilidade de leitura do codigo para um maior numero de pessoas, foi utilizado 
a lingua inglesa na maior parte do codigo.

Por uma questão de facilitar o envio, tanto front quanto back estao no mesmo repositorio, 
o backend na pasta <a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/tree/main/DesafioTecnico.API">DesafioTecnico.API</a>,
já o front na pasta <a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/tree/main/DesafioTecnico.Frontend">DesafioTecnico.Frontend</a>

Durante o projeto foi usado um "git Flow" sendo a main a branch principal com politica de so aceitar pull request e a development a branch onde a partir dela 
eram criadas as branch's de feture, podendo consultar o historico de Historico de Pull Requests/Branch's/Commits
<a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/pulls?q=is%3Apr+is%3Aclosed">aqui</a>.

O backend foi implementado usando  Domain-Driven Design (DDD) criando uma boa seperação do codigo, visando aomentar a produtividade e facilidade de futuras manutenções.
Nesse cenário o Backend foi dividido nos seguintes projetos : 

<a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/tree/main/DesafioTecnico.API/DesafioTecnico.API">Api</a> Responsavel por gerenciar todos os 
endpoints metodos http , startup do projeto e Injeções de dependecias.

<a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/tree/main/DesafioTecnico.API/DesafioTecnico.Application">Application</a> Responsável por conter toda
a regra de negocios, nesse caso os Services, assim como o contrato(interface) garantido a boa pratica de desacoplar o codigo 

<a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/tree/main/DesafioTecnico.API/DesafioTecnico.Domain">Domain</a> Responsável pelas Entities e Dto's
Sendo a Entity um objeto que representa a tabela do banco de dados, com suas propiedades,chaves, relacionamentos. Já o Dto é um objeto de transferencia de dados,
sendo importante para não expor a estrutura do banco de dados e permitir uma melhor eficiencia na transferencia de dados podendo personalizar o objeto para
da forma que transporte os dados que serão uteis para aquela requisição.

