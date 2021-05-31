using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot.Models
{
    public class TelegramUpdates
    {
        public List<Update> result { get; set; }
    }

    public class Update
    {
        public decimal update_id { get; set; }
        public Message message { get; set; }
    }

    public class Message
    {
        public decimal message_id { get; set; }
        public User from { get; set; }
        public Chat chat { get; set; }
        public decimal date { get; set; }
        public string text { get; set; }
        public User forward_from { get; set; }
        public Chat forward_from_chat { get; set; }
        public string forward_sender_name { get; set; }
        public decimal forward_date { get; set; }
        public Animation animation { get; set; }
        public Audio audio { get; set; }
        public Document document { get; set; }
        public List<PhotoSize> photo { get; set; }
        public Sticker sticker { get; set; }
        public Video video { get; set; }
        public VideoNote video_note { get; set; }
        public Voice voice { get; set; }
        public string caption { get; set; }
        public List<User> new_chat_members { get; set; }
        public User left_chat_member { get; set; }
    }

    public class User
    {
        public decimal id { get; set; }
        public bool is_bot { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; } = "";
    }

    public class Chat
    {
        public decimal id { get; set; }
    }

    public class Audio
    {
        public string file_id { get; set; }
        public string title { get; set; }
    }

    public class Document
    {
        public string file_id { get; set; }
    }

    public class PhotoSize
    {
        public string file_id { get; set; }
    }

    public class Sticker
    {
        public string file_id { get; set; }
        public bool is_animated { get; set; }
    }

    public class Video
    {
        public string file_id { get; set; }
    }

    public class VideoNote
    {
        public string file_id { get; set; }
    }

    public class Voice
    {
        public string file_id { get; set; }
    }

    public class Animation
    {
        public string file_id { get; set; }
    }

}
