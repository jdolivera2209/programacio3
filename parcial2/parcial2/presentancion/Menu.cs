using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Logica;

namespace presentancion
{
    public class Menu
    {
        public opciones opt = new opciones();
        public void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("=== Gestión de Ayudas ===");
                Console.WriteLine("1. Listar Estudiantes");
                Console.WriteLine("2. Listar Tipos de Ayuda");
                Console.WriteLine("3. Registrar Estudiante");
                Console.WriteLine("4. Registrar Ayuda");
                Console.WriteLine("5. Salir");
                Console.Write("Selecciona una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                       opt.ListarEstudiantes();
                        break;
                    case 2:
                       opt.ListarTiposAyuda();
                        break;
                    case 3:
                       opt.RegistrarEstudiante();
                        break;
                    case 4:
                        opt.RegistrarAyuda();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 4);
        }
    }
}
