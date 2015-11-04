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
    public partial class Angulo : Form
    {
        private KinectSensor miKinect = null;
        int angulo;

        public Angulo()
        {
            InitializeComponent();
        }
        public Angulo(KinectSensor miKinect)
        {
            InitializeComponent();
            this.miKinect = miKinect;
            angulo = miKinect.ElevationAngle;
            barraAngulo.Value = angulo;
        }

        private void barraAngulo_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                angulo = barraAngulo.Value;

                if (angulo > miKinect.MinElevationAngle && angulo < miKinect.MaxElevationAngle)
                    miKinect.ElevationAngle = angulo;
            }
            catch (Exception)
            {
            }
        }

        private void restablecer_Click(object sender, EventArgs e)
        {
            try
            {
                angulo = 0;
                barraAngulo.Value = angulo;
                miKinect.ElevationAngle = angulo;
            }
            catch (Exception)
            {
            }
        }
    }
}
