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
                Console.WriteLine("2 - Estacionar veículo");
                Console.WriteLine("3 - Consultar valor a pagar");
                Console.WriteLine("4 - Pagar");
                Console.WriteLine("5 - Remover veículo");
                Console.WriteLine("6 - Listar veículos");
                Console.WriteLine("7 - Menu Gerencial");
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
                        case OpcaoMenuPrincipal.Encerrar:
                            ExibirMenuConfirmacaoEncerramento();
                            break;
                        case OpcaoMenuPrincipal.ExibirMenuGerencial:
                            ExibirMenuGerencial();
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

        public void ExibirMenuGerencial()
        {
            bool opcaoConfirmacao = true;
            while (opcaoConfirmacao)
            {
                Console.Clear();
                Console.WriteLine("MENU GERENCIAL");
                Console.WriteLine("1 - Listar Transacoes");
                Console.WriteLine("2 - Listar Transacoes Por Data");                
                Console.WriteLine("3 - Listar Transacoes Por Periodo");
                Console.WriteLine("4 - Listar Transacoes Por Placa");
                Console.WriteLine("5 - Consultar Faturamento Total");
                Console.WriteLine("6 - Consultar Faturamento Por Data");                
                Console.WriteLine("7 - Consultar Faturamento Por Periodo");
                Console.WriteLine("8 - Voltar ao Menu Principal");
                Console.WriteLine("100 - Encerrar");

                if (Enum.TryParse(Console.ReadLine(), out OpcaoMenuGerencial opcao))
                {
                    switch (opcao)
                    {
                        case OpcaoMenuGerencial.ExibirTransacoes:
                            ExibirTransacoes();
                            break;
                        case OpcaoMenuGerencial.ExibirTransacaoPorData:
                            ExibirTransacaoPorData();
                            break;
                        case OpcaoMenuGerencial.ExibirTransacaoPorPeriodo:
                            ListarTransacaoPorPeriodo();
                            break;
                        case OpcaoMenuGerencial.ExibirTransacaoPorPlaca:
                            ListarTransacoesPorPlaca();
                            break;
                        case OpcaoMenuGerencial.ExibirFaturamentoTotal:
                            ExibirFaturamentoTotal();
                            break;
                        case OpcaoMenuGerencial.ExibirFaturamentoPorData:
                            ExibirFaturamentoPorData();
                            break;
                        case OpcaoMenuGerencial.ExibirFaturamentoPorPeriodo:
                            ExibirFaturamentoPorPeriodo();
                            break;

                            

                        case OpcaoMenuGerencial.RetornarMenuPrincipal:
                            opcaoConfirmacao = false;
                            break;
                        case OpcaoMenuGerencial.EncerrarPrograma:
                            ExibirMenuConfirmacaoEncerramento();
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
                Console.Write("Pressione ENTER para voltar ao MENU ...");
                Console.ReadLine();                
            }
        }
        public void ExibirMenuConfirmacaoEncerramento()
        {
            bool opcaoConfirmacao = true;
            while (opcaoConfirmacao)
            {
                Console.Clear();
                Console.WriteLine("Deseja encerrar o programa?");
                Console.WriteLine("1 - Encerrar Programa");
                Console.WriteLine("2 - Voltar ao Menu Anterior");

                if (Enum.TryParse(Console.ReadLine(), out OpcaoMenuConfirmacaoEncerramento opcao))
                {
                    switch (opcao)
                    {
                        case OpcaoMenuConfirmacaoEncerramento.EncerrarPrograma:
                        Console.WriteLine("O programa se encerrou");
                            Environment.Exit(0);
                            break;
                        case OpcaoMenuConfirmacaoEncerramento.RetornarMenu:
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

                if (valorAPagar > 0)
                {
                    Console.WriteLine($"O valor a pagar é R$: {valorAPagar}.");
                }
                else
                {
                    Console.WriteLine($"Não há valor a pagar. Permanência liberada até {veiculo.GetLimiteSaida()}");
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

                if (valorAPagar > 0)
                {
                    Console.WriteLine($"Preço a pagar é R$: {valorAPagar}.");
                    
                    FormaPagamento formaPagamento = ExibirMenuPagamento();
                    estacionamentoService.RealizarPagamento(veiculo, valorAPagar, formaPagamento);
                    Console.WriteLine($"Pagamento Recebido. Permanência liberada até {veiculo.GetLimiteSaida()}");
                }
                else
                {
                    Console.WriteLine($"Não há valor a pagar. Permanência liberada até {veiculo.GetLimiteSaida()}");
                }                
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
            try
            {
                TransacaoService transacaoService = new TransacaoService();
            
                if(transacaoService.GetTransacaoRepository().GetTransacoes().Count() == 0)
                {
                    Console.WriteLine("Até o momento não foram realizadas transações.");
                    return;
                }

                Console.WriteLine("Digite a data desejada, use o formato DD/MM/AAAA: ");
                string data = Console.ReadLine();
                
                List<Transacao> ListaDeTransacao = transacaoService.ListarTransacaoPorData(data);

                if(ListaEstaNulaOuVazia(ListaDeTransacao)){
                    Console.WriteLine($"Não houve transação em: {data}");
                    return;
                }

                Console.WriteLine($"As transações realizadas em {data} foram:");
                foreach (Transacao t in ListaDeTransacao)
                {
                    Console.WriteLine($"\nId: {t.GetId()} \nPlaca: {t.GetVeiculo().GetPlaca()} \nForma Pagamento: {t.GetFormaPagamento()} \nValor Pago R$: {t.GetValorPagamento()} \nData e Hora do Pagamento: {t.GetHoraPagamento()}");
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        public void ListarTransacaoPorPeriodo() {
            try
            {
                TransacaoService transacaoService = new TransacaoService();
            
                if(transacaoService.GetTransacaoRepository().GetTransacoes().Count() == 0)
                {
                    Console.WriteLine("Até o momento não foram realizadas transações.");
                    return;
                }

                Console.WriteLine("Digite a data inicial, use o formato DD/MM/AAAA: ");
                string dataInicio = Console.ReadLine();
                Console.WriteLine("Digite a data final, use o formato DD/MM/AAAA: ");
                string dataFim = Console.ReadLine();
                
                List<Transacao> ListaDeTransacao = transacaoService.ListarTransacaoPorPeriodo(dataInicio, dataFim);
                int quantidadeDeTransacoes = ListaDeTransacao.Count();

                if(ListaEstaNulaOuVazia(ListaDeTransacao)){
                    Console.WriteLine($"Não houveram transações no período: {dataInicio} - {dataFim}");
                    return;
                }

                Console.WriteLine($"As {quantidadeDeTransacoes} transações realizadas em {dataInicio} - {dataFim} foram:");
                foreach (Transacao t in ListaDeTransacao)
                {
                    Console.WriteLine($"\nId: {t.GetId()} \nPlaca: {t.GetVeiculo().GetPlaca()} \nForma Pagamento: {t.GetFormaPagamento()} \nValor Pago R$: {t.GetValorPagamento()} \nData e Hora do Pagamento: {t.GetHoraPagamento()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ListarTransacoesPorPlaca(){
            
            try
            {
                TransacaoService transacaoService = new TransacaoService();
                
                if(transacaoService.GetTransacaoRepository().GetTransacoes().Count() == 0)
                {
                    Console.WriteLine("Até o momento não foram realizadas transações.");
                    return;
                }
                string placa = CapturarPlaca();                
                
                List<Transacao> listaDeTransacao = transacaoService.ListarTransacoesPorPlaca(placa);
                int quantidadeDeTransacoes = listaDeTransacao.Count();

                Console.WriteLine($"A {placa} realizou {quantidadeDeTransacoes} transações, sendo estas:");
                foreach (Transacao t in listaDeTransacao)
                {
                    Console.WriteLine($"\nId: {t.GetId()} \nPlaca: {t.GetVeiculo().GetPlaca()} \nForma Pagamento: {t.GetFormaPagamento()} \nValor Pago R$: {t.GetValorPagamento()} \nData e Hora do Pagamento: {t.GetHoraPagamento()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExibirFaturamentoTotal()
        {
            TransacaoService transacaoService = new TransacaoService();
            
            if(transacaoService.GetTransacaoRepository().GetTransacoes().Count() == 0)
            {
                Console.WriteLine("Até o momento não foram realizadas transações.");
                return;
            }            
            
            decimal faturamentoTotal = transacaoService.ConsultarFaturamentoAcumulado();
            
            Console.WriteLine($"O faturamento total é: {faturamentoTotal}");            
        }

        public void ExibirFaturamentoPorData()
        {   
            try
            {
                TransacaoService transacaoService = new TransacaoService();

                if(transacaoService.GetTransacaoRepository().GetTransacoes().Count() == 0)
                {
                    Console.WriteLine("Até o momento não foram realizadas transações.");
                    return;
                }

                Console.WriteLine("Digite a data desejada, use o formato DD/MM/AAAA: ");
                string data = Console.ReadLine();
                
                decimal faturamentoDoDia = transacaoService.ConsultarFaturamentoPorData(data);
                Console.WriteLine($"O faturamento do dia: {data} foi de R$: {faturamentoDoDia}");                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        public void ExibirFaturamentoPorPeriodo() {
            try
            {
                TransacaoService transacaoService = new TransacaoService();

                if(transacaoService.GetTransacaoRepository().GetTransacoes().Count() == 0)
                {
                    Console.WriteLine("Até o momento não foram realizadas transações.");
                    return;
                }

                Console.WriteLine("Digite a data inicial, use o formato DD/MM/AAAA: ");
                string dataInicio = Console.ReadLine();
                Console.WriteLine("Digite a data final, use o formato DD/MM/AAAA: ");
                string dataFim = Console.ReadLine();
                
                decimal faturamentoDoDia = transacaoService.ConsultarFaturamentoPorPeriodo(dataInicio, dataFim);
                Console.WriteLine($"O faturamento realizado em {dataInicio} - {dataFim} foi de R$: {faturamentoDoDia}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }    
    }
}