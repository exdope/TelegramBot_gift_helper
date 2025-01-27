using System;
using Telegram.Bot;
using Telegram;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Microsoft.VisualBasic;
using static System.Net.WebRequestMethods;

class Program
{
    private static string age4 = "Детям в возрасте от 3 до 4 лет , вне зависимости от пола можно подарить\n * Кинетический песок\n * Магнитные конструкторы\n * Планшет для рисования песком";
    private static string age10m = "Мальчикам в возрасте от 4 до 10лет\n * можно подарить велосипед\n * Самокат\n * Набор для эксперементов";
    private static string age10w = "Девочкам в возрасте от 4 до 10 лет \n  * можно подарить куклу\n * набор для эксперементов";
    private static string age16w = "Девочкам в возрасте от 10 до 16 лет \n  * можно подарить мобильный телефон\n * Косметику";
    private static string age16m = "Девочкам в возрасте от 10 до 16 лет \n  * можно подарить мобильный телефон\n * Конструктор Лего";
    private static int genderNumber = 0;
    private static string token { get; set; } = "7876101802:AAFZzEFv7OlA5kgA5g1dbE8V_HN05f6hGmQ";
    private static TelegramBotClient client;
    static void Main(string[] args)
    {
        client = new TelegramBotClient(token);
        client.StartReceiving();
        client.OnMessage += OnMessageHandler;
        Console.ReadLine();
        client.StartReceiving();
    }

