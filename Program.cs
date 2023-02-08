using System;

namespace CuentaBancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Cajero MiCajero = new Cajero();
            CajaAhorro CtaCA1 = new CajaAhorro("123767/6", "Roberto Gomez");
            CuentaCorriente CtaCC1 = new CuentaCorriente("235767/6", "Roberto Gomez");
            // variable Tipo de cuenta
            string strTC;



            // Bucle y validación, elección de tipo de cuenta
            do
            {
                Console.WriteLine();
                Console.WriteLine("¿Qué tipo de cuenta desea ver?");
                Console.WriteLine("1 - Caja de ahorro");
                Console.WriteLine("2 - Cuenta Corriente");
                strTC = Console.ReadLine();
                if (strTC != "1" && strTC != "2")
                {
                    Console.WriteLine("La opción ingresada no es válida");
                }
            } while (strTC != "1" && strTC != "2");


            if (strTC == "1")
            {

                MiCajero.MenuPrincipal(CtaCA1);
            }
            else if (strTC == "2")
            {

                MiCajero.MenuPrincipal(CtaCC1);

            }


            
            Console.WriteLine("Presione cualquier tecla para terminar...");
            Console.ReadKey();
        }
    }
}
