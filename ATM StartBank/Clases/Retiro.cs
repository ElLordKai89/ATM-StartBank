using ATM_StarBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_StarBank.Clases
{
    internal class Retiro: IClienteable , INoClientable
    {
        int MontoSalida { get; set; }
        double Saldo { get; set; }
        public string? Tipo { get; set; }

        public Retiro(List<DatosClientes> tarjetas, int cantidadSalida)
        {
            MontoSalida = cantidadSalida;
        }

        public int De50, De100, De200, De500, De1000;
        public void CalcularMonedas()
        {
            

            De1000 = (int)MontoSalida / 1000;

            De500 = (int)MontoSalida / 500;

            De200 = (int)MontoSalida / 200;

            De100 = (int)MontoSalida / 100;

            De50 = (int)MontoSalida / 50;
            

        }

        public double DevolverSaldo()
        {
            CalcularMonedas();
            Saldo -= MontoSalida;
            return Saldo;
        }

    }
}
