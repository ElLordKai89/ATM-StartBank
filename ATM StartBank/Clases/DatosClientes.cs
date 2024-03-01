using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_StarBank.Clases
{
    internal class DatosClientes
    {

        public long CodigoTarjeta { get; set; }
        public int Pin { get; set; }
        public double SaldoDisponible { get; set; }
        public string? Name {  get; set; }

        public long NumeroCuenta { get; set; }  

    }
}
