using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console1
{
    class CCuenta
    {
        private string numero;
        private string clave;
        private float saldo;

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        public float Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public CCuenta()
        {
           
        }
        public CCuenta(string cuenta, string clave, float saldo)
        {
            numero = cuenta;
            Clave = clave;
            Saldo = saldo;
        }
        /*
        public void numeroCuenta(string valor)
        {
            if (valor.Length != 8 || valor.Length < 8)
            {
                Console.WriteLine("ERROR: debe de ingresar 8 digitos");
                return;
            }
            Numero = valor;
        }*/
        public void deposito(float cantidad)
        {
            if(cantidad < 0)
            {
                Console.WriteLine("ERROR: cantidad ingresada es negativa");
                return;
            }
            saldo = saldo + cantidad;
        }
        public void retiro(float cantidad)
        {
            if (saldo - cantidad < 0)
            {
                Console.WriteLine("ERROR: no dispone de saldo suficiente");
                Console.WriteLine("No sea IMBECIL como va ha pretender retirar mas dinero del que tiene guardado");
                return;
            }
            saldo = saldo - cantidad;
        }
        // Aqui se deberia de implementar el foreach  OJO
        /*
        public void consultar()
        {
            Console.WriteLine("Usted tiene: " + saldo + "SOLES en su cuenta");
        }
        */
    }
}
