using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace TelegramBot
{
    public class Requests
    {
        public static readonly string telegram_token = "1686575346:AAHz3YTu2bafUngS45-0-bSfjlRKgYV_4WI";

        private static string Request(string method, string uri, params string[] json) // універсальний метод запиту до API
        { // params string[] json => необов'язкова зміна -> якщо json не передали, то список буде пустим
            if (method.ToLower() == "get" && json.Length != 0) return "fail"; // перевірка чи не передали у GET - json

            string result = "";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri); // об'єкт запиту

            switch (method.ToLower()) // вказування на метод http запиту 
            {
                case "get":
                    httpWebRequest.Method = "GET";
                    break;

                case "post":
                    httpWebRequest.Method = "POST";
                    break;

                case "put":
                    httpWebRequest.Method = "PUT";
                    break;

                case "delete":
                    httpWebRequest.Method = "DELETE";
                    break;

                default: return "fail";
            }

            if (method.ToLower() != "get" && json.Length != 0) //якщо GET -> запису у Body не буде, якщо json не передали запису не буде
            {
                httpWebRequest.ContentType = "application/json"; //який вид контенту передаємо =(json)

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) // запис у Body json'у
                {
                    streamWriter.Write(json[0]);
                }
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse(); // відправка запиту + отримання відповіді

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) // зчитувння json'y із Body
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        public static string TelegramRequests(string telegram_method, params string[] json) // заготовка запиту до ТГ-апі
        {
            string url = @$"https://api.telegram.org/bot{telegram_token}/{telegram_method}";
            return Request("post", url, json);
        }

        public static string MyAPIRequests(string uri, params string[] json) // заготовка запиту до власного-апі
        {
            string url = @$"https://wheatleyapi.azurewebsites.net/api/{uri}";
            if (uri.StartsWith("getdef") || uri.StartsWith("savedwords")) return Request("get", url, json);
            else if (uri.StartsWith("adduser") || uri.StartsWith("addword")) return Request("post", url, json);
            else if (uri.StartsWith("deleteuser") || uri.StartsWith("deleteword")) return Request("delete", url, json);
            return "";
        }
    }
}
