using DreamBusServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfUI.Server
{
    public class WpfPrinter : IWriter
    {
        ListView listViewHistory;

        public WpfPrinter(ListView listViewHistory)
        {
            this.listViewHistory = listViewHistory;
        }

        public void WriteMessage(Informator info)
        {
            listViewHistory.Dispatcher.Invoke(() => listViewHistory.Items.Add(info));
            //listViewHistory.Items.Add(info);
        }
    }
}
