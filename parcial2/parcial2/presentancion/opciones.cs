using Entidad;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presentancion
{
    public class opciones
    {
        private Ayuda controller = new Ayuda();
        public void ListarEstudiantes()
        {
            List<Estudiante> estudiantes = controller.ListarEstudiantes();
            Console.WriteLine("=== Listado de Estudiantes ===");
            foreach (var estudiante in estudiantes)
            {
                Console.WriteLine($"{estudiante.ID} - {estudiante.Nombre} - Recibió Ayuda: {(estudiante.RecibioAyuda ? "Sí" : "No")}");
            }
            Console.WriteLine("==============================");
        }

        public void ListarTiposAyuda()
        {
            List<TipoAyuda> tiposAyuda = controller.ListarTiposAyuda();
            Console.WriteLine("=== Tipos de Ayuda ===");
            foreach (var tipoAyuda in tiposAyuda)
            {
                Console.WriteLine($"{tipoAyuda.Codigo} - {tipoAyuda.Nombre} - Beneficiados: {tipoAyuda.CantidadBeneficiados}");
            }
            Console.WriteLine("=======================");
        }
        public void RegistrarEstudiante()
        {
            Console.Write("Ingrese el ID del estudiante: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nombre del estudiante: ");
            string nombre = Console.ReadLine();

            string resultado = controller.RegistrarEstudiante(id, nombre);
            Console.WriteLine(resultado);
        }
        public void RegistrarAyuda()
        {
            Console.Write("Ingrese el ID del estudiante: ");
            int idEstudiante = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el código del tipo de ayuda: ");
            string codigoAyuda = Console.ReadLine();

            string resultado = controller.RegistrarAyuda(idEstudiante, codigoAyuda);
            Console.WriteLine(resultado);
            Console.ReadLine();
        }
    }
}
