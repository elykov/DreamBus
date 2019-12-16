using BusinessLayerLibrary;
using BusinessLayerLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DreamBusServer
{
    public class DreamBusServer : AsyncTcpServer
    {
        class Query
        {
            public string Type { get; set; } // Тип запроса
            public string Token { get; set; } // Токен, не нул если пользователь зарегистрирован
            public IList<object> Values { get; set; } // Пришедшие значения
        }

        public DreamBusServer(IWriter writer) : base(writer)
        {
        }

        /// <summary>
        /// Принимает сообщение и отправляет ответ на него.
        /// </summary>
        /// <param name="byte_message">Пришедшее сообщение</param>
        /// <returns>Ответ на сообщение</returns>
        public override byte[] MessageParse(byte[] byte_message)
        {
            string resultMessage = "";
            PrintLog(new Informator("Сервер", "Запрос данных."));
            string message = byte_message.ToString();
            var query = JsonConvert.DeserializeObject<Query>(message);

            switch (query.Type)
            {
                case "reg": // User registration.
                    {
                        resultMessage = "Registration";
                        break;
                    }
                case "auth": // Client authorization.
                    {
                        resultMessage = "Authorization";
                        break;
                    }
                case "path": // Search path by cities, date and? time.
                    {
                        resultMessage = "Path";
                        break;
                    }
                case "flight":
                    {
                        resultMessage = "Flight";
                        break;
                    }

                // Check is authorized
                case "buy":
                    {
                        if (query.Token != null)
                        {

                        }
                        
                        break;
                    }
                case "return":
                    {
                        if (query.Token != null)
                        {

                        }

                        break;
                    }
                case "tickets":
                    {
                        if (query.Token != null)
                        {

                        }

                        break;
                    }
                case "profile":
                    {
                        if (query.Token != null)
                        {

                        }

                        break;
                    }
                default:
                    return Encoding.ASCII.GetBytes($"The type {query.Type} is not defined.");
            }

            /*
             {
                "type" : "", // Тип запроса: (авторизация, регистрация, поиск)
                "token": "", // Если пользователь зареган
                "values": [] // Если 1 объект - просто его внутри массива
             }
             */

            /*
             Запросы без авторизации:
             1. Регистрация клиента // reg
             2. Авторизация клиента (Возвращение токена) // auth
             3. Поиск маршрута по городам, дате и времени. // path
             4. Информация о рейсе // flight
             (после поиска выдача информации о автобусе и занятых местах, 
                    необходимо проверять на покупку одного и того же места одновременно)
            
             С авторизацией: 
             1. Покупка билетов. // buy
             2. Возврат билетов. // return
             3. Просмотр билетов пользователя (сервер отправляет без порядка, клиент сортирует) // tickets
             4. Просмотр информации о профиле // profile
             */

            // Encoding.ASCII.GetString(bytes);
            return Encoding.ASCII.GetBytes(resultMessage);
        }

        public void PrintLog(Informator info)
        {
            this.Writer.WriteMessage(info);
        }
    }
}
