using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamBusServer
{
    public interface IWriter
    {
        void WriteMessage(Informator info);
    }
}
