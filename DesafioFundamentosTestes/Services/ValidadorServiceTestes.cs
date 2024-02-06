using DesafioFundamentos.Exceptions;
using DesafioFundamentos.Models.Classes;
using DesafioFundamentos.Models.Enums;
using DesafioFundamentos.Services;

namespace DesafioFundamentosTestes.Services
{
    public class ValidadorServiceTestes
    {
        private Estacionamento _estacionamento;

        private ValidadorService _validadorService;
        private EstacionamentoService _estacionamentoService;

        public ValidadorServiceTestes(){
            _estacionamento = new Estacionamento(10, 5, 3);
            _validadorService = new ValidadorService();            
            _estacionamentoService = new EstacionamentoService(_estacionamento);

        }

        [Fact]
        public void DeveRetornarFalseAoConsultarSePlacaEhValidaSePlacaForNula()
        {
            var resultado = _validadorService.PlacaEhValida(null);

            Assert.False(resultado);
        }

        [Fact]
        public void DeveRetornarFalseAoConsultarSePlacaEhValidaSePlacaForVazia()
        {
            string placa = ""; 
            
            var resultado = _validadorService.PlacaEhValida(placa);

            Assert.False(resultado);
        }

        [Fact]
        public void DeveRetornarFalseAoConsultarSePlacaEhValidaSePlacaForInvalida()
        {
            string placa = "A"; 
            
            var resultado = _validadorService.PlacaEhValida(placa);

            Assert.False(resultado);
        }

        [Fact]
        public void DeveRetornarTrueAoConsultarSePlacaEhValidaSePlacaForABC1234()
        {
            string placa = "ABC1234"; 
            
            var resultado = _validadorService.PlacaEhValida(placa);

            Assert.True(resultado);
        }
                
