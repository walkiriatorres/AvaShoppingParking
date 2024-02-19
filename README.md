# AVA SHOPPING PARKING

AvaShoppingPark é um sistema de gerenciamento de estacionamento de um shopping, é uma nova versão do [AvaParkEstacionamento](https://github.com/walkiriatorres/AvaParkEstacionamento).

📌 **O Projeto**

◾ Desenvolvido em .NET, adota o padrão MVC. A modelagem de domínio aderente ao SRP (SOLID);

◾ O repositório se comportará como o banco de dados da aplicação, persistindo transações e veículos. Segue o Singleton, garantindo que a aplicação esteja acessando o mesmo repositório;

◾ Foram desenvolvidas validações e exceções personalizadas para a camada de lógica do negócio;

◾ O sistema conta ainda com a cobertura de testes unitários utilizando Xunit.

💡 **As Melhorias**

✔ Nesta versão adicionei a função Pagar e deverá ser realizado o pagamento do ticket para saída do estacionamento, que é autorizada conforme o horário limite de saída.

✔ Implementei menus interativos para aprimorar a experiência de navegação dos usuários no sistema, incluindo uma confirmação de encerramento da aplicação, de forma a prevenir saídas acidentais.

✔ Introduzi Enums para representar os diferentes tipos de opções dos menus, simplificando a manutenção do código, permitindo a adição ou modificação de itens de forma rápida.

💻 **Menu de Configuração**

Serão solicitados ao usuário dados para configurar o estacionamento:
1. **quantidade de vagas** a serem disponibilizadas;
2. **preço da 1ª hora**;
3. **preço da hora/fração adicional**

💻 **Menu Principal:**

Será possível estacionar, consultar valor, pagar e remover veículo, além de acesso ao relatório de veículos estacionados:

1. Deverá permitir estacionar veículos com placa validada conforme padrões utilizados no Brasil:
     - **Padrão Brasileiro** (**ABC1234**): Padrão utilizado desde 2011 e ainda aceito, devido a não obrigatoriedade do padrão mercosul para todos veículos;
     - **Padrão Mercosul** (**ABC1C34**): Em 2020 tornou-se brigatório para novos veículos no Brasil, em comparação ao padrão anterior traz uma letra no lugar do segundo número.

2. O valor a pagar deverá ser calculado conforme os preços fornecidos no cadastro do estacionamento. O estacionamento permite uma tolerância de permanência de 20 minutos a partir da entrada, período em que não será necessário realizar pagamento. Para permanência excedente a este período, será cobrado o preço calculado por: preço da 1ª hora + (preço da hora adicional * quantidade de hora/fração adicional).

3. Deverá ser garantida uma tolerância de saída mínima de 15 minutos para que o veículo tenha tempo hábil de se locomover até a cancela. Então caso seja necessário realizar o pagamento e este seja feito a menos de 15 minutos até a cobrança da próxima hora, o limite de saída será acrescido de tempo adicional até completar os 15 minutos necessários para saída do veículo.

4. A remoção do veículo do estacionamento está condicionada ao pagamento deste. Caso o veículo realize o pagamento, mas e permaneça estacionado após o tempo limite, deverá realizar o pagamento do valor excedente para ter sua saída autorizada.

5. **Veículos Estacionados**: mostra quais veículos estão estacionados naquele momento.

💻 **Menu Gerencial**

Será possível ter acesso a relatórios referente a transações:
1. **Consultar Transações**: mostra quais transações foram realizadas, sendo ainda possível pesquisar por data, período ou placa.
2. **Consultar Faturamento**: mostra total faturado, sendo ainda possível pesquisar por data ou período.

💻 **Menu de Confirmação de Encerramento:**

Ao solicitar sair do sistema, deverá ser exibida uma mensagem de confirmação de saída, de forma a prevenir saídas acidentais.

## Diagrama de Classes:
![Diagrama de Classe](Imagens/Diagrama_De_Classe/DiagramaAvaShoppingParking.png)

## Funcionalidades:
### Menu Configuração:
- **Solicitação de dados**: solicita quantidade de vagas e os preços da 1ª hora e das horas adicionais 

### Menu Principal:
- **Exibir dados do estacionamento**
- **Estacionar Veículo**
- **Consultar Valor a pagar**
- **Pagar**
- **Remover Veículo**
- **Listar veículos Estacionados**

### Menu Gerencial:
- **Listar Transacoes**: exibe todas as transações realizadas
- **Listar Transacoes Por Data**: solicita uma data e exibe as trasações realizadas na data informada
- **Listar Transacoes Por Periodo**: solicita um período (datas inicial e final) e exibe as trasações realizadas no período informado
- **Listar Transacoes Por Placa**: solicita uma placa e exibe as trasações realizadas para placa informada
- **Consultar Faturamento Total**: exibe a soma dos valores pagos em todas as transações
- **Consultar Faturamento Por Data**: solicita uma data e exibe a soma dos valores pagos na data informada
- **Consultar Faturamento Por Periodo**: solicita um período (datas inicial e final) e exibe a soma dos valores pagos no período informado

### Menu Confirmação Encerramento:
- **Encerrar Programa**
- **Retornar Menu Anterior**

## Instalando o Sistema
### Requisitos:
- [.NET 6.0](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0);
- IDE ou Editor de Texto que suporte .NET: [VS Code](https://code.visualstudio.com/download) | [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/)

### Clone o repositório:
```
git clone https://github.com/walkiriatorres/AvaShoppingParking.git
```

### Acesse o Diretório:
```
cd DesafioFundamentos
```

### Execute o programa:
```
 dotnet run
```

## Navegando no Ava Shopping Parking:
### Navegando pelos Menus:
![Menu Configuração e Menu Principal](Imagens/Aplicacao/Menus/1_Menu_Configuracao_2_Menu_Principal.png)
![Menu Gerencial e Menu Encerramento](Imagens/Aplicacao/Menus/3_Menu_Gerencial_4_Menu_Encerramento.png)
### Navegando no Menu Principal:
![Exibir dados e Adicionar Veículo](Imagens/Aplicacao/Menu_Principal/2.1_Exibir_dados_2.2_Adicionar_Veiculo.png)
![Consultar Valor A Pagar](Imagens/Aplicacao/Menu_Principal/2.3_Consultar_Valor_A_Pagar.png)
![Pagar Estacionamento](Imagens/Aplicacao/Menu_Principal/2.4_Pagar.png)
![Remover Veiculo Listar Veiculos Estacionados](Imagens/Aplicacao/Menu_Principal/2.5_Remover_Veiculo_2.6_Listar_Veiculos_Estacionados.png)
### Navegando no Menu Gerencial:
![Listar Todas Transacoes](Imagens/Aplicacao/Menu_Gerencial/3.1_Listar_Transacoes.png)
![Listar Transacoes Por Data](Imagens/Aplicacao/Menu_Gerencial/3.2_Listar_Transacoes_Por_data.png)
![Listar Transacoes Por Periodo](Imagens/Aplicacao/Menu_Gerencial/3.1_Listar_Transacoes.png)
![Listar Transacoes Por Placa](Imagens/Aplicacao/Menu_Gerencial/3.4_Listar_Transacoes_Por_Placa.png)
![Consultar Faturamento Total](Imagens/Aplicacao/Menu_Gerencial/3.5_Consultar_Faturamento_Total.png)
![Consultar Faturamento Por Data](Imagens/Aplicacao/Menu_Gerencial/3.6_Consultar_Faturamento_Por_Data.png)
![Consultar Faturamento Por Periodo](Imagens/Aplicacao/Menu_Gerencial/3.7_Consultar_Faturamento_Por_Periodo.png)

