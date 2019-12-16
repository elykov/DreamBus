using DreamBusDBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfUI.Server
{
    /// <summary>
    /// Логика взаимодействия для BusWindow.xaml
    /// </summary>
    public partial class BusWindow : Window
    {
        public BusWindow(BusType type)
        {
            InitializeComponent();

            BusContainerCanvas.Height = type.BusHeight;
            BusContainerCanvas.Width = type.BusWidth;
            BusContainerCanvas.Background = new SolidColorBrush(Colors.Yellow);

            int seatWidth = type.SeatWidth, 
                seatHeight = type.SeatHeight;
            int i = 1;
            Title = $"Height: {type.BusHeight}; Width {type.BusWidth}; Seat size: {seatWidth}x{seatHeight}";

            //void AddElement(BusSeat seat)
            //{
            //    var elem = new Button()
            //    {
            //        Width = seatWidth,
            //        Height = seatHeight,
            //        Content = i.ToString()
            //        //Content = $"X: {seat.XCoord};\nY: {seat.YCoord}"
            //    };
            //    Canvas.SetLeft(elem, seat.XCoord);
            //    Canvas.SetTop(elem, seat.YCoord);
            //    BusContainerCanvas.Children.Add(elem);

            //    i++;
            //}

            //foreach (var seat in type.BusSeats)
            //{
            //    AddElement(seat);
            //}

            void AddElement(BusSeat seat)
            {
                //BusSeat seat = param as BusSeat;
                var elem = new Button()
                {
                    Width = seatWidth,
                    Height = seatHeight,
                    Content = i.ToString()
                    //Content = $"X: {seat.XCoord};\nY: {seat.YCoord}"
                };

                Canvas.SetLeft(elem, seat.XCoord);
                Canvas.SetTop(elem, seat.YCoord);
                BusContainerCanvas.Children.Add(elem);

                i++;
            }

            Parallel.ForEach(type.BusSeats, (seat) =>
            {
                Dispatcher.BeginInvoke(new Action<BusSeat>(AddElement), new object[] { seat });
            });
        }
    }
}
