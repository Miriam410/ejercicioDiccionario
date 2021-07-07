using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        //ordenar alumnos por ranking.


        static void Main(string[] args)
        {
            var cursos = new List<Curso>(); //cursos x Codigo.
            var alumnos = new List<Alumno>(); //alumnos x Legajo.

            cursos.Add(new Curso { Codigo = "654-1", Capacidad = 1 }); //0
            cursos.Add(new Curso { Codigo = "123-1", Capacidad = 2 }); //1
            cursos.Add(new Curso { Codigo = "678-1", Capacidad = 2 }); //2


            alumnos.Add(new Alumno { Legajo = 671977, Ranking = 4.2M });
            alumnos.Add(new Alumno { Legajo = 456777, Ranking = 3.4M });
            alumnos.Add(new Alumno { Legajo = 317491, Ranking = 66.9M });
            alumnos.Add(new Alumno { Legajo = 346778, Ranking = 8.1M });
            alumnos.Add(new Alumno { Legajo = 123467, Ranking = 2.7M });
            alumnos.Add(new Alumno { Legajo = 419752, Ranking = 23.7M });

            //hay que ordenar x ranking.
            alumnos.Sort(comparison: ComparacionAlumno);

            Console.WriteLine("Alumnos ordenados");
            foreach (var alumno in alumnos)
            {
                Console.WriteLine($"Legajo = {alumno.Legajo}, Ranking = {alumno.Ranking}");
            }
            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadKey();

            int indiceCurso = 0;
            foreach (var alumno in alumnos)
            {
                if (cursos[indiceCurso].Capacidad > 0)
                {
                    cursos[indiceCurso].Alumnos.Add(alumno);
                    cursos[indiceCurso].Capacidad--;
                }

                indiceCurso++;
                if (indiceCurso > cursos.Count - 1)
                {
                    indiceCurso = 0;
                }
            }

            //y listo.
            foreach (var curso in cursos)
            {
                Console.WriteLine($"Curso {curso.Codigo}");
                foreach (var alumno in curso.Alumnos)
                {
                    Console.WriteLine($"Legajo = {alumno.Legajo}, Ranking = {alumno.Ranking}");
                }
                Console.WriteLine("--------------------------");
            }

            Console.ReadKey();
        }

        static int ComparacionAlumno(Alumno x, Alumno y)
        {
            return y.Ranking.CompareTo(x.Ranking);
        }
    }
}
