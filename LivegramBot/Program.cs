using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace LivegramBot
{
    public class Program
    {
        public static ITelegramBotClient _botClient;

        public static void Main(string[] args)
        {
            _botClient = new TelegramBotClient("7086530018:AAFBbs_rua6mjiIYTq6pQsoQMKxnnK_XzHQ");

            _botClient.OnMessage += OnMessage;

            _botClient.StartReceiving();

            Console.ReadLine();
        }

        public static async void OnMessage(object? sender, MessageEventArgs e)
        {
            string text = e.Message.Text;


            // Write you Telegram chatId
            long chatId = 6601604832;

            if (text == "/start")
            {
                await _botClient.SendTextMessageAsync(e.Message.Chat.Id, "Assalomu aleykum !\r\n\r\nBo't bo'yicha qanday savol taklif yoki shikoyatingiz bo'lsa bizga bemalol yo'llashingiz mumkin");
                
                Console.WriteLine($"Connected user: {e.Message.Chat.Username}");
            }
            else if(e.Message.Chat.Id != chatId)
            {
                await _botClient.SendTextMessageAsync(e.Message.Chat.Id, "Sizning habaringiz muvaffaqiyatli yuborildi");
                await _botClient.ForwardMessageAsync(chatId, e.Message.Chat.Id,e.Message.MessageId);
            }
            else if (e.Message.ReplyToMessage != null && e.Message.ReplyToMessage.ForwardFrom != null)
            {
                var forwardFromId = e.Message.ReplyToMessage.ForwardFrom.Id;
                await _botClient.SendTextMessageAsync(forwardFromId, e.Message.Text);
            }
        }
    }
}

//1726806055