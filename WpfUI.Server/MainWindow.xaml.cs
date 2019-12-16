using BusinessLayerLibrary;
using BusinessLayerLibrary.Models;
using DreamBusServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows;

namespace WpfUI.Server
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WpfPrinter logger;
        DbConnector DBConnector;
        DreamBusServer.DreamBusServer server;
        public IPAddress CurrentIP { get => (comboBoxIP.SelectedItem as IPAddress); }
        public int CurrentPort { get => int.Parse(textBoxPort.Text); }

        #region Настройки окна, сети и приложения

        public MainWindow()
        {
            InitializeComponent();
            logger = new WpfPrinter(listViewHistory);
            InitNetUIServer();
            DBConnector = new DbConnector();
            Subscribes();

            //this.Hide();
            //var buswin = new BusWindow(DBConnector.BusTypeService.GetAll().First());
            //buswin.ShowDialog();
            //Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите выключить сервер?\nЕго работа будет прекращена.", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                server?.StopServer();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Спасибо за использование продукта.", "DreamBus Server 1.0");
        }
        #endregion

        #region Работа с БД и UI

        public void Subscribes()
        {
            comboBoxRegions.ItemsSource = listViewRegions.ItemsSource = DBConnector.RegionService.GetAll();
            comboBoxNeighborCityFrom.ItemsSource = comboBoxNeighborCityTo.ItemsSource = listViewCities.ItemsSource = DBConnector.CityService.GetAll();
            listViewNeighborCities.ItemsSource = DBConnector.NeighborCitiesService.GetAll();
            listViewMediumPathes.ItemsSource = DBConnector.MediumPathService.GetAll();
            listViewFlights.ItemsSource = DBConnector.FlightService.GetAll();
            listViewBusSeats.ItemsSource = DBConnector.BusSeatService.GetAll();
            listViewBusTypes.ItemsSource = DBConnector.BusTypeService.GetAll();
            listViewBusModels.ItemsSource = DBConnector.BusModelService.GetAll();
            listViewBuses.ItemsSource = DBConnector.BusService.GetAll();
        }

        #endregion

        #region Страница Данные сервера (1)

        void InitNetUIServer()
        {
            List<IPAddress> addresses = new List<IPAddress>();
            addresses.Add(IPAddress.Parse("127.0.0.1"));

            addresses.AddRange(Dns.GetHostEntry(Dns.GetHostName()).
                AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork));

            comboBoxIP.ItemsSource = addresses;
        }

        private void ButtonStartServer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (server == null)
                {
                    server = new DreamBusServer.DreamBusServer(logger);
                    var ep = new IPEndPoint(CurrentIP, CurrentPort);
                    server.StartServer(ep);
                    buttonStartServer.Content = "Выключить сервер";
                }
                else
                {
                    server.StopServer();
                    server = null;
                    buttonStartServer.Content = "Включить сервер";
                }
            }
            catch (Exception ex)
            {
                logger.WriteMessage(new Informator("Сервер", ex.Message));
            }
        }

        #endregion

        #region Страница Области (2)

        private void ButtonAddRegion_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxRegionTitle.Text.Length < 3)
            {
                MessageBox.Show(
                    "Название области слишком короткое!",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            try
            {
                DBConnector.RegionService.Add(new RegionDTO() { Title = textBoxRegionTitle.Text });
                DBConnector.RegionService.Save();
                MessageBox.Show("Область успешно добавлена!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Произошла ошибка при добавлении данных. Подробнее: " + ex.Message,
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            comboBoxRegions.ItemsSource = listViewRegions.ItemsSource = DBConnector.RegionService.GetAll();
            textBoxRegionTitle.Clear();
        }

        #endregion

        #region Страница городов (3)

        private void ButtonAddCity_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxCityTitle.Text.Length < 3)
            {
                MessageBox.Show(
                    "Название города слишком короткое!",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            try
            {
                RegionDTO currentRegion = comboBoxRegions.SelectedValue as RegionDTO;
                if (currentRegion == null)
                {
                    MessageBoxResult result = MessageBox.Show(
                        "Укажите область города.",
                        "Область не выбрана",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }

                DBConnector.CityService.Add(new CityDTO() { Title = textBoxCityTitle.Text, RegionId = currentRegion.Id });
                DBConnector.CityService.Save();
                MessageBox.Show("Город успешно добавлен!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Произошла ошибка при добавлении данных. Подробнее: " + ex.Message,
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            listViewCities.ItemsSource = DBConnector.CityService.GetAll();
            textBoxCityTitle.Clear();
        }

        #endregion

    }
}
