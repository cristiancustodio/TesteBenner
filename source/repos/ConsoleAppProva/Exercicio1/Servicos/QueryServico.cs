using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1.Servicos
{
    public class QueryServico : IQueryServico
    {

        private IList<Tuple<ushort, ushort>> _elementos;
        private IList<Tuple<ushort, ushort>> _percorrido;

        public QueryServico(IList<Tuple<ushort, ushort>> elementos)
        {
            _elementos = elementos;
            _percorrido = new List<Tuple<ushort, ushort>>();
        }

        public Boolean Query(ushort origem, ushort destino)
        {
            var result = _elementos.Contains(new Tuple<ushort, ushort>(origem, destino)) || _elementos.Contains(new Tuple<ushort, ushort>(destino, origem));

            if (result)
            {
                Console.WriteLine($"{origem}-{destino}");
                return true;
            }

            return RecursivoQuery(origem, destino);
        }

        private Boolean RecursivoQuery(ushort origem, ushort destino)
        {
            var vElementos = _elementos.Where(x => x.Item1 == origem).ToList();
            vElementos.AddRange(_elementos.Where(x => x.Item2 == origem));
            vElementos = vElementos.Except(_percorrido).ToList();

            foreach (var item in vElementos)
            {
                _percorrido.Add(item);
                Console.WriteLine($"{item.Item1}-{item.Item2}");
                if (item.Item1 == destino ||item.Item2 == destino) return true;

                if (RecursivoQuery(item.Item1==origem?item.Item2:item.Item1, destino)) return true;

            }

            return false;
        }

    }
}
