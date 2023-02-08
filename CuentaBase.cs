using System;
using System.Collections.Generic;
using System.Text;

namespace CuentaBancaria
{
    public class CuentaBase
    {
        //Constantes de Clase, se pueden acceder desde el exterior directo contra la clase
        //sin necesidad de declarar un objeto de la misma.
        //public const double SaldoMin = 0;
        public const double SaldoMax = 9999999;
        public const double TransMin = 1;
        public const double TransMax = 10000;

        private double saldoMin;
        private string tipo;
        private string nombreTit;

        /* Propiedad de sólo lectura (sólo se escriben en el constructor): 
         * Se usa Propiedad sin variable de instancia, solo get sin contenido.*/
        public string NumeroCuenta
        {
            get;
        }

        public string NombreTitular
        {
            /* Tener en cuenta que cuando no haya lógica particular ni en el set ni en el get
            *  el entorno sugiere:
            *  1- NO usar variable de instancia
            *  2- Declarar la propiedad pública como Auto Implemented Property
            *  Ej.: public string NombreTitular { get; set; }
            */
            set
            {
                if (string.IsNullOrEmpty(value)) //si es nula, el ToUpper() genera error.
                {
                    nombreTit = "";
                }
                else
                {
                    nombreTit = value.ToUpper();
                }
            }
            get
            {
                return nombreTit;
            }
        }


        /*Propiedades que no se escriben a través del set, sino solo a través de otros métodos de la clase:
         * 1-Con variable de instancia
         * 2-Propiedad que tiene sólo el get
         * 3-Las modificaciones directas que se hacen en los métodos de la clase van contra la variable de instancia.
         * Además, si no hay lógica particular en el get, el entorno sugiere:
         * 1-No usar variable de instancia
         * 2-Declarar la propiedad pública como Auto Implemented Property, estableciendo el set como privado.
         *   como se muestra aquí.
         */
        public double Saldo
        {
            get;
            private set;
        }

        // Constructor cuenta
        public CuentaBase(string numeroCuenta, string nombreTitular, double SaldoMin, string TipoCuenta)
        {
            NumeroCuenta = numeroCuenta;
            NombreTitular = nombreTitular;
            Saldo = 0;
            saldoMin = SaldoMin;
            tipo = TipoCuenta;
        }

        // Método para extraer dinero de cuenta
        public string Extraer(double monto)
        {
            if (Saldo - monto >= saldoMin)
            {
                Saldo = Saldo - monto;
                return "";
            }
            else
            {
                return ("El monto a retirar supera el saldo disponible. \n Límite para operar en descubierto $" + saldoMin); 
            }
        }

        // Método para depositar dinero en cuenta
        public string Depositar(double monto)
        {
            if (Saldo + monto <= SaldoMax)
            {
                Saldo = Saldo + monto;
                return "";
            }
            else
            {
                return "El depósito excedería el saldo máximo permitido.";
            }
        }
    }
    // Clase Cuenta corriente (acepta saldo negativo hasta $ 100.000)
    public class CuentaCorriente : CuentaBase
    {
        private static int saldoMin;
        private static string tipoCuenta;
        static CuentaCorriente()
        {
            saldoMin = -100000;
            tipoCuenta = "cuenta corriente";
        }
        // Constructor Cuenta Corriente
        public CuentaCorriente(string numeroCuenta, string nombreTitular) : base(numeroCuenta, nombreTitular, saldoMin, tipoCuenta)
        {

        }

    }
    // Clase Cuenta corriente (NO acepta saldo negativo)
    public class CajaAhorro : CuentaBase
    {
        private static int saldoMin;
        private static string tipoCuenta;
        static CajaAhorro()
        {
            saldoMin = 0;
            tipoCuenta = "caja de ahorro";

        }
        // Constructor Caja de Ahorro
        public CajaAhorro(string numeroCuenta, string nombreTitular) : base(numeroCuenta, nombreTitular, saldoMin, tipoCuenta)
        {

        }
    }
}
