using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServidorKinectPizarra
{
    public partial class Form1 : Form
    {
        private KinectSensor miKinect;

        Conexion conexion = new Conexion();
        Audio audio = new Audio();
        Esqueletos esqueletos = new Esqueletos();

        public Form1()
        {
            InitializeComponent();
            conexion.InitializeSockets();
            inicializarKinect();

            WindowState = FormWindowState.Minimized;
            trayBar.Text = "Click derecho para mostrar menu";
        }

        private void inicializarKinect()
        {
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    miKinect = potentialSensor;
                    KinectSensor.KinectSensors.StatusChanged += new EventHandler<StatusChangedEventArgs>(KinectSensors_StatusChanged);
                    break;
                }
            }

            if (miKinect != null)
            {
                try
                {
                    miKinect.Start();
                    esqueletos.Cargar(miKinect);
                    audio.Cargar(miKinect);

                    //System.Diagnostics.Process.Start("http://aladren.dyndns.org/");

                    trayBar.BalloonTipTitle = "Servidor kinect";
                    trayBar.BalloonTipText = "Servidor funcionando";
                    trayBar.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                    trayBar.ShowBalloonTip(1000);
                }
                catch (Exception)
                {
                    miKinect = null;
                }
            }
            else
            {
                trayBar.BalloonTipTitle = "Servidor kinect";
                trayBar.BalloonTipText = "Kinect no encontrado";
                trayBar.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Error;
                trayBar.ShowBalloonTip(1000);
            }
        }
        void KinectSensors_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case (KinectStatus.Connected):
                    if(miKinect==null)
                        inicializarKinect();
                    break;
                //En caso de que el status sea Disconnected se la variable miKinect se volvera nula e 
                //intentaremos buscar otro dispositivo Kinect cuyo estado sea Connected si no se encuentra 
                //mandaremos un mensaje indicando que No hay ningun Kinect conectado
                case (KinectStatus.Disconnected):
                    //statusK.Text = "No hay ningun Kinect conectado";
                    miKinect = null;
                    inicializarKinect();
                    break;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                this.Visible = false;
                trayBar.Visible = true;
            }
        }

        private void trayBar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*
            Show();
            WindowState = FormWindowState.Normal;
            trayBar.Visible = false;*/
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            desconectarKinect();
        }

        private void desconectarKinect()
        {
            if (miKinect != null)
            {
                audio.cierraAudio();
                miKinect.Stop();
                miKinect = null;
            }
        }

        private void menuItemSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItemConectar_Click(object sender, EventArgs e)
        {
            inicializarKinect();
        }

        private void menuItemDesconectar_Click(object sender, EventArgs e)
        {
            desconectarKinect();
        }

        private void menuItemAngulo_Click(object sender, EventArgs e)
        {
            Angulo angulo = new Angulo(miKinect);
            angulo.Show();
        }
    }
}
