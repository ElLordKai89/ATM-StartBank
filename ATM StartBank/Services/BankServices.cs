using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
using ATM_StarBank.Clases;
using ATM_StarBank.Interfaces;




namespace ATM_StarBank.Services
{
    internal class BankServices
    {
        internal long CodTarjeta;
        internal int Nip;

        private List<TipoTransaccionEntity> tiposTransaccion = new List<TipoTransaccionEntity>();
        private List<DatosClientes> Tarjetas = new List<DatosClientes>();
        private List<RegistroTransaccion> Transacciones = new List<RegistroTransaccion>();

        public BankServices()
        {

            DatosClientes cliente1 = new DatosClientes { CodigoTarjeta = 5432109876543210, Pin = 1098, Name = "Heyder Ix", SaldoDisponible = 50000.00, NumeroCuenta = 9876543210123456 };
            DatosClientes cliente2 = new DatosClientes { CodigoTarjeta = 1234567890123456, Pin = 2156, Name = "Kairós Díaz", SaldoDisponible = 10000.00, NumeroCuenta = 2345678901234567 };
            DatosClientes cliente3 = new DatosClientes { CodigoTarjeta = 2345678901234567, Pin = 3098, Name = "Jesús Euan", SaldoDisponible = 40000.00, NumeroCuenta = 3456789012345678 };
            DatosClientes cliente4 = new DatosClientes { CodigoTarjeta = 3456789012345678, Pin = 4167, Name = "Alan Polanco", SaldoDisponible = 20000.00, NumeroCuenta = 4567890123456789 };
            DatosClientes cliente5 = new DatosClientes { CodigoTarjeta = 4567890123456789, Pin = 5234, Name = "Luis Ek", SaldoDisponible = 15000.00, NumeroCuenta = 5678901234567890 };
            DatosClientes cliente6 = new DatosClientes { CodigoTarjeta = 5678901234567890, Pin = 6341, Name = "Rommel Canepa", SaldoDisponible = 45000.00, NumeroCuenta = 6789012345678901 };
            DatosClientes cliente7 = new DatosClientes { CodigoTarjeta = 6789012345678901, Pin = 7412, Name = "Kevin Montero", SaldoDisponible = 65000.00, NumeroCuenta = 7890123456789012 };
            DatosClientes cliente8 = new DatosClientes { CodigoTarjeta = 7890123456789012, Pin = 8567, Name = "Eduardo Flores", SaldoDisponible = 25000.00, NumeroCuenta = 8901234567890123 };
            DatosClientes cliente9 = new DatosClientes { CodigoTarjeta = 8901234567890123, Pin = 9672, Name = "Yussif Paredes", SaldoDisponible = 35000.00, NumeroCuenta = 9012345678901234 };
            DatosClientes cliente10 = new DatosClientes { CodigoTarjeta = 9012345678901234, Pin = 1076, Name = "Andrea Arellano", SaldoDisponible = 30000.00, NumeroCuenta = 1234567890123456 };
            DatosClientes cliente11 = new DatosClientes { CodigoTarjeta = 5432109876543210, Pin = 1158, Name = "Josue Ciau", SaldoDisponible = 40000.00, NumeroCuenta = 5432109876543210 };
            DatosClientes cliente12 = new DatosClientes { CodigoTarjeta = 4321098765432109, Pin = 1283, Name = "Wendy Novelo", SaldoDisponible = 50000.00, NumeroCuenta = 4321098765432109 };
            DatosClientes cliente13 = new DatosClientes { CodigoTarjeta = 3210987654321098, Pin = 1354, Name = "Diego Sánchez", SaldoDisponible = 60000.00, NumeroCuenta = 3210987654321098 };
            DatosClientes cliente14 = new DatosClientes { CodigoTarjeta = 2109876543210987, Pin = 1429, Name = "Daniel Ucan", SaldoDisponible = 70000.00, NumeroCuenta = 2109876543210987 };
            DatosClientes cliente15 = new DatosClientes { CodigoTarjeta = 1098765432109876, Pin = 1567, Name = "Luis Valle", SaldoDisponible = 80000.00, NumeroCuenta = 1098765432109876 };


            // Añadir a la lista
            Tarjetas.Add(cliente1);
            Tarjetas.Add(cliente2);
            Tarjetas.Add(cliente3);
            Tarjetas.Add(cliente4);
            Tarjetas.Add(cliente5);
            Tarjetas.Add(cliente6);
            Tarjetas.Add(cliente7);
            Tarjetas.Add(cliente8);
            Tarjetas.Add(cliente9);
            Tarjetas.Add(cliente10);
            Tarjetas.Add(cliente11);
            Tarjetas.Add(cliente12);
            Tarjetas.Add(cliente13);
            Tarjetas.Add(cliente14);
            Tarjetas.Add(cliente15);

            // Agregar tipos de transacción
            tiposTransaccion.Add(new TipoTransaccionEntity() { Id = 1, Tipo = "Depósito" });
            tiposTransaccion.Add(new TipoTransaccionEntity() { Id = 2, Tipo = "Retiro" });
            tiposTransaccion.Add(new TipoTransaccionEntity() { Id = 3, Tipo = "Cambio de NIP" });
            tiposTransaccion.Add(new TipoTransaccionEntity() { Id = 4, Tipo = "Ver transacciones" });
            tiposTransaccion.Add(new TipoTransaccionEntity() { Id = 5, Tipo = "Consultar saldo" });
            tiposTransaccion.Add(new TipoTransaccionEntity() { Id = 6, Tipo = "Cerrar sesión" });

        }

