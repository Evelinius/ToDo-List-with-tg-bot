using Newtonsoft.Json;
using System;

namespace Todo.Contracts
{
    public class AddTaskRequest
    {
        [JsonProperty("task_name")]
        public string TaskName { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }

        [JsonProperty("dateTime")]
        public DateTime DateTime { get; set; }
    }
}
