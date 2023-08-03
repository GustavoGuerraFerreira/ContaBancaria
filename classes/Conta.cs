using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.classes
{
    class Conta
    {
        public int Numero { get; set; }
        public double Saldo { get; set; }
        public Cliente Cliente { get; set; }
        public Conta(int numero, Cliente cliente)
        {
            this.Numero = numero;
            this.Cliente = cliente;
            this.Saldo = 0;
        }
        public bool Sacar(double value)
        {
            if (this.Saldo > 0)
            {
                this.Saldo -= value;
                return true;
            }
            else
            {
                return false;
            }
        } 
        public void Depositar(double value)
        {
            this.Saldo += value;
        }

        public bool Transferir(double value, Conta destino)
        {
            if (this.Saldo >= value)
            {
                this.Saldo -= value;
                destino.Depositar(value);
                return true;
            }
            else
            {
                return false;
            }
        }
        public double ConsultarSaldo()
        {
            return Saldo;
        }
    }


}
