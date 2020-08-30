using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo
{
    public class BotUser
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("users")]
        public int UserId { get; set; }

        public RegistrationState State { get; set; }

        public DateTime LastTimeUpdated { get; set; }

        public Guid RegistrationGuid { get; set; }
    }

    public enum RegistrationState
    {
        NotRegistered,
        EnteringToken,
        Registered
    }
}
