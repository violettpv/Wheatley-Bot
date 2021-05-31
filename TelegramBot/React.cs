using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TelegramBot.Models;

namespace TelegramBot
{
    public class React
    {
        public static async void Process(Message message) // метод реагування на повідомлення 
        {
            if (message == null) return;

            Console.WriteLine($"{message.from.first_name}: {message.text}"); // для дебагінгу
            if (message.from.id == 235314374)
            {
                Actions.SendMessage(message.from.id, "<b>BAN</b>ana :)");
                return;
            }

            if (message.text.StartsWith('/') == false) return; // перевірка на команду

            // розбиття команди на аргументи
            var command = message.text.Replace("/", ""); 
            var argument = Regex.Split(command, @"\s+");

            string text;
            switch (argument[0].ToLower()) // argument[0] = команда 
            {
                case "ping":
                    Actions.SendMessage(message.chat.id, "Pong!");
                    break;

                case "sub":
                case "start":
                    Commands.Start(message.chat.id, message.from.last_name, message.from.first_name);
                    break;

                case "def":
                case "definition":
                    if (argument.Length < 2) // перевірка чи достатньо аргументів 
                    {
                        Actions.SendMessage(message.chat.id, "Error! Wrong usage of command.");
                        break;
                    }
                    text = message.text.Replace($"/{argument[0]}", "").TrimStart(); // залишаємо те, що потрібно знайти 
                    Commands.Define(message.chat.id, text);
                    break;

                case "help":
                    Commands.Help(message.chat.id);
                    break;

                case "add":
                case "save":
                    if (argument.Length < 2)
                    {
                        Actions.SendMessage(message.chat.id, "Error! Wrong usage of command.");
                        break;
                    }
                    text = message.text.Replace($"/{argument[0]}", "").TrimStart();
                    Commands.Save(message.chat.id, text);
                    break;

                case "list":
                    Commands.List(message.chat.id);
                    break;

                case "daily":
                    Commands.Daily(message.chat.id);
                    break;

                case "del":
                case "delete":
                    if (argument.Length < 2)
                    {
                        Actions.SendMessage(message.chat.id, "Error! Wrong usage of command.");
                        break;
                    }
                    text = message.text.Replace($"/{argument[0]}", "").TrimStart();
                    Commands.Delete(message.chat.id, text);
                    break;

                case "unsub":
                    Commands.Unsub(message.chat.id);
                    break;

                default:
                    Actions.SendMessage(message.chat.id, "Error! I do not know this command.");  
                    break;
            }

        }

    }
}
