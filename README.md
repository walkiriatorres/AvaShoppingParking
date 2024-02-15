# AVA SHOPPING PARKING

AvaShoppingPark é um sistema de gerenciamento de estacionamento de um shopping desenvolvido em C#.

O sistema solicitará ao usuário dados para configurar o estacionamento: 
1. **quantidade de vagas** a serem disponibilizadas;
2. **preço da 1ª hora**;
3. **preço da hora/fração adicional**

Deverá permitir estacionar veículos com placa validada conforme padrões utilizados no Brasil, por exemplo: **ABC1C34** e **ABC1234**.

O valor a pagar deverá ser calculado conforme os preços fornecidos no cadastro do estacionamento.
O estacionamento permite uma tolerância de permanência de 20 minutos a partir da entrada, período em que não será necessário realizar pagamento.
Para permanência excedente a este período, será cobrado o preço calculado por: preço da 1ª hora + (preço da hora adicional * quantidade de hora/fração adicional).

Deverá ser garantida uma tolerância de saída mínima de 15 minutos para que o veículo tenha tempo hábil de se locomover até a cancela.
Então caso seja necessário realizar o pagamento e este seja feito a menos de 15 minutos até a cobrança da próxima hora, o limite de saída será acrescido de tempo adicional até completar os 15 minutos necessários para saída do veículo.

A remoção do veículo do estacionamento está condicionada ao pagamento deste.
Caso o veículo realize o pagamento, mas e permaneça estacionado após o tempo limite, deverá realizar o pagamento do valor excedente para ter sua saída autorizada.

No Menu Principal será possível ter acesso ao relatório:
- **Veículos Estacionados**: mostra quais veículos estão estacionados naquele momento

No Menu Gerencial será possível ter acesso a relatórios referente a transações:
- **Consultar Transações**: mostra quais transações foram realizadas, sendo ainda possível pesquisar por data, período ou placa.
- **Consultar Faturamento**: mostra total faturado, sendo ainda possível pesquisar por data ou período.

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

