using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot.Models
{
    public class AddUser
    {
        public string user_id { get; set; }
        public string user_surname { get; set; }
        public string user_name { get; set; }

        public List<string> saved_words { get; set; }

    }
}
