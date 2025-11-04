
PayFlow API

PayFlow é uma API de processamento de pagamentos que seleciona automaticamente o provedor mais adequado com base no valor bruto da transação. O projeto foi desenvolvido em .NET 9 e segue os princípios da arquitetura limpa, com suporte à execução via Docker Compose.

Arquitetura Adotada

O projeto está estruturado em camadas, seguindo os princípios da Clean Architecture:

API: camada responsável pela exposição dos endpoints HTTP e configuração do ambiente.

Application: camada que contém as regras de negócio e orquestração entre serviços e provedores.

Domain: define os contratos e entidades que representam o modelo de negócio.

Infrastructure: implementações concretas dos provedores de pagamento e da fábrica de seleção.

Design Patterns utilizados

Factory Method: utilizado na PaymentProviderFactory para selecionar dinamicamente o provedor.

Strategy: cada provedor implementa sua própria lógica de cálculo de taxa via IPaymentProvider.

Dependency Injection: todas as dependências são injetadas via configuração no Startup.

DTOs: utilizados para transportar dados entre camadas, como PaymentRequest e PaymentResponse.

Como executar com Docker Compose

Pré-requisitos:

- Docker Desktop instalado e em execução
- .NET SDK 9.0 instalado (opcional, apenas para desenvolvimento local)

Passos:
- Clone o repositório
- No terminal, execute o comando:

docker-compose up --build


- Após a execução, acesse a API via navegador:
http://localhost:5000/swagger

Caso a porta 5000 esteja ocupada, você pode alterar o mapeamento no arquivo docker-compose.yml.

Renato Kishi 
renatotgakishi@gmail.com
(11) 91561-8008