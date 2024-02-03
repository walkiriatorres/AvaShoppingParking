using DesafioFundamentos.Models.Classes;
using DesafioFundamentos.Models.Enums;
using DesafioFundamentos.Services;
using DesafioFundamentos.Exceptions;

namespace DesafioFundamentos.View
{
    public class TelaUsuario
    {
        public Estacionamento ExibirMenuConfiguracao(){
            Console.WriteLine("Seja bem-vindo ao sistema de estacionamento AVA SHOPPING PARKING!\nDigite o preço inicial:");

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

            return new Estacionamento(precoInicial, precoPorHora, totalDeVagas);
        }
        
        public void ExibirMenuPrincipal(Estacionamento es)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Digite a sua opção:");
                Console.WriteLine("1 - Exibir Dados do Estacionamento");
                Console.WriteLine("2 - Cadastrar veículo");
                Console.WriteLine("3 - Consultar valor a pagar");
                Console.WriteLine("4 - Pagar");
                Console.WriteLine("5 - Remover veículo");
                Console.WriteLine("6 - Listar veículos");
                Console.WriteLine("7 - Listar Transacoes");
                Console.WriteLine("8 - Listar Transacoes Por Data");
                Console.WriteLine("9 - Consultar Faturamento Acumulado");
                Console.WriteLine("10 - Consultar Faturamento Por Data");
                Console.WriteLine("100 - Encerrar");

                if (Enum.TryParse(Console.ReadLine(), out OpcaoMenuPrincipal opcao))
                {
                    switch (opcao)
                    {
                        case OpcaoMenuPrincipal.ExibirDadosEstacionamento:
                            ExibirDadosDoEstacionamento(es);
                            break;
                        case OpcaoMenuPrincipal.CadastrarVeiculo:
                            AdicionarVeiculo(es);
                            break;
                        case OpcaoMenuPrincipal.ConsultarValorAPagar:
                            CalculadoraDePagamento(es);
                            break;
                        case OpcaoMenuPrincipal.Pagar:
                            ReceberPagamento(es);
                            break;
                        case OpcaoMenuPrincipal.RemoverVeiculo:
                            RemoverVeiculo(es);
                            break;
                        case OpcaoMenuPrincipal.ExibirVeiculosEstacionados:
                            ExibirVeiculosEstacionados(es);
                            break;
                        case OpcaoMenuPrincipal.ExibirTransacoes:
                            ExibirTransacoes();
                            break;
                        case OpcaoMenuPrincipal.ExibirTransacaoPorData:
                            ExibirTransacaoPorData();
                            break;
                        case OpcaoMenuPrincipal.ExibirFaturamentoTotal:
                            ExibirFaturamentoTotal();
                            break;
                        case OpcaoMenuPrincipal.ExibirFaturamentoPorData:
                            ExibirFaturamentoPorData();
                            break;
                        case OpcaoMenuPrincipal.Encerrar:
                            ConfirmarEncerramentoDoPrograma();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Opção inválida");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida");
                }

