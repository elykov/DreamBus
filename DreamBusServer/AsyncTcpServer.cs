using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DreamBusServer
{
    /// <summary>
    /// Класс реализующий TCP-сервер абстрактно. Работает по принципу "вопрос-ответ".
    /// Для работы необходимо наследоваться от данного класса и переопределить метод "MessageParse"
    /// </summary>
    public abstract class AsyncTcpServer
    {
        protected class SuperSocket
        {
            public Socket ClientSocket { get; set; }
            public byte[] data = new byte[4096];
        }

        public event Action ClientConnected;
        public event Action ClientDisconnected;
        public event Action<byte[]> MessageReceived;
        public event Action<byte[]> MessageSended;

        public bool IsServerStarted { get; set; } = false;
        protected IWriter Writer;

        protected Thread listenerThread;
        protected ManualResetEvent allDone = new ManualResetEvent(false);
        protected IPEndPoint endPoint;

        public abstract byte[] MessageParse(byte[] message);

        public AsyncTcpServer(IWriter writer)
        {
            Writer = writer;
        }

        public void StartServer(IPEndPoint ep)
        {
            endPoint = ep;
            listenerThread = new Thread(new ParameterizedThreadStart(Listening));
            listenerThread.Start(endPoint);
            IsServerStarted = true;
            Writer.WriteMessage(new Informator("Сервер", "Сервер запущен."));
        }

        public void StopServer()
        {
            listenerThread?.Abort();
            IsServerStarted = false;
            Writer.WriteMessage(new Informator("Сервер", "Сервер остановлен."));
        }

        /// <summary>
        /// Метод принимает подключения, запускается в отдельном потоке. Для запуска потока передается Object.
        /// </summary>
        /// <param name="endPoint"></param>
        protected void Listening(object endPoint)
        {
            IPEndPoint localEndPoint = endPoint as IPEndPoint;
            Socket listener = new Socket(localEndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Writer.WriteMessage(new Informator("Сервер", $"Прослушивание порта {localEndPoint.Port} началось..."));

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(500);

                while (true)
                {
                    allDone.Reset();
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                }
            }
            catch (ThreadAbortException ex)
            {
                //Writer.WriteMessage(new Informator("Ошибка сервера", "Listener exception: " + ex.Message));
            }
            catch (Exception ex)
            {
                Writer.WriteMessage(new Informator("Ошибка сервера", "Undefined exception: " + ex.Message));
            }
        }

        protected void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();

            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            SuperSocket state = new SuperSocket();
            state.ClientSocket = handler;
            ClientConnected?.Invoke();
            handler.BeginReceive(state.data, 0, state.data.Length, 0, new AsyncCallback(ReadCallback), state);
        }

        protected void ReadCallback(IAsyncResult ar)
        {
            string content = string.Empty;

            try
            {
                SuperSocket state = (SuperSocket)ar.AsyncState;
                Socket handler = state.ClientSocket;

                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    byte[] byteResponse = MessageParse(state.data);
                    MessageReceived?.Invoke(state.data);
                    state.ClientSocket.BeginSend(byteResponse, 0, byteResponse.Length, 0, new AsyncCallback(SendCallback), state);
                }
            }
            catch (SocketException ex)
            {
                Writer.WriteMessage(new Informator("Ошибка сервера", "Socket exception: " + ex.Message));
                ClientDisconnected?.Invoke();
            }
            catch (Exception ex)
            {
                Writer.WriteMessage(new Informator("Ошибка сервера", "Undefined exception: " + ex.Message));
            }
        }

        protected void SendCallback(IAsyncResult ar)
        {
            SuperSocket state = (SuperSocket)ar.AsyncState;
            Socket handler = state.ClientSocket;
            int bytesSent = handler.EndSend(ar);
            MessageSended?.Invoke(state.data);
            handler.BeginReceive(state.data, 0, state.data.Length, 0, new AsyncCallback(ReadCallback), state);
        }
    }
}
