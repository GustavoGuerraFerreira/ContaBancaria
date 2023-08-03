using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.classes
{
     class Cliente
    {
        public long Cpf;
        public string Nome;

        public Cliente(string Nome, long Cpf)
        {
            this.Nome = Nome;
            this.Cpf = Cpf;

        }
    }
  
}
