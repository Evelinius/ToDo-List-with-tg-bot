using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo
{
    public class ToDoDatabaseContext : DbContext
    {
        /// <summary>
        ///     Задачи
        /// </summary>
        public DbSet<TodoDeal> Deals { get; set; }

        /// <summary>
        ///     Пользователи бот-уведомлений
        /// </summary>
        public DbSet<BotUser> BotUsers { get; set; }

        /// <summary>
        ///     Пользователи
        /// </summary>
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=todo_db;Username=postgres;Password=1234");
    }
}
