# Kobold.TodoApp

## Introdução

Este repositório define uma web API para gerenciamento de tarefas. O código fonte está organizado da seguinte forma:

* Controllers:
* Models:
* Services:
* run.sh: arquivo de inicialização da aplicação.

Para iniciar a aplicação execute o comando:

```
> dotnet run -p src/Kobold.TodoApp.Api
```

## Exercício

O exercício é composto de duas partes, a primeira obrigatória e a segunda opcional.

### Parte I

Altere o código da aplicação, implementando um mecanismo de agrupamento das tarefas (definidas pela classe `Todo`) em coleções, expondo as novas funcionalidades implementadas para consumo na web API.

### Parte II

A aplicação não define um mecanismo de tratamento de erros, e exceções no processamento são expostas na resposta ao usuário. Implementar mecanismo de tratamento de erros na aplicação, de forma que as respostas apresentadas ao usuário não exponham detalhes da aplicação, e apresentem mensagens claras.

## Avaliação

No processo de avaliação do código, avaliaremos as seguintes características:
* Aderência da implementação ao código existente.
* Clareza do código implementado.
* Documentação das alterações efetuadas.
* Estrutura das mensagens de commit.

A solução para o problema não é única. O candidato deve analisar o código existente, definir as funcionalidades a serem implementadas e implementa-las. A avaliação da solução apresentada será realizada em conversa com o candidato, com o objetivo de entender o processo de análise e tomada de decisões que levou àquela solução.