using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using TelegramBot.Models;

namespace TelegramBot
{
    public class Actions // клас із заготовленими апі-методами інших апі
    {
        public static TelegramUpdates GetUpdates(int offset = 0) // метод повертає модель нових повідомлень
        {
            GetUpdates obj;
            if (offset == 0)
            {
                obj = new GetUpdates();
            }
            else
            {
                obj = new GetUpdates
                {
                    offset = offset
                };
            }
            var json = JsonSerializer.Serialize<GetUpdates>(obj);
            string response = Requests.TelegramRequests("getUpdates", json);
            return JsonSerializer.Deserialize<TelegramUpdates>(response);
        }

        public static void SendMessage(decimal chat_id, string text) // метод ТГ-апі
        {
            SendMessage obj = new SendMessage
            {
                chat_id = chat_id,
                text = text
            };
            Requests.TelegramRequests("sendMessage", JsonSerializer.Serialize(obj));
        }

        // методи власного апі
        public static GetDef GetDef(string word) 
        {
            string json = Requests.MyAPIRequests($"getdef/{word}");
            return JsonSerializer.Deserialize<GetDef>(json);
        }

        public static SavedWords SavedWords(string user_id) 
        {
            string json = Requests.MyAPIRequests($"savedwords/{user_id}");
            return JsonSerializer.Deserialize<SavedWords>(json);
        }

        public static void AddUser(string user_id, string surname, string name) 
        {
            AddUser user = new AddUser
            {
                user_id = user_id,
                user_surname = surname,
                user_name = name
            };
            var json = JsonSerializer.Serialize<AddUser>(user);
            Requests.MyAPIRequests($"adduser", json);
        }  

        public static void AddWord(string user_id, string word)
        {
            Requests.MyAPIRequests($"addword/{user_id}/{word}");
        }

        public static void DeleteUser(string user_id)
        {
            Requests.MyAPIRequests($"deleteuser/{user_id}");
        }

        public static void DeleteWord(string user_id, string word)
        {
            Requests.MyAPIRequests($"deleteword/{user_id}/{word}");
        }
        
    }
}
