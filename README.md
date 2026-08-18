# aulas-arq-software

Repositório de exercícios da disciplina de **Arquitetura de Software**, na 4ª fase do curso de Engenharia de Sofware do Centro Universitário SATC.

## Estrutura

Cada aula fica em sua própria pasta, contendo o projeto/exercício trabalhado em sala.

| Aula | Exercício | Stack |
|------|-----------|-------|
| [`aula03`](./aula03) | API REST de cadastro de veículos e marcas | C# / ASP.NET Core 8 |

## aula03 — Cadastro de Veículos e Marcas (API REST)

Web API em ASP.NET Core com CRUD de veículos e marcas. Ao cadastrar ou editar um veículo, a API valida se a marca informada existe e está ativa.

```
aula03/
├── Controllers/
│   ├── marcas_controller.cs      # CRUD de marcas
│   └── veiculos_controller.cs    # CRUD de veículos + atualização de km
├── Models/
│   ├── marca.cs                  # Modelo de marca
│   ├── veiculo.cs                # Modelo de veículo
│   └── request_atualizarkm.cs    # DTO de atualização de quilometragem
├── Properties/
│   └── launchSettings.json
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
└── exercicios_apirest.csproj
```

### Endpoints

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/marcas` | Lista todas as marcas |
| GET | `/api/marcas/{id}` | Busca uma marca específica |
| POST | `/api/marcas` | Cadastra uma marca |
| PUT | `/api/marcas/{id}` | Edita uma marca |
| DELETE | `/api/marcas/{id}` | Remove uma marca |
| GET | `/api/veiculos` | Lista todos os veículos |
| GET | `/api/veiculos/{id}` | Busca um veículo específico |
| POST | `/api/veiculos` | Cadastra um veículo (valida se a marca está ativa) |
| PUT | `/api/veiculos/{id}` | Edita um veículo (valida se a marca está ativa) |
| DELETE | `/api/veiculos/{id}` | Remove um veículo |
| PATCH | `/api/veiculos/{id}/quilometragem` | Atualiza a quilometragem do veículo |

### Como rodar

```bash
cd aula03
dotnet restore
dotnet run
```

A API sobe em `http://localhost:<porta>` (a porta exibida no terminal ao rodar). 
Exemplo de teste:

```bash
curl -X POST http://localhost:5198/api/marcas -H "Content-Type: application/json" -d '{"nome":"Toyota","ativa":true}'
```