        //para iniciar sesion si es un cliente 
        internal DatosClientes? VerificarCliente()
        {
            bool SesionValida = false;
            DatosClientes? tarjeta = null;
            do
            {

                Console.WriteLine("Ingrese los 16 dígitos de la tarjeta:");
                string input = Console.ReadLine();

                if (input.Length != 16 || !long.TryParse(input, out long CodTarjeta))
                {
                    Console.WriteLine("Código inválido");
                    continue;
                }

                while (!Tarjetas.Any(x => x.CodigoTarjeta == CodTarjeta))
                {
                    Console.WriteLine("No existe un usuario con el código ingresado, ingrese un código válido por favor.");
                    Console.WriteLine();
                    Console.WriteLine("Ingrese los 16 dígitos de la tarjeta:");
                    CodTarjeta = long.Parse(Console.ReadLine());
                }

                tarjeta = Tarjetas.Where(x => x.CodigoTarjeta == CodTarjeta).FirstOrDefault();
                string? nombre = tarjeta.Name;


                Console.WriteLine("Ingrese su PIN (4 dígitos)");
                Nip = int.Parse(Console.ReadLine());

                if (tarjeta.Pin == Nip)
                {
                    SesionValida = true;
                }

                int intentosRestantes = 3;
                while (intentosRestantes > 0 && !SesionValida)
                {
                    Console.WriteLine($"PIN incorrecto, quedan {intentosRestantes} intentos.");
                    Console.WriteLine("Ingrese su PIN (4 dígitos)");
                    Nip = int.Parse(Console.ReadLine());

                    // Verificar si el PIN es correcto
                    if (tarjeta.Pin == Nip)
                    {
                        SesionValida = true;
                    }
                    else
                    {
                        intentosRestantes--;
                        if (intentosRestantes == 0)
                        {
                            Console.WriteLine("Límite de intentos alcanzado");
                            break;
                        }
                    }
                }

            } while (!SesionValida);
            return tarjeta;
        }






