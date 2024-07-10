using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercicio1.Validacao.ArgumentoValidador;

namespace Exercicio1.Validacao
{
    public class ArgumentoValidador : IArgumentoValidador
    {

        public ushort Min { get; set; }
        public ushort Max { get; set; }

        public ArgumentoValidador()
        {
            
        }
        public void Validate(ushort value)
        {
            if (value < Min || value > Max)
            {
                throw new ArgumentOutOfRangeException("ArgumentoInvalido", $"Argumento tem que ser maior ou igual a {Min} ou menor ou igual a {Max}.");
            }
        }
    }
}
