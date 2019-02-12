using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TBot
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string token = "710427075:AAHQuR_S3pqoFOdn1bOXpm4BGT_1pYKa7gg";
            TelegramBotClient telegramBotClient = new TelegramBotClient(token);
            telegramBotClient.OnMessage +=
                delegate (object sender, MessageEventArgs e)
                {
                    if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Sticker)
                    {
                        telegramBotClient.SendStickerAsync(
                            e.Message.Chat.Id,
                            e.Message.Sticker.FileId
                            );
                    }

                    else if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                    {
                        Console.WriteLine(e.Message.Text);
                        telegramBotClient.SendTextMessageAsync(
                        e.Message.Chat.Id,
                        Parser.GetTemperature(e.Message.Text)
                        );
                    }
                    else
                    {
                        telegramBotClient.SendTextMessageAsync(
                        e.Message.Chat.Id,
                        "i'm don't know"
                        );

                    }
                    
                };


            telegramBotClient.StartReceiving();

            Console.WriteLine("Какой город Вас интересует?");
            string city = Console.ReadLine();
            Console.WriteLine(Parser.GetTemperature(city));
            Console.ReadKey();
        }
    }
}
