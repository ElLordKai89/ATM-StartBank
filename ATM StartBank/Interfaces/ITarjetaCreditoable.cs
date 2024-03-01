using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_StarBank.Interfaces
{
    internal interface ITarjetaCreditoable
    {
        string? NipC { get; set; }

        string? NumeroPlasticoC { get; set; }

        string? NumeroCuentaC { get; set; }

        double CreditoAutorizado { get; set; }

    }
}
