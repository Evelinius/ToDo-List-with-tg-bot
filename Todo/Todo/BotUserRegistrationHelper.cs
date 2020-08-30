using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Todo
{
    /// <summary>
    ///     Хелпер регистрации пользователя бот-уведоблений
    /// </summary>
    public class BotUserRegistrationHelper
    {
        private readonly IServiceProvider _serviceProvider;

        public BotUserRegistrationHelper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Guid StartRegistration(int userId)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ToDoDatabaseContext>();
            Guid guid = Guid.NewGuid();

            context.BotUsers.Add(new BotUser
            {
                UserId = userId,
                LastTimeUpdated = DateTime.UtcNow,
                State = RegistrationState.EnteringToken,
                RegistrationGuid = guid,
            });

            context.SaveChanges();

            return guid;
        }

        public bool ValidateRegistrationGuid(Guid guid)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ToDoDatabaseContext>();

            var botUser = context.BotUsers.SingleOrDefault(u => u.RegistrationGuid.Equals(guid));
            if (botUser != null)
            {
                botUser.LastTimeUpdated = DateTime.UtcNow;
                botUser.State = RegistrationState.Registered;

                return true;
            }

            return false;
        }
    }
}
