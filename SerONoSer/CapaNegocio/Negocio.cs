using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    class Negocio
    {
        //Instanciamos el objeto gestor para poder usar los metodos de Datos.Gestor
        public static CapaDatos.DatosDSet gestor = new CapaDatos.DatosDSet();

        public List<Pregunta> PreguntasPorNivel(int nivel)
        {
            List<Pregunta> reguntas;
            reguntas = gestor.PreguntasPorNivel(nivel);
            return reguntas;
        }
    }
}
