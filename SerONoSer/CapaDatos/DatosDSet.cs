using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using static CapaDatos.DataSet1;

namespace CapaDatos
{
    public class DatosDSet
    {
        public string error;

        //Creamos el DataSet (DataSet: Estructura que simula una base de daos con la peculiaridad de que trabaja en memoria)
        DataSet1 ds = new DataSet1();

        //Creamos un adaptador por cada tabla (Adaptador: Intermediario entre DataSet y Base de datos)
        DataSet1TableAdapters.PreguntasTableAdapter daPreguntas = new DataSet1TableAdapters.PreguntasTableAdapter();
        DataSet1TableAdapters.RespuestasTableAdapter daRespuestas = new DataSet1TableAdapters.RespuestasTableAdapter();
        DataSet1TableAdapters.RespNoValidasTableAdapter daRespuestasNoValidas = new DataSet1TableAdapters.RespNoValidasTableAdapter();

        public DatosDSet()
        {
            // Llena las tablas que estan en el dataset ds a partir de la BD
            try
            {
                daPreguntas.Fill(ds.Preguntas);
                daRespuestas.Fill(ds.Respuestas);
                daRespuestasNoValidas.Fill(ds.RespNoValidas);
            }
            catch (Exception)
            {
                error = "Se ha producido un error en una de las tablas de la base de datos";
            }

        }

        //devolver todas las preguntas de un nivel pasado como parámetro.
        //Comprobar que ese nivel no es superior al máximo existente (si lo es sacará un mensaje que lo explique así).

        public List<Pregunta> PreguntasPorNivel(int nivel, out string mens)
        {
            if (error != "" && error != null)
            {
                mens = error;
                return null;
            }
            mens = "";
            List<Pregunta> pregs = null;

            var nivelmax = ds.Preguntas.OrderByDescending(drPreg => drPreg.Nivel).First();
            if (nivelmax.Nivel<nivel)
            {
                mens = "Se ha sobrepasado el nivel maximo";
            }
            else
            {
                List<PreguntasRow> drPregs = ds.Preguntas.Where(drPreg => drPreg.Nivel.Equals(nivel)).ToList();
                pregs = drPregs.Select(dr => new Pregunta(dr.NumPregunta, dr.Enunciado, dr.Nivel, RespuestasDeUnaPregunta(dr))).ToList();
            }

            return pregs;
        }

        public List<Respuesta> RespuestasDeUnaPregunta(PreguntasRow dr)
        {
            List<Respuesta> respuestas = dr.GetRespuestasRows().Select(drResp => new Respuesta(drResp.NumPregunta, drResp.NumRespuesta, drResp.PosibleRespuesta, drResp.Valida, ExplicacionDeUnaRespuesta(drResp))).ToList();
            if (respuestas.Count!=12)
            {
                error = "Una de las preguntas no contiene 12 respuestas";
            }
            return respuestas;
        }
        public string ExplicacionDeUnaRespuesta(RespuestasRow dr)
        {
            return dr.GetRespNoValidasRows().Select(drResp => drResp.Explicacion).SingleOrDefault(); //retorna nulo si no hay explicacion (gracias a SingleOrDefault)
        }
    }
}