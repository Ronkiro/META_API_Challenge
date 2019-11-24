# Contato
API para um serviço de gestão de contatos

## Version: 1.0.0

**Contact information:**  
Developer Team  
http://devtest.com  
dev.team@devtest.com  

**License:** [MIT License](https://opensource.org/licenses/MIT)

### /{idContato}

#### GET
##### Summary:

Retorna um único objeto do tipo Contato

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| idContato | path | Identificador único de objetos do tipo Contato | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 |  |
| 401 |  |
| 404 |  |

#### PUT
##### Summary:

Altera um objeto do tipo Contato

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| idContato | path | Identificador único de objetos do tipo Contato | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 204 |  |
| 400 |  |
| 401 |  |
| 404 |  |

#### DELETE
##### Summary:

Apaga um objeto do tipo Contato

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| idContato | path | Identificador único de objetos do tipo Contato | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 204 |  |
| 401 |  |
| 404 |  |

### /

#### GET
##### Description:

Retorna uma lista de registros de acordo com o informado nos parâmetros page e size. Se estes parâmetros não forem passados na consulta, os seguintes valores padrão serão utilizados: page = 0 e size = 10

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| size | query | Quantidade de registros a ser retornada em uma única página | No | integer |
| page | query | Página onde se encontra o subconjunto de registros desejado | No | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 |  |
| 401 |  |
| 404 |  |

#### POST
##### Summary:

Cria um novo objeto do tipo Contato

##### Responses

| Code | Description |
| ---- | ----------- |
| 201 |  |
| 400 |  |
| 401 |  |
