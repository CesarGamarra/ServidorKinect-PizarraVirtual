using Fleck;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ServidorKinectPizarra
{
    public partial class Conexion
    {
        static List<IWebSocketConnection> _sockets;

        public void InitializeSockets()
        {
            _sockets = new List<IWebSocketConnection>();

            var server = new WebSocketServer("ws://localhost:8181");

            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    _sockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    _sockets.Remove(socket);
                };
                socket.OnMessage = message =>
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();

                    dynamic obj = js.Deserialize<object>(message);
                    dynamic listaComandos = obj["Palabras"];
                    Audio.añadirComandos(listaComandos);
                };
            });
        }
        public void enviar(String json)
        {
            foreach (var socket in _sockets)
            {
                socket.Send(json);
            }
        }
    }
}