        // Cliente 
        public IClienteable? HacerTransacción(DatosClientes? tarjeta)
        {
            IClienteable tipotransacción = null;
            int NumeroTransacciones = 1;


            //creo que esto hay que pasarlo abajo de verificar cliente

            askType();
            int tipo = 0;
            while (!int.TryParse(Console.ReadLine(), out tipo) || tipo < 1 || tipo > 6)
            {
                Console.WriteLine("Valor Incorrecto!");
                askType();

            }

            string? nombre = tarjeta.Name;
            long? numeroc = tarjeta.NumeroCuenta;
            int TotalMonto = 0;



            int LimiteRetiro = 9000;
            int EfectivoTotal = 200000;


            if (NumeroTransacciones >= 1 && NumeroTransacciones <= 5)
            {


                switch (tipo)
                {
                    case 1:
                        //depositar a tu misma cuenta u otra, deposito de tu saldo
                        Console.WriteLine("Seleccione una opción:");
                        Console.WriteLine("1. Depositar a mi cuenta");
                        Console.WriteLine("2. Depositar a otra cuenta");
                        double MontoEntrada = 0;
                        int opcionDeposito = 0;
                        while (!int.TryParse(Console.ReadLine(), out opcionDeposito) || (opcionDeposito != 1 && opcionDeposito != 2))
                        {
                            Console.WriteLine("Opción inválida. Introduzca 1 para Depositar a mi cuenta o 2 para Depositar a otra cuenta:");
                        }

                        switch (opcionDeposito)
                        {
                            case 1:
                                // Lógica para depositar en la propia cuenta
                                Console.WriteLine("Ingrese la cantidad de depósito en efectivo");
                                while (!double.TryParse(Console.ReadLine(), out MontoEntrada) || MontoEntrada <= 0)
                                {
                                    Console.WriteLine("Cantidad inválida. Ingrese una cantidad válida:");
                                }

                                foreach (var item in Tarjetas.Where(x => x.CodigoTarjeta == CodTarjeta))
                                {
                                    item.SaldoDisponible += MontoEntrada;  // Actualizar el saldo en la propia cuenta
                                }

                                DateTime FechaTransaccionPropiaCuenta = DateTime.Now;

                                tipotransacción = new Deposito(MontoEntrada);
                                NumeroTransacciones++;

                                // Generar recibo
                                Console.WriteLine($" ****************************************\n      RECIBO STARBANK    \n ****************************************  \n Fecha {FechaTransaccionPropiaCuenta}   \n  Cliente:{tarjeta.Name}  \n Numero de cuenta:{tarjeta.NumeroCuenta} \n  Monto: {MontoEntrada}   ");

                                Transacciones.Add(new RegistroTransaccion { FechaTransaccion = FechaTransaccionPropiaCuenta, MontoEntrada = MontoEntrada });

                                break;

                            case 2:
                                // Lógica para depositar en otra cuenta
                                Console.WriteLine("Ingrese el número de la tarjeta a la que desea depositar");
                                long numeroTarjetaDestino;
                                while (!long.TryParse(Console.ReadLine(), out numeroTarjetaDestino))
                                {
                                    Console.WriteLine("Número de tarjeta inválido. Ingrese un número de tarjeta válido:");
                                }

                                // Buscar la tarjeta destino
                                DatosClientes tarjetaDestino = Tarjetas.FirstOrDefault(x => x.CodigoTarjeta == numeroTarjetaDestino);

                                if (tarjetaDestino != null)
                                {
                                    Console.WriteLine("Ingrese la cantidad de depósito");
                                    while (!double.TryParse(Console.ReadLine(), out MontoEntrada) || MontoEntrada <= 0)
                                    {
                                        Console.WriteLine("Cantidad inválida. Ingrese una cantidad válida:");
                                    }

                                    foreach (var item in Tarjetas.Where(x => x.CodigoTarjeta == numeroTarjetaDestino))
                                    {
                                        item.SaldoDisponible += MontoEntrada;  // Actualizar el saldo en la cuenta destino
                                    }

                                    DateTime FechaTransaccionOtraCuenta = DateTime.Now;

                                    tipotransacción = new Deposito(MontoEntrada);
                                    NumeroTransacciones++;

                                    // Generar recibo
                                    Console.WriteLine($" ****************************************\n      RECIBO STARBANK    \n ****************************************  \n Fecha {FechaTransaccionOtraCuenta}   \n  Cliente:{tarjetaDestino.Name}  \n Numero de cuenta:{tarjetaDestino.NumeroCuenta} \n  Monto: {MontoEntrada}   ");

                                    Transacciones.Add(new RegistroTransaccion { FechaTransaccion = FechaTransaccionOtraCuenta, MontoEntrada = MontoEntrada });
                                }
                                else
                                {
                                    Console.WriteLine("La tarjeta destino no fue encontrada. No se realizó el depósito.");
                                }

                                break;
                        }

        

                      
                        NumeroTransacciones++;

        

                        break;
                    case 2:
                        bool EsMultiplo50 = false;
                        int MontoSalida = 0;
                        int MontoSalidaModular = 0;
                        do
                        {
                            Console.WriteLine("Elija la cantidad a retirar: ");
                            MontoSalida = int.Parse(Console.ReadLine());
                            TotalMonto += MontoSalida;
                            while (TotalMonto > LimiteRetiro)
                            {
                                Console.WriteLine("La cantidad excede el límite de retiro permitido.");
                                Console.WriteLine("Por favor, elija una cantidad menor.");
                                MontoSalida = int.Parse(Console.ReadLine());
                                TotalMonto += MontoSalida;
                            }

                            if (MontoSalida % 50 == 0)
                            {
                                EsMultiplo50 = true;
                            }
                            else
                            {
                                Console.WriteLine("Por favor, elija una cantidad múltiplo de 50.");
                            }

                        } while (!EsMultiplo50);

                        DateTime FechaSalida = DateTime.Now;

                        tipotransacción = new Retiro(Tarjetas, MontoSalida);
                        Retiro Retiro1 = new Retiro(Tarjetas, MontoSalida);

                        Transacciones.Add(new RegistroTransaccion { FechaSalida = FechaSalida, Montosalida = MontoSalida });

                        Console.WriteLine("Procesando retiro...");
                        Console.WriteLine("Retiro exitoso.");

                        MontoSalidaModular = MontoSalida;

                        Console.WriteLine($" ****************************************\n      RECIBO STARTBANK    \n ****************************************  \n Fecha {FechaSalida}  \n  Cliente:{tarjeta.Name}  \n Numero de cuenta:{tarjeta.NumeroCuenta} \n  Monto: {MontoSalida} ");


                        if (MontoSalidaModular >= 1000)
                        {
                            Console.WriteLine($"Entregando {MontoSalidaModular / 1000} billetes de $1000");
                            MontoSalidaModular %= 1000;
                        }

                        if (MontoSalidaModular >= 500 && MontoSalidaModular < 1000)
                        {
                            Console.WriteLine($"Entregando {MontoSalidaModular / 500} billetes de $500");
                            MontoSalidaModular %= 500;
                        }

                        if (MontoSalidaModular >= 200 && MontoSalidaModular < 500)
                        {
                            Console.WriteLine($"Entregando {MontoSalidaModular / 200} billetes de $200");
                            MontoSalidaModular %= 200;
                        }

                        if (MontoSalidaModular >= 100 && MontoSalidaModular < 200)
                        {
                            Console.WriteLine($"Entregando {MontoSalidaModular / 100} billetes de $100");
                            MontoSalidaModular %= 100;
                        }

                        if (MontoSalidaModular >= 50 && MontoSalidaModular < 100)
                        {
                            Console.WriteLine($"Entregando {MontoSalidaModular / 50} billetes de $50");
                            MontoSalidaModular %= 50;
                        }

                        EfectivoTotal -= MontoSalida;


                        NumeroTransacciones++;

                        foreach (var item in Tarjetas.Where(x => x.CodigoTarjeta == CodTarjeta))
                        {
                            item.SaldoDisponible -= MontoSalida;
                        }

                        break;



                    case 3:
                        Console.WriteLine("Ingrese el nuevo valor");
                        int valor;

                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out valor))
                            {

                                string valorStr = valor.ToString("D");
                                if (valorStr.Length == 4)
                                {
                                    // Verificar si el valor no es repetido más de dos veces
                                    bool esRepetidoMasDeDosVeces = false;
                                    for (int i = 0; i < valorStr.Length - 1; i++)
                                    {
                                        int conteoRepetidos = 1;


                                        for (int j = i + 1; j < valorStr.Length; j++)
                                        {
                                            if (valorStr[i] == valorStr[j])
                                            {
                                                conteoRepetidos++;

                                                if (conteoRepetidos > 2)
                                                {
                                                    esRepetidoMasDeDosVeces = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }

                                    // Verificar si el valor no tiene dígitos consecutivos
                                    bool tieneConsecutivos = false;
                                    for (int i = 0; i < valorStr.Length - 1; i++)
                                    {
                                        if (valorStr[i] == valorStr[i + 1] - 1)
                                        {
                                            tieneConsecutivos = true;
                                            break;
                                        }
                                    }
                                    if (!esRepetidoMasDeDosVeces && !tieneConsecutivos)
                                    {

                                        Console.WriteLine("Nip agregado con éxito");
                                        foreach (var item in Tarjetas.Where(x => x.CodigoTarjeta == CodTarjeta))
                                        {
                                            item.Pin = valor;

                                        }
                                        break;
                                    }
                                }
                            }

                            Console.WriteLine("Valor inválido. Asegúrese de que tenga exactamente 4 dígitos, no sea repetido más de dos veces y no tenga dígitos consecutivos.");
                        }
                        tipotransacción = new CambioDeNip(valor);

                        Console.WriteLine($" ****************************************\n      RECIBO STARBANK    \n ****************************************  \n Fecha   \n  Cliente:{tarjeta.Name}  \n Numero de cuenta:{tarjeta.NumeroCuenta} \n  Nuevo NIP: {valor} ");

                        break;


                    case 4:
                        Console.WriteLine("Seleccione la dirección de orden para la lista de transacciones:");
                        Console.WriteLine("1. Ascendente");
                        Console.WriteLine("2. Descendente");

                        int opcionOrden = 0;
                        while (!int.TryParse(Console.ReadLine(), out opcionOrden) || (opcionOrden != 1 && opcionOrden != 2))
                        {
                            Console.WriteLine("Opción inválida. Introduzca 1 para orden ascendente o 2 para orden descendente:");
                        }

                        // Ordenar las transacciones según la opción del usuario
                        if (opcionOrden == 1)
                        {
                            // Ordenar de manera ascendente
                            Transacciones.Sort((t1, t2) => (t1.MontoEntrada + t1.Montosalida).CompareTo(t2.MontoEntrada + t2.Montosalida));
                        }
                        else
                        {
                            // Ordenar de manera descendente
                            Transacciones.Sort((t1, t2) => (t2.MontoEntrada + t2.Montosalida).CompareTo(t1.MontoEntrada + t1.Montosalida));
                        }

                        Console.WriteLine("Lista de transacciones ordenadas por monto total:");

                        foreach (var transaccion in Transacciones)
                        {
                            string tipoTransaccion = (transaccion.MontoEntrada > 0) ? "Depósito" : "Retiro";
                            Console.WriteLine($"Fecha: {transaccion.FechaTransaccion}, Tipo: {tipoTransaccion}, Monto total: {transaccion.MontoEntrada + transaccion.Montosalida}");
                        }

                        break;


                    case 5:
                        DateTime FechaConsulta = DateTime.Now;

                        Console.WriteLine($" ****************************************\n      RECIBO STARBANK    \n ****************************************  \n Fecha {FechaConsulta}   \n  TItular:{tarjeta.Name}  \n Numero de cuenta:{tarjeta.NumeroCuenta} \n  saldo total : {tarjeta.SaldoDisponible}   ");



                        break;

                    case 6:
                        
                        break;

                    default:
                        Console.WriteLine("Opción no reconocida");
                        break;

                }




            }

            else
            {

                Console.WriteLine(" Limite de transacciones alcanzado");


            }

            return tipotransacción;

        }







