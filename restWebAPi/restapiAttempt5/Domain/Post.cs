using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace restapiAttempt5.Domain
{

    
    public class Post
    {

        //primary key

        [Key]
        public Guid ID { get; set; }

        public string  Name { get; set; }
    }
}
