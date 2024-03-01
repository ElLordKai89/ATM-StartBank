using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_StarBank.Clases
{
    internal class DispensadorEfectivo
    {

        public int LimiteRetiro;
        public int EfectivoTotal;

        internal DispensadorEfectivo()
        {
            LimiteRetiro = 9000;
            EfectivoTotal = 200000;
        }
    }
}
