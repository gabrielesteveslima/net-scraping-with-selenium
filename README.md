# net-sib-sample-api

Projeto de web scraping com selenium

## Sobre Web Scraping

O proposito desse projeto é utilizar de uma técnica chamada `web scraping`. 

Trata-se de uma forma de mineração que permite a extração de dados de sites da web convertendo-os em informação estruturada para posterior análise.

## Fonte de dados

Para simplificar eu trouxe para dentro do projeto uma fonto de dados extraída da CIP, que é uma associação civil sem fins lucrativos que integra o Sistema de Pagamentos Brasileiro (SPB).

A fonte é uma simples listagem de alguns bancos que se comunicam com a CIP para efetuarem operações de pagamentos.

## Estrutura do projeto

A solução possui alguns projetos, separando uma intenção de camada de dominio, digo intenção porque visto que é somente para aprendizado e o projeto não possui alta complexidade de negocio.

Camadas de aplicação e infraestrutura e uma camada compartilhada chamada `SeedWorks`.

## Docker

Para simplificar o teste da solução criei os arquivos do containers do docker, junto com o docker-compose, portanto para rodar a solução basta:

``` bash
docker-compose up -d --build
```

e para a migração, só rodar o powershell na raiz do projeto:

``` bash
.\run-infrastructure.ps1
```

Feito isso o docker vai levantar os serviços configurados sendo eles:

* O banco de dados postgres;
* A aplicação web api; e
* E um servidor nginx onde foi colocado nossa tabela estática para treino.

``` bash
PS C:\> docker-compose ps
       Name                       Command             State            Ports
------------------------------------------------------------------------------------
scraping-source-data   /docker-entrypoint.sh ngin ...   Up      0.0.0.0:80->80/tcp
sib-sample-api         dotnet SibSample.API.dll         Up      0.0.0.0:8080->80/tcp
sib-sample-api-db      docker-entrypoint.sh postgres    Up      0.0.0.0:5432->5432/tcp
```

Assim temos os serviços do ngix, WebApi e o banco rodando nas portas http/80, http/8080 e tcp/5432 respectivamente.

## Um pouco sobre a stack

O projeto é em dotnet core 3.1, estou utilizando bibliotecas de mercado como: 
Polly => para conexão da console com a API para fazer o bulk insert após a mineração de dados, assim evitando chamadas http desnecessarias e não correndo o risco que outra aplicação altere o estado do banco de dados sem passar pelas regras.


Build.Cake => Automatizador escrito em .NET para tarefas repetitivas como gerar release, rodar tester publicar a dist.

Ele é bem fácil de usar, já é integrado ao comando dotnet.

``` bash 
dotnet tool restore && dotnet-cake

The 'addin' directive is attempting to install the 'Cake.Figlet' package 
without specifying a package version number.
More information on this can be found at https://cakebuild.net/docs/tutorials/pinning-cake-version
It's not recommended, but you can explicitly override this warning
by configuring the Skip Package Version Check setting to true
(i.e. command line parameter "--settings_skippackageversioncheck=true",
environment variable "CAKE_SETTINGS_SKIPPACKAGEVERSIONCHECK=true",
read more about configuration at https://cakebuild.net/docs/fundamentals/configuration)
 ____   ___  ____      _   _  _____  _____
/ ___| |_ _|| __ )    | \ | || ____||_   _|
\___ \  | | |  _ \    |  \| ||  _|    | |
 ___) | | | | |_) | _ | |\  || |___   | |
|____/ |___||____/ (_)|_| \_||_____|  |_|


Application: Sample API
Running target AllDefault in configuration Release
Bulding using version 0.38.5.0 of cake

========================================
Clean
========================================

```

Isso vai instalar o dotnet-cake ao projeto e rodar todos os scripts no arquivo build.cake

E para logs é utilizado o Serilog, é lib muito boa que permite inclusão com o Elasticsearch... mas nesse projeto é utilizado somente em console.

E por último, utilizo da especificação do [jsonapi.org](https://jsonapi.org/) para construção de contratos da api.

``` json
{
    "data": [{
        "attributes": {
            "name": " Banco S.A.",
            "code": "025",
            "document": "03323840000183",
            "ispb": "03323840"
        }
    }]
}
```

 ## O projeto do Selenium
 
 No projeto do selenium `CipScrapingBot` tem o arquivo de configuração appsettings.js que vai facilitar a hora de rodar o projeto:
 
 ``` note
{
  "selenium": {
    "drivePath": "C:\\WebDrivers" ,
    "browser": "Chrome",
    "headless": false,
    "scrapingPath": "http://localhost/index.html" ,
    "timeout": 10
  },
  "sibApi": {
    "importDataPath": "http://localhost:8080/v1/banks"
  }
}
```

Só você encaminhar o seus Web drivers Chrome e Firefox para essa pasta conforme no exemplo acima e selecionar um browser.

O parametro headless é para rodar sem a UI do navegador, perfeito para sistemas de integração continua como o Jenkins.

É isso! Obrigado pela atenção.