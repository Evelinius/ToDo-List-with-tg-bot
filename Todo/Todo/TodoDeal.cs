using System;
using System.ComponentModel.DataAnnotations;

namespace Todo
{
    public class TodoDeal
    {
        [Key]
        public int Id { get; set; }

        public string TaskName { get; set; }
        public string Priority { get; set; }
        public DateTime DateTime { get; set; }
    }
}