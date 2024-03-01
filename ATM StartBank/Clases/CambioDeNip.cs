using ATM_StarBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_StarBank.Clases
{
    internal class CambioDeNip:IClienteable
    {
        int Nip { get; set; }
        int NuevoNip;
        public string? Tipo { get; set; }

        public CambioDeNip(int nuevoNip)
        {
            Nip = nuevoNip;
        }


        public int? CambiarNip()
        {
            Nip = NuevoNip;
            return Nip;
        }



    }
}
