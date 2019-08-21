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
            throw new NotImplementedException();
        }

        public void PrintLog(Informator info)
        {
            this.Writer.WriteMessage(info);
        }
    }
}
