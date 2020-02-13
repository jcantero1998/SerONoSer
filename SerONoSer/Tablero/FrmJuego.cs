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
        private int tiempo = 12;
        private int nivel;
        private Pregunta preguntaActual;
        private int respuestasCorrectas = 0;
        private int respuestasIncorrectas = 0;

        private CapaNegocio.Negocio gestor = new CapaNegocio.Negocio();

        public FrmJuego()
        {
            InitializeComponent();
            lblTiempo.Text = "12";
        }
        private void FrmJuego_Load(object sender, EventArgs e)
        {
        }

        private void CargarPreguntasDeUnNivel(int nivel)
        {
            string mens = "";
            gestor.PreguntasPorNivel(nivel, out mens);
            if (mens=="")
            {
                PreguntaAlAzar();
            }
            else
            {
                if (mens== "Se ha sobrepasado el nivel maximo")
                {
                    nivel -= 1;
                    lblNivel.Text = nivel.ToString();
                    MessageBox.Show("¡¡¡Has ganado!!!", "Enhorabuena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show(mens);
                    finalizar();
                }
            }
        }
        private void PreguntaAlAzar()
        {
            string msg;

            preguntaActual = gestor.PreguntaAlAzar(out msg);

            if (preguntaActual==null)
            {
                //Aumentar nivel
                nivel += 1;
                lblNivel.Text = nivel.ToString();
                CargarPreguntasDeUnNivel(nivel);
            }

            lblEnunciado.Text = preguntaActual.Enunciado;

            List<Button> botones = ObtenerBotonesRespuestas();
            for (int i = 0; i < 12; i++)
            {
                //Cambiamos el color de los botones
                botones.ElementAt(i).BackColor = SystemColors.Control;
                //Le pongo como texto, la posible respuesta
                botones.ElementAt(i).Text = preguntaActual.Respuestas.ElementAt(i).PosibleRespuesta;


                //En el tag guardo el boton
                botones.ElementAt(i).Tag = preguntaActual.Respuestas.ElementAt(i);
            }
        }
        private List<Button> ObtenerBotonesRespuestas()
        {
            return Controls.OfType<Button>().Where(btn => btn.Name.Length <= 5).ToList(); // Hace referencia a los controles de tipo Button que tienen un nombre de máximo 5 caracteres
        }

        private void btnPosibleRespuesta_Click(object sender, EventArgs e)
        {//TODO Que no se pueda pulsar más de 1 vez en un mismo boton --> No se deshabilitan
            // TODO Debía modificar la etiqueta de errores
            try
            {
                Button btnActual = (Button)sender;
                Respuesta respuestaActual = (Respuesta)btnActual.Tag;

                //Comprobamos si la respuesta es correcta
                if (respuestaActual.Valida)
                {
                    btnActual.BackColor = Color.Green;
                    respuestasCorrectas += 1;
                }
                else
                {
                    btnActual.BackColor = Color.Red;
                    respuestasIncorrectas += 1;

                    if (!String.IsNullOrEmpty(respuestaActual.Explicacion))
                    {
                        lblRespuestaValida.Text = respuestaActual.Explicacion;
                    }
                }
                FinalizarPrograma();

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Pulsa el boton 'Re/Comenzar' para iniciar el juego");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FinalizarPrograma()
        {
            //Si las respuestas correctas son 8
            if (respuestasCorrectas >= 8)
            {
                tmrTiempoTotal.Enabled = false;
                DialogResult result = MessageBox.Show("Has acertado las 8 respuestas válidas, ¿Deseas continuar con otra pregunta?", "Atención", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    tmrTiempoTotal.Enabled = true;
                    tiempo = 12;
                    lblTiempo.Text = tiempo.ToString();
                    respuestasIncorrectas = 0;
                    respuestasCorrectas = 0;
                    PreguntaAlAzar();
                }
                else
                {
                    Close();
                }
            }
            //si las preguntas incorrectas son 4
            else if (respuestasIncorrectas == 4)
            {
                MessageBox.Show("Fin del juego...");
                finalizar();
            }
        }
        private void finalizar()
        {
            tmrTiempoTotal.Enabled = false;
            Close();
        }
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            lblTiempo.Text = "12";
            tiempo = 12;
            tmrTiempoTotal.Enabled = true;
            nivel = 1;
            CargarPreguntasDeUnNivel(nivel);
            lblNivel.Text = nivel.ToString();
        }

        private void tmrTiempoTotal_Tick(object sender, EventArgs e)
        {
            tiempo -= 1;

            if (tiempo==0)
            {
                MessageBox.Show("El tiempo ha llegado a 0, Fin del juego...");
                finalizar();
            }
            lblTiempo.Text = tiempo.ToString();

        }

    }
}