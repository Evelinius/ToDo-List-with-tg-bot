using System;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Todo.TelegramBot
{
    public class TelegramBotApi : ITelegramBotApi, IDisposable
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private TelegramBotClient _botClient;

        const string ApiKey = "1161557053:AAFe0auenT2gZ6W-mqkmK3Ct8DTiajxrla4";

        public TelegramBotApi(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void Setup()
        {
            _botClient = new TelegramBotClient(ApiKey);
            _botClient.OnMessage += BotClientOnMessage;
            _botClient.StartReceiving();
        }

        private void BotClientOnMessage(object? sender, MessageEventArgs e)
        {
            if (e.Message.Text == "/start")
            {
                _botClient.SendTextMessageAsync(e.Message.Chat.Id, "Enter your token");
            }
            else
            {
                if (Guid.TryParse(e.Message.Text, out var guid))
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var registrationSm = scope.ServiceProvider.GetService<BotUserRegistrationHelper>();

                        if (registrationSm.ValidateRegistrationGuid(guid))
                        {
                            _botClient.SendTextMessageAsync(e.Message.Chat.Id, "Registration successful");
                        }
                        else
                        {
                            _botClient.SendTextMessageAsync(e.Message.Chat.Id, "Registration failed");
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            _botClient.StopReceiving();
        }
    }
}
