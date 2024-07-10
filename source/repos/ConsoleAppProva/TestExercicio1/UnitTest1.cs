using Exercicio1;
using Exercicio1.Validacao;

namespace TestExercicio1
{
    public class UnitTest1
    {
        [Fact]
        public void DeveAcharConexaoDireta()
        {
            // Arrange
            var network = new Network(new ArgumentoValidador(), 8);
            network.Connect(1, 6);

            //Act
            var result = network.Query(1, 6);

            Assert.True(result);

        }

        [Fact]
        public void DeveAcharConexaoInvertida()
        {
            // Arrange
            var network = new Network(new ArgumentoValidador(), 8);
            network.Connect(1, 6);
            network.Connect(1, 2);
            network.Connect(2, 4);
            network.Connect(5, 8);

            //Act
            var result = network.Query(6, 1);

            Assert.True(result);

        }

        [Fact]
        public void DeveAcharConexaoIndiretaAfrente()
        {
            // Arrange
            var network = new Network(new ArgumentoValidador(), 8);
            network.Connect(1, 2);
            network.Connect(1, 6);
            network.Connect(2, 4);
            network.Connect(5, 8);
            network.Connect(6, 2);

            //Act
            var result = network.Query(1, 4);

            Assert.True(result);

        }

        [Fact]
        public void DeveAcharConexaoAtras()
        {
            // Arrange
            var network = new Network(new ArgumentoValidador(), 8);
            network.Connect(1, 2);
            network.Connect(1, 6);
            network.Connect(2, 4);
            network.Connect(4, 7);
            network.Connect(5, 8);
            network.Connect(6, 2);

            //Act
            var result = network.Query(4, 7);

            Assert.True(result);

        }

        [Fact]
        public void NaoDeveAcharConexao()
        {
            // Arrange
            var network = new Network(new ArgumentoValidador(), 8);
            network.Connect(1, 2);
            network.Connect(1, 6);
            network.Connect(2, 4);
            network.Connect(4, 7);
            network.Connect(5, 8);
            network.Connect(6, 2);

            //Act
            var result = network.Query(3, 7);

            Assert.False(result);

        }

        [Fact]
        public void DeveAcharConexaoOrdemAleatoria()
        {
            // Arrange
            var network = new Network(new ArgumentoValidador(), 8);
            network.Connect(1, 6);
            network.Connect(2, 6);
            network.Connect(2, 4);
            network.Connect(4, 7);
            network.Connect(5, 8);

            var result = network.Query(1, 4);

            Assert.True(result);

        }

        [Fact]
        public void DeveOcorrerErroDeArgumento()
        {
            // Arrange
            var network = new Network(new ArgumentoValidador(), 8);
            network.Connect(1, 2);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => network.Query(9, 7));

            Assert.Equal("ArgumentoInvalido", exception.ParamName);


        }

    }

}