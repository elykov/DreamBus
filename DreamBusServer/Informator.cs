using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamBusServer
{
    public class Informator
    {
        public Informator(string status, string data)
        {
            DateTime dt = DateTime.Now;
            Time = dt.ToShortDateString() + ": " + dt.ToShortTimeString();
            this.Status = status;
            this.DataView = data;
        }

        public string Status { get; }
        public string Time { get; }
        public string DataView { get; }
    }
}
