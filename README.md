

# SOLUTION DESCRIPTION #

I have decided to use Elastic Search to develop this solution, the first who brings to think about him was the volume of information, sensors will "ping" in every second, so we will around 86k inserts per day or 2.5M per month, and per sensor yet. So, I figured that relational database is not a fine solution to do this and we are not relationing this information as well, by the last the schema free looks a great aproach to do this.

The first idea was to use some time series database like InfluxDB, but searching about it found a post which explain that Elastic Search has better performance than InfluxDB:

https://www.elastic.co/blog/elasticsearch-as-a-time-series-data-store

I thought "it's elastic website, so they will say that", but there a link to CERN website comparing both, also using to Time Series:

http://cds.cern.ch/record/2011172/files/LHCb-TALK-2015-060.pdf


By the last I thought about MongoDB, but in my experience ElasticSearch/Lucene make a better info aggregation to create graphic, but I didn't have time to real test both on this project. In this case I thought that ElasticSearhc Rest API may help.

https://db-engines.com/en/system/Elasticsearch%3BInfluxDB%3BMongoDB



This project it what I done in a day, cause I have a free Saturday. I have enjoy the C# and .net experience, but some google search about specific code was not easy to find, therefore probaly I did the wrong searchs.

## ITEMS IMPLEMENTED ##

    - Post to save sensors in async mode
    - Get to list sensors recently saved
    - nunit installed
    - ElasticSearch docker

## HOW TO USE ##

    - Git clone of the project
    - Run docker
    - Go to the docker directory and type docker-compose up
    - In another terminal tab/window go to the project directory source and type code ./
    - With VS Code opened press F5 (Mac) or Ctrl+R (Windows I guess)
    - To run tests dotnet test
    - endpoint grouping sensors total by Elasticsearch aggregation

## ITEMS MISSED ##

    
    - interface with table and graphic
    - better scripts to deploy
    - more tests to cover every step of the application, find a way to mock elasticsearch
    - access ElasticSearch using singleton, I have started this, but did not finished









# Desafio para vaga de analista pleno/sênior

## Considerações Gerais

* Sua solução deverá ser desenvolvida em dotnet core 2.1+.

* Devemos ser capazes de executar sua solução em uma VM limpa, com scripts de automatização de tarefas como Make, Shell Script ou similares. Esses scripts devem ser suficientes para rodarmos sua solução.

* Considere que já temos o seguinte ambiente:
    * Windows 10 Professional
    * Ubuntu 18.0.4
    * .NET Core 2.2

* No seu README, você deverá fazer uma explicação sobre a solução encontrada, tecnologias envolvidas e instrução de uso da solução. 

* É interessante que você também registre ideias que gostaria de implementar caso tivesse mais tempo.

## Problema

Imagine que você ficou responsável por construir um sistema que seja capaz de receber milhares de eventos por segundo de sensores espalhados pelo Brasil, nas regiões norte, nordeste, sudeste e sul. Seu cliente também deseja que na solução ele possa visualizar esses eventos de forma clara.

Um evento é defino por um JSON com o seguinte formato:

```json
{
   "timestamp": <Unix Timestamp ex: 1539112021301>,
   "tag": "<string separada por '.' ex: brasil.sudeste.sensor01 >",
   "valor" : "<string>"
}
```

Descrição:
 * O campo timestamp é quando o evento ocorreu em UNIX Timestamp.
 * Tag é o identificador do evento, sendo composto de pais.região.nome_sensor.
 * Valor é o dado coletado de um determinado sensor (podendo ser numérico ou string).

## Requisitos

* Sua solução deverá ser capaz de armazenar os eventos recebidos.

* Considere um número de inserções de 1000 eventos/sec. Cada sensor envia um evento a cada segundo independente se seu valor foi alterado, então um sensor pode enviar um evento com o mesmo valor do segundo anterior.

* Cada evento poderá ter o estado processado ou erro, caso o campo valor chegue vazio, o status do evento será erro caso contrário processado.

* Para visualização desses dados, sua solução deve possuir:
    * Uma tabela que mostre todos os eventos recebidos. Essa tabela deve ser atualizada automaticamente.
    * Um gráfico apenas para eventos com valor numérico.

* Para seu cliente, é muito importante que ele saiba o número de eventos que aconteceram por região e por sensor. Como no exemplo abaixo:
    * Região sudeste e sul ambas com dois sensores (sensor01 e sensor02):
        * brasil.sudeste - 1000
        * brasil.sudeste.sensor01 - 700
        * brasil.sudeste.sensor02 - 300
        * brasil.sul - 1500
        * brasil.sul.sensor01 - 1250
        * brasil.sul.sensor02 - 250

## Avaliação

Nossa equipe de desenvolvedores irá avaliar código, simplicidade da solução, testes unitários, arquitetura e automatização de tarefas.

Tente automatizar ao máximo sua solução. Isso porque no caso de deploy em vários servidores, não é interessante que tenhamos que entrar de máquina em máquina para instalar cada componente da solução.

Em caso de dúvida, entre em contato com o responsável pelo seu processo seletivo.