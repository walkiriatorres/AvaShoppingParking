using DesafioFundamentos.Exceptions;
using DesafioFundamentos.Models;
using DesafioFundamentos.Services;

namespace DesafioFundamentosTestes
{
    public class EstacionamentoValidadorTestes
    {
        private Estacionamento _estacionamento;

        private EstacionamentoValidador _estacionamentoValidador;
        private EstacionamentoService _estacionamentoService;

        public EstacionamentoValidadorTestes(){
            _estacionamento = new Estacionamento(10, 5, 3);
            _estacionamentoValidador = new EstacionamentoValidador();            
            _estacionamentoService = new EstacionamentoService(_estacionamento);

        }

        [Fact]
        public void DeveExibirEstacionamentoNaoPodeSerNuloQuandoPodeAdicionarVeiculoReceberEstacionamentoNulo()
        {
            string placa = "abc1234";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<EstacionamentoInvalidoException>(() => _estacionamentoValidador.PodeAdicionarVeiculo(veiculo, null));
            
            string resultadoEsperado = "O estacionamento não pode ser nulo.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void DeveExibirVeiculoNaoPodeSerNuloQuandoPodeAdicionarVeiculoReceberVeiculoForNulo()
        {
            var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoValidador.PodeAdicionarVeiculo(null, _estacionamento));
            
            string resultadoEsperado = "O veiculo não pode ser nulo.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }
        

        [Fact]
        public void DeveExibirPlacaNulaOuVaziaQuandoPodeAdicionarVeiculoReceberVeiculoComPlacaVazia()
        {
            string placa = "";
            Veiculo veiculo = new Veiculo(placa);

            var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoValidador.PodeAdicionarVeiculo(veiculo, _estacionamento));

            string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";

            Assert.Equal(resultadoEsperado, exception.Message);
        }

        [Fact]
        public void DeveExibirPlacaNulaOuVaziaQuandoPodeAdicionarVeiculoReceberVeiculoComPlacaNula()
        {
            string placa = null;
            Veiculo veiculo = new Veiculo(placa);

            var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoValidador.PodeAdicionarVeiculo(veiculo, _estacionamento));
            
            string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";

            Assert.Equal(resultadoEsperado, exception.Message);
        }

        [Fact]
        public void DeveExibirEstacionamentoEstaLotadoQuandoPodeAdicionarVeiculoReceberVeiculoEmEstacionamentoComVagasOcupadas()
        {
            int vagas = 1;

            Estacionamento _estacionamento = new Estacionamento(10, 2, vagas);
            EstacionamentoService _estacionamentoService = new EstacionamentoService(_estacionamento);
            EstacionamentoValidador _estacionamentoValidador = new EstacionamentoValidador();

            string placa1 = "ABC1234";        
            Veiculo veiculo1 = new Veiculo(placa1);
            _estacionamentoService.AdicionarVeiculo(veiculo1);

            string placa2 = "bcd1234";        
            Veiculo veiculo2 = new Veiculo(placa2);   

            var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoValidador.PodeAdicionarVeiculo(veiculo2, _estacionamento));
            string resultadoEsperado = "Estacionamento está lotado.";
            
