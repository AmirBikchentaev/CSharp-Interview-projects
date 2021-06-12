using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapiAttempt5.Contract
{
    public class ApiRoutes
    {
        public const string root = "api";
        public const string version = "v1"; 
        public const string Base = root + "/" + version;   

        public class Posts 
        {
            public const string getAllAPI = Base + "/posts" ;
            public const string Create = Base + "/posts";
            public const string Update = Base + "/posts/{postId}";
            public const string Delete = Base + "/posts/{postId}";


            public const string Get = Base + "/posts/{postId}";

        }

    }
}
