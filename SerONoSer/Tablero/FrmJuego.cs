using CapaNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tablero
{
    public partial class FrmJuego : Form
    {
        private int nivel = 1;
        private Pregunta preguntaActual;

        private CapaNegocio.Negocio gestor = new CapaNegocio.Negocio();

        public FrmJuego()
        {
            InitializeComponent();
        }
        private void FrmJuego_Load(object sender, EventArgs e)
        {
            gestor.PreguntasPorNivel(nivel);
            preguntaActual = gestor.PreguntaAlAzar();

            lblEnunciado.Text = preguntaActual.Enunciado;
            List<Button> botones = ObtenerBotonesRespuestas();
            for (int i = 0; i < 12; i++)
            {
                botones.ElementAt(i).Text = preguntaActual.Respuestas.ElementAt(i).PosibleRespuesta;
            }

            //MessageBox.Show(pregunta.Enunciado);

            //MessageBox.Show(gestor.preguntas.Count().ToString());

            //if (gestor.preguntas.Contains(pregunta))
            //{
            //    MessageBox.Show("la contiene");
            //}
            //else
            //{
            //    MessageBox.Show("no la contiene");
            //}
        }
        private List<Button> ObtenerBotonesRespuestas()
        {
            return Controls.OfType<Button>().Where(btn => btn.Name.Length <= 5).ToList(); // Hace referencia a los controles de tipo Button que tienen un nombre de máximo 5 caracteres
        }
        private void btnCambiarPregunta_Click(object sender, EventArgs e)
        {

        }




        private void btnPosibleRespuesta_Click(object sender, EventArgs e)
        {



        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {

        }

        private void tmrTiempoTotal_Tick(object sender, EventArgs e)
        {

        }


    }
}