using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo
{
    public class User
    {
        /// <summary>
        ///     Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        public BotUser BotUserProfile { get; set; }
    }
}
