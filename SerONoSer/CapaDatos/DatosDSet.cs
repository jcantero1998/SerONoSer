using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace CapaDatos
{
    public class DatosDSet
    {
        //Creamos el DataSet (DataSet: Estructura que simula una base de daos con la peculiaridad de que trabaja en memoria)
        DataSet1 ds = new DataSet1();

        //Creamos un adaptador por cada tabla (Adaptador: Intermediario entre DataSet y Base de datos)
        DataSet1TableAdapters.PreguntasTableAdapter daPreguntas = new DataSet1TableAdapters.PreguntasTableAdapter();
        DataSet1TableAdapters.RespuestasTableAdapter daRespuestas = new DataSet1TableAdapters.RespuestasTableAdapter();
        DataSet1TableAdapters.RespNoValidasTableAdapter daRespuestasNoValidas = new DataSet1TableAdapters.RespNoValidasTableAdapter();

        public DatosDSet()
        {
            // Llena las tablas que estan en el dataset ds a partir de la BD
            daPreguntas.Fill(ds.Preguntas); 
            daRespuestas.Fill(ds.Respuestas);
            daRespuestasNoValidas.Fill(ds.RespNoValidas);
        }

        //devolver todas las preguntas de un nivel pasado como parámetro.
        //Comprobar que ese nivel no es superior al máximo existente (si lo es sacará un mensaje que lo explique así).

        //public List<Pregunta> PreguntasPorNuvel(string nivel)
        //{
            //return (from drProv in ds.Provincias
            //        orderby drProv.Nombre.StartsWith(comienzaPor)
            //        select new Provincia(drProv.Id, drProv.Nombre)).ToList();
            // var provs = ds.Provincias.Select(drProv => new Provincia(drProv.Id, drProv.Nombre)).OrderBy(drProv => drProv.Nombre.Equals(comienzaPor)).ToList();

            //List<ProvinciasRow> drProvs = ds.Provincias.Where(drProv => drProv.Nombre.ToLower().StartsWith(comienzaPor)).OrderBy(drProv => drProv.Nombre).ToList();
            //List<Pregunta> provs = drProvs.Select(dr => new Pregunta(dr.Id, dr.Nombre)).ToList();
            //return provs;
        //}
    }
}
