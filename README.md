# Mottu Tech Test API

Esta é a API desenvolvida para o teste técnico da Mottu. A API gerencia o processo de manutenção de motos, incluindo a criação, atualização, consulta e exclusão de registros de conserto.

## Configuração do Ambiente

### Requisitos

- .NET 8.0 SDK
- MySQL rodando na porta `3306`
- Docker (opcional para rodar o MySQL em container)

### Configuração do Banco de Dados

1. O script SQL para criar e popular a tabela utilizada pela API está localizado na raiz do projeto no arquivo `schema.sql`.
2. Execute o script `schema.sql` no seu ambiente MySQL para configurar o banco de dados necessário.

### String de Conexão

Certifique-se de que a string de conexão está correta no arquivo `appsettings.json` ou no `Program.cs`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=mottu_tech_test;User=root;Password=password;"
}
```

### Execução da Aplicação

Para rodar a aplicação, use o seguinte comando:

```bash
dotnet run
```

A aplicação estará disponível na porta `5078`.

## Endpoints

### 1. Criar Registro de Conserto - POST `/ConsertoDeMotos`

Cria um novo registro de conserto para uma moto.

#### Requisição:

- Corpo da requisição (JSON):

```json
{
  "motoId": 1,
  "complexidadeDoConserto": 3,
  "dataDeEntrada": "2024-09-05",
  "tipoConsertoId": 2
}
```

#### Regras:

- `motoId`, `complexidadeDoConserto` e `dataDeEntrada` são obrigatórios.
- `mecanicoId` e `tempoReal` são automaticamente definidos como `null`.

#### Respostas:

- `200 OK`: Se o registro for criado com sucesso.
- `400 Bad Request`: Se algum dos campos obrigatórios não for fornecido.
- `404 Not Found`: Se o `tipoConsertoId` não existir.

### 2. Atualizar Registro de Conserto - PUT `/ConsertoDeMotos/{motoId}/{dataEntrada}/{tipoConsertoId}`

Atualiza as informações de um registro de conserto existente.

#### Requisição:

- Corpo da requisição (JSON):

```json
{
  "mecanicoId": 1,
  "tempoReal": 5
}
```

#### Regras:

- Verifica se o `motoId`, `dataEntrada` e `tipoConsertoId` correspondem a um registro existente.
- Atualiza o `mecanicoId` e o `tempoReal`.

#### Respostas:

- `200 OK`: Se o registro for atualizado com sucesso.
- `400 Bad Request`: Se o `tempoReal` for inválido ou se o `mecanicoId` não existir.
- `404 Not Found`: Se o registro de moto não for encontrado.

### 3. Consultar Registros de Conserto - GET `/ConsertoDeMotos`

Retorna todos os registros de conserto de motos, incluindo informações dos mecânicos e tipos de conserto.

#### Respostas:

`200 OK`: Retorna a lista de registros de conserto.

### 4. Deletar Registro de Conserto - DELETE `/ConsertoDeMotos/{motoId}/{dataEntrada}/{tipoConsertoId}`

Deleta um registro de conserto de moto

#### Requisição:

- Parâmetros na URL: `motoId`, `dataEntrada`, `tipoConsertoId`.

#### Respostas:

`200 OK`: Se o registro for deletado com sucesso.
`404 Not Found`: Se o registro de moto não for encontrado.

## Considerações Finais

- Certifique-se de que o MySQL está rodando na porta `3306` e acessível para a aplicação.
- O projeto não utiliza um `Startup.cs`, toda a configuração está no `Program.cs`.
