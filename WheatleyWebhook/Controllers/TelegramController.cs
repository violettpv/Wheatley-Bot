using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramBot;
using TelegramBot.Models;

namespace WheatleyWebhook.Controllers
{
    [ApiController]
    [Route("webhook")]
    public class TelegramController : ControllerBase
    {
        [HttpPost("telegram")]
        public async Task<IActionResult> Post(Update update)
        {
            if (update.message == null || update.message.text == null) return Ok(); // перевірка, щоб повідомлення було текстовим
            React.Process(update.message); // реагування на повідомлення 
            return Ok();
        }
    }
}
