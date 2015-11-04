using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;

namespace ServidorKinectPizarra
{
    class Esqueletos
    {
        KinectSensor miKinect;
        Conexion conexion = new Conexion();

        String jsonSkeleton = "";
        JavaScriptSerializer oSerializer = new JavaScriptSerializer();
        Timer timer;

        public void Cargar(KinectSensor miKinect)
        {
            this.miKinect = miKinect;
            
            miKinect.SkeletonStream.Enable();
            miKinect.SkeletonFrameReady +=new EventHandler<SkeletonFrameReadyEventArgs>(miKinect_SkeletonFrameReady);
            this.timer = new Timer(this.TimerCallback, null, 0, 50);
        }

        private void miKinect_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] skeletons = new Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }
            }
            if (skeletons.Length != 0)
            {
                string json = "{\"Skeleton\":[";
                foreach (Skeleton skel in skeletons)
                {

                    if (skel.TrackingState == SkeletonTrackingState.Tracked)
                    {
                        json += "{\"Id\":" + skel.TrackingId + ",";
                        foreach (Joint joint in skel.Joints)
                        {
                            switch (joint.JointType)
                            {
                                case JointType.Head:
                                    //Cabeza
                                    var heanp = joint.Position;

                                    json += "\"Cabeza\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                                case JointType.ShoulderCenter:
                                    //Cuello
                                    heanp = joint.Position;

                                    json += "\"Cuello\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                                case JointType.ShoulderLeft:
                                    //Hombro izquierdo
                                    heanp = joint.Position;

                                    json += "\"HombroIzq\":" + oSerializer.Serialize(heanp) + ",";

                                    break;
                                case JointType.ShoulderRight:
                                    //Hombro derecho
                                    heanp = joint.Position;

                                    json += "\"HombroDer\":" + oSerializer.Serialize(heanp) + ",";
                                    //distancia += heanp.Z;
                                    break;
                                case JointType.ElbowLeft:
                                    //Codo Izquierdo
                                    heanp = joint.Position;

                                    json += "\"CodoIzq\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                                case JointType.ElbowRight:
                                    //Codo derecho
                                    heanp = joint.Position;

                                    json += "\"CodoDer\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                                case JointType.WristLeft:
                                    //Muñeca Izquierda
                                    heanp = joint.Position;

                                    json += "\"MuñecaIzq\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                                case JointType.WristRight:
                                    //Muñeca Derecha
                                    heanp = joint.Position;

                                    json += "\"MuñecaDer\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                                case JointType.HandLeft:
                                    //Mano Izquierda
                                    heanp = joint.Position;

                                    json += "\"ManoIzq\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                                case JointType.HandRight:
                                    //Mano Derecha
                                    heanp = joint.Position;

                                    json += "\"ManoDer\":" + oSerializer.Serialize(heanp) + ",";
                                    //distancia -= heanp.Z;
                                    break;
                                case JointType.Spine:
                                    //Columna
                                    heanp = joint.Position;

                                    json += "\"Columna\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                                case JointType.HipCenter:
                                    //Cadera
                                    heanp = joint.Position;

                                    json += "\"Cadera\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                                case JointType.HipRight:
                                    //Cadera derecha
                                    heanp = joint.Position;

                                    json += "\"CaderaDer\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                                case JointType.HipLeft:
                                    //Cadera izquierda
                                    heanp = joint.Position;

                                    json += "\"CaderaIzq\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                                case JointType.KneeRight:
                                    //Rodilla derecha
                                    heanp = joint.Position;

                                    json += "\"RodillaDer\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                                case JointType.KneeLeft:
                                    //Rodilla izquierda
                                    heanp = joint.Position;

                                    json += "\"RodillaIzq\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                                case JointType.AnkleRight:
                                    //Tobillo derecho
                                    heanp = joint.Position;

                                    json += "\"TobilloDer\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                                case JointType.AnkleLeft:
                                    //Tobillo izquierdo
                                    heanp = joint.Position;

                                    json += "\"TobilloIzq\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                                case JointType.FootRight:
                                    //Pie derecho
                                    heanp = joint.Position;

                                    json += "\"PieDer\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                                case JointType.FootLeft:
                                    //Pie izquierdo
                                    heanp = joint.Position;

                                    json += "\"PieIzq\":" + oSerializer.Serialize(heanp) + ",";
                                    break;
                            }
                        }
                        json = json.Substring(0, json.Length - 1) + "},";
                    }
                }
                json = json.Substring(0, json.Length - 1) + "]}";
                jsonSkeleton = json;
            }
        }



        private void TimerCallback(object state)
        {
            try
            {
                if (jsonSkeleton.Length > 20)
                {
                    conexion.enviar(jsonSkeleton);
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Error al enviar");
            }

        }
    }
}
