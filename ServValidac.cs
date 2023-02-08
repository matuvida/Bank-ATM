using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancaria
{
    class ServValidac
    {
        public string PedirStrNoVac(string mensaje)
        {
            string valor;
            do
            {
                Console.WriteLine(mensaje);
                valor = Console.ReadLine().ToUpper();
                if (valor == "")
                {
                    Console.WriteLine("No puede ser vacío");
                }
            } while (valor == "");

            return valor;
        }
        public string PedirSoN(string mensaje)
        {
            string valor = "";
            string mensError = "Debe ingresar S o N";
            do
            {
                valor = PedirStrNoVac(mensaje);
                if (valor != "S" && valor != "N")
                {
                    Console.WriteLine(mensError);
                }
            } while (valor != "S" && valor != "N");

            return valor;
        }

        public bool ValidaDouble(double valor, double min, double max)
        {
            bool valido = false;

            if (valor >= min && valor <= max)
            {
                valido = true;
            }
            return valido;
        }

        public double PedirDouble(string mensaje, double min, double max)
        {
            double valor;
            bool valido = false;
            string mensError = "Debe ingresar un valor entre " + min + " y " + max;

            do
            {
                Console.WriteLine(mensaje);
                if (!double.TryParse(Console.ReadLine(), out valor))
                {
                    Console.WriteLine(mensError);
                }
                else
                {
                    if (!ValidaDouble(valor, min, max))
                    {
                        Console.WriteLine(mensError);
                    }
                    else
                    {
                        valido = true;
                    }
                }
            } while (!valido);

            return valor;
        }
    }
}
