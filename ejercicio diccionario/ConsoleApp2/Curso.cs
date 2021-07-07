using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Curso
    {
        public Curso()
        {
            Alumnos = new List<Alumno>();
        }

        public string Codigo { get; set; }
        public int Capacidad { get; set; }

        public List<Alumno> Alumnos { get; } 
    }
}
