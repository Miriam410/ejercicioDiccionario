using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            EjecutarEjemplo();
            Console.ReadKey();
        }

        static void EjecutarEjemplo()
        {
            var personas = new Dictionary<int, string>(); //Personas por dni.

            bool salir = false;
            do
            {
                bool ok = false;
                int numeroDocumento;
                do
                {
                    Console.WriteLine("Ingrese un numero de documento");
                    string ingreso = Console.ReadLine();
                    if (!int.TryParse(ingreso, out numeroDocumento))
                    {
                        Console.WriteLine("No es un número de documento válido.");
                        continue;
                    }

                    if (numeroDocumento < 10_000_000 || numeroDocumento > 99_999_999)
                    {
                        Console.WriteLine("Debe tener 8 cifras.");
                        continue;
                    }

                    /* mas validaciones => más ifs.... */

                    ok = true;
                }
                while (!ok);

                string nombre;
                do
                {
                    Console.WriteLine("Ingrese el nombre");
                    nombre = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        Console.WriteLine("Tiene que indicar un nombre.");
                        continue;
                    }

                    if (nombre.Length > 50)
                    {
                        Console.WriteLine("Debe ser menor a 50 caracteres.");
                        continue;
                    }

                    if (nombre.Any(c => Char.IsNumber(c)))
                    {
                        Console.WriteLine("No puede tener dígitos.");
                        continue;
                    }

                    /* mas validaciones => más ifs.... */

                    ok = true;
                }
                while (!ok);

                if (personas.ContainsKey(numeroDocumento))
                {
                    //la persona ya existe => la modifico.
                    var nombreanterior = personas[numeroDocumento];
                    personas[numeroDocumento] = nombre;
                    Console.WriteLine($"Se ha cambiado el nombre de {nombreanterior} a {nombre}");
                }
                else
                {
                    personas.Add(numeroDocumento, nombre);
                    Console.WriteLine("Se ha agregado la persona al diccionario.");
                }

                Console.WriteLine("Presione Q para salir o cualquier tecla para continuar.");
                var tecla = Console.ReadKey(intercept: true);
                if (tecla.Key == ConsoleKey.Q)
                {
                    salir = true;
                }

            } while (!salir);


            Console.WriteLine($"El diccionario tiene {personas.Count} personas.");

            foreach(var persona in personas)
            {
                Console.WriteLine($"{persona.Key} - {persona.Value}");
            }

            /*            
            personas.Add(12444788, "Lorena Lopez");
            */
            //....
        }
    }
}
