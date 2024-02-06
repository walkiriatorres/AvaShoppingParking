using DesafioFundamentos.Exceptions;
using DesafioFundamentos.Models.Classes;
using DesafioFundamentos.Models.Enums;
using DesafioFundamentos.Services;

namespace DesafioFundamentosTestes.Services;

public class EstacionamentoServiceTestes
{
    private Estacionamento _estacionamento;
    private EstacionamentoService _estacionamentoService;

    public EstacionamentoServiceTestes(){
        _estacionamento = new Estacionamento(10, 5, 2);
        _estacionamentoService = new EstacionamentoService(_estacionamento);
    }

    [Fact]
    public void DeveExibirOEstacionamento()
    {
        Estacionamento _estacionamento = new Estacionamento(10, 5, 5);
        EstacionamentoService _estacionamentoService = new EstacionamentoService(_estacionamento);
        
        Estacionamento resultado = _estacionamentoService.GetEstacionamento();
        var resultadoEsperado = new Estacionamento(10, 5, 5);
        
        Assert.Equal(resultadoEsperado, resultado);
    }

    [Fact]
    public void DeveExibir1QuandoForAdicionadoUmVeiculoComPlacaABC1234()
    {
        string placa = "ABC1234";
        Veiculo veiculo = new Veiculo(placa);
        _estacionamentoService.AdicionarVeiculo(veiculo);

        int resultadoEsperado = 1;
        var resultado = _estacionamento.GetVagasOcupadas().Count;

        Assert.Equal(resultadoEsperado, resultado);
    }

    [Fact]
    public void DeveExibirVeiculoNaoPodeSerNuloQuandoForAdicionadoUmVeiculoNulo()
    {
        string resultadoEsperado = "O veiculo não pode ser nulo.";        
        var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoService.AdicionarVeiculo(null));        
        
