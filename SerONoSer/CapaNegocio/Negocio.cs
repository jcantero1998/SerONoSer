using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Negocio
    {
        //Instanciamos el objeto gestor para poder usar los metodos de la capa de datos
        private CapaDatos.DatosDSet gestor = new CapaDatos.DatosDSet();
        
        public List<Pregunta> preguntas;

        public List<Pregunta> PreguntasPorNivel(int nivel, out string mens)
        {
            return preguntas = gestor.PreguntasPorNivel(nivel, out mens);
        }

        public Pregunta PreguntaAlAzar( out string msg)
        {
            if (preguntas.Count==0)
            {
                msg = "No quedan preguntas";
                return null;
            }
            else
            {
                msg = "";

                Random random = new Random();
                int rnd = random.Next(preguntas.Count);
                Pregunta pregunta = preguntas.ElementAt(rnd);
                preguntas.RemoveAt(rnd);

                return pregunta;
            }
        }

        //TODO Sacar los posibles mensajes de error que llegan de la capa anterior, o si alguno se puede producir en esta.

    }
}