                Console.WriteLine();
                Console.Write("Pressione ENTER para voltar ao MENU...");
                Console.ReadLine();
            }
        }

        public void ConfirmarEncerramentoDoPrograma()
        {
            bool opcaoConfirmacao = true;
            while (opcaoConfirmacao)
            {
                Console.Clear();
                Console.WriteLine("Deseja encerrar o programa?");
                Console.WriteLine("1 - Encerrar Programa");
                Console.WriteLine("2 - Voltar ao Menu Principal");

                if (Enum.TryParse(Console.ReadLine(), out OpcaoMenuConfirmacaoEncerramento opcao))
                {
                    switch (opcao)
                    {
                        case OpcaoMenuConfirmacaoEncerramento.EncerrarPrograma:
                        Console.WriteLine("O programa se encerrou");
                            Environment.Exit(0);
                            break;
                        case OpcaoMenuConfirmacaoEncerramento.RetornarMenuPrincipal:
                            opcaoConfirmacao = false;
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                }
            }
        }

        public string CapturarPlaca()
        {
            Console.WriteLine("Digite a placa do veículo: ");
            return Console.ReadLine().ToUpper();
        }

        public bool ListaEstaNulaOuVazia<T>(List<T> lista)
        {
            return lista == null || !lista.Any();
        }

        public void ExibirDadosDoEstacionamento(Estacionamento es)
        {
            EstacionamentoService estacionamentoService = new EstacionamentoService(es);
            Estacionamento estacionamento = estacionamentoService.GetEstacionamento();

            Console.WriteLine("AVA SHOPPING PARK");
            Console.WriteLine($"Capacidade de vagas: {estacionamento.GetTotalDeVagas()}");
            Console.WriteLine($"Vagas ocupadas: {estacionamento.GetVagasOcupadas().Count}");
            Console.WriteLine($"Preco Inicial R$: {estacionamento.GetPrecoInicial()}");
            Console.WriteLine($"Preco por hora R$: {estacionamento.GetPrecoPorHora()}");
        }

        public void AdicionarVeiculo(Estacionamento es)
        {
            try
            {
                string placa = CapturarPlaca();

                Veiculo veiculo = new Veiculo(placa);

                EstacionamentoService estacionamentoService = new EstacionamentoService(es);

                estacionamentoService.AdicionarVeiculo(veiculo);

                Console.WriteLine($"Entrada liberada.");
            }
            catch (VeiculoInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CalculadoraDePagamento(Estacionamento es)
        {
            try
            {
                if (es.GetVagasOcupadas().Count == 0)
                {
                    Console.WriteLine("Estacionamento está vazio");
                    return;
                }

                string placa = CapturarPlaca();

                EstacionamentoService estacionamentoService = new EstacionamentoService(es);
                Veiculo veiculo = estacionamentoService.ConsultarVeiculoEstacionado(new Veiculo(placa));

                if (veiculo == null)
                {
                    Console.WriteLine($"Veiculo placa: {placa} não encontrado.");
                    return;
                }

                decimal valorAPagar = estacionamentoService.ConsultarValorPagamento(veiculo);

                Console.Write($"\nO valo a pagar é R$: {valorAPagar}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ReceberPagamento(Estacionamento es)
        {
            try
            {
                if (es.GetVagasOcupadas().Count == 0)
                {
                    Console.WriteLine("Estacionamento está vazio");
                    return;
                }

                string placa = CapturarPlaca();

                EstacionamentoService estacionamentoService = new EstacionamentoService(es);
                Veiculo veiculo = estacionamentoService.ConsultarVeiculoEstacionado(new Veiculo(placa));

                if (veiculo == null)
                {
                    Console.WriteLine($"Veiculo placa: {placa} não encontrado.");
                    return;
                }

                decimal valorAPagar = estacionamentoService.ConsultarValorPagamento(veiculo);

                Console.WriteLine($"Preço a pagar é R$: {valorAPagar}.");

                if (valorAPagar > 0)
                {
                    FormaPagamento formaPagamento = ExibirMenuPagamento();
                    estacionamentoService.RealizarPagamento(veiculo, valorAPagar, formaPagamento);
                }

                Console.WriteLine($"Pagamento Recebido. Permanência liberada até {veiculo.GetLimiteSaida()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RemoverVeiculo(Estacionamento es)
        {
            try
            {
                if (es.GetVagasOcupadas().Count == 0)
                {
                    Console.WriteLine("Estacionamento está vazio");
                    return;
                }

                string placa = CapturarPlaca();
                EstacionamentoService estacionamentoService = new EstacionamentoService(es);
                Veiculo veiculo = estacionamentoService.ConsultarVeiculoEstacionado(new Veiculo(placa));

                if (veiculo == null)
                {
                    Console.WriteLine($"Veiculo placa: {placa} não encontrado.");
                    return;
                }

                decimal valorAPagar = estacionamentoService.ConsultarValorPagamento(veiculo);

                if (valorAPagar > 0)
                {
                    Console.WriteLine($"Por gentileza, realizar pagamento!");
                    return;
                }

                estacionamentoService.RemoverVeiculo(veiculo);

                Console.WriteLine("Saída Liberada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExibirVeiculosEstacionados(Estacionamento es)
        {
            EstacionamentoService estacionamentoService = new EstacionamentoService(es);
            List<Veiculo> veiculosEstacionados = estacionamentoService.ListarTodos();

            if (ListaEstaNulaOuVazia(veiculosEstacionados))
            {
                Console.WriteLine("Estacionamento está vazio.");
            }
            else
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (Veiculo v in veiculosEstacionados)
                {
                    Console.WriteLine($"\nId: {v.GetId()} \nPlaca: {v.GetPlaca()} \nEntrada: {v.GetEntrada()} \nTotal Pago: {v.GetTotalPago()} \nLimite Saída: {v.GetLimiteSaida()}");
                }
            }
        }

        public void ExibirTransacoes()
        {
            TransacaoService transacaoService = new TransacaoService();
            List<Transacao> ListaDeTransacao = transacaoService.ListarTodas();

            if (ListaEstaNulaOuVazia(ListaDeTransacao))
            {
                Console.WriteLine("Até o momento não foram realizadas transações.");
            }
            else
            {
                Console.WriteLine("As transações realizadas foram:");
                foreach (Transacao t in ListaDeTransacao)
                {
                    Console.WriteLine($"\nId: {t.GetId()} \nPlaca: {t.GetVeiculo().GetPlaca()} \nForma Pagamento: {t.GetFormaPagamento()} \nValor Pago R$: {t.GetValorPagamento()} \nData e Hora do Pagamento: {t.GetHoraPagamento()}");
                }
            }
        }

        public void ExibirTransacaoPorData()
        {
            TransacaoService transacaoService = new TransacaoService();

            Console.WriteLine("Digite a data desejada, use o formato DD/MM/AAAA: ");
            string data = Console.ReadLine();

            if (DateTime.TryParse(data, out DateTime dataInformada))
            {
                List<Transacao> ListaDeTransacao = transacaoService.ListarTransacaoPorData(data);

                if (ListaDeTransacao.Count() == 0)
                {
                    Console.WriteLine("Até o momento não foram realizadas transações.");
                }
                else
                {
                    Console.WriteLine($"As transações realizadas em {data} foram:");
                    foreach (Transacao t in ListaDeTransacao)
                    {
                        Console.WriteLine($"\nId: {t.GetId()} \nPlaca: {t.GetVeiculo().GetPlaca()} \nForma Pagamento: {t.GetFormaPagamento()} \nValor Pago R$: {t.GetValorPagamento()} \nData e Hora do Pagamento: {t.GetHoraPagamento()}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Formato de data inválido. Certifique-se de usar o formato DD/MM/AAAA.");
            }
        }

        public void ExibirFaturamentoTotal()
        {
            TransacaoService transacaoService = new TransacaoService();
            decimal faturamentoAcumulado = transacaoService.ConsultarFaturamentoAcumulado();

            if (faturamentoAcumulado <= 0)
            {
                Console.WriteLine("Até o momento não foram realizadas transações.");
            }
            else
            {
                Console.WriteLine($"O faturamento acumulado é: {faturamentoAcumulado}");
            }
        }

        public void ExibirFaturamentoPorData()
        {
            Console.WriteLine("Digite a data desejada, use o formato DD/MM/AAAA: ");
            string data = Console.ReadLine();

            TransacaoService transacaoService = new TransacaoService();

            if (DateTime.TryParse(data, out DateTime dataInformada))
            {
                decimal faturamentoDoDia = transacaoService.ConsultarFaturamentoPorData(data);
                Console.WriteLine($"O faturamento do dia: {data} é de R$: {faturamentoDoDia}");
            }
            else
            {
                Console.WriteLine("Formato de data inválido. Certifique-se de usar o formato DD/MM/AAAA.");
            }
        }

        public FormaPagamento ExibirMenuPagamento()
        {
            Console.WriteLine("Informe o método de pagamento:");
            Console.WriteLine("1 - Cartão de Débito");
            Console.WriteLine("2 - Cartão de Crédito");
            Console.WriteLine("3 - Dinheiro");
            Console.WriteLine("4 - Pix");

            string opcaoPagamento = Console.ReadLine();
            if (Enum.TryParse(opcaoPagamento, out FormaPagamento formaPagamento))
            {
                return formaPagamento;
            }
            else
            {
                throw new FormaPagamentoInvalidaException("Forma de pagamento inválida");
            }
        }
    }
}