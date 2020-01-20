using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