            Assert.Equal(resultadoEsperado, exception.Message);
        }

        [Fact]
        public void DeveExibirPlacaInvalidaQuandoPodeAdicionarVeiculoReceberVeiculoComPlacaABC()
        {
            string placa1 = "ABC";        
            Veiculo veiculo1 = new Veiculo(placa1);

            var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoValidador.PodeAdicionarVeiculo(veiculo1, _estacionamento));
            
            string resultadoEsperado = "Placa inválida.";

            Assert.Equal(resultadoEsperado, exception.Message);
        }

        [Fact]
        public void DeveExibirVeiculoJaEstacionadoQuandoPodeAdicionarVeiculoReceberVeiculoPreviamenteAdicionado()
        {
            string placa1 = "ABC1234";
            Veiculo veiculo = new Veiculo(placa1);
            _estacionamentoService.AdicionarVeiculo(veiculo);

            var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoValidador.PodeAdicionarVeiculo(veiculo, _estacionamento));
            
            string resultadoEsperado = "Veiculo já está estacionado.";

            Assert.Equal(resultadoEsperado, exception.Message);
        }
        
        [Fact]
        public void DeveExibirTrueQuandoPlacaForVazia()
        {
            string placa = "";

            Assert.True(_estacionamentoValidador.PlacaNulaOuVazia(placa));
        }

        [Fact]
        public void DeveExibirTrueQuandoPlacaForNula()
        {
            string placa = null;

            Assert.True(_estacionamentoValidador.PlacaNulaOuVazia(placa));
        }

        [Fact]
        public void DeveExibirTrueQuandoEstacionamentoEstiverLotado()
        {
            int vagas = 1;

            Estacionamento _estacionamento = new Estacionamento(10, 2, vagas);
            EstacionamentoService _estacionamentoService = new EstacionamentoService(_estacionamento);
            EstacionamentoValidador _estacionamentoValidador = new EstacionamentoValidador();

            string placa = "ABC1234";        
            Veiculo veiculo = new Veiculo(placa);
            _estacionamentoService.AdicionarVeiculo(veiculo);

            var resultado = _estacionamentoValidador.EstacionamentoEstaLotado(_estacionamento);

            Assert.True(resultado);
        }        

        [Fact]
        public void DeveExibirTrueQuandoEstacionamentoNaoEstiverLotado()
        {
            var resultado = _estacionamentoValidador.EstacionamentoEstaLotado(_estacionamento);

            Assert.False(resultado);
        }

        [Fact]
        public void DeveExibirTrueQuandoEstacionamentoForNulo()
        {
            var resultado = _estacionamentoValidador.EstacionamentoEstaLotado(null);

            Assert.False(resultado);
        } 

        [Fact]
        public void DeveExibirUmQuandoContarVeiculosEstacionados(){
            string placa = "ABC1234";        
            Veiculo veiculo = new Veiculo(placa);
            _estacionamentoService.AdicionarVeiculo(veiculo);

            var resultado = _estacionamentoValidador.ContarVeiculosEstacionados(_estacionamento);

            var resultadoEsperado = 1;

            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void DeveExibirEstacionamentoNaoPodeSerNuloQuandoContarVeiculosEstacionadosTiverEstacionamentoNulo()
        {
            var exception = Assert.Throws<EstacionamentoInvalidoException>(() => _estacionamentoValidador.ContarVeiculosEstacionados(null));
            
            string resultadoEsperado = "O estacionamento não pode ser nulo.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }   

        [Fact]
        public void PlacaEhValida_DeveRetornarFalseSePlacaForNull()
        {
            var resultado = _estacionamentoValidador.PlacaEhValida(null);

            Assert.False(resultado);
        }

        [Fact]
        public void PlacaEhValida_DeveRetornarFalseSePlacaForVazia()
        {
            string placa = ""; 
            
            var resultado = _estacionamentoValidador.PlacaEhValida(placa);

            Assert.False(resultado);
        }

        [Fact]
        public void PlacaEhValida_DeveRetornarFalseSePlacaForInvalida()
        {
            string placa = "A"; 
            
            var resultado = _estacionamentoValidador.PlacaEhValida(placa);

            Assert.False(resultado);
        }

        [Fact]
        public void PlacaEhValida_DeveRetornarTrueSePlacaForABC1234()
        {
            string placa = "ABC1234"; 
            
            var resultado = _estacionamentoValidador.PlacaEhValida(placa);

            Assert.True(resultado);
        }

        [Fact]
        public void VeiculoEstaEstacionado_DeveRetornarTrueSeVeiculoEstiverEstacionado()
        {
            string placa = "ABC1234";
            Veiculo veiculo = new Veiculo(placa);
            _estacionamentoService.AdicionarVeiculo(veiculo);
            
            var resultado = _estacionamentoValidador.VeiculoEstaEstacionado(veiculo, _estacionamento);

            Assert.True(resultado);
        }

        [Fact]
        public void VeiculoEstaEstacionado_DeveRetornarFalseSeVeiculoNãoEstiverEstacionado()
        {
            string placa = "ABC1234";
            Veiculo veiculo = new Veiculo(placa);
            
            var resultado = _estacionamentoValidador.VeiculoEstaEstacionado(veiculo, _estacionamento);

            Assert.False(resultado);
        }

        [Fact]
        public void VeiculoEstaEstacionado_DeveRetornarFalseSeVeiculoForNull()
        {            
            var resultado = _estacionamentoValidador.VeiculoEstaEstacionado(null, _estacionamento);

            Assert.False(resultado);
        }

        [Fact]
        public void VeiculoEstaEstacionado_DeveRetornarFalseSeEstacionamentoForNull()
        {            
            string placa = "ABC1234";
            Veiculo veiculo = new Veiculo(placa);
            
            var resultado = _estacionamentoValidador.VeiculoEstaEstacionado(veiculo, null);

            Assert.False(resultado);
        }

        [Fact]
        public void PodeConsultarValor_DeveExibirVeiculoNaoPodeSerNuloQuandoVeiculoForNulo()
        {
            var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoValidador.PodeConsultarValor(null, _estacionamento));
            
            string resultadoEsperado = "O veiculo não pode ser nulo.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void PodeConsultarValor_DeveExibirEstacionamentoNaoPodeSerNuloQuandoVeiculoForNulo()
        {
            string placa = "abc1234";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<EstacionamentoInvalidoException>(() => _estacionamentoValidador.PodeConsultarValor(veiculo, null));
            
            string resultadoEsperado = "O estacionamento não pode ser nulo.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void PodeConsultarValor_DeveExibirPlacaNulaOuVaziaQuandoPlacaForNula()
        {
            Veiculo veiculo = new Veiculo(null);
            
            var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoValidador.PodeConsultarValor(veiculo, _estacionamento));
            
            string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void PodeConsultarValor_DeveExibirPlacaNulaOuVaziaQuandoPlacaForVazia()
        {
            string placa = "";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoValidador.PodeConsultarValor(veiculo, _estacionamento));
            
            string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void PodeConsultarValor_DeveExibirPlacaInvalidaQuandoPlacaForInvalida()
        {
            string placa = "Ab1";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoValidador.PodeConsultarValor(veiculo, _estacionamento));
            
            string resultadoEsperado = "Placa inválida.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void PodeConsultarValor_DeveExibirVeiculoNaoEstaEstacionadoQuandoVeiculoNaoEstiverEstacionado()
        {
            string placa = "Abc1234";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoValidador.PodeConsultarValor(veiculo, _estacionamento));
            
            string resultadoEsperado = "Veiculo não está estacionado.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void PodeConsultarVeiculoEstacionado_DeveExibirVeiculoNaoPodeSerNuloQuandoVeiculoForNulo()
        {
            var exception = Assert.Throws<VeiculoInvalidoException>(() => _estacionamentoValidador.PodeConsultarVeiculoEstacionado(null, _estacionamento));
            
            string resultadoEsperado = "O veiculo não pode ser nulo.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void PodeConsultarVeiculoEstacionado_DeveExibirEstacionamentoNaoPodeSerNuloQuandoVeiculoForNulo()
        {
            string placa = "abc1234";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<EstacionamentoInvalidoException>(() => _estacionamentoValidador.PodeConsultarVeiculoEstacionado(veiculo, null));
            
            string resultadoEsperado = "O estacionamento não pode ser nulo.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }
        
        [Fact]
        public void PodeConsultarVeiculoEstacionado_DeveExibirPlacaNulaOuVaziaQuandoPlacaForVazia()
        {
            string placa = "";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoValidador.PodeConsultarVeiculoEstacionado(veiculo, _estacionamento));
            
            string resultadoEsperado = "Placa nula ou vazia não pode ser estacionada.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }

        [Fact]
        public void PodeConsultarVeiculoEstacionado_DeveExibirPlacaInvalidaQuandoPlacaForInvalida()
        {
            string placa = "Ab1";
            Veiculo veiculo = new Veiculo(placa);
            
            var exception = Assert.Throws<PlacaInvalidaException>(() => _estacionamentoValidador.PodeConsultarVeiculoEstacionado(veiculo, _estacionamento));
            
            string resultadoEsperado = "Placa inválida.";

            Assert.Equal(resultadoEsperado, exception.Message);            
        }
    }
}