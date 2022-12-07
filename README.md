# DesafioTecnico-Siemens 

Repositório destinado ao desafio Técnico proposto 

  

  

Utilizado net Core 3.1 para o Backend e Angular 12 para FrontEnd, e visando a possibilidade de leitura do código para um maior numero de pessoas, foi utilizado
a língua inglesa na maior parte do código. 


Por uma questão de facilitar o envio, tanto front quanto back estão no mesmo repositório,  

o backend na pasta <a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/tree/main/DesafioTecnico.API">DesafioTecnico.API</a>, 

já o front na pasta <a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/tree/main/DesafioTecnico.Frontend">DesafioTecnico.Frontend</a> 


Durante o projeto foi usado um "git Flow" sendo a main a branch principal com politica de só aceitar pull request e a development a branch onde a partir dela  

eram criadas as branch's de feture, podendo consultar o histórico de Histórico de Pull Requests/Branch's/Commits 

<a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/pulls?q=is%3Apr+is%3Aclosed">aqui</a>. 

  
O backend foi implementado usando  Domain-Driven Design (DDD) criando uma boa separação do código, visando aumentar a produtividade e facilidade de futuras manutenções. 

Nesse cenário o Backend foi dividido nos seguintes projetos :  

<a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/tree/main/DesafioTecnico.API/DesafioTecnico.API">Api</a> Responsável por gerenciar todos os  
endpoints metodos http , startup do projeto e Injeções de dependências. 

<a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/tree/main/DesafioTecnico.API/DesafioTecnico.Application">Application</a> Responsável por conter toda a regra de negócios, nesse caso os Services, assim como o contrato(interface) garantido a boa pratica de desacoplar o código  

<a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/tree/main/DesafioTecnico.API/DesafioTecnico.Domain">Domain</a> Responsável pelas Entities e Dto's 

Sendo a Entity um objeto que representa a tabela do banco de dados, com suas propriedades, chaves, relacionamentos. Já o Dto é um objeto de transferência de dados, 

sendo importante para não expor a estrutura do banco de dados e permitir uma melhor eficiência na transferência de dados podendo personalizar o objeto para 

da forma que transporte os dados que serão uteis para aquela requisição. 

<a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/tree/main/DesafioTecnico.API/DesafioTecnico.Infrastructure">Infrastructure</a> Responsável pelo contexto, repositório e interface do repositório. Sendo o contexto o responsável por todo ciclo de vida das entities onde as mudanças devem ocorrer para serem persistidas ao banco de dados. O repositório abstrai os métodos responsáveis por gerar ações dentro do contexto, sendo escrito métodos personalizados para 
atender as necessidades ou padrões organizacionais, já a interface do repositório gera um contrato para desacoplar o código. 

<a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/tree/main/DesafioTecnico.API/DesafioTecnico.Library">Library</a> Responsável por abrigar códigos úteis que podem ser usados ao longo de toda aplicação como uma estrutura padrão de retorno e mensagens de sucesso e erro padronizadas. evitando a reescrita de códigos e garantido a padronização de grandes sistemas. 

  
O Frontend foi pensado em ter uma aparência que lembrasse um pouco um terminal, com fundo preto e letras brancas sem grandes efeitos gráficos. 

A ideia principal ao desenvolve-lo foi demonstrar o  uso de componentes e classes de controle, buscando evitar repetição de código e padronização durante todo o ciclo de vida da aplicação. Para isso foram criados quatro pastas principais sendo elas: 

<a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/tree/main/DesafioTecnico.Frontend/src/app/components">Components</a> Responsável por conter todos os componentes genéricos que podem ser reutilizados para construir varias telas conforme a necessidade. 

<a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/tree/main/DesafioTecnico.Frontend/src/app/controls">Controls</a> Responsável por conter todos os objetos utilizados durante a construção das telas, sendo eles informações de como montar um tabela, combobox, Dto's. 

<a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/tree/main/DesafioTecnico.Frontend/src/app/screen">Screen</a> Local onde de fato as telas foram montadas reutilizando os componentes e adicionando novos códigos html, css, ts. 

<a href="https://github.com/rafael-a-m-chaves/DesafioTecnico-Siemens/tree/main/DesafioTecnico.Frontend/src/app/service">Service</a> Local onde fica todos os códigos referente as chamadas http de endpoint que serão realizadas na Api, utilizando o Observable, HttpClient e HttpHeaders 

Existem algumas coisas quem podem ser adotadas para a melhoria do projeto. 
<ul> 
  <li>Modularização no frontend deixando somente as telas que estão em uso carregadas, diminuindo o uso de recursos</li> 

  <li>Adoção de Autenticação</li> 

  <li>Analise dos ciclo de vida dos serviços injetados no backend diminuindo a criação de novas instancias sem comprometer a segurança</li> 

  <li>Gerar logs para guardar quaisquer erros que aconteça em qualquer umas das pontas</li> 

  <li>Logs de modificações de dados importantes cadastrados gerando possibilidade de Auditoria e recuperação</li> 

  <li>Regras de usuário  para gerar controle sobre ações</li> 

  <li>Dtos mais específicos para aumentar a eficiência na transferência de dados</li> 
</ul> 

Esses foram os pontos principais que foram visualizados, oque não descarta a possibilidade de terem outras melhorias ou tecnologias a serem implementadas. 

   
