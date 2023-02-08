using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancaria
{
    class Cajero
    {
        const string opcDep = "1";
        const string opcExt = "2";
        const string opcCon = "3";
        const string opcSal = "4";
        
        public void MenuPrincipal(CuentaBase unaCaja)
        {
            string opcion = "";
            string strCont;
            ServValidac MiVal = new ServValidac();

            do
            {
                Console.WriteLine("Está operando sobre el cliente " + unaCaja.NombreTitular
                    + "\nCaja de ahorro Nro: " + unaCaja.NumeroCuenta);

                opcion = MiVal.PedirStrNoVac("Qué operación desea realizar?\n"
                    + opcDep + "- Depositar dinero\n"
                    + opcExt + "- Extraer fondos\n"
                    + opcCon + "- Consulta de saldo\n"
                    + opcSal + "- Salir");
                switch (opcion)
                {
                    case opcDep:
                        PedirDeposito(unaCaja);
                        break;
                    case opcExt:
                        PedirExtraccion(unaCaja);
                        break;
                    case opcCon:
                        Console.WriteLine("Saldo: $" + unaCaja.Saldo);
                        break;
                    case opcSal:
                        break;
                    default:
                        Console.WriteLine("La opción ingresada no es válida");
                        break;
                }
                // Bucle y validación, "Desea continuar?"
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("¿Desea continuar? S/N");
                    strCont = Console.ReadLine().ToUpper();

                    if (strCont != "S" && strCont != "N")
                    {
                        Console.WriteLine("Debe ingresar S o N");
                    }
                    else
                    {
                        opcion = "4";
                    }
                } while (strCont != "S" && strCont != "N");

            } while (opcion != opcSal);
            Console.WriteLine("Gracias por operar con nosotros.");
        }

        public void PedirDeposito(CuentaBase unaCaja)
        {
            double montoD = 0;
            ServValidac miVal = new ServValidac();
            string retorno = "";

            montoD = miVal.PedirDouble("Ingrese monto a depositar:", CuentaBase.TransMin,CuentaBase.TransMax);
            retorno = unaCaja.Depositar(montoD);
            if (retorno == "")
            {
                Console.WriteLine("\nSe acreditan en la cuenta $" + montoD + "\nNuevo saldo: $" + unaCaja.Saldo);
            }  else
            {
                Console.WriteLine("\nOperación Rechazada"
                    + "\n" + retorno
                    + "\nSaldo Actual: $" + unaCaja.Saldo);
            }
        }

        public void PedirExtraccion(CuentaBase unaCaja)
        {
            double montoE = 0;
            ServValidac miVal = new ServValidac();
            string retorno = "";

            montoE = miVal.PedirDouble("Ingrese monto a retirar:", CuentaBase.TransMin, CuentaBase.TransMax);
            retorno = unaCaja.Extraer(montoE);
            if (retorno == "")
            {
                Console.WriteLine("\nSe entregan $" + montoE + "\nNuevo saldo: $" + unaCaja.Saldo);
            } else
            {
                Console.WriteLine("\nOperación Rechazada" 
                    +"\n" + retorno
                    +"\nSaldo Actual: $" + unaCaja.Saldo); 
            }
        }
    }
}
