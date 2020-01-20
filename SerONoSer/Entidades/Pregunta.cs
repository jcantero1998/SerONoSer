using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Pregunta
    {
        public int NumPregunta { get; set; }
        public string Enunciado { get; set; }
        public string Nivel { get; set; }
        public List<Respuesta> Respuestas { get; set; }

        public Pregunta()
        {
        }

        public Pregunta(int numPregunta, string enunciado, string nivel, List<Respuesta> respuestas)
        {
            NumPregunta = numPregunta;
            Enunciado = enunciado;
            Nivel = nivel;
            Respuestas = respuestas;
        }
    }
}
