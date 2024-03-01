using ATM_StarBank.Clases;
using ATM_StarBank.Interfaces;
using ATM_StarBank.Services;
using static ATM_StarBank.Services.BankServices;

class Program
{
    static void Main()
    {
        BankServices bankServices = new BankServices();
        bool salir = false; // Variable para controlar si el usuario quiere salir del programa

        while (!salir)
        {
            Console.WriteLine("Bienvenido al cajero automático del sistema StarBank!");
            Console.WriteLine("1. Iniciar sesión \n2. Entrar sin cuenta \n3. Salir");
            int option;

            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 3)
            {
                Console.WriteLine("Opción inválida, selecciona una de las opciones del menú");
            }

            switch (option)
            {
                case 1:
                    var tarjeta = bankServices.VerificarCliente();

                    // Mientras el usuario quiera hacer transacciones
                    while (true)
                    {
                        Console.Clear();
                        IClienteable transaccion = bankServices.HacerTransacción(tarjeta);

                        // Salir del bucle si el usuario decide
                        Console.WriteLine("¿Desea realizar otra transacción? (Sí/No)");
                        string respuesta = Console.ReadLine();

                        if (respuesta?.Trim().ToLower() != "si")
                        {
                            break;
                        }
                    }

                    Console.WriteLine("Gracias por utilizar nuestro servicio bancario. ¡Hasta luego!");
                    break;

                case 2:
                    var DatosNc = bankServices.VerificarDB();

                    // Mientras el usuario quiera hacer transacciones
                    while (true)
                    {
                        Console.Clear();
                        INoClientable Noclient = bankServices.TransaccionAnonima(DatosNc);

                        // Salir del bucle si el usuario decide
                        Console.WriteLine("¿Desea realizar otra transacción? (Sí/No)");
                        string respuesta = Console.ReadLine();

                        if (respuesta?.Trim().ToLower() != "si")
                        {
                            break;
                        }
                    }
                    break;

                case 3:
                    salir = true; // Establecer la variable salir como verdadera para salir del bucle principal
                    break;

                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
        }
    }
}

