using Exercicio1.Validacao;
using Exercicio1.Servicos;

namespace Exercicio1
{
    public class Network
    {
        private uint _count;
        private IList<Tuple<ushort, ushort>> _elementos = new List<Tuple<ushort, ushort>>();
        private IArgumentoValidador _validador;

        public Network(IArgumentoValidador validador, ushort count)
        {
            _count = count;
            _validador = validador;
            _validador.Min = 1;
            _validador.Max = count;
        }

        public void Connect(ushort origem, ushort destino)
        {
            _validador.Validate(origem);
            _validador.Validate(destino);

            _elementos.Add(new Tuple<ushort, ushort>(origem, destino));

        }

        public Boolean Query(ushort origem, ushort destino)
        { 
                    
            _validador.Validate(origem);
            _validador.Validate(destino);

            return new QueryServico(_elementos).Query(origem, destino);

        }


    }
}