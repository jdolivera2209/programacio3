using Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DataM
    {
        public List<Estudiante> CargarEstudiantes(string RutaArchivo)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            foreach (var linea in File.ReadLines(RutaArchivo))
            {
                var datos = linea.Split(';');
                estudiantes.Add(new Estudiante
                {
                    ID = int.Parse(datos[0]),
                    Nombre = datos[1],
                    RecibioAyuda = datos[2] == "SI",
                    CodigoAyuda = datos[3]
                });
            }
            return estudiantes;
        }

        public List<TipoAyuda> CargarTiposAyuda(string RutaArchivo)
        {
            List<TipoAyuda> tiposAyuda = new List<TipoAyuda>();
            foreach (var linea in File.ReadLines(RutaArchivo))
            {
                var datos = linea.Split(';');
                tiposAyuda.Add(new TipoAyuda
                {
                    Codigo = datos[0],
                    Nombre = datos[1],
                    CantidadBeneficiados = int.Parse(datos[2])
                });
            }
            return tiposAyuda;
        }

        public void GuardarEstudiantes(List<Estudiante> estudiantes, string estudent)
        {
            using (StreamWriter sw = new StreamWriter(estudent))
            {
                foreach (var estudiante in estudiantes)
                {
                    sw.WriteLine($"{estudiante.ID};{estudiante.Nombre};{(estudiante.RecibioAyuda ? "SI" : "NO")};{estudiante.CodigoAyuda}");
                }
            }
        }

        public void GuardarTiposAyuda(List<TipoAyuda> tiposAyuda, string tpAyuda)
        {
            using (StreamWriter sw = new StreamWriter(tpAyuda))
            {
                foreach (var tipoAyuda in tiposAyuda)
                {
                    sw.WriteLine($"{tipoAyuda.Codigo};{tipoAyuda.Nombre};{tipoAyuda.CantidadBeneficiados}");
                }
            }
        }
    }
}