        Assert.Equal(resultadoEsperado, exception.Message);
    }

    [Fact]
    public void DeveExibirPlacaNulaOuVaziaQuandoForAdicionadoUmVeiculoComPlacaVazia()
    {
        string placa = "";
        Veiculo veiculo = new Veiculo(placa);

        string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";
        var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoService.AdicionarVeiculo(veiculo));        

        Assert.Equal(resultadoEsperado, exception.Message);
    }

    [Fact]
    public void DeveExibirPlacaNulaOuVaziaQuandoForAdicionadoUmVeiculoComPlacaNula()
    {
        string placa = null;
        Veiculo veiculo = new Veiculo(placa);

        string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";
        var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoService.AdicionarVeiculo(veiculo)); 

        Assert.Equal(resultadoEsperado, exception.Message);
    }

    [Fact]
    public void DeveExibirPlacaInvalidaQuandoForAdicionadoUmVeiculoComPlacaABC()
    {
        string placa = "ABC";
        Veiculo veiculo = new Veiculo(placa);

        string resultadoEsperado = "Placa inválida.";
        var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoService.AdicionarVeiculo(veiculo));        

        Assert.Equal(resultadoEsperado, exception.Message);
    }

    [Fact]
    public void DeveExibirEstacionamentoLotadoQuandoAdicionar3VeiculosNoEstacionamentoCom2Vagas()
    {
        string placa1 = "ABC1234";        
        Veiculo veiculo1 = new Veiculo(placa1);
        _estacionamentoService.AdicionarVeiculo(veiculo1);

        string placa2 = "bcd1234";        
        Veiculo veiculo2 = new Veiculo(placa2);
         _estacionamentoService.AdicionarVeiculo(veiculo2);

        string placa3 = "bcd1234";        
        Veiculo veiculo3 = new Veiculo(placa3);

        string resultadoEsperado = "Estacionamento está lotado.";

        var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoService.AdicionarVeiculo(veiculo3));
        
        Assert.Equal(resultadoEsperado, exception.Message);
    }

    [Fact]
    public void DeveExibirVeiculoJaEstaEstacionadoQuandoAdicionarVeiculoPreviamenteAdicionado()
    {
        string placa1 = "ABC1234";        
        Veiculo veiculo1 = new Veiculo(placa1);
        _estacionamentoService.AdicionarVeiculo(veiculo1);

        string placa2 = "ABC1234";        
        Veiculo veiculo2 = new Veiculo(placa2);

        string resultadoEsperado = "Veiculo já está estacionado.";

        var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoService.AdicionarVeiculo(veiculo2));
        
        Assert.Equal(resultadoEsperado, exception.Message);
    }

    [Fact]
    public void DeveExibirVeiculoNaoPodeSerNuloQuandoConsultarValorPagamentoDeVeiculoNulo()
    {
        Veiculo veiculo = null;

        string resultadoEsperado = "O veiculo não pode ser nulo.";        
        var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoService.ConsultarValorPagamento(veiculo)); 
        
        Assert.Equal(resultadoEsperado, exception.Message);
    }

    [Fact]
    public void DeveExibirPlacaNulaOuVaziaNaoPodeSerEstacionadaQuandoConsultarValorPagamentoDeVeiculoComPlacaVazia()
    {
        string placa = "";
        Veiculo veiculo = new Veiculo(placa);

        string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";        
        var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoService.ConsultarValorPagamento(veiculo)); 
        
        Assert.Equal(resultadoEsperado, exception.Message);
    }

    [Fact]
    public void DeveExibirPlacaNulaOuVaziaNaoPodeSerEstacionadaQuandoConsultarValorPagamentoDeVeiculoComPlacaNula()
    {
        string placa = null;
        Veiculo veiculo = new Veiculo(placa);

        string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";        
        var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoService.ConsultarValorPagamento(veiculo));    

        Assert.Equal(resultadoEsperado, exception.Message);
    }

    [Fact]
    public void DeveExibirPlacaInvalidaQuandoConsultarValorPagamentoDeVeiculoComPlacaInvalida()
    {
        string placa = "a1";
        Veiculo veiculo = new Veiculo(placa);

        string resultadoEsperado = "Placa inválida.";        
        var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoService.ConsultarValorPagamento(veiculo));    

        Assert.Equal(resultadoEsperado, exception.Message);
    }

    [Fact]
    public void DeveExibirVeiculoNaoEstaEstacionadoQuandoConsultarValorPagamentoDeVeiculoNaoEstacionado()
    {
        string placa = "abc1234";
        Veiculo veiculo = new Veiculo(placa);

        string resultadoEsperado = "Veiculo não está estacionado.";        
        var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoService.ConsultarValorPagamento(veiculo));    

        Assert.Equal(resultadoEsperado, exception.Message);
    }

    [Fact]
    public void DeveExibir15QuandoConsultarValorPagamentoDeVeiculoEstacionadoHa60Minutos()
    {
        string placa = "abc1234";
        Veiculo veiculo = new Veiculo(placa);
        _estacionamentoService.AdicionarVeiculo(veiculo);
        veiculo.SetEntrada(DateTime.Now.AddMinutes(-60));
        veiculo.SetLimiteSaida(DateTime.Now);

        decimal resultadoEsperado = 15M;        
        var resultado = _estacionamentoService.ConsultarValorPagamento(veiculo);    

        Assert.Equal(resultadoEsperado, resultado);
    }

    [Fact]
    public void DeveExibir15QuandoConsultarValorPagamentoDeVeiculoEstacionadoHa20Minutos()
    {
        string placa = "abc1234";
        Veiculo veiculo = new Veiculo(placa);
        _estacionamentoService.AdicionarVeiculo(veiculo);
        veiculo.SetEntrada(DateTime.Now.AddMinutes(-20));

        decimal resultadoEsperado = 0M;        
        var resultado = _estacionamentoService.ConsultarValorPagamento(veiculo);    

        Assert.Equal(resultadoEsperado, resultado);
    }  

    [Fact]
    public void DeveExibirVeiculoNaoPodeSerNuloAoRealizarPagamentoQuandoVeiculoForNulo()
    {            
        var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoService.RealizarPagamento(null, 10M, FormaPagamento.CartaoDeCredito));
        
        string resultadoEsperado = "O veiculo não pode ser nulo.";

        Assert.Equal(resultadoEsperado, exception.Message);            
    }

    [Fact]
    public void DeveExibirPlacaNulaOuVaziaAoRealizarPagamentoQuandoPlacaForNula()
    {
        Veiculo veiculo = new Veiculo(null);
        
        var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoService.RealizarPagamento(veiculo, 10M, FormaPagamento.CartaoDeCredito));
        
        string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";

        Assert.Equal(resultadoEsperado, exception.Message);            
    }        

    [Fact]
    public void DeveExibirPlacaNulaOuVaziaAoRealizarPagamentoQuandoPlacaForVazia()
    {
        string placa = "";
        Veiculo veiculo = new Veiculo(placa);
        
        var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoService.RealizarPagamento(veiculo, 10M, FormaPagamento.CartaoDeCredito));
        
        string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";

        Assert.Equal(resultadoEsperado, exception.Message);            
    }

    [Fact]
    public void DeveExibirPlacaInvalidaAoRealizarPagamentoQuandoPlacaForInvalida()
    {
        string placa = "Ab1";
        Veiculo veiculo = new Veiculo(placa);
        
        var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoService.RealizarPagamento(veiculo, 10M, FormaPagamento.CartaoDeCredito));
        
        string resultadoEsperado = "Placa inválida.";

        Assert.Equal(resultadoEsperado, exception.Message);            
    }

    [Fact]
    public void DeveExibirNaoHaValorAPagarAoRealizarPagamentoQuandoValorAPagarForZero()
    {
        string placa = "abc1234";
        Veiculo veiculo = new Veiculo(placa);
        decimal valorAPagar = 0M;
        
        var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoService.RealizarPagamento(veiculo, valorAPagar, FormaPagamento.CartaoDeCredito));
        
        string resultadoEsperado = "Não há valor a pagar.";

        Assert.Equal(resultadoEsperado, exception.Message);            
    }

    [Fact]
    public void DeveExibir1TransacaoQuandoRealizarPagamentode1Veiculo()
    {
        TransacaoService _transacaoService = new TransacaoService();            
        string placa = "abc1234";
        Veiculo veiculo = new Veiculo(placa);
        decimal valorAPagar = 15M;
        var resultadoEsperado = 1;

        _estacionamentoService.RealizarPagamento(veiculo, valorAPagar, FormaPagamento.CartaoDeCredito);
        var resultado = _transacaoService.ListarTodas().Count;

        Assert.Equal(resultadoEsperado, resultado);
        
        _transacaoService.GetTransacaoRepository().GetTransacoes().Clear();            
    }
    
    [Fact]
    public void DeveExibirOTotalPagoPeloVeiculoAtualizadoAoRealizarPagamento()
    {
        TransacaoService _transacaoService = new TransacaoService();            
        string placa = "abc1234";
        Veiculo veiculo = new Veiculo(placa);
        decimal valorAPagar = 15M;
        decimal totalPago = veiculo.GetTotalPago();
        decimal resultadoEsperado = valorAPagar + totalPago;

        _estacionamentoService.RealizarPagamento(veiculo, valorAPagar, FormaPagamento.CartaoDeCredito);
        decimal resultado = veiculo.GetTotalPago();

        Assert.Equal(resultadoEsperado, resultado);

        _transacaoService.GetTransacaoRepository().GetTransacoes().Clear();         
    }

    [Fact]
    public void DeveExibirUmLimiteDeSaidaAtualizadoEm2HorasAMaisDaEntradaQuandoRealizarPagamentoDe2HorasDeEstacionamento()
    {
        TransacaoService _transacaoService = new TransacaoService();

        string placa = "abc1234";
        Veiculo veiculo = new Veiculo(placa);
        veiculo.SetEntrada(DateTime.Now.AddMinutes(-90));
        decimal valorAPagarPorDuasHorasEstacionado = 15M;
        DateTime resultadoEsperado = veiculo.GetEntrada().AddHours(2);

        _estacionamentoService.RealizarPagamento(veiculo, valorAPagarPorDuasHorasEstacionado, FormaPagamento.CartaoDeCredito);
        DateTime resultado = veiculo.GetLimiteSaida();

        Assert.Equal(resultadoEsperado, resultado);

        _transacaoService.GetTransacaoRepository().GetTransacoes().Clear();         
    }

    [Fact]
    public void DeveExibir0QuandoTentarRemoverVeiculoDeEstacionamento()
    {
        string placa = "abc1234";
        Veiculo veiculo = new Veiculo(placa);
        _estacionamentoService.AdicionarVeiculo(veiculo);

        _estacionamentoService.RemoverVeiculo(veiculo);

        int resultadoEsperado = 0;
        var resultado = _estacionamento.GetVagasOcupadas().Count;

        Assert.Equal(resultadoEsperado, resultado);
    }

    [Fact]
    public void DeveExibirVeiculoNaoPodeSerNuloQuandoUmVeiculoNuloForRemovidoDoEstacionamento()
    {
        var resultadoEsperado = "O veiculo não pode ser nulo.";
        var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoService.RemoverVeiculo(null));    

        Assert.Equal(resultadoEsperado, exception.Message);        
    }

    [Fact]
    public void DeveExibirVeiculoNaoEstaEstacionadoQuandoUmVeiculoNuloForRemovidoDoEstacionamento()
    {
        string placa = "abc1234";
        Veiculo veiculo = new Veiculo(placa);        
        var resultadoEsperado = "Veiculo não está estacionado.";

        var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoService.RemoverVeiculo(veiculo));    

        Assert.Equal(resultadoEsperado, exception.Message);        
    }

    [Fact]
    public void DeveExibirPlacaNulaOUVaziaQuandoRemoverVeiculoComPlacaVazia()
    {
        string placa = "";
        Veiculo veiculo = new Veiculo(placa);        
        var resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";

        var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoService.RemoverVeiculo(veiculo));    

        Assert.Equal(resultadoEsperado, exception.Message);        
    }

    [Fact]
    public void DeveExibirPlacaNulaOUVaziaQuandoRemoverVeiculoComPlacaNula()
    {
        Veiculo veiculo = new Veiculo(null);        
        var resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";

        var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoService.RemoverVeiculo(veiculo));    

        Assert.Equal(resultadoEsperado, exception.Message);        
    }

    [Fact]
    public void DeveExibirPlacaInvalidaQuandoRemoverVeiculoComPlacaABC()
    {
        string placa = "abc";
        Veiculo veiculo = new Veiculo(placa);        
        var resultadoEsperado = "Placa inválida.";

        var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoService.RemoverVeiculo(veiculo));    

        Assert.Equal(resultadoEsperado, exception.Message);        
    }

    [Fact]
    public void DeveExibirOVeiculoPlacaABC1234QuandoConsultarSeUmVeiculoDePlacaABC1234EstaEstacionado()
    {
        string placa = "abc1234";
        Veiculo veiculo = new Veiculo(placa);
        _estacionamentoService.AdicionarVeiculo(veiculo);

        var resultadoEsperado = veiculo;
        var resultado = _estacionamentoService.ConsultarVeiculoEstacionado(veiculo);

        Assert.Equal(resultadoEsperado, resultado);
    }

    [Fact]
    public void DeveExibirVeiculoNaoPodeSerNuloQuandoConsultarSeUmVeiculoNuloEstaEstacionado()
    {
        Veiculo veiculo = null;

        var resultadoEsperado = "O veiculo não pode ser nulo.";
        var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoService.ConsultarVeiculoEstacionado(veiculo));    

        Assert.Equal(resultadoEsperado, exception.Message);        
    }

    [Fact]
    public void DeveExibirEstacionamentoNaoPodeSerNuloQuandoConsultarSeUmVeiculoEstaEstacionadoNoEstacionamentoNull()
    {
        Estacionamento _estacionamento = null;
        EstacionamentoService _estacionamentoService = new EstacionamentoService(_estacionamento);

        string placa = "abc1234";
        Veiculo veiculo = new Veiculo(placa);

        var resultadoEsperado = "O estacionamento não pode ser nulo.";
        var exception = Assert.Throws<EstacionamentoInvalidoException>(() => _estacionamentoService.ConsultarVeiculoEstacionado(veiculo));    

        Assert.Equal(resultadoEsperado, exception.Message);        
    }

    [Fact]
    public void DeveExibirPlacaInvalidaQuandoConsultarSeUmVeiculoDePlacaInvalidaEstaEstacionado()
    {
        string placa = "a1";
        Veiculo veiculo = new Veiculo(placa);

        var resultadoEsperado = "Placa inválida.";
        var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoService.ConsultarVeiculoEstacionado(veiculo));    

        Assert.Equal(resultadoEsperado, exception.Message);        
    }

    [Fact]
    public void DeveExibirPlacaNulaOuVaziaQuandoConsultarSeUmVeiculoDePlacaVaziaEstaEstacionado()
    {
        string placa = "";
        Veiculo veiculo = new Veiculo(placa);

        var resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";
        var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoService.ConsultarVeiculoEstacionado(veiculo));    

        Assert.Equal(resultadoEsperado, exception.Message);        
    }

    [Fact]
    public void DeveExibirPlacaNulaOuVaziaQuandoConsultarSeUmVeiculoDePlacaNulaEstaEstacionado()
    {
        string placa = null;
        Veiculo veiculo = new Veiculo(placa);

        var resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";
        var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoService.ConsultarVeiculoEstacionado(veiculo));    

        Assert.Equal(resultadoEsperado, exception.Message);        
    }

    [Fact]
    public void DeveExibirVeiculoNaoEstaEstacionadoQuandoVeiculoNaoEstiverEstacionado()
    {
        string placa = "abc1234";
        Veiculo veiculo = new Veiculo(placa);

        var resultadoEsperado = "Veiculo não está estacionado.";
        var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoService.ConsultarVeiculoEstacionado(veiculo));    

        Assert.Equal(resultadoEsperado, exception.Message);        
    }

    [Fact]
    public void DeveExibirUmaListaQueContemVeiculo1EVeiculo2AoListarTodosQuandoEstesVeiculosForemEstacionados()
    {
        string placa1 = "abc1234";
        Veiculo veiculo1 = new Veiculo(placa1);
        string placa2 = "bcd2345";
        Veiculo veiculo2 = new Veiculo(placa2);

        List<Veiculo> resultadoEsperado = new List<Veiculo> {veiculo1, veiculo2};

        _estacionamentoService.AdicionarVeiculo(veiculo1);
        _estacionamentoService.AdicionarVeiculo(veiculo2);

        List<Veiculo> resultado = _estacionamentoService.ListarTodos();

        Assert.Equal(resultadoEsperado, resultado);        
    }

    [Fact]
    public void DeveExibirUmaListaVaziaAoListarTodosQuandoNãoTiverVeiculoEstacionado()
    {
        List<Veiculo> resultadoEsperado = new List<Veiculo> ();

        List<Veiculo> resultado = _estacionamentoService.ListarTodos();

        Assert.Equal(resultadoEsperado, resultado);
    }
}