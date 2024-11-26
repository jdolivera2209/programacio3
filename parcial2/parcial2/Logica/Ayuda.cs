using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Logica
{
    public class Ayuda
    {
        private DataM dataManager = new DataM();

        public string RegistrarAyuda(int idEstudiante, string codigoAyuda)
        {
            List<Estudiante> estudiantes = dataManager.CargarEstudiantes("Estudiantes.txt");
            List<TipoAyuda> tiposAyuda = dataManager.CargarTiposAyuda("TipoAyuda.txt");

            var estudiante = estudiantes.Find(e => e.ID == idEstudiante);
            if (estudiante == null)
            {
                return "Estudiante no encontrado.";
            }

            if (estudiante.RecibioAyuda)
            {
                return "Este estudiante ya ha recibido ayuda.";
            }

            var tipoAyuda = tiposAyuda.Find(t => t.Codigo == codigoAyuda);
            if (tipoAyuda == null)
            {
                return "Tipo de ayuda no encontrado.";
            }

            estudiante.RecibioAyuda = true;
            estudiante.CodigoAyuda = codigoAyuda;
            tipoAyuda.CantidadBeneficiados++;

            dataManager.GuardarEstudiantes(estudiantes, "Estudiantes.txt");
            dataManager.GuardarTiposAyuda(tiposAyuda, "TipoAyuda.txt");

            return $"Ayuda '{tipoAyuda.Nombre}' registrada exitosamente para el estudiante {estudiante.Nombre}.";
        }
        public string RegistrarEstudiante(int id, string nombre)
        {
            List<Estudiante> estudiantes = dataManager.CargarEstudiantes("Estudiantes.txt");

            if (estudiantes.Any(e => e.ID == id))
            {
                return "El estudiante con este ID ya está registrado.";
            }

            Estudiante nuevoEstudiante = new Estudiante
            {
                ID = id,
                Nombre = nombre,
                RecibioAyuda = false,
                CodigoAyuda = ""
            };

            estudiantes.Add(nuevoEstudiante);
            dataManager.GuardarEstudiantes(estudiantes, "Estudiantes.txt");

            return $"Estudiante {nombre} registrado correctamente.";
        }

        public List<Estudiante> ListarEstudiantes()
        {
            return dataManager.CargarEstudiantes("Estudiantes.txt");
        }

        public List<TipoAyuda> ListarTiposAyuda()
        {
            return dataManager.CargarTiposAyuda("TipoAyuda.txt");
        }
    }
}
