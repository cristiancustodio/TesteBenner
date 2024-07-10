using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1.Validacao
{
    public interface IArgumentoValidador
    {
        ushort Min { get; set; }
        ushort Max { get; set; }
        void Validate(ushort value);
    }
}
