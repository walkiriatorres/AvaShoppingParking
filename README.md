# DIO - Trilha .NET - Fundamentos
www.dio.me

## Desafio de projeto
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de fundamentos, da trilha .NET da DIO.

## Contexto
Você foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## Proposta
Você precisará construir uma classe chamada "Estacionamento", conforme o diagrama abaixo:
![Diagrama de classe estacionamento](diagrama_classe_estacionamento.png)

A classe contém três variáveis, sendo:

**precoInicial**: Tipo decimal. É o preço cobrado para deixar seu veículo estacionado.

**precoPorHora**: Tipo decimal. É o preço por hora que o veículo permanecer estacionado.

**veiculos**: É uma lista de string, representando uma coleção de veículos estacionados. Contém apenas a placa do veículo.

A classe contém três métodos, sendo:

**AdicionarVeiculo**: Método responsável por receber uma placa digitada pelo usuário e guardar na variável **veiculos**.

**RemoverVeiculo**: Método responsável por verificar se um determinado veículo está estacionado, e caso positivo, irá pedir a quantidade de horas que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: **precoInicial** * **precoPorHora**, exibindo para o usuário.

**ListarVeiculos**: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibir a mensagem "Não há veículos estacionados".

Por último, deverá ser feito um menu interativo com as seguintes ações implementadas:
1. Cadastrar veículo
2. Remover veículo
3. Listar veículos
4. Encerrar


## Solução
O código está pela metade, e você deverá dar continuidade obedecendo as regras descritas acima, para que no final, tenhamos um programa funcional. Procure pela palavra comentada "TODO" no código, em seguida, implemente conforme as regras acima.

### Pacote Models:

- **Classe Veiculo**: Possui atributos privados (**Placa**, **Entrada** e **Saida**). Esses Valores são acessados através getters. O método Equals é sobrescrito para comparar este objeto ao realizar remoção dos veiculos estacionados;
- **Classe Estacionamento**: Possui atributos privados (**PrecoInicial**, **PrecoPorHora**, **TotalDeVagas** e **VagasOcupadas** - que é uma lista de **Veiculos**. Esses elementos são acessados através getters. O método Equals é sobrescrito para comparar este objeto ao realizar os testes;
- **Classe Transacao**: Possui atributos privados (**Id**, **Veiculo**(obj), **FormaPagamento**, **ValorPagamento**, **HoraPagamento**). Esses Valores são acessados através getters;
- **Enum FormaPagamento**: É um Enum com valores previamente atribuídos para cada opção de pagamento disponível. (**1-CartaoDeDebito**, **3-CartaoDeCredito**, **3-Dinheiro**, **4-Pix**). Será utilizado nas transações e no menu que exibe as opções de forma de pagamento para o usuário;

### Pacote Repositories:
Nesle serão persistidos nossos dados, simulando um banco de dados.
- **Classe TransacaoRepository**:  Essa classe armazena as transações. Possui o atributo **Transacoes** que é uma lista de Transacao. Segue o padrão **Singleton**. Possui uma instancia do repositório, que é instanciado uma única vez, e é acessada através do método **GetInstancia()**. Possu ainda os métodos **Salvar()**, que adiciona uma transação à lista, e **ListarTodas()**, que exibe todas as transações salvas.

### Pacote Services:
Nele se encontram as regras de negócio, possui as classe:
- **EstacionamentoService**: Faz o controle do estacionamento, utilizando as validações necessárias. Seus métodos são: **ExibirEstacionamento()**, **ConsultarValorPagamento()** **RemoverVeiculo()**, **ConsultarVeiculoEstacionado()**, **istarTodos()** e **CalcularValorPagamentoMinutos()**;
- **EstacionamentoValidador**: Faz as validações necessárias do sistema, retornando exceções caso haja descumprimento dos requisitos necessários;
- **TransacaoService**: Controla o repositório de transações, através da criação destas. O acesso ao repositório é realizado através da instância do repositório, que é único, usando o "TransacaoRepository.GetInstancia()".

### Pacote Exceptions:
Nele se encontram nossas exceções que serão tratadas apenas no **Program.cs**, que simula uma View, para ser posteriormente recebido pelo front e exibido, se necessário, ao cliente.
- **EstacionamentoInvalidoException**
- **VeiculoInvalidoException**
- **PlacaInvalidaException**
- **TransacaoInvalidaException**
- **FormaPagamentoInvalidaException**