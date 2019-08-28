using BusinessLayerLibrary;
using BusinessLayerLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamBusServer
{
    public class DreamBusServer : AsyncTcpServer
    {
        public DreamBusServer(IWriter writer) : base(writer)
        {
        }

        public override byte[] MessageParse(byte[] message)
        {
            PrintLog(new Informator("Сервер", "Получены данные: " + message.ToString()));
            return null;
        }

        public void PrintLog(Informator info)
        {
            this.Writer.WriteMessage(info);
        }
    }
}
