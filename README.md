# Desafio de Backend - Zé Delivery
Este projeto é uma solução para o desafio de backend proposto pela equipe do Zé Delivery. O objetivo é desenvolver um serviço que disponibilize uma API RESTful que permita a criação de parceiros, busca por parceiros com base em localização e outras funcionalidades específicas. Você pode encontrar o desafio original clicando [aqui](https://github.com/ab-inbev-ze-company/ze-code-challenges/blob/master/backend_pt.md).

## ☕ Funcionalidades Implementadas

1. Retorna um parceiro específico com base no seu campo id, incluindo todos os campos relevantes.

2. Dada uma localização pelo usuário da API (coordenadas de longitude e latitude), busca o parceiro mais próximo cuja área de cobertura inclua a localização fornecida.

3. Cadastrar um parceiro.


## 🐱‍🏍Práticas Modernas:
  * Clean Architecture: A aplicação segue os princípios da Clean Architecture, garantindo a separação clara de responsabilidades entre as camadas.
  * CQRS (Command Query Responsibility Segregation): Utilizado para separar operações de leitura e escrita, melhorando a escalabilidade e a manutenção do código.
  * Result Pattern: Adotado para retornar resultados de operações de forma consistente e padronizada.


## 💻 Pré-requisitos
* [.NET 8](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0).
* [PostgreSQL](https://www.postgresql.org/).
* Extensão [PostGIS](https://postgis.net/) instalada no Postgres.


## 🤞 Executando o Projeto Localmente
Para executar o projeto localmente, siga estas etapas:

* Clonar o Repositório:

* Configurar o Banco de Dados:

  * Instale o PostgreSQL em sua máquina, se ainda não o tiver.
  * Instale a extensão Postgis para lidar com dados Geoespaciais.
  * Crie um banco de dados utilizando os scripts presentes em [Create Table](./docs/create_tables.sql).
  * Insira os registros presentes em [Inserts](./docs/inserts.sql)
  * Configurar a sua ConnectionString no appsettings.json.

## 🚀 Executar o Projeto

* Abra o projeto em sua IDE preferida (por exemplo, Visual Studio ou Visual Studio Code).
* Certifique-se de que o .NET 8 SDK esteja instalado em sua máquina.
* Certifique-se de que PostgreSQL esteja instalado em sua máquina.
* Execute o projeto.
* Você pode acessar a interface "Swagger" clicando [aqui](http://localhost:5180/swagger).

## Endpoints
### PartnerById

**Método:** HTTPGET

**URL:** api/Partners/PartnerById?Id={id}

**Parâmetros:** Id

**Exemplo:** api/Partners/PartnerById?Id=1

**Resposta:**

```json
{
  "id": 1,
  "tradingName": "Adega Osasco",
  "ownerName": "Ze da Ambev",
  "document": "02.453.716/000170",
  "coverageArea": {
    "type": "MultiPolygon",
    "coordinates": [
      "(-43.36556, -22.99669)",
      "(-43.36539, -23.01928)",
      "(-43.26583, -23.01802)",
      "(-43.25724, -23.00649)",
      "(-43.23355, -23.00127)",
      "(-43.2381, -22.99716)",
      "(-43.23866, -22.99649)",
      "(-43.24063, -22.99756)",
      "(-43.24634, -22.99736)",
      "(-43.24677, -22.99606)",
      "(-43.24067, -22.99381)",
      "(-43.24886, -22.99121)",
      "(-43.25617, -22.99456)",
      "(-43.25625, -22.99203)",
      "(-43.25346, -22.99065)",
      "(-43.29599, -22.98283)",
      "(-43.3262, -22.96481)",
      "(-43.33427, -22.96402)",
      "(-43.33616, -22.96829)",
      "(-43.342, -22.98157)",
      "(-43.34817, -22.97967)",
      "(-43.35142, -22.98062)",
      "(-43.3573, -22.98084)",
      "(-43.36522, -22.98032)",
      "(-43.36696, -22.98422)",
      "(-43.36717, -22.98855)",
      "(-43.36636, -22.99351)",
      "(-43.36556, -22.99669)"
    ]
  },
  "address": {
    "type": "Point",
    "coordinates": "(-43.297337, -23.013538)"
  }
}
```

### NearestPartnerInCoverageArea

**Método:** HTTPGET

**URL:** /api/Partners/NearestPartnerInCoverageArea?Longitude={longitude}&Latitude={latitude}

**Parâmetros:** Longitude e Latitude

**Exemplo:** /api/Partners/NearestPartnerInCoverageArea?Longitude=-43.301087&Latitude=-23.012689

**Resposta:**

```json
{
  "id": 1,
  "tradingName": "Adega Osasco",
  "ownerName": "Ze da Ambev",
  "document": "02.453.716/000170",
  "coverageArea": {
    "type": "MultiPolygon",
    "coordinates": [
      "(-43.36556, -22.99669)",
      "(-43.36539, -23.01928)",
      "(-43.26583, -23.01802)",
      "(-43.25724, -23.00649)",
      "(-43.23355, -23.00127)",
      "(-43.2381, -22.99716)",
      "(-43.23866, -22.99649)",
      "(-43.24063, -22.99756)",
      "(-43.24634, -22.99736)",
      "(-43.24677, -22.99606)",
      "(-43.24067, -22.99381)",
      "(-43.24886, -22.99121)",
      "(-43.25617, -22.99456)",
      "(-43.25625, -22.99203)",
      "(-43.25346, -22.99065)",
      "(-43.29599, -22.98283)",
      "(-43.3262, -22.96481)",
      "(-43.33427, -22.96402)",
      "(-43.33616, -22.96829)",
      "(-43.342, -22.98157)",
      "(-43.34817, -22.97967)",
      "(-43.35142, -22.98062)",
      "(-43.3573, -22.98084)",
      "(-43.36522, -22.98032)",
      "(-43.36696, -22.98422)",
      "(-43.36717, -22.98855)",
      "(-43.36636, -22.99351)",
      "(-43.36556, -22.99669)"
    ]
  },
  "address": {
    "type": "Point",
    "coordinates": "(-43.297337, -23.013538)"
  }
}
```
### CreatePartner

**Método:** HTTPPOST

**URL:** /api/Partners/NearestPartnerInCoverageArea?Longitude={longitude}&Latitude={latitude}

**Parâmetros:** Longitude e Latitude

**Exemplo:** /api/Partners/CreatePartner

```json
{
  "tradingName": "Noiz Cerveja",
  "ownerName": "Eduardo Pedroso",
  "document": "15.187.572/0001-07",
  "coverageArea": {
      "type": "MultiPolygon",
      "coordinates": [
        [
            [
              [
                  -48.03104,
                  -21.94007
              ],
              [
                  -47.98538,
                  -22.01027
              ],
              [
                  -47.91568,
                  -22.06644
              ],
              [
                  -47.87345,
                  -22.07105
              ],
              [
                  -47.83397,
                  -22.06357
              ],
              [
                  -47.80136,
                  -22.03493
              ],
              [
                  -47.79071,
                  -21.99738
              ],
              [
                  -47.81303,
                  -21.94994
              ],
              [
                  -47.858,
                  -21.91586
              ],
              [
                  -47.95688,
                  -21.90217
              ],
              [
                  -47.99739,
                  -21.91379
              ],
              [
                  -48.03104,
                  -21.94007
              ]
            ]
        ]
      ]
  },
  "address": {
      "type": "Point",
      "coordinates": [
        -47.896477,
        -21.99916
      ]
  }
}
```
**Resposta:**
Id que foi cadastrado no banco.

## 😄 Seja um dos contribuidores

Este projeto é destinado principalmente para fins educacionais, para praticar conceitos e técnicas de programação. No entanto, contribuições são bem-vindas. Se você encontrar problemas ou tiver sugestões de melhorias, sinta-se à vontade para abrir uma issue ou enviar um pull request.

