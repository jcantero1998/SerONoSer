using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pregunta
    {
        public int NumPregunta { get; set; }
        public string Enunciado { get; set; }
        public int Nivel { get; set; }
        public List<Respuesta> Respuestas { get; set; }

        public Pregunta(int numPregunta)
        {
        }

        public Pregunta(int numPregunta, string enunciado, int nivel, List<Respuesta> respuestas)
        {
            NumPregunta = numPregunta;
            Enunciado = enunciado;
            Nivel = nivel;
            Respuestas = respuestas;
        }
    }
}
