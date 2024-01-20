using DesafioFundamentos.Models;
using DesafioFundamentos.Services;
using DesafioFundamentos.Exceptions;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Seja bem-vindo ao sistema de estacionamento AvaPark!\nDigite o preço inicial:");

decimal precoInicial;
while (!decimal.TryParse(Console.ReadLine(), out precoInicial))
{
    Console.WriteLine("Por favor, insira um valor válido para o preço inicial:");
}

Console.WriteLine("Agora digite o preço por hora:");
decimal precoPorHora;
while (!decimal.TryParse(Console.ReadLine(), out precoPorHora))
{
    Console.WriteLine("Por favor, insira um valor válido para o preço por hora:");
}

Console.WriteLine("Para finalizar, digite a capacidade do estacionamento:");
int totalDeVagas;
while (!int.TryParse(Console.ReadLine(), out totalDeVagas))
{
    Console.WriteLine("Por favor, insira um valor válido para a capacidade do estacionamento:");
}

Estacionamento es = new Estacionamento(precoInicial, precoPorHora, totalDeVagas);

bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Exibir Dados do Estacionamento");
    Console.WriteLine("2 - Cadastrar veículo");
    Console.WriteLine("3 - Consultar valor a pagar");
    Console.WriteLine("4 - Remover veículo");
    Console.WriteLine("5 - Listar veículos");
    Console.WriteLine("6 - Listar Transacoes");    
    Console.WriteLine("10 - Encerrar");

    switch (Console.ReadLine())
    {    
        case "1":            
            ExibirDadosDoEstacionamento(es);
            break;

        case "2":
            CadastrarVeiculo(es);            
            break;

        case "3":
            ConsultarValorAPagar(es);                                    
            break;
        
        case "4":
            RemoverVeiculo(es);                                    
            break;

        case "5":
            ExibirListaDeVeiculos(es);
            break;
        case "6":
            ExibirListaDeTransacoes();
            break;
        
        case "10":
            exibirMenu = false;
            break; 

        default:
            Console.WriteLine("Opção inválida");
            break;
    }    
    
    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

static string CapturarPlaca() {
    Console.WriteLine("Digite a placa do veículo: ");
    return Console.ReadLine().ToUpper();           
}

static void ExibirDadosDoEstacionamento(Estacionamento es){
    EstacionamentoService estacionamentoService = new EstacionamentoService(es);
    Estacionamento estacionamento = estacionamentoService.ExibirEstacionamento();

    Console.WriteLine($"Total de vaga: {estacionamento.GetTotalDeVagas()}");
    Console.WriteLine($"Total de vagas ocupadas: {estacionamento.GetVagasOcupadas().Count}");
    Console.WriteLine($"Preco Inicial R$: {estacionamento.GetPrecoInicial()}");
    Console.WriteLine($"Preco por hora R$: {estacionamento.GetPrecoPorHora()}");
}

static bool ListaEstaNulaOuVazia<T>(List<T> lista)
{
    return lista == null || !lista.Any();
}

static void CadastrarVeiculo(Estacionamento es){

    try
    {
        string placa = CapturarPlaca();

        Veiculo veiculo = new Veiculo(placa);

        EstacionamentoService estacionamentoService = new EstacionamentoService(es);

        estacionamentoService.AdicionarVeiculo(veiculo);

        Console.WriteLine($"Veiculo estacionado na vaga{es.GetVagasOcupadas().Count} as {veiculo.GetEntrada()}");
    }
    catch (VeiculoInvalidoException ex)
    {
        Console.WriteLine(ex.Message);
    }    
}

