using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot.Models
{
    public class GetUpdates
    {
        public int offset { get; set; }
        public int limit { get; set; } = 10;
        public string[] allow_updates { get; set; } = { "message" };

    }
}