        //no cliente 

        public INoClientable? TransaccionAnonima(DatosNoCliente? DatosNC)
        {
            INoClientable? noClientable = null;
            int? NumeroTransacciones = 1;


            askType2();
            int tipo = 0;
            while (!int.TryParse(Console.ReadLine(), out tipo) || tipo < 1 || tipo > 2)
            {
                Console.WriteLine("Valor Incorrecto!");
                askType2();
            }

            if (NumeroTransacciones >= 1 && NumeroTransacciones <= 5)
            {



                switch (tipo)
                {
                    case 1:

                        Console.WriteLine("Seleccione una opción:");
                        Console.WriteLine("1. Depositar en una cuenta interna del banco");
                        Console.WriteLine("2. Depositar en otra cuenta externa");

                        int opcionDeposito = 0;
                        while (!int.TryParse(Console.ReadLine(), out opcionDeposito) || (opcionDeposito != 1 && opcionDeposito != 2))
                        {
                            Console.WriteLine("Opción inválida. Introduzca 1 para depositar en una cuenta interna o 2 para depositar en otra cuenta:");
                        }

                        switch (opcionDeposito)
                        {
                            case 1:
                                // Depositar en una cuenta interna del banco
                                Console.WriteLine("Ingrese el número de la tarjeta a la que desea depositar (cuenta interna)");
                                long numeroTarjetaDestinoInterna;
                                while (!long.TryParse(Console.ReadLine(), out numeroTarjetaDestinoInterna))
                                {
                                    Console.WriteLine("Número de tarjeta inválido. Ingrese un número de tarjeta válido:");
                                }

                                DatosClientes tarjetaDestinoInterna = Tarjetas.FirstOrDefault(x => x.CodigoTarjeta == numeroTarjetaDestinoInterna);

                                if (tarjetaDestinoInterna != null)
                                {
                                    Console.WriteLine("Ingrese la cantidad de depósito");
                                    double MontoEntradaInterna = 0;
                                    while (!double.TryParse(Console.ReadLine(), out MontoEntradaInterna) || MontoEntradaInterna <= 0)
                                    {
                                        Console.WriteLine("Cantidad inválida de depósito. Ingrese una cantidad válida:");
                                    }

                                    tarjetaDestinoInterna.SaldoDisponible += MontoEntradaInterna;  // Actualizar el saldo en la cuenta interna

                                    DateTime fechaTransaccionInterna = DateTime.Now;

                                    noClientable = new Deposito(MontoEntradaInterna);
                                    NumeroTransacciones++;

                                    // Generar recibo
                                    Console.WriteLine($" ****************************************\n      RECIBO STARBANK    \n ****************************************  \n Fecha {fechaTransaccionInterna}   \n  Cliente:{tarjetaDestinoInterna.Name}  \n Numero de cuenta:{tarjetaDestinoInterna.NumeroCuenta} \n  Monto: {MontoEntradaInterna}   ");

                                    Transacciones.Add(new RegistroTransaccion { FechaTransaccion = fechaTransaccionInterna, MontoEntrada = MontoEntradaInterna });
                                }
                                else
                                {
                                    Console.WriteLine("La tarjeta interna destino no fue encontrada. No se realizó el depósito.");
                                }
                                break;

                            case 2:
                                // Depositar en otra cuenta externa
                                Console.WriteLine("Ingrese el número de la tarjeta a la que desea depositar (cuenta externa)");
                                long numeroTarjetaDestinoExterna;
                                while (!long.TryParse(Console.ReadLine(), out numeroTarjetaDestinoExterna))
                                {
                                    Console.WriteLine("Número de tarjeta inválido. Ingrese un número de tarjeta válido:");
                                }

                                Console.WriteLine("Ingrese el nombre del destinatario:");
                                string nombreDestinatario = Console.ReadLine();

                                Console.WriteLine("Ingrese la cantidad de depósito");
                                double MontoEntradaExterna = 0;
                                while (!double.TryParse(Console.ReadLine(), out MontoEntradaExterna) || MontoEntradaExterna <= 0)
                                {
                                    Console.WriteLine("Cantidad inválida de depósito. Ingrese una cantidad válida:");
                                }

                                DateTime fechaTransaccionExterna = DateTime.Now;

                                noClientable = new Deposito(MontoEntradaExterna);
                                NumeroTransacciones++;

                                // Generar recibo
                                Console.WriteLine($" ****************************************\n      RECIBO STARBANK    \n ****************************************  \n Fecha {fechaTransaccionExterna}   \n  Destinatario:{nombreDestinatario}  \n Numero de cuenta:{numeroTarjetaDestinoExterna} \n  Monto: {MontoEntradaExterna}   ");

                                Transacciones.Add(new RegistroTransaccion { FechaTransaccion = fechaTransaccionExterna, MontoEntrada = MontoEntradaExterna });

                                break;

                            default:
                                Console.WriteLine("Opción no reconocida");
                                break;
                        }

                    case 2:

                     

                        break;

                }
            }

            return noClientable;
        }


