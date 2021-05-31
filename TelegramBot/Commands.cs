using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot
{
    public class Commands // клас із командами бота
    {
        public static void Start(decimal chat_id, string surname, string name)
        {
            try
            {
                Actions.AddUser(chat_id.ToString(), surname, name);
            }
            catch 
            {
                Actions.SendMessage(chat_id, "<i>Oops!</i> You are already in the system!");
                return;
            }
            Actions.SendMessage(chat_id, $"Hello, <b>{name}</b>!\nI have successfully added you to Aperture Science Labs System as a user!\nUse /help to get the list of full commands.");
        }

        public static void Define(decimal chat_id, string word)
        {
            try
            {
                var def = Actions.GetDef(word);
                string text;
                switch (def.dictionary)
                {
                    case "th":
                        text = $"Here is the definition:\n<b>{word}</b>  <i>{def.fl}</i>\n\n<b>Designation:</b> {def.designation}\n\n";

                        if (def.synonyms.Count != 0)
                        {
                            text += "<b>Synonyms:</b>";
                            foreach (var item in def.synonyms[0])
                            {
                                text += " " + item + ",";
                            }
                            text = text.TrimEnd(',') + ".\n\n";
                        }

                        if (def.antonyms.Count != 0)
                        {
                            text += "<b>Antonyms:</b>";
                            foreach (var item in def.antonyms[0])
                            {
                                text += " " + item + ",";
                            }
                            text = text.TrimEnd(',') + ".\n\n";
                        }
                        break;

                    default:
                    case "ur":
                        text = $"My sources suggests that <b>{word}</b> is not the real word.\nHere is the definition from Urban Dictionary.\n\n<b>Designation:</b> {def.designation.Replace(@"[", "").Replace(@"]", "")}\n\n<b>Example:</b> {def.example.Replace(@"[", "").Replace(@"]", "")}";
                        break;
                }
                Actions.SendMessage(chat_id, text);
            }
            catch 
            {
                Actions.SendMessage(chat_id, $"<b>Sorry</b>, I have not found the definition of <b>{word}</b>.");
            }
        }

        public static void Save(decimal chat_id, string word)
        {
            try
            {
                Actions.AddWord(chat_id.ToString(), word);
                Actions.SendMessage(chat_id, "Your word was saved to your personal list.");
            }
            catch 
            {
                Actions.SendMessage(chat_id, $"<b>Sorry</b>, you are either have already saved <b>{word}</b> or you are not subscribed.");
            }
        }

        public static void List(decimal chat_id)
        {
            try
            {
                List<string> saved_words = Actions.SavedWords(chat_id.ToString()).saved_words;
                if (saved_words.Count == 0)
                {
                    Actions.SendMessage(chat_id, "<i>Sorry</i>, your list is empty.");
                    return;
                }
                string text = "Here are your saved words:\n";
                foreach (var item in saved_words)
                {
                    text += "- " + item + ",\n";
                }
                text = text.TrimEnd('\n').TrimEnd(',') + ".";
                Actions.SendMessage(chat_id, text);
            }
            catch 
            {
                Actions.SendMessage(chat_id, "<i>Sorry</i>, your list is empty or you are not subscribed.");
            }
        }

        public static void Delete(decimal chat_id, string word)
        {
            try
            {
                Actions.DeleteWord(chat_id.ToString(), word);
                Actions.SendMessage(chat_id, "You word has been deleted.");
            }
            catch 
            {
                Actions.SendMessage(chat_id, "<b>Error!</b> You have never saved this word or you are not subscribed!");
            }
        }

        public static void Unsub(decimal chat_id)
        {
            try
            {
                Actions.DeleteUser(chat_id.ToString());
                Actions.SendMessage(chat_id, "You have unsubscribed.\n<b>Goodbye!</b>");
            }
            catch 
            {
                Actions.SendMessage(chat_id, "Error! You were never subscribed!");
            }

        }

        public static void Help(decimal chat_id)
        {
            Actions.SendMessage(chat_id, "Here are your commands:\n/sub - subscribe\n/def [word] - get definition of a word\n/daily - your word of the day\n/save [word] - save a word to your personal list\n/list - show your list of saved words\n/delete [word] - delete the word from your list\n/unsub - unsubscribe");
        }

        public static void Daily(decimal chat_id)
        {
            try
            {
                var words = Actions.SavedWords(chat_id.ToString()).saved_words;
                if (words.Count == 0)
                {
                    Actions.SendMessage(chat_id, "Error! You do not have any saved words.");
                }
                Random rnd = new Random();
                var word = words[rnd.Next(words.Count)];
                Actions.SendMessage(chat_id, $"Your word of the day is <b>{word}</b>");
                Define(chat_id, word);

            }
            catch 
            {
                Actions.SendMessage(chat_id, "Error! You do not have any saved words or you are not subscribed.");
            }
        }
    }
}
