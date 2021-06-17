using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkvelonWebAPI.Models
{
    public class ProjectModel
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime CompletionTime { get; set; }
        public enum Status
        {
            NotStarted,
            Active,
            Completed
        };
        public int Priority { get; set; }
        public List<TaskModel> Tasks { get; set; }
    }
}