        private void askType()
        {
            Console.WriteLine("Ingresa el tipo de transaccion");
            foreach (var tipo in tiposTransaccion)
            {
                Console.WriteLine($"{tipo.Id}.- {tipo.Tipo}");
            }
        }

        private void askType2()
        {
            Console.WriteLine("Ingresa el tipo de transaccion");
            Console.WriteLine("1.Deposito \n 2.Salir ");
            
        }



        internal DatosNoCliente? VerificarDB()
        {
            DatosNoCliente? datosNC = new DatosNoCliente();
            bool validaSesion = false;

            do
            {
                Console.WriteLine("Ingrese los 16 dígitos de la tarjeta:");
                string codeT = Console.ReadLine();

                if (codeT.Length != 16 || !long.TryParse(codeT, out long codTarjeta))
                {
                    Console.WriteLine("Código inválido. Deben ser exactamente 16 dígitos numéricos.");
                    continue;
                }

                datosNC.NCCodTarj = codeT;  // Asignar el valor a la propiedad NCCodTarj

                Console.WriteLine("Ingrese el NIP (4 digitos, no consecutivos y no repetidos mas de dos veces)");
                int valor;

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out valor))
                    {
                        string valorStr = valor.ToString();
                        if (valorStr.Length == 4)
                        {
                            // Verificar condiciones para el NIP
                            bool esRepetidoMasDeDosVeces = false;
                            for (int i = 0; i < valorStr.Length - 1; i++)
                            {
                                int conteoRepetidos = 1;

                                for (int j = i + 1; j < valorStr.Length; j++)
                                {
                                    if (valorStr[i] == valorStr[j])
                                    {
                                        conteoRepetidos++;

                                        if (conteoRepetidos > 2)
                                        {
                                            esRepetidoMasDeDosVeces = true;
                                            break;
                                        }
                                    }
                                }
                            }

                            bool tieneConsecutivos = false;
                            for (int i = 0; i < valorStr.Length - 1; i++)
                            {
                                if (valorStr[i] == valorStr[i + 1] - 1)
                                {
                                    tieneConsecutivos = true;
                                    break;
                                }
                            }

                            if (!esRepetidoMasDeDosVeces && !tieneConsecutivos)
                            {
                                datosNC.NCPin = valor;  // Asignar el valor a la propiedad NCPin

                                // Establecer que la sesión es válida para salir del bucle
                                validaSesion = true;
                                break;
                            }
                        }
                    }

                    Console.WriteLine("Valor inválido. Asegúrese de que tenga exactamente 4 dígitos, no sea repetido más de dos veces y no tenga dígitos consecutivos.");
                }

            } while (!validaSesion);

            return datosNC;
        }


    }
}



