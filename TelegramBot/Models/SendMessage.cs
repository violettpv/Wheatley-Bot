using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot.Models
{
    class SendMessage
    {
        public decimal chat_id { get; set; }
        public string text { get; set; }
        public string parse_mode { get; set; } = "HTML";
        public bool allow_sending_without_reply { get; set; } = true;
    }
}
