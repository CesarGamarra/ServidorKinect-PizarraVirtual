using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Speech.AudioFormat;
using Microsoft.Speech.Recognition;
using Microsoft.Kinect;
using System.Windows;
using System.Windows.Forms;

namespace ServidorKinectPizarra
{
    public class Audio
    {
        static SpeechRecognitionEngine speechengine;
        static Choices opciones;
        static GrammarBuilder grammarb;
        static Grammar grammar;
        static RecognizerInfo ri;

        KinectSensor miKinect;
        Conexion conexion=new Conexion();

        public void Cargar(KinectSensor miKinect)
        {
            this.miKinect = miKinect;

            estableceReconocimiento();
        }

        public static void añadirComandos(dynamic listaComandos)
        {
            for(int i = 0; i < listaComandos.Length;i++)
            {
                opciones.Add(new SemanticResultValue(listaComandos[i], listaComandos[i]));
            }
            grammarb = new GrammarBuilder { Culture = ri.Culture };
            grammarb.Append(opciones);

            grammar = new Grammar(grammarb);
            speechengine.LoadGrammar(grammar);
        }

        void estableceReconocimiento()
        {
            ri = obtenerLP();
            if (ri != null)
            {
                speechengine = new SpeechRecognitionEngine(ri.Id);
                opciones = new Choices();

                opciones.Add(new SemanticResultValue("Angulo Kinect menos veinticinco", "KINECT25NEGATIVO"));
                opciones.Add(new SemanticResultValue("Angulo Kinect menos veinte", "KINECT20NEGATIVO"));
                opciones.Add(new SemanticResultValue("Angulo Kinect menos quince", "KINECT15NEGATIVO"));
                opciones.Add(new SemanticResultValue("Angulo Kinect menos diez", "KINECT10NEGATIVO"));
                opciones.Add(new SemanticResultValue("Angulo Kinect menos cinco", "KINECT5NEGATIVO"));
                opciones.Add(new SemanticResultValue("Angulo Kinect cero", "KINECT0"));
                opciones.Add(new SemanticResultValue("Angulo Kinect cinco", "KINECT5"));
                opciones.Add(new SemanticResultValue("Angulo Kinect diez", "KINECT10"));
                opciones.Add(new SemanticResultValue("Angulo Kinect quince", "KINECT15"));
                opciones.Add(new SemanticResultValue("Angulo Kinect veinte", "KINECT20"));
                opciones.Add(new SemanticResultValue("Angulo Kinect veinticinco", "KINECT25"));

                opciones.Add(new SemanticResultValue("Angulo Kinect restablecer", "KINECT0"));

                //Esta variable creará todo el conjunto de frases y palabras en base a nuestro lenguaje elegido en la variable ri
                grammarb = new GrammarBuilder { Culture = ri.Culture };
                //Agregamos las opciones de palabras y frases a grammarb
                grammarb.Append(opciones);

                grammar = new Grammar(grammarb);
                speechengine.LoadGrammar(grammar);

                speechengine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(speechengine_SpeechRecognized);
                
                //speechengine inicia la entrada de datos de audio
                speechengine.SetInputToAudioStream(miKinect.AudioSource.Start(), new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
                speechengine.RecognizeAsync(RecognizeMode.Multiple);
            }
        }
        private RecognizerInfo obtenerLP()
        {
            //Comprueba todos los languagePack instalados
            foreach (RecognizerInfo recognizer in SpeechRecognitionEngine.InstalledRecognizers())
            {
                string value;
                recognizer.AdditionalInfo.TryGetValue("Kinect", out value);

                //Seleccionamos el languagePack que queramos
                if ("True".Equals(value, StringComparison.OrdinalIgnoreCase) && "es-ES".Equals(recognizer.Culture.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return recognizer;
                }
            }

            return null;
        }
        void speechengine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            const double igualdad = 0.5;

            if (e.Result.Confidence > igualdad)
            {
                String json = "";
                switch (e.Result.Semantics.Value.ToString())
                {
                    case "KINECT25NEGATIVO":
                        miKinect.ElevationAngle = -25;
                        break;
                    case "KINECT20NEGATIVO":
                        miKinect.ElevationAngle = -20;
                        break;
                    case "KINECT15NEGATIVO":
                        miKinect.ElevationAngle = -15;
                        break;
                    case "KINECT10NEGATIVO":
                        miKinect.ElevationAngle = -10;
                        break;
                    case "KINECT5NEGATIVO":
                        miKinect.ElevationAngle = -5;
                        break;
                    case "KINECT0":
                        miKinect.ElevationAngle = 0;
                        break;
                    case "KINECT5":
                        miKinect.ElevationAngle = 5;
                        break;
                    case "KINECT10":
                        miKinect.ElevationAngle = 10;
                        break;
                    case "KINECT15":
                        miKinect.ElevationAngle = 15;
                        break;
                    case "KINECT20":
                        miKinect.ElevationAngle = 20;
                        break;
                    case "KINECT25":
                        miKinect.ElevationAngle = 25;
                        break;
                    default:
                        json = "{\"Palabra\":" + "\"" + e.Result.Semantics.Value.ToString() + "\"}";
                        conexion.enviar(json);
                        break;
                }
            }
        }
        public void cierraAudio()
        {
            miKinect.AudioSource.Stop();
        }
    }
}