    private static async void OnMessageHandler(object? sender, MessageEventArgs e)
    {
        var msg = e.Message;
        switch (msg.Text)
        {
            case "Подобрать подарок":
                {
                    await client.SendTextMessageAsync(msg.Chat.Id, "Для кого вы выбираете подарок", replyMarkup: GetPathButtons());
                } break;

            case "/start":
                {
                    Console.WriteLine($"Бот запущен");
                    msg = e.Message;
                    await client.SendTextMessageAsync(msg.Chat.Id, "Бот запущен", replyToMessageId: msg.MessageId);
                    var stic = await client.SendStickerAsync(
                        chatId: msg.Chat.Id,
                        sticker: "https://tlgrm.ru/_/stickers/300/580/300580a8-42fb-4f56-9fe8-a6c993344e3d/192/63.webp");
                    await client.SendTextMessageAsync(msg.Chat.Id,"Нажмите на кнопку что бы выбрать подарок", replyMarkup: GetMainButtons());

                }
                break;
            case "К началу!":
                {
                    msg = e.Message;
                    await client.SendTextMessageAsync(msg.Chat.Id, "Бот запущен", replyToMessageId: msg.MessageId);
                    var stic = await client.SendStickerAsync(
                        chatId: msg.Chat.Id,
                        sticker: "https://tlgrm.ru/_/stickers/300/580/300580a8-42fb-4f56-9fe8-a6c993344e3d/192/63.webp");
                    await client.SendTextMessageAsync(msg.Chat.Id, "Нажмите на кнопку что бы выбрать подарок", replyMarkup: GetMainButtons());

                }
                break;
            case "Мальчик":
                {
                    genderNumber = 1;
                    await client.SendTextMessageAsync(msg.Chat.Id, "Нажмите на кнопку и выберите возраст", replyMarkup: GetAgeButtons());
                }break;
            case "Девочка":
                {
                    genderNumber = 2;
                    await client.SendTextMessageAsync(msg.Chat.Id, "Нажмите на кнопку и выберите возраст", replyMarkup: GetAgeButtons());
                }
                break;
            case "3-4":
                {
                    await client.SendTextMessageAsync(msg.Chat.Id, age4);
                    var stic = await client.SendStickerAsync(
                        chatId: msg.Chat.Id,
                        sticker: "https://tlgrm.ru/_/stickers/348/e30/348e3088-126b-4939-b317-e9036499c515/1.webp");
                    await client.SendTextMessageAsync(msg.Chat.Id,"Вернутся к началу?",replyMarkup:ToStartButtons());
                }
                break;
            case "4-10":
                {
                    if (genderNumber == 1)
                    {
                        await client.SendTextMessageAsync(msg.Chat.Id, age10m);
                        var stic = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://tlgrm.ru/_/stickers/348/e30/348e3088-126b-4939-b317-e9036499c515/1.webp");
                        await client.SendTextMessageAsync(msg.Chat.Id, "Вернутся к началу?", replyMarkup: ToStartButtons());

                    }
                    if (genderNumber == 2)
                    {
                        await client.SendTextMessageAsync(msg.Chat.Id, age10w);
                        var stic = await client.SendStickerAsync(
                           chatId: msg.Chat.Id,
                           sticker: "https://tlgrm.ru/_/stickers/348/e30/348e3088-126b-4939-b317-e9036499c515/1.webp");
                        await client.SendTextMessageAsync(msg.Chat.Id, "Вернутся к началу?", replyMarkup: ToStartButtons());
                    }
                }
                break;
            case "10-16":
                {
                    if (genderNumber == 1)
                    {
                        await client.SendTextMessageAsync(msg.Chat.Id, age16m);
                        var stic = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://tlgrm.ru/_/stickers/348/e30/348e3088-126b-4939-b317-e9036499c515/1.webp");
                        await client.SendTextMessageAsync(msg.Chat.Id, "Вернутся к началу?", replyMarkup: ToStartButtons());

                    }
                    if (genderNumber == 2)
                    {
                        await client.SendTextMessageAsync(msg.Chat.Id, age16w);
                        var stic = await client.SendStickerAsync(
                           chatId: msg.Chat.Id,
                           sticker: "https://tlgrm.ru/_/stickers/348/e30/348e3088-126b-4939-b317-e9036499c515/1.webp");
                        await client.SendTextMessageAsync(msg.Chat.Id, "Вернутся к началу?", replyMarkup: ToStartButtons());
                    }
                }
                break;
            case "Секретный пользователь":
                {
                    await client.SendTextMessageAsync(msg.Chat.Id,"пасхалка");
                    var pic = await client.SendPhotoAsync(
                    chatId: msg.Chat.Id,
                        photo: "https://private-user-images.githubusercontent.com/161166957/407072621-1bc5e554-d396-41c9-83f3-196c7aa0138e.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MzgwMDg0OTAsIm5iZiI6MTczODAwODE5MCwicGF0aCI6Ii8xNjExNjY5NTcvNDA3MDcyNjIxLTFiYzVlNTU0LWQzOTYtNDFjOS04M2YzLTE5NmM3YWEwMTM4ZS5wbmc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjUwMTI3JTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI1MDEyN1QyMDAzMTBaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT05NjNlMWI2OTUzNmEwMDY2Nzg0ZGQxZWIyMmRmMjNhZWU2N2ZhNWQzMmYwZGVmZTk4OWMxMjdjNzIxYTc5ZjRmJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCJ9.gY7RUqlZvvuwYGTHuv0HReiHodx_QH29eIAI__0F7Wg"
                        );
                    await client.SendTextMessageAsync(msg.Chat.Id, "Вернутся к началу?", replyMarkup: ToStartButtons());
                }
                break;
                 

            default:
                await client.SendTextMessageAsync(msg.Chat.Id, "Незнаю такой команды", replyMarkup: GetMainButtons());
                break;


        }
 
    }


    private static IReplyMarkup GetMainButtons()
    {
        return new ReplyKeyboardMarkup

        {
            Keyboard = new List<List<KeyboardButton>>
            {
               new List<KeyboardButton> { new KeyboardButton { Text = "Подобрать подарок" } },
            }
        };
    }
    private static IReplyMarkup GetPathButtons()
    {
        return new ReplyKeyboardMarkup
        {
            Keyboard = new List<List<KeyboardButton>>
            {
               new List<KeyboardButton> { new KeyboardButton { Text = "Мальчик" }, new KeyboardButton { Text = "Девочка" }, new KeyboardButton {Text = "Секретный пользователь"} },
            }
        };
    }
    private static IReplyMarkup GetAgeButtons()
    {
        return new ReplyKeyboardMarkup
        {
            Keyboard = new List<List<KeyboardButton>>
            {
               new List<KeyboardButton> { new KeyboardButton { Text = "3-4" }, new KeyboardButton { Text = "4-10" } , new KeyboardButton { Text = "10-16" } },
            }
        };
    }
    private static IReplyMarkup ToStartButtons()
    {
        return new ReplyKeyboardMarkup
        {
            Keyboard = new List<List<KeyboardButton>>
            {
               new List<KeyboardButton> { new KeyboardButton { Text = "К началу!" } }
            }
        };
    }
  
}
