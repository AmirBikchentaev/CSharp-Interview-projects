using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkvelonWebAPI.Models
{
    public class TaskModel
    {

        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }
        public enum Status
        {
            Todo,
            InProgress,
            Done
        };


    }
}