        [Fact]
        public void DeveExibirEstacionamentoNaoPodeSerNuloQuandoPodeAdicionarVeiculoReceberEstacionamentoNulo()
        {
            string placa = "abc1234";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<EstacionamentoInvalidoException>(() => _validadorService.PodeAdicionarVeiculo(veiculo, null));
            
            string resultadoEsperado = "O estacionamento não pode ser nulo.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void DeveExibirVeiculoNaoPodeSerNuloQuandoPodeAdicionarVeiculoReceberEstacionamentoForNulo()
        {
            var exception = Assert.Throws<VeiculoInvalidoException>(() => _validadorService.PodeAdicionarVeiculo(null, _estacionamento));
            
            string resultadoEsperado = "O veiculo não pode ser nulo.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }        

        [Fact]
        public void DeveExibirPlacaNulaOuVaziaQuandoPodeAdicionarVeiculoReceberVeiculoComPlacaVazia()
        {
            string placa = "";
            Veiculo veiculo = new Veiculo(placa);

            var exception = Assert.Throws<PlacaInvalidaException>(() => _validadorService.PodeAdicionarVeiculo(veiculo, _estacionamento));

            string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";

            Assert.Equal(resultadoEsperado, exception.Message);
        }

        [Fact]
        public void DeveExibirPlacaNulaOuVaziaQuandoPodeAdicionarVeiculoReceberVeiculoComPlacaNula()
        {
            string placa = null;
            Veiculo veiculo = new Veiculo(placa);

            var exception = Assert.Throws<PlacaInvalidaException>(() => _validadorService.PodeAdicionarVeiculo(veiculo, _estacionamento));
            
            string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";

            Assert.Equal(resultadoEsperado, exception.Message);
        }

        [Fact]
        public void DeveExibirEstacionamentoEstaLotadoQuandoPodeAdicionarVeiculoReceberVeiculoEmEstacionamentoComVagasOcupadas()
        {
            int vagas = 1;

            Estacionamento _estacionamento = new Estacionamento(10, 2, vagas);
            EstacionamentoService _estacionamentoService = new EstacionamentoService(_estacionamento);
            ValidadorService _validadorService = new ValidadorService();

            string placa1 = "ABC1234";        
            Veiculo veiculo1 = new Veiculo(placa1);
            _estacionamentoService.AdicionarVeiculo(veiculo1);

            string placa2 = "bcd1234";        
            Veiculo veiculo2 = new Veiculo(placa2);   

            var exception = Assert.Throws<VeiculoInvalidoException>(() => _validadorService.PodeAdicionarVeiculo(veiculo2, _estacionamento));
            string resultadoEsperado = "Estacionamento está lotado.";
            
            Assert.Equal(resultadoEsperado, exception.Message);
        }

        [Fact]
        public void DeveExibirPlacaInvalidaQuandoPodeAdicionarVeiculoReceberVeiculoComPlacaABC()
        {
            string placa1 = "ABC";        
            Veiculo veiculo1 = new Veiculo(placa1);

            var exception = Assert.Throws<PlacaInvalidaException>(() => _validadorService.PodeAdicionarVeiculo(veiculo1, _estacionamento));
            
            string resultadoEsperado = "Placa inválida.";

            Assert.Equal(resultadoEsperado, exception.Message);
        }

        [Fact]
        public void DeveExibirVeiculoJaEstacionadoQuandoPodeAdicionarVeiculoReceberVeiculoPreviamenteAdicionado()
        {
            string placa1 = "ABC1234";
            Veiculo veiculo = new Veiculo(placa1);
            _estacionamentoService.AdicionarVeiculo(veiculo);

            var exception = Assert.Throws<VeiculoInvalidoException>(() => _validadorService.PodeAdicionarVeiculo(veiculo, _estacionamento));
            
            string resultadoEsperado = "Veiculo já está estacionado.";

            Assert.Equal(resultadoEsperado, exception.Message);
        }

        [Fact]
        public void DeveExibirUmQuandoContarVeiculosEstacionados(){
            string placa = "ABC1234";        
            Veiculo veiculo = new Veiculo(placa);
            _estacionamentoService.AdicionarVeiculo(veiculo);

            var resultado = _validadorService.ContarVeiculosEstacionados(_estacionamento);

            var resultadoEsperado = 1;

            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void DeveExibirZeroQuandoContarVeiculosEstacionados(){

            var resultado = _validadorService.ContarVeiculosEstacionados(_estacionamento);

            var resultadoEsperado = 0;

            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void DeveExibirEstacionamentoNaoPodeSerNuloQuandoContarVeiculosEstacionadosTiverEstacionamentoNulo()
        {
            var exception = Assert.Throws<EstacionamentoInvalidoException>(() => _validadorService.ContarVeiculosEstacionados(null));
            
            string resultadoEsperado = "O estacionamento não pode ser nulo.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void DeveExibirVeiculoNaoPodeSerNuloAoVerificarSePodeConsultarVeiculoEstacionadoQuandoVeiculoForNulo()
        {
            var exception = Assert.Throws<VeiculoInvalidoException>(() => _validadorService.PodeConsultarVeiculoEstacionado(null, _estacionamento));
            
            string resultadoEsperado = "O veiculo não pode ser nulo.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void DeveExibirEstacionamentoNaoPodeSerNuloAoVerificarSePodeConsultarVeiculoEstacionadoQuandoVeiculoForNulo()
        {
            string placa = "abc1234";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<EstacionamentoInvalidoException>(() => _validadorService.PodeConsultarVeiculoEstacionado(veiculo, null));
            
            string resultadoEsperado = "O estacionamento não pode ser nulo.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }
        
        [Fact]
        public void DeveExibirPlacaNulaOuVaziaAoVerificarSePodeConsultarVeiculoEstacionadoQuandoPlacaForVazia()
        {
            string placa = "";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<PlacaInvalidaException>(() => _validadorService.PodeConsultarVeiculoEstacionado(veiculo, _estacionamento));
            
            string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void DeveExibirPlacaInvalidaAoVerificarSePodeConsultarVeiculoEstacionadoQuandoPlacaForInvalida()
        {
            string placa = "Ab1";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<PlacaInvalidaException>(() => _validadorService.PodeConsultarVeiculoEstacionado(veiculo, _estacionamento));
            
            string resultadoEsperado = "Placa inválida.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void DeveRetornarTrueAoConsultarSeVeiculoEstaEstacionadoSeVeiculoEstiverEstacionado()
        {
            string placa = "ABC1234";
            Veiculo veiculo = new Veiculo(placa);
            _estacionamentoService.AdicionarVeiculo(veiculo);
            
            var resultado = _validadorService.VeiculoEstaEstacionado(veiculo, _estacionamento);

            Assert.True(resultado);
        }

        [Fact]
        public void DeveRetornarFalseAoConsultarSeVeiculoEstaEstacionadoSeVeiculoNãoEstiverEstacionado()
        {
            string placa = "ABC1234";
            Veiculo veiculo = new Veiculo(placa);
            
            var resultado = _validadorService.VeiculoEstaEstacionado(veiculo, _estacionamento);

            Assert.False(resultado);
        }

        [Fact]
        public void DeveRetornarFalseAoConsultarSeVeiculoEstaEstacionadoSeVeiculoForNull()
        {            
            var resultado = _validadorService.VeiculoEstaEstacionado(null, _estacionamento);

            Assert.False(resultado);
        }

        [Fact]
        public void DeveRetornarFalseAoConsultarSeVeiculoEstaEstacionadoSeEstacionamentoForNull()
        {            
            string placa = "ABC1234";
            Veiculo veiculo = new Veiculo(placa);
            
            var resultado = _validadorService.VeiculoEstaEstacionado(veiculo, null);

            Assert.False(resultado);
        }        

        [Fact]
        public void DeveExibirVeiculoNaoPodeSerNuloAoConsultarSePodeRealizarPagamentoQuandoVeiculoForNulo()
        {            
            var exception = Assert.Throws<VeiculoInvalidoException>(() => _validadorService.PodeRealizarPagamento(null, 10M, FormaPagamento.CartaoDeCredito, _estacionamento));
            
            string resultadoEsperado = "O veiculo não pode ser nulo.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void DeveExibirEstacionamentoNaoPodeSerNuloAoConsultarSePodeRealizarPagamentoQuandoEstacionamentoForNulo()
        {
            string placa = "abc1234";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<EstacionamentoInvalidoException>(() => _validadorService.PodeRealizarPagamento(veiculo, 10M, FormaPagamento.CartaoDeCredito, null));
            
            string resultadoEsperado = "O estacionamento não pode ser nulo.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void DeveExibirPlacaNulaOuVaziaAoConsultarSePodeRealizarPagamentoQuandoPlacaForNula()
        {
            Veiculo veiculo = new Veiculo(null);
            
            var exception = Assert.Throws<PlacaInvalidaException>(() => _validadorService.PodeRealizarPagamento(veiculo, 10M, FormaPagamento.CartaoDeCredito, _estacionamento));
            
            string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }        

        [Fact]
        public void DeveExibirPlacaNulaOuVaziaAoConsultarSePodeRealizarPagamentoQuandoPlacaForVazia()
        {
            string placa = "";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<PlacaInvalidaException>(() => _validadorService.PodeRealizarPagamento(veiculo, 10M, FormaPagamento.CartaoDeCredito, _estacionamento));
            
            string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void DeveExibirPlacaInvalidaAoConsultarSePodeRealizarPagamentoQuandoPlacaForInvalida()
        {
            string placa = "Ab1";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<PlacaInvalidaException>(() => _validadorService.PodeRealizarPagamento(veiculo, 10M, FormaPagamento.CartaoDeCredito, _estacionamento));
            
            string resultadoEsperado = "Placa inválida.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void DeveExibirNaoHaValorAPagarAoConsultarSePodeRealizarPagamentoQuandoValorAPagarForZero()
        {
            string placa = "abc1234";
            Veiculo veiculo = new Veiculo(placa);
            decimal valorAPagar = 0M;
            
            var exception = Assert.Throws<VeiculoInvalidoException>(() => _validadorService.PodeRealizarPagamento(veiculo, valorAPagar, FormaPagamento.CartaoDeCredito, _estacionamento));
            
            string resultadoEsperado = "Não há valor a pagar.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }        

        [Fact]
        public void DeveExibirVeiculoNaoPodeSerNuloAoConsultarSePodeRemoverVeiculoQuandoVeiculoForNulo()
        {
            var exception = Assert.Throws<VeiculoInvalidoException>(() => _validadorService.PodeRemoverVeiculo(null, _estacionamento));
            
            string resultadoEsperado = "O veiculo não pode ser nulo.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void DeveExibirEstacionamentoNaoPodeSerNuloAoConsultarSePodeRemoverVeiculoQuandoVeiculoForNulo()
        {
            string placa = "abc1234";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<EstacionamentoInvalidoException>(() => _validadorService.PodeRemoverVeiculo(veiculo, null));
            
            string resultadoEsperado = "O estacionamento não pode ser nulo.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }
        
        [Fact]
        public void DeveExibirPlacaNulaOuVaziaAoConsultarSePodeRemoverVeiculoQuandoPlacaForVazia()
        {
            string placa = "";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<PlacaInvalidaException>(() => _validadorService.PodeRemoverVeiculo(veiculo, _estacionamento));
            
            string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void DeveExibirPlacaInvalidaAoConsultarSePodeRemoverVeiculoQuandoPlacaForInvalida()
        {
            string placa = "Ab1";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<PlacaInvalidaException>(() => _validadorService.PodeRemoverVeiculo(veiculo, _estacionamento));
            
            string resultadoEsperado = "Placa inválida.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void DeveExibirVeiculoExcedeuLimiteSaidaAoConsultarSePodeRemoverVeiculoQuandoPlacaForInvalida()
        {
            string placa = "abc1234";
            Veiculo veiculo = new Veiculo(placa);
            _estacionamentoService.AdicionarVeiculo(veiculo);
            veiculo.SetLimiteSaida(DateTime.Now.AddMinutes(-10));
            
            var exception = Assert.Throws<VeiculoInvalidoException>(() => _validadorService.PodeRemoverVeiculo(veiculo, _estacionamento));
            
            string resultadoEsperado = "Veiculo excedeu limite de saída.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }
    }
}