static void ConsultarValorAPagar(Estacionamento es)
{
    try
    {
        /* Console.WriteLine($"O total de vagas disponiveis é: {es.GetTotalDeVagas() - es.GetVagasOcupadas().Count}");

        EstacionamentoValidador estacionamentoValidador = new EstacionamentoValidador();
        estacionamentoValidador.EstacionamentoEstaVazio(es);
       
        if (es.GetVagasOcupadas().Count == 0) {
            Console.WriteLine("Estacionamento esta vazio");
            return;
        }
        */

        string placa = CapturarPlaca();
        
        EstacionamentoService estacionamentoService = new EstacionamentoService(es);
        Veiculo veiculo = estacionamentoService.ConsultarVeiculoEstacionado(new Veiculo(placa));

        if(veiculo == null)
        {
            Console.WriteLine($"Veiculo placa: {placa} não encontrado.");
            return;
        }

        DateTime dataHoraAtual = DateTime.Now;
        DateTime dataHoraSimuladaSaida = dataHoraAtual.AddMinutes(new Random().Next(0,10080));

        veiculo.SetSaida(dataHoraSimuladaSaida);            

        decimal valorAPagar = estacionamentoService.ValorPagamento(veiculo);

                        
        Console.Write($"Entrada: {veiculo.GetEntrada()} ");                
        Console.Write($"Saida: {dataHoraSimuladaSaida} ");        
        Console.WriteLine($"Preço a pagar é R$: {valorAPagar}.");

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void RemoverVeiculo(Estacionamento es)
{
    try
    {
        
        string placa = CapturarPlaca();
        EstacionamentoService estacionamentoService = new EstacionamentoService(es);
        Veiculo veiculo = estacionamentoService.ConsultarVeiculoEstacionado(new Veiculo(placa));

        if (veiculo == null)
        {
            Console.WriteLine($"Veiculo placa: {placa} não encontrado.");
            return;
        }

        DateTime dataHoraAtual = DateTime.Now;
        DateTime dataHoraSimuladaSaida = dataHoraAtual.AddMinutes(new Random().Next(0, 10080));

        veiculo.SetSaida(dataHoraSimuladaSaida);

        decimal valorAPagar = estacionamentoService.ValorPagamento(veiculo);

        Console.WriteLine($"Preço a pagar é R$: {valorAPagar}.");

        string formaPagamento = ExibirMenuPagamento();

        estacionamentoService.RemoverVeiculo(veiculo, formaPagamento, valorAPagar);

        Console.WriteLine("Veiculo Removido com Sucesso");

        ExibirListaDeTransacoes();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
} 

static void ExibirListaDeVeiculos(Estacionamento es){

    EstacionamentoService estacionamentoService = new EstacionamentoService(es);
    List<Veiculo> veiculosEstacionados = estacionamentoService.ListarTodos();

    if(ListaEstaNulaOuVazia(veiculosEstacionados))
    {
        Console.WriteLine("Não há veiculos estacionados."); 
    }
    else
    {
        Console.WriteLine("Os veículos estacionados são:");
        foreach (Veiculo v in veiculosEstacionados)
        {
            Console.WriteLine($"Placa: {v.GetPlaca()} - Entrada: {v.GetEntrada()} - Saída: {v.GetSaida()}");
        }
    }    
}

static void ExibirListaDeTransacoes(){
    TransacaoService transacaoService = new TransacaoService();
    List<Transacao> ListaDeTransacao = transacaoService.ListarTodas();

    if(ListaEstaNulaOuVazia(ListaDeTransacao))
    {
        Console.WriteLine("Até o momento não foram realizadas transações."); 
    }
    else 
    {
        Console.WriteLine("As transações realizadas foram:");
        foreach (Transacao t in ListaDeTransacao)
        {
            Console.WriteLine($"Id: {t.GetId()} - Placa: {t.Veiculo.GetPlaca()} - Forma Pagamento: {t.GetFormaPagamento()} - Valor Pago R$: {t.GetValorPagamento()} - Data e Hora do Pagamento: {t.GetHoraPagamento()}");
        }
    }    
}

static string ExibirMenuPagamento(){
    Console.WriteLine("Informe o método de pagamento:");
    Console.WriteLine("1 - Cartão de Débito");
    Console.WriteLine("2 - Cartão de Crédito");
    Console.WriteLine("3 - Dinheiro");
    Console.WriteLine("4 - Pix");

    return Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
