# API de Contato - Desafio META

Este repositório tem por objetivo fornecer uma solução para o desafio
META. Este desafio busca a implementação de umas especificações feitas
com base na OpenAPI 3.0. As especificações foram disponibilizadas no arquivo
*contato.yaml*, na mesma forma que recebi.

Você pode utilizar a [Live Demo do Swagger](https://editor.swagger.io/) para
analisar as especificações contidas em *contato.yaml* de forma mais interativa.

Há também a opção de acessar o [contato.md](./contato.md), um documento criado
usando [swagger-markdown](https://www.npmjs.com/package/swagger-markdown).

## Instalação

```
Requer .NET SDK 3.0 ou superior.
```

- Realize um *fork* e clone este repositório 
(`git clone https://github.com/<USERNAME>/META_API_Challenge.git`)

- Execute as seguintes linhas de comando:

```
cd ContatoAPI
dotnet restore
```

Seu projeto está pronto para ser executado.

**OBS**: O projeto foi criado com um banco de dados InMemory,
isto significa que não será necessário configurar qualquer conexão 
com um servidor SQL.

Caso seja de seu interesse, altere `UseInMemoryDatabase` (Em Startup.cs)
para `UseSqlServer(StringDeConexão)`.

## Execução

Execute o comando `dotnet run`.
Um servidor será iniciado no endereço *localhost*, portas 5001 e 5000. Você
deve receber uma mensagem semelhante à esta no seu terminal:

```
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

Você pode teclar <kbd>CTRL</kbd> + <kbd>C</kbd> à qualquer momento para parar
a execução deste servidor. 

Caso tenha interesse, você pode instalar o certificado do aplicativo usando
`dotnet dev-certs https --trust`.

**Para mais informações sobre o uso da API, consulte a sua especificação (*contato.yaml* ou [contato.md](./contato.md))**

*OBS*: Toda requisição deverá ter um parâmetro "Authorization: TESTAPI" incluída em
seu cabeçalho para permitir sua execução. Requisições sem este cabeçalho retornarão
401 (Not Authorized).

### Exemplo de requisição
```
GET /Contato/1

HEADERS: - Authorization: TESTAPI
```

### Exemplo de resposta
```
[
  {
    "id": "string",
    "nome": "string",
    "canal": "string",
    "valor": "string",
    "obs": "string"
  }
]
```