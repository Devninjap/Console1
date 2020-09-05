using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console1
{
    class Principal
    {
        static void Main(string[] args)
        {
            int opcion = 15;
            List<CCuenta> clientes = new List<CCuenta>();
            string num, pass;
            float sal;
            int val = 0;

            CCuenta cuenta1 = new CCuenta("11111111", "123456", 10000);
            clientes.Add(cuenta1);
            CCuenta cuenta2 = new CCuenta("22222222", "654321", 4000);
            clientes.Add(cuenta2);
            CCuenta cuenta3 = new CCuenta("33333333", "123123", 5000);
            clientes.Add(cuenta3);
            CCuenta cuenta4 = new CCuenta("44444444", "121212", 8000);
            clientes.Add(cuenta4);

            Console.WriteLine("********************************");
            Console.WriteLine("Bienvenido, que desea realizar: ");
            Console.WriteLine("********************************");
            do
            {
                Console.WriteLine("1. CREAR UNA NUEVA CUENTA");
                Console.WriteLine("2. DEPOSITAR DINERO EN SU CUENTA");
                Console.WriteLine("3. RETIRAR DINERO DE SU CUENTA");
                Console.WriteLine("4. VER SALDO TOTAL DE SU CUENTA");
                Console.WriteLine("5. LISTAR CUENTAS");
                Console.WriteLine("0: SALIR");
                Console.WriteLine("********************************");
                Console.WriteLine("Ingrese una de las opciones: ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("**DATOS NUEVA CUENTA**");
                        Console.WriteLine("Ingrese el numero de su cuenta: ");
                        num = Console.ReadLine();
                        // validar si ya esta almacenado
                        val = validar(num, clientes);
                        
                        // LAMBDA EXPRESSIONS
                        /*
                        clientes.Contains(new CCuenta(num, "", 0));  // bool
                        clientes.Find(x => x.Numero.Contains(num));  // devuelve coincidencia
                        clientes.Exists(x => x.Clave == "123456");   // bool  // Esto podria reemplazar a metodo validar
                        */
                        if (clientes.Exists(x => x.Numero == num)) { Console.WriteLine("==========ERROR: el numero YA Existe"); }
                        else { Console.WriteLine("==========NUEVO registro!!"); }

                        if (val==-1)
                        {
                            Console.WriteLine("Ingrese la clave de la cuenta: ");
                            pass = Console.ReadLine();
                            Console.WriteLine("ingrese el saldo inicial de la cuenta: ");
                            sal = float.Parse(Console.ReadLine());
                            CCuenta cuenta = new CCuenta(num,pass,sal);
                            /*cuenta.Numero = num;
                            cuenta.Clave = pass;
                            cuenta.Saldo = sal;*/
                            clientes.Add(cuenta);
                        }
                        else
                        {
                            Console.WriteLine("ERROR: El numero de cuenta ya existe");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("**DEPOSITAR DINERO**");
                        Console.WriteLine("Ingrese el numero de su cuenta: ");
                        num = Console.ReadLine();                        
                        if (clientes.Exists(x => x.Numero == num))
                        {                            
                            Console.WriteLine("Ingrese la clave de su cuenta: ");
                            pass = Console.ReadLine();
                            int c = clientes.FindIndex(x => x.Numero.Contains(num));                            
                            //Console.WriteLine("El valor de C es =============== " + c);
                            if (clientes[c].Clave==pass)
                            {
                                Console.WriteLine("CLAVE CORRECTA");
                                Console.WriteLine("Ingrese el monto que desea depositar");
                                sal = float.Parse(Console.ReadLine());
                                clientes[c].deposito(sal);
                                Console.WriteLine("Operacion Completada");
                                Console.WriteLine("Saldo Actual: " + clientes[c].Saldo);
                                Console.WriteLine("Presione una tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("ERROR: la clave que ingreso es incorrecta");
                            }
                        }
                        else
                        {
                            Console.WriteLine("El numero de cuenta ingresado no existe");                            
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("**RETIRAR DINERO**");
                        Console.WriteLine("Ingrese el numero de su cuenta: ");
                        num = Console.ReadLine();
                        if (clientes.Exists(x => x.Numero == num))
                        {
                            Console.WriteLine("Ingrese la clave de su cuenta: ");
                            pass = Console.ReadLine();
                            int c = clientes.FindIndex(x => x.Numero.Contains(num));
                            //Console.WriteLine("El valor de C es =============== " + c);
                            if (clientes[c].Clave == pass)
                            {
                                Console.WriteLine("CLAVE CORRECTA");
                                Console.WriteLine("Ingrese el monto que desea retirar");
                                sal = float.Parse(Console.ReadLine());
                                clientes[c].retiro(sal);
                                Console.WriteLine("Operacion Completada");
                                Console.WriteLine("Saldo Actual: " + clientes[c].Saldo);
                                Console.WriteLine("Presione una tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("ERROR: la clave que ingreso es incorrecta");
                            }
                        }
                        else
                        {
                            Console.WriteLine("El numero de cuenta ingresado no existe");
                        }
                        break;
                    case 4:
                        Console.WriteLine("**SALDO DE SU CUENTA**");
                        Console.WriteLine("Ingrese el numero de su cuenta: ");
                        num = Console.ReadLine();
                        // buscar coincidencia y rescatar la clave del List<>
                        /*if (true)
                        {                            
                            Console.WriteLine("Ingrese la clave de la cuenta: ");
                            pass = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("ERROR: La cuenta no existe");
                        }*/
                        for(int i = 0;i<clientes.Count; i++)
                        {
                            Console.WriteLine("CUENTA: ");
                            Console.WriteLine("CLAVE:  ");
                            Console.WriteLine("SALDO:  ");
                            Console.WriteLine("***************");
                        }
                        break;
                    case 5:
                        Console.WriteLine("NUMERO CTA || CLAVE || SALDO");
                        foreach (CCuenta cuenta in clientes)
                        {
                            Console.WriteLine(cuenta.Numero + " || " + cuenta.Clave+" || "+cuenta.Saldo);
                        }
                        break;
                }
                //Console.Clear(); // Limpiar la consola
            } while (opcion != 0);
        }
        public static int validar(string n,List<CCuenta> cliente)
        {
            int ind = -1;
            for(int i = 0; i < cliente.Count; i++)
            {
                if (cliente[i].Numero == n)
                {
                    ind = i;
                    break;
                }
            }
           
            return ind;
        }
    }
}
