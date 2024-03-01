using ATM_StarBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_StarBank.Clases
{
    internal class Deposito:IClienteable, INoClientable
    {

        double MontoEntrada { get; set; }
        double Saldo { get; set; }
        public string? Tipo { get; set; }

        public Deposito(double montoEntrada)
        {

            MontoEntrada = montoEntrada;
        }

        public Deposito(List<DatosClientes> tarjetas, double montoEntrada)
        {
            MontoEntrada = montoEntrada;
        }

        public double CalculaDeposito()
        {
            MontoEntrada += Saldo;
            return MontoEntrada;
        }

    }
}
